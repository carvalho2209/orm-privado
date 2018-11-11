using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Nampula.DI;

namespace Nampula.UI
{

    /// <summary>
    /// Classe para trabalhar com Formulário do SAP
    /// </summary>
    public class FormSystem
    {

        
        /// <summary>
        /// Classse de apoio a escuta de eventos
        /// </summary>
        private class MethodInfoEvent
        {
            public FormSystemEventAttribute Attribute { get; set; }
            public MethodInfo MethodInfo { get; set; }
        }
        

        
        /// <summary>
        /// Construtor padrão
        /// </summary>
        private FormSystem()
        {
            MethodEvents = new List<MethodInfoEvent>();
            Assemlbly = Assembly.GetAssembly(this.GetType());
            SboApp = ApplicationSAP.GetInstance().SAPApp;
        }

        /// <summary>
        /// Instancia uma classe de formulário
        /// </summary>
        /// <param name="pFormID">ID do Formulário que se deseja instanciar</param>
        public FormSystem(int pFormID, int pTypeCode)
            : this()
        {
            this.FormBind = SboApp.Forms.GetFormByTypeAndCount(pFormID, pTypeCode) as SAPbouiCOM.Form;
            this.Type = pFormID;
            GetEvents();
        }

        /// <summary>
        /// Instancia uma classe de formulário
        /// </summary>
        /// <param name="pFormID">ID do Formulário que se deseja instanciar</param>
        public FormSystem(int pFormType)
            : this()
        {
            this.Type = pFormType;
        }
        

        /// <summary>
        /// Formulário Customizado
        /// </summary>
        /// <param name="pType"></param>
        public FormSystem(SAPbouiCOM.BoFormBorderStyle pBorderStyle)
            : this()
        {
            var creationPackage = SboApp.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_FormCreationParams)
                as SAPbouiCOM.FormCreationParams;

            creationPackage.UniqueID = this.GetHashCode().ToString();
            creationPackage.FormType = string.Format("{0}_{1}",
                Application.GetInstance().NameSpace, this.GetType().Name);
            creationPackage.BorderStyle = pBorderStyle;

            FormBind = SboApp.Forms.AddEx(creationPackage) as SAPbouiCOM.Form;
            GetEvents();
            FormSystemManager.Instance().AddFormOpen(this);
        }
        
        /// <summary>
        /// Captura todos os eventos da classe 
        /// e adiciona escuta para os objetos do SAP
        /// e pega o formulário do SAP
        /// </summary>
        internal void GetEvents()
        {
            foreach (var method in this.GetType().GetMethods())
            {
                foreach (var item in Attribute.GetCustomAttributes(method))
                {
                    if (item is FormSystemEventAttribute)
                    {

                        if (method.GetParameters().Length != 2 ||
                            method.GetParameters()[0].ParameterType != typeof(ItemEvent) ||
                            method.GetParameters()[1].ParameterType != typeof(Boolean)
                            )
                        {
                            throw new Exception("Os métodos que escutam eventos do SAP devem ser 2 parametros (  EventArItemEvent , bool )");
                        }

                        var customAtributte = item as FormSystemEventAttribute;

                        MethodEvents.Add(new MethodInfoEvent
                        {
                            Attribute = customAtributte,
                            MethodInfo = method,
                        });
                    }
                }
            }
        }
        

        
        public Assembly Assemlbly { get; set; }
        private List<MethodInfoEvent> MethodEvents { get; set; }

        private SAPbouiCOM.Form m_FormBind;
        public SAPbouiCOM.Form FormBind
        {
            get { return m_FormBind; }
            set
            {
                Type = value.Type;
                TypeEx = value.TypeEx;
                TypeCount = value.TypeCount;
                m_FormBind = value;
            }
        }

        protected SAPbouiCOM.Application SboApp { get; set; }
        public bool NeverRemove { get; set; }
        public int Type { get; set; }
        public string TypeEx { get; set; }
        public int TypeCount { get; set; }
        

        
        /// <summary>
        /// Faz um evento ser disparado
        /// </summary>
        /// <param name="pVal">Argumentos do Eventos que está sendo disparado</param>
        /// <param name="BubbleEvent">Caso queira parar o evento set false, true o evento continua</param>
        internal void DoEvent(ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            var eventType = pVal.ToItemEvent();
            DoEvent(eventType, out BubbleEvent);
        }

        /// <summary>
        /// Faz um evento ser disparado
        /// </summary>
        /// <param name="pVal1">Argumentos do Eventos que está sendo disparado</param>
        /// <param name="BubbleEvent">Caso queira parar o evento set false, true o evento continua</param>
        internal void DoEvent(Nampula.UI.ItemEvent pVal1, out bool BubbleEvent)
        {
            BubbleEvent = true;

            var methodInfo = MethodEvents.FindAll(
                p => p.Attribute.EventType == pVal1.EventType &
                    p.Attribute.ItemID == pVal1.ItemUID &
                    p.Attribute.BeforeAction == pVal1.BeforeAction);

            var parameters = new Object[] { pVal1, BubbleEvent };
            foreach (var methodInfoEvent in methodInfo)
            {                
                methodInfoEvent.MethodInfo.Invoke(this, parameters);
                
                if(!Convert.ToBoolean(parameters[1]))
                {
                    BubbleEvent = false;
                    break;
                }
            }

            //throw new NotImplementedException( );
        }
        

        
        /// <summary>
        /// Adiciona um novo item ao formulário
        /// </summary>
        /// <param name="ItemUID">ID do Item</param>
        /// <param name="pItemType">Tipo do Item</param>
        /// <returns>Um novo item</returns>
        public SAPbouiCOM.Item AddItem(string ItemUID, SAPbouiCOM.BoFormItemTypes pItemType)
        {
            return FormBind.Items.Add(ItemUID, pItemType);
        }
        

        
        /// <summary>
        /// Pega um item existente no formulário
        /// </summary>
        /// <param name="ItemUID">ID do Item</param>
        /// <returns>O objeto do item passado</returns>
        public SAPbouiCOM.Item GetItem(string ItemUID)
        {
            return FormBind.Items.Item(ItemUID);
        }
        

        public void ShowMessageError(Exception ex)
        {
            SboApp.SetStatusBarMessage(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
        }

        public void Show()
        {
            this.FormBind.Visible = true;
        }

        public void ShowSystemModel()
        {
            Show();
            FormSystemManager.Instance().FormSystemModal = this;
        }

        internal void Select()
        {
            FormBind.Select();
        }

        internal void SetFormBind(SAPbouiCOM.Form formClass)
        {
            this.FormBind = formClass;
        }
    }

}
