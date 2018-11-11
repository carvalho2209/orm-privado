using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.UI;
using Nampula.Framework;
using NampulaDemo;

namespace TaxOne.Logon
{
    public class FormChooseCompany : FormSystem
    {

        protected struct UniqueID
        {
            public const string itmCompany = "grdComp";
            public const string itmOk = "cmdOk";
            public const string itmCancel = "cmdCancel";
            public const string dtTable = "dtTable";
        }

        public FormChooseCompany()
            : base(SAPbouiCOM.BoFormBorderStyle.fbs_Fixed)
        {
            FormBind.Title = "Selecionar Empresa...";
            InitializeItem();
        }


        /// <summary>
        /// Cria os itens na tela
        /// </summary>
        private void InitializeItem()
        {
            var itmOk = AddItem(UniqueID.itmOk, SAPbouiCOM.BoFormItemTypes.it_BUTTON);
            var itmCancel = AddItem(UniqueID.itmCancel, SAPbouiCOM.BoFormItemTypes.it_BUTTON);
            var itmCompany = AddItem(UniqueID.itmCompany, SAPbouiCOM.BoFormItemTypes.it_GRID);

            itmOk.Left = 5;
            itmOk.Top = FormBind.Height - itmOk.Height - 30;  //285;
            var cmdOk = itmOk.Specific as SAPbouiCOM.Button;
            cmdOk.Caption = "Ok";

            itmCancel.Left = itmOk.Left + itmOk.Width + 5;
            itmCancel.Top = itmOk.Top;
            var cmdCancel = itmCancel.Specific as SAPbouiCOM.Button;
            cmdCancel.Caption = "Cancelar";

            itmCompany.Top = 5;
            itmCompany.Left = 5;
            itmCompany.Width = this.FormBind.Width - itmCompany.Left - 5;
            itmCompany.Height = itmOk.Top - 5;
            var grdCompany = itmCompany.Specific as SAPbouiCOM.Grid;

            var data = FormBind.DataSources.DataTables.Add(UniqueID.dtTable);
            data.ExecuteQuery(GetQuery());
            grdCompany.DataTable = data;
            grdCompany.SelectionMode = SAPbouiCOM.BoMatrixSelect.ms_Single;
            //grdCompany.DataTable(
            foreach (SAPbouiCOM.GridColumn item in grdCompany.Columns)
                item.Editable = false;

            grdCompany.Columns.Item("ConnID").Visible = false;
            //grdCompany.DataTable.ExecuteQuery("Select @@SPID");

        }

        private string GetQuery()
        {
            StringBuilder query = new StringBuilder();
            query.Append("Select ")
                    .Append(" Codigo =  T0.ID,")
                    .Append(" Empresa = T0.NomeFantasia,")
                    .Append(" RazaoSocial = T0.RazaoSocial, ")
                    .Append(" ConnID = @@SPID")
                .Append(" From ")
                    .Append(" SBO_TaxOne..Entidade T0")
                    .Append(" Inner Join SBO_TaxOne..EntidadeUsuario T1 On T0.ID = T1.EntidadeID")
                .Append(" Where")
                .AppendFormat(" T1.UserCode = '{0}' And T0.CompanyDb = '{1}'",
                        Program.GetCurrentUserName(),
                        Program.GetCurrentCompanyDb());

            return query.ToString();
        }

        #region cmdOk_Click
        /// <summary>
        /// Método para caputra de evento FORM_LOAD do SAP
        /// </summary>
        /// <param name="pEvent">Argumentos do Evento</param>
        /// <param name="bubleevent">Propagar execução do evento</param>
        [FormSystemEventAttribute(ItemID = UniqueID.itmOk, EventType = BoEventTypes.et_CLICK)]
        public void cmdOk_Click(ItemEvent pEvent, bool bubleevent)
        {
            try
            {
                var grdCompany = GetItem(UniqueID.itmCompany).Specific
                        as SAPbouiCOM.Grid;

                if (grdCompany.Rows.Count == 0)
                    throw new Exception("Selecione uma empresa");

                var rowSel = grdCompany.Rows.SelectedRows.Item(
                    0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                var entitiID = grdCompany.DataTable.GetValue("Codigo", rowSel).To<Int32>();
                var spID = grdCompany.DataTable.GetValue("ConnID", rowSel).To<Int32>();

                //EntitySelection.Instace.SetCompany( entitiID, spID );

                FormBind.Close();

            }
            catch (Exception ex)
            {
                SboApp.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

        }
        #endregion

        #region cmdCancel_Click
        /// <summary>
        /// Método para caputra de evento FORM_CLOCK do botão Ok
        /// </summary>
        /// <param name="pEvent">Argumentos do Evento</param>
        /// <param name="bubleevent">Propagar execução do evento</param>
        [FormSystemEventAttribute(ItemID = UniqueID.itmCancel, EventType = BoEventTypes.et_CLICK)]
        public void cmdCancel_Click(ItemEvent pEvent, bool bubleevent)
        {
            FormBind.Close();
        }
        #endregion


    }
}
