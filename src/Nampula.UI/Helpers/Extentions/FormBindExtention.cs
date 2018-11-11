using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Windows.Forms;
using Nampula.Framework;
using Nampula.UI.Helpers.Extentions;
using Nampula.UI.DinamicInterface;

namespace Nampula.UI.Helpers
{
    /// <summary>
    /// Gerenciamento de Vincula entre data source e o controle na tela
    /// </summary>
    public static class FormBindExtention
    {

        /// <summary>
        /// Preenche os controles na tela
        /// </summary>
        /// <param name="pBinds">Lista de pares entre o controle em tela e o campo da tabela</param>
        /// <param name="pTableObject">Table Adapter do Objeto</param>
        public static void FillControls(this Dictionary<string, Control> pBinds, TableAdapter pTableObject, EventHandler<BindChangedValueEventArgs> pHandler = null)
        {
            foreach (var item in pBinds)
            {
                if (!pTableObject.Collumns.Exists(c => c.Name == item.Key))
                    throw new Exception("Coluna informada [{0}] não existe na tabela [{1}]"
                        .Fmt(item.Key, pTableObject.TableName));

                try
                {
                    FillControl(item.Value, pTableObject.Collumns[item.Key]);
                }
                catch (Exception exception)
                {
                    if (pHandler != null)
                    {
                        var eventHanlder = new BindChangedValueEventArgs
                                               {
                                                   Bind = item,
                                                   Ex = exception,
                                                   Value = pTableObject.Collumns[item.Key]
                                               };
                        pHandler(pBinds, eventHanlder);

                        if (eventHanlder.Continue)
                            continue;
                    }
                    throw;
                }

            }
        }

        public static void SetDataSourceInformation(this Dictionary<string, Control> pBinds, TableAdapter pTableObject)
        {
            foreach (var item in pBinds)
            {
                if (!pTableObject.Collumns.Exists(c => c.Name == item.Key))
                    throw new Exception("Coluna informada [{0}] não existe na tabela [{1}]"
                        .Fmt(item.Key, pTableObject.TableName));

                SetDataSourceInformation(item.Value, pTableObject.Collumns[item.Key]);
            }
        }



        /// <summary>
        /// Preenche um controle da tela
        /// </summary>
        /// <param name="pControl">Controle do Objeto</param>
        /// <param name="pField">TableField do Objeto</param>
        private static void SetDataSourceInformation(Control pControl, TableAdapterField pField)
        {
            var controlName = pControl.GetType().FullName;
            if (pField.TableAdapter == null)
                return;

            var informationSource = string.Format("[{0}]-[{1}]", pField.TableAdapter.TableName, pField.Name );
            switch (controlName)
            {
                case "Nampula.UI.OptionBtn":
                    var optionBtn = (pControl as Nampula.UI.OptionBtn);
                    optionBtn.DataSourceInformation = informationSource;
                    optionBtn.MouseEnter += new EventHandler((object sender, EventArgs e) =>
                    {
                        if (Keyboard.IsKeyDown(Keys.ControlKey))
                            Nampula.UI.Application.GetInstance().SetTextOnStatusBar(string.Format(optionBtn.DataSourceInformation+ "{0}", ", "+(sender as Nampula.UI.OptionBtn).Text), BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Warning);
                    });
                    break;
                case "Nampula.UI.CheckBox":
                    var checkBox = (pControl as Nampula.UI.CheckBox);
                    checkBox.DataSourceInformation = informationSource;
                    checkBox.MouseEnter += new EventHandler((object sender, EventArgs e) =>
                    {
                        if (Keyboard.IsKeyDown(Keys.ControlKey))
                            Nampula.UI.Application.GetInstance().SetTextOnStatusBar(
                                string.Format(checkBox.DataSourceInformation+ "{0}", ", " +((sender as Nampula.UI.CheckBox).Checked ? "1":"0")), BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Warning);
                    });
                    break;
                case "Nampula.UI.ComboBox":
                    var combo = pControl as Nampula.UI.ComboBox;
                    combo.DataSourceInformation = informationSource;
                    combo.MouseEnter += new EventHandler((object sender, EventArgs e) =>
                    {
                        if (Keyboard.IsKeyDown(Keys.ControlKey))
                            Nampula.UI.Application.GetInstance().SetTextOnStatusBar(
                                string.Format(
                                combo.DataSourceInformation + "{0}", ", " + 
                                ((sender as Nampula.UI.ComboBox).Selected == null ? (sender as Nampula.UI.ComboBox).Text : (sender as Nampula.UI.ComboBox).Selected.Value))
                                , BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Warning);
                    });
                    break;
                case "Nampula.UI.EditTextButton":
                    var textButton = pControl as Nampula.UI.EditTextButton;

                    textButton.DataSourceInformation = informationSource;

                    break;
                case "Nampula.UI.EditText":
                    var editText = pControl as Nampula.UI.EditText;
                    editText.DataSourceInformation = informationSource;
                    editText.MouseEnter += new EventHandler((object sender, EventArgs e) =>
                    {
                        if (Keyboard.IsKeyDown(Keys.ControlKey))
                            Nampula.UI.Application.GetInstance().SetTextOnStatusBar(
                                string.Format(editText.DataSourceInformation + "{0}", ", " + (sender as Nampula.UI.EditText).Text), BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Warning);
                    });
                    break;
                case "Nampula.UI.EditMemo":
                    var editMemo = pControl as Nampula.UI.EditMemo;

                    editMemo.DataSourceInformation = informationSource;
                    editMemo.MouseEnter += new EventHandler((object sender, EventArgs e) =>
                    {
                        if (Keyboard.IsKeyDown(Keys.ControlKey))
                            Nampula.UI.Application.GetInstance().SetTextOnStatusBar(
                                string.Format(editMemo.DataSourceInformation + "{0}", ", " + (sender as Nampula.UI.EditMemo).Text), BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Warning);
                    });

                    break;
                case "Nampula.UI.EditDateTime":
                    var editDateTime = (pControl as Nampula.UI.EditDateTime);
                        editDateTime.DataSourceInformation = informationSource;

                        editDateTime.MouseEnter += new EventHandler((object sender, EventArgs e) =>
                        {
                            if (Keyboard.IsKeyDown(Keys.ControlKey))
                                Nampula.UI.Application.GetInstance().SetTextOnStatusBar(
                                    string.Format(editDateTime.DataSourceInformation + "{0}", ", " + (sender as Nampula.UI.EditDateTime).Text), BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Warning);
                        });
                    break;
                default:
                    throw new ArgumentException("Controle não é um controle padrão da nampula: [{0}]", controlName);
            }
        }


        /// <summary>
        /// Preenche um controle da tela
        /// </summary>
        /// <param name="pBinds">Lista de pares entre o controle em tela e o campo da tabela</param>
        /// <param name="pControl">Controle do Objeto</param>
        /// <param name="pField">TableField do Objeto</param>
        public static void FillControl(this Dictionary<string, Control> pBinds, TableAdapterField pField)
        {
            if (!pBinds.ContainsKey(pField.Name))
                throw new Exception("Coluna não existe na lista de controles [{0}]".Fmt(pField.Name));

            FillControl(pBinds[pField.Name], pField);
        }



        /// <summary>
        /// Preenche um controle da tela
        /// </summary>
        /// <param name="pControl">Controle do Objeto</param>
        /// <param name="pField">TableField do Objeto</param>
        public static void FillControl(Control pControl, TableAdapterField pField)
        {
            var controlName = pControl.GetType().FullName;

            switch (controlName)
            {
                case "Nampula.UI.OptionBtn":
                    (pControl as Nampula.UI.OptionBtn).Checked = pField.GetBool();
                    break;
                case "Nampula.UI.CheckBox":
                    (pControl as Nampula.UI.CheckBox).Checked = pField.GetBool();
                    break;
                case "Nampula.UI.ComboBox":
                    var combo = pControl as Nampula.UI.ComboBox;
                    if (pField.Value != null)
                        combo.Select(pField.Value, BoSearchKey.psk_ByValue);
                    break;
                case "Nampula.UI.EditTextButton":
                    var textButton = pControl as Nampula.UI.EditTextButton;

                    textButton.EditValue = pField.Value;

                    if (pField.DbType == DbType.String)
                        textButton.Properties.MaxLength = pField.Size;

                    break;
                case "Nampula.UI.EditText":
                    var editText = pControl as Nampula.UI.EditText;

                    editText.EditValue = pField.Value;

                    if (pField.DbType == DbType.String)
                        editText.Properties.MaxLength = pField.Size;

                    break;
                case "Nampula.UI.EditMemo":
                    var editMemo = pControl as Nampula.UI.EditMemo;

                    editMemo.EditValue = pField.Value;

                    if (pField.DbType == DbType.String)
                        editMemo.Properties.MaxLength = pField.Size;

                    break;
                case "Nampula.UI.EditDateTime":
                    (pControl as Nampula.UI.EditDateTime).EditValue = pField.Value;
                    break;
                default:
                    throw new ArgumentException("Controle não é um controle padrão da nampula: [{0}]", controlName);
            }
        }



        /// <summary>
        /// Preenche os campos da classe com os valores da tela
        /// </summary>
        /// <param name="pBinds">Lista de pares entre o controle em tela e o campo da tabela</param>
        /// <param name="pTableObject">Table Adapter do Objeto</param>
        public static void FillClass(this Dictionary<string, Control> pBinds, TableAdapter pTableObject)
        {
            foreach (var item in pBinds)
            {
                if (item.Value.GetType() == typeof(Nampula.UI.OptionBtn))
                {
                    var pControl = item.Value as Nampula.UI.OptionBtn;
                    pTableObject.Collumns[item.Key].Value = pControl.Checked;
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.CheckBox))
                {
                    var pControl = item.Value as Nampula.UI.CheckBox;
                    pTableObject.Collumns[item.Key].Value = pControl.Checked;
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.ComboBox))
                {
                    var pControl = item.Value as Nampula.UI.ComboBox;
                    if (pControl.Selected != null)
                        pTableObject.Collumns[item.Key].Value = pControl.Selected.Value;
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.EditText))
                {
                    var pControl = item.Value as Nampula.UI.EditText;
                    pTableObject.Collumns[item.Key].Value = pControl.EditValue;
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.EditTextButton))
                {
                    var pControl = item.Value as Nampula.UI.EditTextButton;
                    pTableObject.Collumns[item.Key].Value = pControl.EditValue;
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.EditMemo))
                {
                    var pControl = item.Value as Nampula.UI.EditMemo;
                    pTableObject.Collumns[item.Key].Value = pControl.EditValue;
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.EditDateTime))
                {
                    var pControl = item.Value as Nampula.UI.EditDateTime;
                    pTableObject.Collumns[item.Key].Value = pControl.EditValue;
                    continue;
                }
            }
        }



        /// <summary>
        /// Seta os controles para somente leitura
        /// </summary>
        /// <param name="pBinds">Lista de controles</param>
        public static void SetReadOnly(Dictionary<string, Control> pBinds)
        {
            foreach (var item in pBinds)
            {
                if (item.Value.GetType() == typeof(Nampula.UI.OptionBtn))
                {
                    var pControl = item.Value as Nampula.UI.OptionBtn;
                    pControl.Enabled = false;
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.CheckBox))
                {
                    var pControl = item.Value as Nampula.UI.CheckBox;
                    pControl.Enabled = false;
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.ComboBox))
                {
                    var pControl = item.Value as Nampula.UI.ComboBox;
                    pControl.Properties.ReadOnly = true;
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.EditText))
                {
                    var pControl = item.Value as Nampula.UI.EditText;
                    pControl.Properties.ReadOnly = true;
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.EditTextButton))
                {
                    var pControl = item.Value as Nampula.UI.EditTextButton;
                    pControl.Properties.ReadOnly = true;
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.EditMemo))
                {
                    var pControl = item.Value as Nampula.UI.EditMemo;
                    pControl.Properties.ReadOnly = true;
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.EditDateTime))
                {
                    var pControl = item.Value as Nampula.UI.EditDateTime;
                    pControl.Properties.ReadOnly = true;
                    continue;
                }
            }
        }



        /// <summary>
        /// Atribui o flag de ativo e desativado
        /// </summary>
        /// <param name="pBinds">Lista de controles</param>
        /// <param name="pEnabled">True para ativado e false para desativado</param>
        public static void SetEnabled(Dictionary<string, Control> pBinds, bool pEnabled)
        {
            foreach (var item in pBinds)
                item.Value.Enabled = pEnabled;
        }



        /// <summary>
        /// Checar por atualização
        /// </summary>
        /// <param name="pBinds">Vínculo de atualizações</param>
        /// <param name="pHandler">Evento</param>
        public static void OnChangeValue(this  Dictionary<string, Control> pBinds, EventHandler<BindChangedValueEventArgs> pHandler)
        {
            foreach (var item in pBinds)
            {
                if (item.Value.GetType() == typeof(Nampula.UI.OptionBtn))
                {
                    var pControl = item.Value as Nampula.UI.OptionBtn;
                    pControl.CheckedChanged += (sender, e) =>
                                                   {
                                                       pHandler(sender, new BindChangedValueEventArgs()
                                                       {
                                                           Bind = item,
                                                           Value = pControl.Checked
                                                       });
                                                   };
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.CheckBox))
                {
                    var pControl = item.Value as Nampula.UI.CheckBox;
                    pControl.CheckedChanged += (sender, e) =>
                                                   {
                                                       pHandler(sender, new BindChangedValueEventArgs()
                                                       {
                                                           Bind = item,
                                                           Value = pControl.Checked
                                                       });
                                                   };
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.ComboBox))
                {
                    var pControl = item.Value as Nampula.UI.ComboBox;
                    pControl.SelectedValueChanged += (sender, e) =>
                                                         {
                                                             pHandler(sender, new BindChangedValueEventArgs()
                                                             {
                                                                 Bind = item,
                                                                 Value = pControl.Selected.Value ?? null
                                                             });
                                                         };
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.EditText))
                {
                    var pControl = item.Value as Nampula.UI.EditText;
                    pControl.EditValueChanged += (sender, e) =>
                                                     {
                                                         pHandler(sender, new BindChangedValueEventArgs()
                                                         {
                                                             Bind = item,
                                                             Value = pControl.EditValue
                                                         });
                                                     };
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.EditTextButton))
                {
                    var pControl = item.Value as Nampula.UI.EditTextButton;
                    pControl.EditValueChanged += (sender, e) =>
                                                     {
                                                         pHandler(sender, new BindChangedValueEventArgs()
                                                         {
                                                             Bind = item,
                                                             Value = pControl.EditValue
                                                         });
                                                     };
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.EditMemo))
                {
                    var pControl = item.Value as Nampula.UI.EditMemo;
                    pControl.EditValueChanged += (sender, e) =>
                                                     {
                                                         pHandler(sender, new BindChangedValueEventArgs()
                                                         {
                                                             Bind = item,
                                                             Value = pControl.EditValue
                                                         });
                                                     };
                    continue;
                }
                if (item.Value.GetType() == typeof(Nampula.UI.EditDateTime))
                {
                    var pControl = item.Value as Nampula.UI.EditDateTime;
                    pControl.EditValueChanged += (sender, e) =>
                                                     {
                                                         pHandler(sender, new BindChangedValueEventArgs()
                                                                              {
                                                                                  Bind = item,
                                                                                  Value = pControl.EditValue
                                                                              });
                                                     };
                    continue;
                }
            }
        }

        ///// <summary>
        ///// Seta os controles para somente leitura
        ///// </summary>
        ///// <param name="pBinds">Lista de controles</param>
        //public  static void SetReadOnOnly(this Dictionary<string, Control> pBinds)
        //{
        //    //foreach (GridColumn item in ViewItem.Columns)
        //    //    item.OptionsColumn.AllowEdit = false;

        //    foreach (var item in pBinds)
        //    {
        //        if (item.Value.GetType() == typeof(CheckBox))
        //        {
        //            var pControl = item.Value as CheckBox;
        //            pControl.Enabled = false;
        //            continue;
        //        }
        //        if (item.Value.GetType() == typeof(ComboBox))
        //        {
        //            var pControl = item.Value as ComboBox;
        //            pControl.Properties.ReadOnly = true;
        //            continue;
        //        }
        //        if (item.Value.GetType() == typeof(EditText))
        //        {
        //            var pControl = item.Value as EditText;
        //            pControl.Properties.ReadOnly = true;
        //            continue;
        //        }
        //        if (item.Value.GetType() == typeof(EditMemo))
        //        {
        //            var pControl = item.Value as EditMemo;
        //            pControl.Properties.ReadOnly = true;
        //            continue;
        //        }
        //        if (item.Value.GetType() == typeof(EditDateTime))
        //        {
        //            var pControl = item.Value as EditDateTime;
        //            pControl.Properties.ReadOnly = true;
        //            continue;
        //        }
        //    }
        //}
    }
}
