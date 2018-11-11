using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Nampula.DI;
using Nampula.Framework;

namespace Nampula.UI
{

    internal class DICompany : IDisposable
    {

        private object m_Company;
        private Type m_ComanyType;

        internal DICompany()
        {
            m_ComanyType = Type.GetTypeFromProgID("SAPbobsCOM.Company");
            m_Company = Activator.CreateInstance(m_ComanyType);
            //this.XmlExportType = 3;
            //this.XMLAsString = false;
        }

        internal string GetContextCookie()
        {
            object mreturn = m_Company.GetType().InvokeMember("GetContextCookie",
                BindingFlags.InvokeMethod,
                null,
                m_Company,
                new Object[0],
                System.Globalization.CultureInfo.CurrentCulture);

            return mreturn.ToString();
        }

        internal int SetSboLoginContext(string conStr)
        {
            object mreturn = m_Company.GetType().InvokeMember("SetSboLoginContext",
                BindingFlags.InvokeMethod,
                null,
                m_Company,
                new Object[1] { conStr },
                System.Globalization.CultureInfo.CurrentCulture);
            return Convert.ToInt16(mreturn);
        }

        internal string GetLastErrorDescription()
        {
            object mreturn = m_Company.GetType().InvokeMember("GetLastErrorDescription",
                BindingFlags.InvokeMethod,
                null,
                m_Company,
                new Object[0],
                System.Globalization.CultureInfo.CurrentCulture);
            return mreturn.ToString();
        }

        internal string GetLastErrorCode()
        {
            object mreturn = m_Company.GetType().InvokeMember("GetLastErrorCode",
                BindingFlags.InvokeMethod,
                null,
                m_Company,
                new Object[0],
                System.Globalization.CultureInfo.CurrentCulture);
            return mreturn.ToString();
        }

        internal string AddonIdentifier
        {
            get
            {
                object mreturn = m_Company.GetType().InvokeMember("AddonIdentifier",
                      BindingFlags.GetProperty,
                      null,
                      m_Company,
                      new Object[0],
                      System.Globalization.CultureInfo.CurrentCulture);
                return mreturn.ToString();
            }
            set
            {
                object mreturn = m_Company.GetType().InvokeMember("AddonIdentifier",
                      BindingFlags.SetProperty,
                      null,
                      m_Company,
                      new Object[1] { value },
                      System.Globalization.CultureInfo.CurrentCulture);
            }
        }

        internal string CompanyDB
        {
            get
            {
                object mreturn = m_Company.GetType().InvokeMember("CompanyDB",
                      BindingFlags.GetProperty,
                      null,
                      m_Company,
                      new Object[0],
                      System.Globalization.CultureInfo.CurrentCulture);
                return mreturn.ToString();
            }
            set
            {
                object mreturn = m_Company.GetType().InvokeMember("CompanyDB",
                      BindingFlags.SetProperty,
                      null,
                      m_Company,
                      new Object[1] { value },
                      System.Globalization.CultureInfo.CurrentCulture);
            }
        }

        internal int Connect()
        {
            object mreturn = m_Company.GetType().InvokeMember("Connect",
                BindingFlags.InvokeMethod,
                null,
                m_Company,
                new Object[0],
                System.Globalization.CultureInfo.CurrentCulture);

            return mreturn.To<Int32>();
        }

        internal void Disconnect()
        {
            object mreturn = m_Company.GetType().InvokeMember("Disconnect",
                BindingFlags.InvokeMethod,
                null,
                m_Company,
                new Object[0],
                System.Globalization.CultureInfo.CurrentCulture);
        }

        //private MethodInfo GetMethod(string pName)
        //{
        //    //            m_Company.GetType().InvokeMember(pName, BindingFlags.SuppressChangeType, BindingFlags.GetProperty, m_Company, null);
        //    Object[] mObj = new Object[0];
        //    object mreturn = m_Company.GetType().InvokeMember(pName, BindingFlags.InvokeMethod, null, m_Company, mObj, System.Globalization.CultureInfo.CurrentCulture);
        //    return m_ComanyType.GetMethod(pName, BindingFlags.Public);
        //}

        public object GetConcrete()
        {
            return m_Company;
        }

        public string Server
        {
            get
            {
                return GetProperty("Server").ToString();
            }
            set
            {
                SetProperty("Server", value);
            }
        }



        private object GetProperty(string pName)
        {
            var mReturn = m_Company.GetType().InvokeMember(pName,
                BindingFlags.GetProperty,
                null,
                m_Company,
                new Object[0],
                System.Globalization.CultureInfo.CurrentCulture);
            return mReturn;
        }

        private object SetProperty(string pName, object pValue)
        {
            object mReturn = m_Company.GetType().InvokeMember(pName,
                  BindingFlags.SetProperty,
                  null,
                  m_Company,
                  new Object[1] { pValue },
                  System.Globalization.CultureInfo.CurrentCulture);
            return mReturn;
        }



        public string UserName
        {
            get
            {
                return GetProperty("UserName").ToString();
            }
            set
            {
                SetProperty("UserName", value);
            }
        }

        public string Password
        {
            get
            {
                return GetProperty("Password").ToString();
            }
            set
            {
                SetProperty("Password", value);
            }
        }

        public BoLanguages language
        {
            get
            {
                return (BoLanguages)(GetProperty("language").To<Int32>());
            }
            set
            {
                SetProperty("language", value.To<Int32>());
            }
        }

        public bool UseTrusted
        {
            get
            {
                return Convert.ToBoolean(GetProperty("UseTrusted"));
            }
            set
            {
                SetProperty("UseTrusted", Convert.ToByte(value));
            }
        }

        public string LicenseServer
        {
            get
            {
                return GetProperty("LicenseServer").ToString();
            }
            set
            {
                SetProperty("LicenseServer", value);
            }
        }

        public eDataServerType DbServerType
        {
            get
            {
                return (eDataServerType)GetProperty("DbServerType").To<Int32>();
            }
            set
            {
                SetProperty("DbServerType", value.To<Int32>());
            }
        }

        public string DbUserName
        {
            get
            {
                return GetProperty("DbUserName").ToString();
            }
            set
            {
                SetProperty("DbUserName", value);
            }
        }

        public string DbPassword
        {
            get
            {
                return GetProperty("DbPassword").ToString();
            }
            set
            {
                SetProperty("DbPassword", value);
            }
        }

        public int XmlExportType
        {
            get
            {
                return Convert.ToInt16(GetProperty("XmlExportType"));
            }
            set
            {
                SetProperty("XmlExportType", (int)value);
            }
        }

        public bool XMLAsString
        {
            get
            {
                return Convert.ToBoolean(GetProperty("XMLAsString"));
            }
            set
            {
                SetProperty("XMLAsString", (Boolean)value);
            }
        }




        public void Dispose()
        {
            if (m_Company != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_Company);
        }

        ~DICompany()
        {
            this.Dispose();
        }




        internal object GetBusinessObject(int pObjectID)
        {
            object mreturn = m_Company.GetType().InvokeMember("GetBusinessObject",
                BindingFlags.InvokeMethod,
                null,
                m_Company,
                new Object[1] { pObjectID },
                System.Globalization.CultureInfo.CurrentCulture);

            return mreturn;
        }

        internal object GetBusinessObjectFromXML(string pFileName, int p)
        {
            object myReturn = m_Company.GetType().InvokeMember("GetBusinessObjectFromXML",
                BindingFlags.InvokeMethod,
                null,
                m_Company,
                new Object[2] { pFileName, p },
                System.Globalization.CultureInfo.CurrentCulture);

            return myReturn;
        }
    }
}
