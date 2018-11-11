using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.UI {

    public class FormMain : System.Windows.Forms.Form {

        public MenuEventsListing MenuEventsList = new MenuEventsListing();
        //public ItemEventsListing ItemEventList = new ItemEventsListing();

        public event MenuEventsListing.OnAfterLoadEventHandler OnReseiveMenuEvent;
        //public event ItemEventsListing.OnAfterLoadEventHandler OnReseiveItemEvent;

        public FormMain(eAppType AppType) {

            switch (AppType) {
                case eAppType.Nothing:
                    break;
                case eAppType.WinForms:
                    InitializeWindowsForms();
                    break;
                case eAppType.SAPForms:
                    InitializeClassSAP();
                    break;
                default:
                    break;
            }

        }

        private void InitializeWindowsForms() {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Top = 0;
            this.Left = 0;
            this.Width = 0;
            this.Height = 0;
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void InitializeClassSAP() {

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Top = 0;
            this.Left = 0;
            this.Width = 0;
            this.Height = 0;

            this.Visible = false;
            this.ShowInTaskbar = false;

            this.MenuEventsList.OnReceiveEvent += new MenuEventsListing.OnAfterLoadEventHandler(EventsLis_ChegouEvento);
            ///this.ItemEventList.OnReceiveEvent += new ItemEventsListing.OnAfterLoadEventHandler(m_ItemEventList_OnReceiveEvent);

        }

        //void m_ItemEventList_OnReceiveEvent(ItemEvent pEvent) {
        //    if (OnReseiveItemEvent != null) {
        //        OnReseiveItemEvent(pEvent);
        //    }
        //}

        void EventsLis_ChegouEvento(MenuEvent pEvent) {
            if (OnReseiveMenuEvent != null) {
                OnReseiveMenuEvent(pEvent);
            }
        }

        protected override void OnShown(EventArgs e) {
            this.Visible = false;
            base.OnShown(e);
        }


    }

}
