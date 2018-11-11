using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.BusinessPartners {

    public class BusinessPartnerCardGroup : TableAdapter {

        public struct FieldsName {
            public static readonly string GroupCode = "GroupCode";
            public static readonly string GroupName= "GroupName";
            public static readonly string GroupType= "GroupType";
            public static readonly string Locked = "Locked";
        }

        public struct Description {
            public static readonly string GroupCode = "Código";
            public static readonly string GroupName= "Nome";
            public static readonly string GroupType= "Tipo";
            public static readonly string Locked = "Bloqueado";
        }

        TableAdapterField m_GroupCode = new TableAdapterField (FieldsName.GroupCode, Description.GroupCode, DbType.Int32, 10, null, true, true );
        TableAdapterField m_GroupName = new TableAdapterField (FieldsName.GroupName, Description.GroupName, 100 );
        TableAdapterField m_GroupType = new TableAdapterField (FieldsName.GroupType, Description.GroupType, 1 );
        TableAdapterField m_Locked = new TableAdapterField (FieldsName.Locked, Description.Locked, 1 );

        public BusinessPartnerCardGroup ()
            : base ( "OCRG" ) {
        }

        public BusinessPartnerCardGroup ( string pCompanyDb )
            : this ( ) {
            this.DBName = pCompanyDb;
        }

        public int GroupCode {
            get { return m_GroupCode.GetInt32() ;}
            set { m_GroupCode.Value = value; }
        }

        public string GroupName {
            get { return m_GroupName.GetString ( ); }
            set { m_GroupName.Value = value; }
        }

        public eCardType GroupType {
            get { return m_GroupType.GetString ( ).ToEnum(); }
            set { m_GroupType.Value = value.ToStringEnum(); }
        }

        public eYesNo Locked {
            get { return m_Locked.GetString ( ).ToYesNoEnum ( ); }
            set { m_Locked.Value = value.ToYesNoString ( ); }
        }

        public bool GetByKey ( int pGroupCode ) {
            this.GroupCode = pGroupCode;
            return base.GetByKey ( );
        }

    }
}
