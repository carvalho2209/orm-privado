using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using DevExpress.XtraTreeList.Columns;
using Nampula.Framework;
using System.Drawing;
using DevExpress.XtraTreeList.StyleFormatConditions;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace Nampula.UI.Helpers.Extentions
{

    /// <summary>
    /// Extensões de métodos para o controle Nampula.UI.DataGridTreeView
    /// </summary>
    public static class TreeGridViewExtention
    {

        /// <summary>
        /// Formata as colunas do grid de acordo com o objeto passado como parâmetro.
        /// </summary>
        /// <typeparam name="T">Um objeto do tipo TableAdapter.</typeparam>
        /// <param name="pGridView">O controle GridView.</param>
        /// <param name="pDB">Objeto do banco de dados</param>
        /// <param name="pColumns">Uma lista de colunas.</param>
        public static void FormatGrid<T>(
            this DataGridTreeView pGridView,
            DataBaseAdapter pDB,
            params KeyValuePair<string, Dictionary<object, string>>[] pColumns) where T : TableAdapter
        {
            var pObject = pDB.CreateObject<T>();
            TreeGridViewExtention.CreateColumn(pGridView, pObject.Collumns, pColumns);
        }



        /// <summary>
        /// Formata as colunas do grid de acordo com o objeto passado como parâmetro.
        /// </summary>
        /// <typeparam name="T">Um objeto do tipo TableAdapter (B1).</typeparam>
        /// <param name="pGridView">O controle GridView.</param>
        /// <param name="pCompanyDb">O nome da empresa no SAP.</param>
        public static void FormatGrid<T>(this DataGridTreeView pGridView, string pCompanyDb,
            params KeyValuePair<string, Dictionary<object, string>>[] pColumns) where T : TableAdapter, new()
        {
            T pObject = new T() { DBName = pCompanyDb };
            TreeGridViewExtention.CreateColumn(pGridView, pObject.Collumns, pColumns);
        }



        /// <summary>
        /// Formata as colunas do grid de acordo com a lista de colunas passdas com parametors
        /// </summary>
        /// <param name="pGridView">O controle GridView.</param>
        /// <param name="pTableColumns">Lista de Coluns da Tabela</param>
        /// <param name="pColumns">Lista de Coluns</param>
        public static void FormatGrid(this DataGridTreeView pGridView,
            TableAdapterFieldCollection pTableColumns,
            params KeyValuePair<string, Dictionary<object, string>>[] pColumns)
        {
            TreeGridViewExtention.CreateColumn(pGridView, pTableColumns, pColumns);
        }



        /// <summary>
        /// Formata a coluna de acordo com o tipo especificado.
        /// </summary>
        /// <param name="pCollumn">A coluna do GridView.</param>
        /// <param name="pDataType">Tipo da coluna.</param>
        private static void CreateColumn(DataGridTreeView pTreeGridView, TableAdapterFieldCollection pTableColumns,
            params KeyValuePair<string, Dictionary<object, string>>[] pColumns)
        {

            foreach (TableAdapterField field in pTableColumns)
            {
                var columnList = (from p in pColumns
                                  where p.Key.Equals(field.Name)
                                  select new { Key = p.Key, Value = p.Value }).FirstOrDefault();

                var hasCustomColumn = (columnList != null);

                var column = pTreeGridView.Columns.AddField(field.Name);
                column.Caption = field.Description;
                column.VisibleIndex = pTreeGridView.Columns.Count;

                if (hasCustomColumn)
                {
                    var comboEdit = new TreeGridValidValuesColumn(column);
                    foreach (var item in columnList.Value)
                        comboEdit.ValidValues.Add(item.Key, item.Value);
                }
                else
                {
                    FormatColumn(pTreeGridView.Columns[field.Name], field.GetDbType());
                }
            }
        }



        /// <summary>
        /// Formata a coluna de acordo com o tipo especificado.
        /// </summary>
        /// <param name="pCollumn">A coluna do GridView.</param>
        /// <param name="pDataType">Tipo da coluna.</param>
        public static void FormatColumn(TreeListColumn pCollumn, Type pDataType)
        {
            if (pDataType == typeof(byte) ||
                pDataType == typeof(short) ||
                pDataType == typeof(int) ||
                pDataType == typeof(long))
            {
                pCollumn.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                pCollumn.Format.FormatString = "n0";
                pCollumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            }
            else if (pDataType == typeof(double) ||
                pDataType == typeof(float) ||
                pDataType == typeof(decimal)
                )
            {
                pCollumn.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                pCollumn.Format.FormatString = "n2";
                pCollumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            }
            else if (pDataType == typeof(DateTime))
            {
                pCollumn.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
                pCollumn.Format.FormatString = "d";
            }
        }



        /// <summary>
        /// Define cor padrão, baseado no look and feel das telas do SAP
        /// </summary>
        /// <param name="pView">View da Grid</param>
        public static void SetColors(this DataGridTreeView pView)
        {
            var color = Color.FromArgb(244, 231, 156);
            pView.Appearance.FocusedCell.BackColor = color;
            pView.Appearance.FocusedCell.ForeColor = Color.Black;

            pView.Appearance.FocusedRow.BackColor = color;
            pView.Appearance.FocusedRow.ForeColor = Color.Black;

            pView.Appearance.SelectedRow.BackColor = color;
            pView.Appearance.SelectedRow.ForeColor = Color.Black;

            pView.Appearance.HideSelectionRow.BackColor = color;
            pView.Appearance.HideSelectionRow.ForeColor = Color.Black;
        }



        /// <summary>
        /// Atribui as cores a aparencia da grid
        /// </summary>
        /// <param name="pView">View da grid</param>
        /// <param name="pDefaultColor">Color</param>
        /// <param name="pApplyRow">Aplica a linha</param>
        public static void SetColors(this DataGridTreeView pView, Color pDefaultColor, bool pApplyRow)
        {
            pView.Appearance.FocusedCell.BackColor = pDefaultColor;
            pView.Appearance.FocusedCell.ForeColor = pDefaultColor;

            if (pApplyRow)
            {
                pView.Appearance.FocusedRow.BackColor = pDefaultColor;
                pView.Appearance.FocusedRow.ForeColor = pDefaultColor;

                pView.Appearance.SelectedRow.BackColor = pDefaultColor;
                pView.Appearance.SelectedRow.ForeColor = pDefaultColor;

                pView.Appearance.HideSelectionRow.BackColor = pDefaultColor;
                pView.Appearance.HideSelectionRow.ForeColor = pDefaultColor;
            }
        }



        /// <summary>
        /// Adiciona coluna de CheckBox de seleção e define as cores de seleção padrão quando selecionado
        /// </summary>
        /// <param name="pView">View da Grid</param>
        /// <param name="pFieldName">Nome da coluna</param>
        /// <param name="pCaption">Título da coluna</param>
        public static void AddSelColumn(this DataGridTreeView pView, string pFieldName, string pCaption)
        {
            var col = pView.Columns.Add();
            col.FieldName = pFieldName;
            col.Name = pFieldName;
            col.Caption = pCaption;
            col.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Boolean;
            col.Visible = true;

            var style = new StyleFormatCondition(
                 DevExpress.XtraGrid.FormatConditionEnum.Equal, col, true, true, true, true);

            style.Appearance.BackColor = Color.FromArgb(240, 204, 77);
            style.Appearance.ForeColor = Color.Black;

            pView.FormatConditions.Add(style);
        }



        /// <summary>
        /// Atribiu a visibilidade das colunas 
        /// </summary>
        /// <param name="pView">GridView</param>
        /// <param name="pColumns">Nome das Colunas</param>
        /// <param name="pVisible">True se visivel False se não visivel</param>
        public static void SetVisible(this DataGridTreeView pView, List<String> pColumns, bool pVisible)
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
        public static void SetEditable(this DataGridTreeView pView, List<String> pColumns, bool pEditable)
        {
            foreach (var item in pColumns)
                pView.Columns[item].OptionsColumn.AllowEdit = pEditable;
        }



        /// <summary>
        /// Adiciona uma seta laranja em uma coluna da grid.
        /// </summary>
        /// <param name="pColumn">Coluna que receberá a seta amarela</param>
        /// <param name="pEventHandler">Evento que será disparado ao clicar na seta.</param>
        public static void SetLinkedButton(this TreeListColumn pColumn, ButtonPressedEventHandler pEventHandler)
        {
            const string strImage64 = @"iVBORw0KGgoAAAANSUhEUgAAAAwAAAAJCAIAAACJ2loDAAAABnRSTlMA/wAAAACkwsAdAAABWElEQVR42gFNAbL+Af8AAAAAAAAAAAAAAAAAAAAAAAEAAAAAAP8AAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAD/xgABAAAAAAAAAAAAAAACAQAAAQAAAQAAAQAAAQAAAQAAAAAAAAAA/8YAAQAAAAAAAAAAAQAAAP/GAAAAAAAAAAAAAAAAAAAAAAAAAADGAAAAAAF0AP8AAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAxgAAAAAAAAD/jAABAAAEAAAAAMYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAXQA/wAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAP+MAAAAAAF0AP8AAAAAAAT/AAAAAAAAAAAAAAAAAAAAAAABAAAAAAABdAD/AAAAAAAAAAAB/wAAAAAAAAAAAAAAAAAAAAAAAQAAAAAA/wAAAAAAAAAAAAAAe1QVoTe5U8AAAAAASUVORK5CYII=";

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

            pColumn.TreeList.RepositoryItems.Add(colunmLink);

            pColumn.OptionsColumn.AllowEdit = true;

            colunmLink.ButtonClick += (s, e) =>
            {
                if (!ReferenceEquals(e.Button.Tag, "LinkedButton"))
                    return;

                pEventHandler(s, e);
            };

            pColumn.ColumnEdit = colunmLink;
        }



        /// <summary>
        /// Adiciona uma seta laranja em uma coluna da grid para um objeto do SAP
        /// </summary>
        /// <param name="pColumn">Coluna que receberá a seta amarela</param>
        /// <param name="pObject">Evento que será disparado ao clicar na seta.</param>
        public static void SetLinkedButton(this TreeListColumn pColumn, BoLinkedObject pObject)
        {
            SetLinkedButton(pColumn, (sender, e) =>
            {
                var eventargs = new LinkedButtonEventArgs();
                var value = pColumn.TreeList.EditingValue;

                eventargs.LinkedObjectType = pObject;
                eventargs.Values = new List<object>() { value };

                Application.GetInstance().PeformLinkedButton(sender, eventargs);
            });
        }


    }

}
