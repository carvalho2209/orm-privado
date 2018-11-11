using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using Nampula.UI;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Nampula.Framework;

namespace Nampula.UI.DinamicInterface
{
    /// <summary>
    /// Serviços de controle de alteração de propriedades na tela 
    /// </summary>
    public class DinamicInterfaceService
    {
        /// <summary>
        /// Banco de dados dos registros da tela
        /// </summary>
        DataBaseAdapter db = null;

        /// <summary>
        /// Lista de Nomes que foram alterados
        /// </summary>
        Dictionary<string, string> controlChanged = new Dictionary<string, string>();

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="pDB"></param>
        public DinamicInterfaceService(DataBaseAdapter pDB, Nampula.UI.Form pForm)
        {
            db = pDB;
            this.CreateNotExists();
            this.SetForm(pForm);
        }

        /// <summary>
        /// Cria a tabela caso a mesma não exista
        /// </summary>
        private void CreateNotExists()
        {
            var table = CreateUserControlProperty();
            var schema = new InformationSchemaColumn() { DBName = db.DataBaseName };

            if (!schema.GetByKey(table.TableName, table.Collumns.First().Name))
                table.Create();
        }

        private void SetForm(Nampula.UI.Form pForm)
        {
            pForm.KeyPreview = true;

            SetControlEvents(pForm.Controls);

            SetLabels(pForm);
        }

        private void SetControlEvents(Control.ControlCollection controlCollection)
        {
            foreach (Control item in controlCollection)
            {
                if (item.GetType() == typeof(Nampula.UI.DataGrid))
                {
                    var grid = item as Nampula.UI.DataGrid;
                    grid.DoubleClick += new EventHandler(grid_DoubleClick);
                }

                if (item.HasChildren)
                    SetControlEvents(item.Controls);
            }
        }

        void grid_DoubleClick(object sender, EventArgs e)
        {
            var form = (sender as Control).FindForm() as Nampula.UI.Form;

            try
            {
                if (!Keyboard.IsKeyDown(Keys.ControlKey))
                    return;

                if (sender.GetType() == typeof(Nampula.UI.DataGrid))
                {
                    var grid = sender as Nampula.UI.DataGrid;
                    var gridView = grid.Views[0] as GridView;

                    var info = gridView.CalcHitInfo(grid.PointToClient(System.Windows.Forms.Control.MousePosition));

                    //form.SetTextOnStatusBar(string.Format("Column: {0}  In Column:{1} In Column Panel: {2}",
                    //        info.Column.Name, info.InColumn, info.InColumnPanel));

                    if (info.InColumnPanel)
                    {
                        var colCaption = info.Column.Caption;
                        var dicKey = string.Format("{0}_{1}", grid.Name, info.Column.Name);

                        if (controlChanged.ContainsKey(dicKey))
                            colCaption = controlChanged[dicKey];

                        ShowPropertyForm(form, grid.Name, info.Column.Name, colCaption);
                    }

                }


            }
            catch (Exception ex)
            {
                form.SetTextOnStatusBar(ex.Message,
                    Nampula.UI.BoMessageTime.bmt_Short, Nampula.UI.BoStatusBarMessageType.smt_Error);
            }
        }

        /// <summary>
        /// Exibe o formulário para alteração da descrição
        /// </summary>
        /// <param name="form">Formulário onde está o controle</param>
        /// <param name="pControl">Nome do Controle</param>
        /// <param name="pColumn">Nome da Coluna</param>
        /// <param name="pDesc">Descrição atual do controle</param>
        private void ShowPropertyForm(Nampula.UI.Form pForm, string pControl, string pColumn, string pDesc)
        {
            var userControl = GetUserControlOrNull(pForm.Name, pControl, pColumn);

            if (userControl == null)
            {
                userControl = CreateUserControlProperty();
                userControl.Form = pForm.Name;
                userControl.Control = pControl;
                userControl.Column = pColumn;
                userControl.Caption = pDesc;
            }
            else
            {
                userControl.StateRecord = eState.eUpdate;
            }

            using (var form = new frmSettingDescription(userControl, pDesc))
            {
                if (form.ShowDialog(pForm) == DialogResult.OK)
                    SetLabels(pForm);
            }
        }

        /// <summary>
        /// Atribui as legendas a tela
        /// </summary>
        /// <param name="pForm">Formulário</param>
        private void SetLabels(Nampula.UI.Form pForm)
        {
            var userControl = CreateUserControlProperty();
            var query = new TableQuery(userControl);

            query.Where.Add(new QueryParam(userControl.Collumns[UserControlProperty.FieldsName.Form], pForm.Name));

            var listProperty = userControl.FillCollection<UserControlProperty>(query);

            if (!listProperty.IsEmpty())
                SetLabels(pForm.Controls, listProperty);

        }

        /// <summary>
        /// Atribui as legendas a tela se encontrar o controles e seus filhos
        /// </summary>
        /// <param name="pControls">Lista de Controles</param>
        /// M<param name="pProperty">Lista de Propriedades do formulário</param>
        private void SetLabels(Control.ControlCollection pControls, List<UserControlProperty> pProperty)
        {
            foreach (Control item in pControls)
            {
                if (pProperty.IsEmpty())
                    break;

                var propertyFounded = pProperty.Where(c => c.Control == item.Name).ToList();

                if (propertyFounded.IsEmpty())
                {
                    if (item.HasChildren)
                        SetLabels(item.Controls, pProperty);
                    continue;
                }

                if (item.GetType() == typeof(Nampula.UI.DataGrid))
                {
                    var grid = item as Nampula.UI.DataGrid;
                    var gridView = grid.Views[0] as GridView;

                    foreach (var property in propertyFounded)
                    {
                        var column = gridView.Columns.ColumnByName(property.Column);

                        var dicKey = string.Format("{0}_{1}", grid.Name, column.Name);

                        if (!controlChanged.ContainsKey(dicKey))
                            controlChanged[dicKey] = column.Caption;

                        if (column != null)
                        {
                            ///Quando o nome for igual não precisa ter uma atualização
                            ///de leganda, portanto não precisa ser igual
                            if (controlChanged[dicKey].Equals(property.Caption))
                                property.Remove();

                            column.Caption = property.Caption;
                        }

                        pProperty.Remove(property);
                    }

                }

                if (item.HasChildren && !pProperty.IsEmpty())
                    SetLabels(item.Controls, pProperty);
            }
        }

        /// <summary>
        /// Pega um registro no banco de dados com os parametros passados, se não encontrar traz nulo
        /// </summary>
        /// <param name="pForm">Formulário</param>
        /// <param name="pControl">Controle</param>
        /// <param name="pColumn">Coluna</param>
        /// <returns>Um controle UserControlProperty ou nulo</returns>
        private UserControlProperty GetUserControlOrNull(string pForm, string pControl, string pColumn)
        {
            var userControl = CreateUserControlProperty();
            var query = new TableQuery(userControl);

            query.Where.Add(new QueryParam(userControl.Collumns[UserControlProperty.FieldsName.Form], pForm));
            query.Where.Add(new QueryParam(userControl.Collumns[UserControlProperty.FieldsName.Control], pControl));
            query.Where.Add(new QueryParam(userControl.Collumns[UserControlProperty.FieldsName.Column], pColumn));

            return userControl.FillCollection<UserControlProperty>(query).FirstOrDefault();
        }

        /// <summary>
        /// Pega a instancia do objeto UserControlProperty
        /// </summary>
        /// <returns></returns>
        private UserControlProperty CreateUserControlProperty()
        {
            return new UserControlProperty() { DBName = db.DataBaseName };
        }

    }
}
