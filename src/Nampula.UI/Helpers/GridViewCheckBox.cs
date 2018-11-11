using System;
using System.Collections.Generic;
using System.Linq;
using Nampula.DI;
using System.Data;
using Nampula.Framework;
using DevExpress.XtraGrid.Views.Grid;
using Nampula.UI.Helpers.Extentions;

namespace Nampula.UI.Helpers
{
    /// <summary>
    /// Ajudador que trata uma grid que tem um CheckBox.. para seleção de configurações ( Exemplo uma lista de utilizações )
    /// </summary>
    /// <typeparam name="TT">Um objeto TableAdapter</typeparam>
    /// <typeparam name="TD">Origem dos registros</typeparam>
    public class GridViewCheckBox<TT, TD>
        where TT : TableAdapter, new()
        where TD : TableAdapter, new()
    {

        
        /// <summary>
        /// Antes de selecionar/deselecionar um registro
        /// </summary>
        public event EventHandler<EventArgs> OnBeforeSel;
        /// <summary>
        /// Depois de selecionar/deselecionar um registro
        /// </summary>
        public event EventHandler<EventArgs> OnAfterSel;
        
        List<TT> _sels = new List<TT>();
        readonly GridView _gridView;
        readonly string _selKey;
        readonly string _dataSourceKey;
        
        /// <summary>
        /// Nome das colunas adicionais como (Sel)
        /// </summary>
        private struct FieldsName
        {
            public static readonly string Sel = "Sel";
        }
        
        /// <summary>
        /// Construtor padrão
        /// </summary>
        private GridViewCheckBox()
        {
        }

        /// <summary>
        /// construtor padrão da da classe
        /// </summary>
        /// <param name="pView">GridView que será tratado</param>
        /// <param name="pSelKey">Campo de <see cref="TT"/> que defini qual o campo será comparado com pDataSourceKey para determinar se um registro está selecionado</param>
        /// <param name="pDataSourceKey">Campo de <see cref="TD"/> que defini qual o campo será comparado com pSelKey para determinar se um registro está selecionado</param>
        /// <param name="pVisibleColumns">Lista de Colunas Visiveis</param>
        /// <param name="pColumns">Lista de Colunas com registros relacionados</param>
        public GridViewCheckBox(GridView pView, string pSelKey, string pDataSourceKey, List<String> pVisibleColumns,
            params KeyValuePair<string, Dictionary<object, string>>[] pColumns)
            : this()
        {
            _gridView = pView;
            _gridView.Tag = this;

            _selKey = pSelKey;
            _dataSourceKey = pDataSourceKey;

            FormatGrid(pView, pVisibleColumns, pColumns);
            _gridView.CellValueChanged += View_CellValueChanged;
        }
        

        void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == FieldsName.Sel)
            {
                var row = _gridView.GetDataRow(e.RowHandle);

                var line = _sels.FirstOrDefault(p =>
                    (p.Collumns[_selKey].GetString() == row[_dataSourceKey].ToString())
                    && (p.StateRecord != eState.eRemove));

                if (row[FieldsName.Sel].To<Boolean>())
                {
                    line = new TT
                    {
                        StateRecord = eState.eAdd
                    };

                    line.Collumns[_selKey].Value = row[_dataSourceKey];
                    _sels.Add(line);
                }
                else
                {
                    if (line == null)
                        return;

                    if (line.StateRecord == eState.eAdd)
                        _sels.Remove(line);
                    else
                        line.StateRecord = eState.eRemove;
                }

                if (OnAfterSel != null)
                    OnAfterSel(this, new EventArgs());

            }

        }

        
        /// <summary>
        /// Origem dos Registros da grid
        /// </summary>
        public void SetDataSource(List<TD> pDataSource)
        {
            AddSelColumn(pDataSource);
            _gridView.GridControl.DataSource = null;
            _gridView.GridControl.DataSource = pDataSource.ToDataTable();
            _gridView.BestFitColumns();
        }
        /// <summary>
        /// Lista de Registros selecionados
        /// </summary>
        public List<TT> RecordSels
        {
            get { return _sels; }
            set
            {
                _sels = new List<TT>();
                _sels = value;
                CheckRecords(value);
            }
        }
        

        

        
        /// <summary>
        /// Atribui true a coluna sel se houver na coleção sels
        /// </summary>
        private void CheckRecords(IEnumerable<TT> pSels)
        {
            var data = _gridView.GridControl.DataSource as DataTable;

            if (data == null)
                return;

            foreach (DataRow line in data.Rows)
                line.SetField(FieldsName.Sel, false);

            foreach (var item in pSels.Where(s => s.StateRecord != eState.eRemove))
            {
                var line = data.AsEnumerable().FirstOrDefault(
                    x => x[_dataSourceKey].To<String>() == item.Collumns[_selKey].GetString());

                if (line != null)
                    line.SetField(FieldsName.Sel, true);
            }
        }
        

        
        /// <summary>
        /// Verifica se existe a coluna Sel no datasource , se não existir cria uma
        /// </summary>
        private static void AddSelColumn(ICollection<TD> pDataSource)
        {
            if (pDataSource.Count == 0)
                return;

            foreach (var item in pDataSource.Where(item => !item.Collumns.Exists(p => p.Name == FieldsName.Sel)))
                item.Collumns.Add(new TableAdapterField(FieldsName.Sel, FieldsName.Sel, DbType.Boolean));
        }


        ///// <summary>
        ///// Converte uma coleção de table adpaters em um DataTable
        ///// </summary>
        ///// <typeparam name="TT">Tipo do Objeto</typeparam>
        ///// <param name="pCollection">Coleção</param>
        ///// <returns>Um dataTable</returns>
        //private DataTable ToDataTable(List<TD> pCollection)
        //{
        //    var dataTable = new DataTable();

        //    if (pCollection.Count == 0)
        //        return dataTable;

        //    foreach (var item in pCollection.First().Collumns)
        //        dataTable.Columns.Add(item.Name, item.GetDbType());

        //    foreach (var item in pCollection)
        //    {
        //        var row = dataTable.NewRow();
        //        item.Collumns.ForEach(p => row[p.Name] = p.Value ?? DBNull.Value);
        //        dataTable.Rows.Add(row);
        //    }

        //    return dataTable;

        //}
        

        
        /// <summary>
        /// Formata a grid, cria as coluna da grid
        /// </summary>
        /// <param name="pView">View da Grid</param>
        /// <param name="pVisbleColumns">Lista de Coluns que serão visiveis</param>
        /// <param name="pColumns">Colunas que tem dados relacionados</param>
        private void FormatGrid(GridView pView, IEnumerable<string> pVisbleColumns,
            params KeyValuePair<string, Dictionary<object, string>>[] pColumns)
        {
            var objectSource = new TD();
            objectSource.Collumns.RemoveAll(p => pVisbleColumns.All(v => v != p.Name));
            objectSource.Collumns.Insert(0, new TableAdapterField(FieldsName.Sel, FieldsName.Sel, DbType.Boolean));
            pView.FormatGrid(objectSource.Collumns, pColumns);

            pView.Columns[FieldsName.Sel].OptionsColumn.AllowEdit = true;

        }
        

        

    }

}
