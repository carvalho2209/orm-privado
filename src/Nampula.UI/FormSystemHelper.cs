using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.Framework;

namespace Nampula.UI
{
    /// <summary>
    /// Classe que gerencia as classe de FormSystem
    /// </summary>
    public class FormSystemManager
    {

        /// <summary>
        /// Construtor padrão
        /// </summary>
        private FormSystemManager()
        {
            AppSAP = ApplicationSAP.GetInstance().SAPApp;
            Forms = new List<FormSystem>();
            FormOpens = new List<FormSystem>();
            AppSAP.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SAPApp_ItemEvent);
            AppSAP.MenuEvent += new SAPbouiCOM._IApplicationEvents_MenuEventEventHandler(AppSAP_MenuEvent);
            AppSAP.FormDataEvent += new SAPbouiCOM._IApplicationEvents_FormDataEventEventHandler(AppSAP_FormDataEvent);
        }

        /// <summary>
        /// Pega a insancia da classe
        /// </summary>
        /// <returns>uma instancia da classe FormSytemManager</returns>
        public static FormSystemManager Instance()
        {
            return Singleton<FormSystemManager>.Instance;
        }


        /// <summary>
        /// Lista de Formulários que devem ser ouvidos
        /// </summary>
        private List<FormSystem> Forms { get; set; }
        /// <summary>
        /// Lista de Fromulários que vem estão abertos
        /// </summary>
        private List<FormSystem> FormOpens { get; set; }
        /// <summary>
        /// Objeto Application do SAP
        /// </summary>
        private SAPbouiCOM.Application AppSAP { get; set; }
        /// <summary>
        /// Permite eventos somente desse formulário Formulário
        /// </summary>
        public FormSystem FormSystemModal { get; set; }



        /// <summary>
        /// Adicionar uma Formulário de Sistema a lista de formulário ouvintes
        /// </summary>
        /// <param name="pForm">Um Formulário</param>
        public void AddFormWath(FormSystem pForm)
        {
            //if ( pForm.FormBind == null )
            //{
            //    if ( !Forms.Exists(
            //        p => ( p.FormType == pForm.FormType ) ) )
            //        Forms.Add( pForm );
            //}
            //else if ( !Forms.Exists(
            //    p => ( p.FormBind.TypeEx == pForm.FormBind.TypeEx || p.FormBind.Type == p.FormBind.Type ) ) )
            //{
            Forms.Add(pForm);
            //}
        }



        /// <summary>
        /// Adicionar uma Formulário de Sistema a lista de formulário já abertos
        /// </summary>
        /// <param name="pForm">Um Formulário</param>
        public void AddFormOpen(FormSystem pForm)
        {
            FormOpens.Add(pForm);
        }


        void AppSAP_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo businessObjectInfo, out bool bubbleEvent)
        {
            bubbleEvent = true;

            var formUID = businessObjectInfo.FormUID;

            var formOpen = FormOpens.FirstOrDefault(c => c.FormBind.UniqueID == formUID);

            if (formOpen != null)
            {
                try
                {
                    var item = businessObjectInfo.ToBusinessObjectInfo();
                    formOpen.DoEvent(item, out bubbleEvent);
                }
                catch (Exception ex)
                {
                    bubbleEvent = false;
                    Application.GetInstance().SetTextOnStatusBar(ex.InnerException.Message, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
                }

            }
        }


        /// <summary>
        /// Método que é excutado quando evento do SAP é disparado
        /// </summary>
        /// <param name="FormUID">ID do Formuário</param>
        /// <param name="pVal">Argumentos do Evento</param>
        /// <param name="BubbleEvent">Propagar a continuação desse evento</param>
        void SAPApp_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                var formType = pVal.FormType;
                var formTypeEx = pVal.FormTypeEx;
                var formTypeCount = pVal.FormTypeCount;

                if (FormSystemModal != null)
                {
                    if ((pVal.FormType != FormSystemModal.Type
                        || pVal.FormTypeEx != FormSystemModal.TypeEx))
                    {
                        FormSystemModal.Select();
                        BubbleEvent = false;
                        return;
                    }
                }

                if (formType != 0 && pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_LOAD && pVal.Before_Action)
                {
                    var form = Forms.FirstOrDefault(f => (f.Type == formType));
                    if (form != null)
                    {
                        var newForm = form.Assemlbly.CreateInstance(form.ToString()) as FormSystem;
                        newForm.SetFormBind(ApplicationSAP.GetInstance().SAPApp.Forms.GetFormByTypeAndCount(formType, formTypeCount) as SAPbouiCOM.Form);
                        newForm.GetEvents();
                        FormOpens.Add(newForm);
                    }
                }

                var formOpen = FormOpens.FirstOrDefault(
                    f => ((f.Type == formType || f.TypeEx == formTypeEx) && f.TypeCount == formTypeCount));

                if (formOpen == null)
                    formOpen = FormOpens.FirstOrDefault(f => (f.Type == formType && f.NeverRemove));

                if (formOpen != null)
                {
                    try
                    {
                        formOpen.DoEvent(ref pVal, out BubbleEvent);
                    }
                    catch (Exception ex)
                    {
                        BubbleEvent = false;
                        Application.GetInstance().SetTextOnStatusBar(ex.Message, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
                    }

                    if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD && !formOpen.NeverRemove)
                    {
                        FormOpens.Remove(formOpen);
                        FormSystemModal = null;
                    }

                }
            }
            catch (Exception ex)
            {
                Application.GetInstance().SetTextOnStatusBar(ex.Message, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
            }
        }



        /// <summary>
        /// Isso é feio mas vou corrigir quando tiver tempo viu !
        /// </summary>
        public static bool pBubbleEvent = true;

        void AppSAP_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            try
            {
                if (!pBubbleEvent)
                {
                    BubbleEvent = false;
                    pBubbleEvent = true;
                    return;
                }

                BubbleEvent = true;


                if (FormSystemModal != null)
                {
                    FormSystemModal.Select();
                    BubbleEvent = false;
                    return;
                }

                ///Tenho sempre de qualquer forma atribuir um valor a esse bloco
                ///Isso é feio demais!!!
                // BubbleEvent = BubbleEvent ? true : false;

                SAPbouiCOM.Form form = null;

                try
                {
                    form = AppSAP.Forms.ActiveForm;
                }
                catch { }

                if (form != null)
                {
                    var formType = form.Type;
                    var formTypeEx = form.TypeEx;
                    var formcount = form.TypeCount;
                    var formOpen = FormOpens.FirstOrDefault(
                        f => ((f.Type == formType || f.TypeEx == formTypeEx) && f.TypeCount == formcount));
                    if (formOpen != null)
                    {
                        try
                        {
                            ItemEvent item = new ItemEvent()
                            {
                                EventType = BoEventTypes.et_MENU_CLICK,
                                ItemUID = pVal.MenuUID,
                                BeforeAction = pVal.BeforeAction,
                            };

                            formOpen.DoEvent(item, out BubbleEvent);
                        }
                        catch (Exception ex)
                        {
                            BubbleEvent = false;
                            Application.GetInstance().SetTextOnStatusBar(ex.Message, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                BubbleEvent = false;
                Application.GetInstance().SetTextOnStatusBar(ex.Message, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
            }
        }


    }
}
