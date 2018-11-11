using System;
using System.Collections.Generic;
using System.Linq;
using Nampula.DI;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Nampula.Framework;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using System.Drawing;
using System.Windows.Forms;
using Nampula.UI.DinamicInterface;

namespace Nampula.UI.Helpers.Extentions
{


    /// <summary>
    /// Extensões de métodos para o controle Nampula.UI.GridView
    /// </summary>
    public static class GridViewExtension
    {


        /// <summary>
        /// Busca o objeto selecionado na grid.
        /// </summary>
        /// <typeparam name="T">Um objeto do tipo TableAdapter.</typeparam>
        /// <param name="pGridView">O controle GridView.</param>
        /// <returns>Retorna um objeto do tipo TableAdapter.</returns>
        public static T GetSelected<T>(this GridView pGridView) where T : TableAdapter
        {
            T row = null;

            if (pGridView.IsValidRowHandle(pGridView.FocusedRowHandle))
                row = pGridView.GetFocusedRow() as T;

            return row;
        }



        /// <summary>
        /// Busca os 'handles' dos filhos da linha.
        /// </summary>
        /// <remarks>Se não for uma linha agrupada, retorna o código da própria linha.</remarks>
        /// <param name="pGridView">O controle GridView.</param>
        /// <param name="pRowHandle">O 'handle' da linha em questão.</param>
        /// <returns>Uma lista de 'handles' filhos.</returns>
        public static int[] GetChildRowHandles(this GridView pGridView, int pRowHandle)
        {
            // Verifica se é uma linha agrupada
            if (!pGridView.IsGroupRow(pRowHandle))
                return new[] { pRowHandle };

            var indexes = new List<int>();

            var count = pGridView.GetChildRowCount(pRowHandle);
            for (int i = 0; i < count; i++)
            {
                var handle = pGridView.GetChildRowHandle(pRowHandle, i);

                if (pGridView.IsGroupRow(handle))
                    indexes.AddRange(pGridView.GetChildRowHandles(handle));
                else
                    indexes.Add(handle);
            }

            return indexes.ToArray();
        }



        /// <summary>
        /// Seleciona os filhos da linha.
        /// </summary>
        /// <param name="pGridView">O controle GridView.</param>
        /// <param name="pRowHandle">O 'handle' da linha em questão.</param>
        public static void SelectChildRows(this GridView pGridView, int pRowHandle)
        {
            var childs = pGridView.GetChildRowHandles(pRowHandle);

            pGridView.BeginSelection();

            try
            {
                foreach (var i in childs)
                    pGridView.SelectRow(i);
            }
            finally
            {
                pGridView.EndSelection();
            }
        }



        /// <summary>
        /// Busca as linhas selecionadas.
        /// </summary>
        /// <param name="pGridView">O controle GridView.</param>
        /// <returns>Uma lista de DataRow selecionadas no grid.</returns>
        public static DataRow[] GetSelectedData(this GridView pGridView)
        {
            var selectedRows = pGridView.GetSelectedRows();

            if (selectedRows == null)
                return null;

            var list = new List<DataRow>();

            for (var i = 0; i < selectedRows.Length; i++)
            {
                if (!pGridView.IsGroupRow(selectedRows[i]))
                {
                    var dataRowView = pGridView.GetRow(selectedRows[i]) as DataRowView;

                    if (dataRowView != null)
                        list.Add(dataRowView.Row);
                }
            }

            return list.ToArray();
        }



        /// <summary>
        /// Busca as linhas selecionadas.
        /// </summary>
        /// <param name="pGridView">O controle GridView.</param>
        /// <returns>Uma lista de DataRow selecionadas no grid.</returns>
        public static List<T> GetRowsSelected<T>(this GridView pGridView) where T : TableAdapter
        {
            var selectedRows = pGridView.GetSelectedRows();

            if (selectedRows == null)
                return null;

            var list = new List<T>();

            for (var i = 0; i < selectedRows.Length; i++)
            {
                if (!pGridView.IsGroupRow(selectedRows[i]))
                    list.Add((pGridView.GetRow(selectedRows[i]) as T));
            }

            return list;
        }



        /// <summary>
        /// Cria um parâmetro que será passado para o método FormatGrid.
        /// </summary>
        /// <typeparam name="T">O Tipo do objeto da coluna.</typeparam>
        /// <param name="pSourceColumnName">O nome da coluna na tabela do grid.</param>
        /// <param name="pDb">Objeto do banco de dados</param>
        /// <param name="pElementKey">O nome do código do objeto da coluna.</param>
        /// <param name="pElementValue">O nome do valor do objeto da coluna.</param>
        /// <returns>Um objeto a ser passado como parâmetro.</returns>
        public static KeyValuePair<string, Dictionary<object, string>>
            CreateFormatGridParam<T>(
            DataBaseAdapter pDb,
            string pSourceColumnName,
            string pElementKey,
            params string[] pElementValue) where T : TableAdapter
        {
            var pObject = pDb.CreateObject<T>();

            var values = pObject.GetData().ToDictionary(pElementKey, pElementValue);

            return new KeyValuePair<string, Dictionary<object, string>>(
                pSourceColumnName, values);
        }


        /// <summary>
        /// Cria um parâmetro que será passado para o método FormatGrid.
        /// </summary>
        /// <typeparam name="T">O Tipo do objeto da coluna.</typeparam>
        /// <param name="pCompanyDb">Nome do Banco de Dados da Empresa</param>
        /// <param name="pSourceColumnName">O nome da coluna na tabela do grid.</param>
        /// <param name="pElementKey">O nome do código do objeto da coluna.</param>
        /// <param name="pElementValue">O nome do valor do objeto da coluna.</param>
        /// <returns>Um objeto a ser passado como parâmetro.</returns>
        public static KeyValuePair<string, Dictionary<object, string>>
            CreateFormatGridParam<T>(string pCompanyDb, string pSourceColumnName, string pElementKey,
            params string[] pElementValue) where T : TableAdapter, new()
        {
            var pObject = new T { DBName = pCompanyDb };

            var values = pObject.GetData().ToDictionary(pElementKey, pElementValue);

            return new KeyValuePair<string, Dictionary<object, string>>(
                pSourceColumnName, values);
        }


        /// <summary>
        /// Formata as colunas do grid de acordo com o objeto passado como parâmetro.
        /// </summary>
        /// <param name="pGridView">O controle GridView.</param>
        /// <param name="pTable">Um DataTable tipado.</param>
        /// <param name="pColumns">Colunas do Grid</param>
        public static void FormatGrid(this GridView pGridView, DataTable pTable,
            params KeyValuePair<string, Dictionary<object, string>>[] pColumns)
        {
            pGridView.Columns.Clear();

            foreach (DataColumn field in pTable.Columns)
            {
                var columnList = (from p in pColumns
                                  where p.Key.Equals(field.ColumnName)
                                  select new { p.Key, p.Value })
                                  .FirstOrDefault();

                var hasCustomColumn = (columnList != null);

                if (hasCustomColumn)
                {
                    var column = new GridValidValuesColumn();
                    column.Name = field.ColumnName;
                    column.Caption = field.Caption;
                    column.OptionsColumn.AllowEdit = false;
                    column.FieldName = field.ColumnName;
                    column.ColumnEdit.NullText = String.Empty;
                    pGridView.Columns.Add(column);
                    column.Visible = true;

                    foreach (var item in columnList.Value)
                        column.ValidValues.Add(item.Key, item.Value);

                }
                else
                {
                    pGridView.Columns.AddVisible(field.ColumnName, field.Caption);
                    pGridView.Columns[field.ColumnName].OptionsColumn.AllowEdit = false;
                    FormatColumn(pGridView.Columns[field.ColumnName], field.DataType, field.MaxLength);
                }
            }
        }


        /// <summary>
        /// Formata as colunas do grid de acordo com o objeto passado como parâmetro.
        /// </summary>
        /// <typeparam name="T">Um objeto do tipo TableAdapter (B1).</typeparam>
        /// <param name="pGridView">O controle GridView.</param>
        /// <param name="pCompanyDb">O nome da empresa no SAP.</param>
        /// <param name="pColumns">Lista de Columnas</param>
        public static void FormatGrid<T>(this GridView pGridView, string pCompanyDb,
            params KeyValuePair<string, Dictionary<object, string>>[] pColumns) where T : TableAdapter, new()
        {
            var pObject = new T { DBName = pCompanyDb };
            CreateColumn(pGridView, pObject.Collumns, pColumns);
        }


        /// <summary>
        /// Formata as colunas do grid de acordo com o objeto passado como parâmetro.
        /// </summary>
        /// <typeparam name="T">Um objeto do tipo TableAdapter.</typeparam>
        /// <param name="pGridView">O controle GridView.</param>
        /// <param name="dataBaseAdapter">Adaptador de banco de dados</param>
        /// <param name="pColumns">Uma lista de colunas.</param>
        public static void FormatGrid<T>(
            this GridView pGridView,
            DataBaseAdapter dataBaseAdapter,
            params KeyValuePair<string, Dictionary<object, string>>[] pColumns) where T : TableAdapter
        {
            var pObject = dataBaseAdapter.CreateObject<T>();
            CreateColumn(pGridView, pObject.Collumns, pColumns);
        }

        /// <summary>
        /// Formata as colunas do grid de acordo com o objeto passado como parâmetro.
        /// </summary>
        /// <typeparam name="T">Um objeto do tipo TableAdapter.</typeparam>
        /// <param name="pGridView">O controle GridView.</param>
        /// <param name="dataBaseAdapter">Objeto do banco de dados</param>
        /// <param name="showDataSourceInformation">Exibi informações de Origem do Registros</param>
        /// <param name="pColumns">Uma lista de colunas.</param>
        public static void FormatGrid<T>(
            this GridView pGridView,
            DataBaseAdapter dataBaseAdapter,
            bool showDataSourceInformation = false,
            params KeyValuePair<string, Dictionary<object, string>>[] pColumns) where T : TableAdapter
        {
            var pObject = dataBaseAdapter.CreateObject<T>();
            CreateColumn(pGridView, pObject.Collumns, pColumns);

            if (showDataSourceInformation)
            {
                pGridView.MouseMove += (sender, e) =>
                {

                    if (Keyboard.IsKeyDown(Keys.ControlKey))
                    {
                        var hiBand = pGridView.CalcHitInfo(e.Location);

                        if (hiBand.InColumnPanel)
                        {
                            if (!pObject.Collumns.Exists(c => c.Name == hiBand.Column.FieldName))
                                return;
                            var tableAdapterField = pObject.Collumns[hiBand.Column.FieldName];
                            var informationSource = string.Format("[{0}]-[{1}]", tableAdapterField.TableAdapter.TableName, tableAdapterField.Name);
                            Application.GetInstance().SetTextOnStatusBar(informationSource, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Warning);
                        }
                    }
                };
            }
        }



        /// <summary>
        /// Formata as colunas do grid de acordo com a lista de colunas passdas com parametors
        /// </summary>
        /// <param name="pGridView">O controle GridView.</param>
        /// <param name="pTableColumns">Lista de Coluns da Tabela</param>
        /// <param name="pColumns">Lista de Coluns</param>
        public static void FormatGrid(this GridView pGridView,
            TableAdapterFieldCollection pTableColumns,
            params KeyValuePair<string, Dictionary<object, string>>[] pColumns)
        {
            CreateColumn(pGridView, pTableColumns, pColumns);
        }


        /// <summary>
        /// Formata a coluna de acordo com o tipo especificado.
        /// </summary>
        /// <param name="pGridView">Grid</param>
        /// <param name="pTableColumns">A coluna do GridView.</param>
        /// <param name="pColumns">Columnas com lista suspensa.</param>
        private static void CreateColumn(GridView pGridView, TableAdapterFieldCollection pTableColumns,
            params KeyValuePair<string, Dictionary<object, string>>[] pColumns)
        {

            foreach (TableAdapterField field in pTableColumns)
            {
                var columnList = (from p in pColumns
                                  where p.Key.Equals(field.Name)
                                  select new { p.Key, p.Value }).FirstOrDefault();

                var hasCustomColumn = (columnList != null);

                if (hasCustomColumn)
                {
                    var column = new GridValidValuesColumn();

                    column.Name = field.Name;
                    column.Caption = field.Description;
                    column.OptionsColumn.AllowEdit = false;
                    column.FieldName = field.Name;
                    column.ColumnEdit.NullText = String.Empty;

                    pGridView.Columns.Add(column);
                    column.Visible = true;

                    foreach (var item in columnList.Value)
                        column.ValidValues.Add(item.Key, item.Value);

                }
                else
                {
                    pGridView.Columns.AddVisible(field.Name, field.Description);
                    pGridView.Columns[field.Name].OptionsColumn.AllowEdit = false;
                    FormatColumn(pGridView.Columns[field.Name], field.GetDbType(), field.Size);
                }
            }
        }

        /// <summary>
        /// Define uma coluna CheckBox com padrão de seleção de linhas
        /// </summary>
        /// <param name="pView">View da Grid</param>
        /// <param name="pColumnName">Nome da coluna</param>
        /// <param name="pColumnCaption">Título da coluna</param>
        public static void SetSelectColumn(this GridView pView, string pColumnName, string pColumnCaption)
        {
            pView.Appearance.Reset();

            var myCol = new GridColumn();
            myCol.FieldName = pColumnName;
            myCol.Name = pColumnName;
            myCol.Caption = pColumnCaption;
            myCol.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;

            pView.Columns.Add(myCol);

            myCol.Visible = true;

            var myCondition = new StyleFormatCondition(
                 FormatConditionEnum.Equal,
                 myCol,
                 true,
                 true,
                 true,
                 true);

            myCondition.Appearance.BackColor = Color.FromArgb(240, 204, 77);
            myCondition.Appearance.ForeColor = Color.Black;

            pView.FormatConditions.Add(myCondition);
        }


        /// <summary>
        /// Formata a coluna de acordo com o tipo especificado.
        /// </summary>
        /// <param name="pCollumn">A coluna do GridView.</param>
        /// <param name="pDataType">Tipo da coluna.</param>
        /// <param name="maxLenth">Tamanho maximo da coluna</param>
        public static void FormatColumn(GridColumn pCollumn, Type pDataType, int maxLenth = 0)
        {
            if (pDataType == typeof(byte) ||
                pDataType == typeof(short) ||
                pDataType == typeof(int) ||
                pDataType == typeof(long))
            {
                pCollumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                pCollumn.DisplayFormat.FormatString = "g";
                pCollumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                SetMaxLenth(pCollumn, maxLenth);
            }
            else if (pDataType == typeof(double) ||
                pDataType == typeof(float) ||
                pDataType == typeof(decimal)
                )
            {
                pCollumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                pCollumn.DisplayFormat.FormatString = "n2";
                pCollumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                SetMaxLenth(pCollumn, maxLenth);
            }
            else if (pDataType == typeof(DateTime))
            {
                pCollumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                pCollumn.DisplayFormat.FormatString = "d";
            }
            else if (pDataType == typeof(string))
            {
                if (maxLenth != 0)
                {
                    var columnEdi = pCollumn.RealColumnEdit as RepositoryItemTextEdit;

                    if (columnEdi != null)
                        columnEdi.MaxLength = maxLenth;
                }
            }
        }

        private static void SetMaxLenth(GridColumn pCollumn, int maxLenth = 0)
        {
            var columnEdi = pCollumn.RealColumnEdit as RepositoryItemTextEdit;

            if (columnEdi != null)
                columnEdi.MaxLength = maxLenth;
        }

        /// <summary>
        /// Preenche o grid de acordo com o objeto passado como parâmetro.
        /// </summary>
        /// <typeparam name="T">Um objeto do tipo TableAdapter.</typeparam>
        /// <param name="dataBaseAdapter">Objeto do banco de dados</param>
        /// <param name="pGridView">O controle GridView.</param>
        public static void FillAll<T>(this GridView pGridView, DataBaseAdapter dataBaseAdapter) where T : TableAdapter, new()
        {
            var table = dataBaseAdapter.CreateObject<T>();
            pGridView.GridControl.DataSource = null;
            pGridView.GridControl.DataSource = table.FillCollection<T>(table.GetData().Rows);
            pGridView.BestFitColumns();
        }



        /// <summary>
        /// Cria um parâmetro que será passado para o método FormatGrid.
        /// </summary>
        /// <param name="pDictionary">Um dicionário (int, string).</param>
        /// <param name="pFieldsName">O nome do campo (chave estrangeira) relacionado.</param>
        /// <returns>Um objeto do tipo KeyValuePair.</returns>
        public static KeyValuePair<string, Dictionary<object, string>> CreateGridParam(
            this Dictionary<object, string> pDictionary, string pFieldsName)
        {
            return new KeyValuePair<string, Dictionary<object, string>>(pFieldsName, pDictionary);
        }



        /// <summary>
        /// Atribiu a visibilidade das colunas 
        /// </summary>
        /// <param name="pView">GridView</param>
        /// <param name="pColumns">Nome das Colunas</param>
        /// <param name="pVisible">True se visivel False se não visivel</param>
        public static void SetVisible(this GridView pView, List<String> pColumns, bool pVisible)
        {
            foreach (var item in pColumns)
                pView.Columns[item].Visible = pVisible;
        }



        /// <summary>
        /// Atribui edição das colunas 
        /// </summary>
        /// <param name="pView">GridView</param>
        /// <param name="pColumns">Nome das Colunas</param>
        /// <param name="pEditable">True se Editável False se não editável</param>
        public static void SetEditable(this GridView pView, List<String> pColumns, bool pEditable)
        {
            foreach (var item in pColumns)
                pView.Columns[item].OptionsColumn.AllowEdit = pEditable;
        }



        /// <summary>
        /// Popula o datasource de um GridView com um DataTable.
        /// </summary>
        /// <param name="pGridView">O controle GridView.</param>
        /// <param name="pDataTable">Um objeto System.Data.DataTable</param>
        public static void BindDataTable(this GridView pGridView, DataTable pDataTable)
        {
            pGridView.GridControl.DataSource = null;
            pGridView.GridControl.DataSource = pDataTable;
            pGridView.GridControl.ForceInitialize();
            pGridView.BestFitColumns();
        }



        /// <summary>
        /// Move as linhas de um DataTable para outro.
        /// </summary>
        /// <param name="pRows">Uma lista de DataRow.</param>
        /// <param name="pFrom">A tabela original.</param>
        /// <param name="pTo">A tabela que recebe a linha.</param>
        public static void MoveRows(this DataRow[] pRows, DataTable pFrom, DataTable pTo)
        {
            pTo.BeginLoadData();

            try
            {
                foreach (var row in pRows)
                {
                    var keyValue = row.Table.PrimaryKey.Select(c=> row[c.ColumnName]).ToList();

                    // Inserir linha
                    var rowTo = pTo.Rows.Find(keyValue.ToArray());
                    if (rowTo == null)
                        pTo.ImportRow(row);

                    // Remover linha
                    var rowFrom = pFrom.Rows.Find(keyValue.ToArray());
                    if (rowFrom != null)
                        pFrom.Rows.Remove(rowFrom);
                }
            }
            finally
            {
                pTo.EndLoadData();
            }
        }


        /// <summary>
        /// Adiciona uma seta laranja em uma coluna da grid.
        /// </summary>
        /// <param name="pColumn">Coluna que receberá a seta amarela</param>
        /// <param name="pEventHandler">Evento que será disparado ao clicar na seta.</param>
        /// <param name="editable">A coluna é editável ?</param>
        public static void SetLinkedButton(this GridColumn pColumn, ButtonPressedEventHandler pEventHandler, bool editable = false)
        {
            const string strImage64 = @"Qk16AQAAAAAAADYAAAAoAAAADAAAAAkAAAABABgAAAAAAAAAAADEDgAAxA4AAAAAAAAAAAAAAAD/AAD/AAD/AAD/AAD/AAD/RaK2RaK2AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/R6a7J9f9R6a7AAD/AAD/AAD/SqzCSqzCSqzCSqzCSqzCSqzCSqzCW+H9J9f9SqzCAAD/AAD/TLLJYuL9aeT9deb+guj+hOn+e+f+a+T9W+H9J9f9TLLJAAD/T7jQeef+fuf+iOn+kuv+lOv+jer+fef+a+T9W+H9J9f9T7jQUb7XyPX/yfX/xvX+wvT+u/L+rvD+jur+fef+Q9z9Ub7XAAD/VMTdVMTdVMTdVMTdVMTdVMTdVMTdmez+beT+VMTdAAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/Vsniguj+VsniAAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/V8zmV8zmAAD/AAD/AAD/AAD//wAAAACkwsAdAAABWElEQVR42gFNAbL+Af8AAAAAAAAAAAAAAAAAAAAAAAEAAAAAAP8AAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAD/xgABAAAAAAAAAAAAAAACAQAAAQAAAQAAAQAAAQAAAQAAAAAAAAAA/8YAAQAAAAAAAAAAAQAAAP/GAAAAAAAAAAAAAAAAAAAAAAAAAADGAAAAAAF0AP8AAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAxgAAAAAAAAD/jAABAAAEAAAAAMYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAXQA/wAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAP+MAAAAAAF0AP8AAAAAAAT/AAAAAAAAAAAAAAAAAAAAAAABAAAAAAABdAD/AAAAAAAAAAAB/wAAAAAAAAAAAAAAAAAAAAAAAQAAAAAA/wAAAAAAAAAAAAAAe1QVoTe5U8AAAAAASUVORK5CYII=";

            var colunmLink = pColumn.ColumnEdit as RepositoryItemButtonEdit;

            if (colunmLink == null)
            {
                colunmLink = new RepositoryItemButtonEdit();
                colunmLink.Buttons.Clear();
            }

            var button = new EditorButton
            {
                IsLeft = true
            };

            button.Appearance.Options.UseImage = true;
            button.Kind = ButtonPredefines.Glyph;
            button.Image = strImage64.Base64ToImage();
            button.Tag = "LinkedButton";
            colunmLink.TextEditStyle = TextEditStyles.Standard;

            colunmLink.Buttons.Add(button);

            pColumn.OptionsColumn.AllowEdit = true;
            pColumn.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;

            colunmLink.ButtonClick += (s, e) =>
            {
                if (!ReferenceEquals(e.Button.Tag, "LinkedButton"))
                    return;

                pEventHandler(s, e);
            };

            //if (pColumn.ColumnEdit != null)
            //    ExpHelper.ThrowException(
            //    "Já existe vinculado à coluna um editor, caso for um ChooseFromList, faça o linked antes do choose.");

            pColumn.ColumnEdit = colunmLink;
        }



        /// <summary>
        /// Adiciona uma seta laranja em uma coluna da grid para um objeto do SAP
        /// </summary>
        /// <param name="pColumn">Coluna que receberá a seta amarela</param>
        /// <param name="pObject">objeto do SAP que será atribuído.</param>
        public static void SetLinkedButton(this GridColumn pColumn, BoLinkedObject pObject)
        {
            SetLinkedButton(pColumn, delegate(object sender, ButtonPressedEventArgs e)
                {
                    var eventargs = new LinkedButtonEventArgs { LinkedObjectType = pObject, Values = new List<object> { pColumn.View.FocusedValue } };

                    Application.GetInstance().PeformLinkedButton(sender, eventargs);
                });
        }



        /// <summary>
        /// Define cor padrão, baseado no look and feel das telas do SAP
        /// </summary>
        /// <param name="pView">View da Grid</param>
        public static void SetColors(this GridView pView)
        {
            pView.Appearance.Reset();

            pView.Appearance.FocusedCell.BackColor = VisualStyles.focusedEditorColor;
            pView.Appearance.FocusedCell.ForeColor = Color.Black;

            pView.Appearance.FocusedRow.BackColor = VisualStyles.selectedRow;
            pView.Appearance.FocusedRow.ForeColor = Color.Black;

            pView.Appearance.SelectedRow.BackColor = VisualStyles.selectedRow;
            pView.Appearance.SelectedRow.ForeColor = Color.Black;

            pView.Appearance.HideSelectionRow.BackColor = VisualStyles.selectedRow;
            pView.Appearance.HideSelectionRow.ForeColor = Color.Black;

            pView.ShowingEditor += (sender, args) => VisualStyles.SetStyle(pView.ActiveEditor);


        }


        /// <summary>
        /// Atribui as cores a aparencia da grid
        /// </summary>
        /// <param name="pView">View da grid</param>
        /// <param name="pDefaultColor">Color de fundo</param>
        /// <param name="pDefaultForeColor">Color da Fonte</param>
        /// <param name="pApplyRow">Aplica a linha</param>
        public static void SetColors(this GridView pView, Color pDefaultColor, Color pDefaultForeColor, bool pApplyRow)
        {
            pView.Appearance.Reset();
            pView.Appearance.FocusedCell.BackColor = pDefaultColor;
            pView.Appearance.FocusedCell.ForeColor = pDefaultForeColor;

            if (pApplyRow)
            {
                pView.Appearance.FocusedRow.BackColor = pDefaultColor;
                pView.Appearance.FocusedRow.ForeColor = pDefaultForeColor;

                pView.Appearance.SelectedRow.BackColor = pDefaultColor;
                pView.Appearance.SelectedRow.ForeColor = pDefaultForeColor;

                pView.Appearance.HideSelectionRow.BackColor = pDefaultColor;
                pView.Appearance.HideSelectionRow.ForeColor = pDefaultForeColor;
            }
        }



        /// <summary>
        /// Cria um menu com opções de importação na grid
        /// Poderá exportar dados da grid para Excel, PDF, RTF e Texto
        /// </summary>
        /// <param name="pView"></param>
        public static void CreateMenuExport(this GridView pView)
        {
            pView.BestFitColumns();


            //Menu exportar Excel
            var mnuItemExcel = new ToolStripMenuItem("Excel", Properties.Resources.document_excel);
            mnuItemExcel.Click += (sender, args) =>
            {
                var form = new SaveFileDialog { Filter = "Excel (*.xls)|*.xls" };

                if (form.ShowDialog(pView.GridControl.Parent as Form) == DialogResult.OK)
                {
                    pView.ExportToXls(form.FileName);
                }
            };

            //PDF
            var mnuItemPdf = new ToolStripMenuItem("PDF", Properties.Resources.document_pdf);
            mnuItemPdf.Click += (sender, args) =>
            {
                var form = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf"
                };

                if (form.ShowDialog(pView.GridControl.Parent as Form) == DialogResult.OK)
                {
                    pView.ExportToPdf(form.FileName);
                }
            };


            //RTF
            var mnuItemRtf = new ToolStripMenuItem("RTF", Properties.Resources.document_word);
            mnuItemRtf.Click += (sender, args) =>
            {
                var form = new SaveFileDialog { Filter = "RTF (*.rtf)|*.rtf" };
                if (form.ShowDialog(pView.GridControl.Parent as Form) == DialogResult.OK)
                {
                    pView.ExportToRtf(form.FileName);
                }
            };

            //Texto
            var mnuItemTxt = new ToolStripMenuItem("Texto", Properties.Resources.document_text);
            mnuItemTxt.Click += (sender, args) =>
            {
                var form = new SaveFileDialog { Filter = "Texto (*.txt)|*.txt" };
                if (form.ShowDialog(pView.GridControl.Parent as Form) == DialogResult.OK)
                {
                    pView.ExportToText(form.FileName);
                }
            };

            //HTML
            var mnuItemHtml = new ToolStripMenuItem("Html", Properties.Resources.HTMLPageHS);
            mnuItemHtml.Click += (sender, args) =>
            {
                var form = new SaveFileDialog { Filter = "Html (*.html)|*.html" };
                if (form.ShowDialog(pView.GridControl.Parent as Form) == DialogResult.OK)
                {
                    pView.ExportToText(form.FileName);
                }
            };


            if (pView.GridControl.ContextMenuStrip == null)
            {
                var mnu = new ContextMenuStrip();

                mnu.Items.Add(mnuItemExcel);
                mnu.Items.Add(mnuItemPdf);
                mnu.Items.Add(mnuItemRtf);
                mnu.Items.Add(mnuItemTxt);
                mnu.Items.Add(mnuItemHtml);

                pView.GridControl.ContextMenuStrip = mnu;
            }
            else
            {
                //Menu Folder
                var mnuExport = new ToolStripMenuItem("Exportar", Properties.Resources.document_export);

                mnuExport.DropDownItems.Add(mnuItemExcel);
                mnuExport.DropDownItems.Add(mnuItemPdf);
                mnuExport.DropDownItems.Add(mnuItemRtf);
                mnuExport.DropDownItems.Add(mnuItemTxt);
                mnuExport.DropDownItems.Add(mnuItemHtml);

                pView.GridControl.ContextMenuStrip.Items.Add(new ToolStripSeparator());
                pView.GridControl.ContextMenuStrip.Items.Add(mnuExport);
            }
        }



        /// <summary>
        /// Adiciona coluna de CheckBox de seleção e define as cores de seleção padrão quando selecionado
        /// </summary>
        /// <param name="pView">View da Grid</param>
        /// <param name="pFieldName">Nome da coluna</param>
        /// <param name="pCaption">Título da coluna</param>
        public static void AddSelColumn(this GridView pView, string pFieldName, string pCaption)
        {
            var col = new GridColumn
            {
                FieldName = pFieldName,
                Name = pFieldName,
                Caption = pCaption,
                UnboundType = DevExpress.Data.UnboundColumnType.Boolean
            };

            pView.Columns.Add(col);

            col.Visible = true;

            var style = new StyleFormatCondition(
                 FormatConditionEnum.Equal, col, true, true, true, true);

            style.Appearance.BackColor = Color.FromArgb(240, 204, 77);
            style.Appearance.ForeColor = Color.Black;

            pView.FormatConditions.Add(style);
        }


        /// <summary>
        /// Adiciona uma soma a colunn
        /// </summary>
        /// <param name="pGridView">Objeto GridVIew</param>
        /// <param name="pFieldName">Nome do Campo da Grid</param>
        /// <param name="displayForm">Formatação do Summary</param>
        public static void AddSumSummary(this GridView pGridView, string pFieldName, string displayForm = "{0:N2}")
        {
            var sumary = pGridView.Columns[pFieldName].SummaryItem;
            sumary.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            sumary.DisplayFormat = displayForm;
        }

        /// <summary>
        /// Atribui a visibilidade ou não de todos os campos da grid
        /// </summary>
        /// <param name="gridView">Um GridView</param>
        /// <param name="visibled">Um Booleando</param>
        public static void SetAllVisible(this GridView gridView, bool visibled)
        {
            foreach (GridColumn column in gridView.Columns)
            {
                column.Visible = visibled;
            }
        }

        /// <summary>
        /// Atribui a visibilidade ou não de todos os campos da grid
        /// </summary>
        /// <param name="gridView">Um GridView</param>
        /// <param name="allowEdit">Permite edição</param>
        public static void SetAllEditable(this GridView gridView, bool allowEdit)
        {
            foreach (GridColumn column in gridView.Columns)
            {
                column.OptionsColumn.AllowEdit = allowEdit;
            }
        }

        /// <summary>
        /// Atribui a visibilidade ou não de todos os campos da grid
        /// </summary>
        /// <param name="gridView">Um GridView</param>
        /// <param name="columns">Nome dos Campos das Colunas</param>
        public static void FreezeOnLeft(this GridView gridView, params string[] columns)
        {
            foreach (var columnName in columns)
            {
                var gridColumna = gridView.Columns.ColumnByFieldName(columnName);

                gridColumna.OptionsColumn.AllowMove = false;
                gridColumna.Fixed = FixedStyle.Left;
            }
        }

        /// <summary>
        /// Torna visiable as colunas e aplica a ordem passada
        /// </summary>
        /// <param name="gridView">GridView</param>
        /// <param name="columns">Nome dos Campos das Colunas</param>
        public static void OrderByAndVisible(this GridView gridView, List<string> columns)
        {
            var index = 0;

            foreach (var columnName in columns)
            {
                var gridColumna = gridView.Columns.ColumnByFieldName(columnName);
                gridColumna.VisibleIndex = ++index;
            }
        }


        /// <summary>
        /// Torna visiable somente as colunas e aplica a ordem passada
        /// </summary>
        /// <param name="gridView">GridView</param>
        /// <param name="columns">Nome dos Campos das Colunas</param>
        public static void SetVisbleOnly(this GridView gridView, List<string> columns)
        {
            gridView.SetAllVisible(false);
            gridView.OrderByAndVisible(columns);
        }

        /// <summary>
        /// Torna visiable somente as colunas e aplica a ordem passada
        /// </summary>
        /// <param name="gridView">GridView</param>
        /// <param name="columns">Nome dos Campos das Colunas</param>
        public static void SetEditableOnly(this GridView gridView, List<string> columns)
        {
            gridView.SetAllEditable(false);
            gridView.SetEditable(columns, true);
        }

        /// <summary>
        /// Mantém o foco na linha da grid enquanto atualiza os novos valores ou novos registros.
        /// </summary>
        /// <param name="gridView">Uma grid View</param>
        /// <param name="updateRows">Método chamado para atualizar os dados da grid</param>
        /// <param name="GetDataSourceRowIndex">Método chamado quando o registro eh novo, null caso não for</param>
        public static void KeepFocusedRowHandle(this GridView gridView, Action updateRows, Func<int> GetDataSourceRowIndex = null)
        {
            var currentDataSourceIndex = gridView.GetFocusedDataSourceRowIndex();

            updateRows();

            if (GetDataSourceRowIndex != null)
                currentDataSourceIndex = GetDataSourceRowIndex();

            gridView.FocusedRowHandle = gridView.GetRowHandle(currentDataSourceIndex);
        }
    }


}
