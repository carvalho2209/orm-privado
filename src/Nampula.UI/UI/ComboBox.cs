using System;
using System.Text;

namespace Nampula.UI
{
    /// <summary>
    /// Componente combobox
    /// </summary>
    public class ComboBox : DevExpress.XtraEditors.ComboBoxEdit
    {
        /// <summary>
        /// Nome do campo
        /// </summary>
        public struct FieldsName
        {
            public const string Selected = "Selected";
            public const int iNoCurrentValue = 0;
        }

        /// <summary>
        /// Descrições dos campos
        /// </summary>
        public struct Description
        {
            public const string Selected = "Sel";
            public const string NoCurrentValue = "Não selecionado";
        }

        /// <summary>
        /// Informações fonte de dados
        /// </summary>
        public string DataSourceInformation { get; set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public ComboBox()
        {
            ValidValues = new ValidValues();
            ValueAlign = eValueAlign.eLeft;
            ShowTextCombo = eShowTextCombo.eAll;
            ValidValues.OnAdd += ValidValues_OnAdd;
            ValidValues.OnRemove += ValidValues_OnRemove;
            ValidValues.OnClear += ValidValues_OnClear;

            InitializeComponent();

            VisualStyles.SetStyle(this);
        }

        void ValidValues_OnClear(object sender, ManagerCollectionEventHargs<ValidValue> e)
        {
            Properties.Items.Clear();
            Text = String.Empty;
        }

        void ValidValues_OnRemove(object sender, ManagerCollectionEventHargs<ValidValue> e)
        {
            RemoveItem(e.Index);
        }

        private delegate void OnInvokeValueHandler(int pIndex);
        private void RemoveItem(int index)
        {
            if (InvokeRequired)
            {
                var mySetValue = new OnInvokeValueHandler(RemoveItem);
                BeginInvoke(mySetValue, new object[] { index });
            }
            else
            {
                if (SelectedIndex == index)
                    Text = string.Empty;
                Properties.Items.RemoveAt(index);
            }
        }

        

        /// <summary>
        /// Item Selecionado
        /// </summary>
        public ValidValue Selected { get; private set; }
        
        /// <summary>
        /// Valores válidos para o combox
        /// </summary>
        public ValidValues ValidValues { get; set; }

        /// <summary>
        /// O que deve ser exibido no combo box
        /// </summary>
        public eShowTextCombo ShowTextCombo { get; set; }

        /// <summary>
        /// Alinhamento do Valor
        /// </summary>
        public eValueAlign ValueAlign { get; set; }

        void ValidValues_OnAdd(object sender, ManagerCollectionEventHargs<ValidValue> e)
        {
            StringBuilder myItem;

            switch (ShowTextCombo)
            {
                case eShowTextCombo.eAll:
                    myItem = new StringBuilder();

                    switch (ValueAlign)
                    {
                        case eValueAlign.eRight:
                            myItem.AppendFormat("{0,15:S}", Convert.ToString(e.Item.Value));
                            break;
                        case eValueAlign.eLeft:
                            myItem.AppendFormat("{0,-15:S}", Convert.ToString(e.Item.Value));
                            break;
                    }

                    myItem.Append(" - ");
                    myItem.Append(e.Item.Description);

                    AddItem(myItem.ToString());
                    break;

                case eShowTextCombo.eName:
                    AddItem(e.Item.Description);
                    break;
                case eShowTextCombo.eValue:

                    myItem = new StringBuilder();

                    switch (ValueAlign)
                    {
                        case eValueAlign.eRight:
                            myItem.AppendFormat("{0,15:S}", e.Item.Value);
                            break;
                        case eValueAlign.eLeft:
                            myItem.AppendFormat("{0,-15:S}", e.Item.Value);
                            break;
                    }

                    myItem.Append("  ");

                    AddItem(myItem.ToString());

                    break;
            }
        }

        private void AddItem(string p)
        {
            if (InvokeRequired)
            {
                var mySetValue = new OnSetValueHandler(AddItem);
                BeginInvoke(mySetValue, new object[] { p });
            }
            else
            {
                Properties.Items.Add(p);
            }
        }

        /// <summary>
        /// Seleciona um item no comboBox
        /// </summary>
        /// <param name="index">Indice a ser selecionado</param>
        /// <param name="searchKey">Qual o campo deve ser considerado como indcie</param>
        public void Select(object index, BoSearchKey searchKey)
        {
            SetSelectedIndex(ValidValues.GetIndex(index, searchKey));
        }

        private delegate void OnSelectedIndexHandler(int pValue);

        private void SetSelectedIndex(int pValue)
        {
            if (InvokeRequired)
            {
                var mySetValue = new OnSelectedIndexHandler(SetSelectedIndex);
                BeginInvoke(mySetValue, new object[] { pValue });
            }
            else
            {
                SelectedIndex = pValue;
            }
        }

        

        private void InitializeComponent()
        {
            SuspendLayout();
            Font = new System.Drawing.Font("Tahoma", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Size = new System.Drawing.Size(121, 21);
            SelectedValueChanged += ComboBoxSelectedValueChanged;
            ResumeLayout(false);
        }

        void ComboBoxSelectedValueChanged(object sender, EventArgs e)
        {
            Selected = ValidValues.Item(SelectedIndex);
        }

        private delegate void OnSetValueHandler(string pValue);

        private void SetValue(string p)
        {
            if (InvokeRequired)
            {
                var mySetValue = new OnSetValueHandler(SetValue);
                BeginInvoke(mySetValue, new object[] { p });
            }
            else
            {
                //this.SelectedValue = p;
                Select(p, BoSearchKey.psk_ByValue);
            }
        }

        /// <summary>
        /// Adicionar um item Fake para nenhuma seleção
        /// </summary>
        public void AddNoCurrentSelect()
        {
            ValidValues.Add(FieldsName.iNoCurrentValue, Description.NoCurrentValue);
        }

        /// <summary>
        /// Selecionar o item fake de nenhum seleção
        /// </summary>
        public void SelectNoCurrent()
        {
            Select(FieldsName.iNoCurrentValue, BoSearchKey.psk_ByValue);
        }
    }
}
