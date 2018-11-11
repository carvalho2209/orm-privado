using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Documents
{

    /// <summary>
    /// Tabela de DocumentModel
    /// </summary>
    public class DocumentModel : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "ONFM";
        }

        public struct FieldsName
        {
            public static readonly string AbsEntry = "AbsEntry";
            public static readonly string NfmName = "NfmName";
            public static readonly string NfmDescrip = "NfmDescrip";
            public static readonly string UserSign = "UserSign";
            public static readonly string UserSign2 = "UserSign2";
            public static readonly string UpdateDate = "UpdateDate";
            public static readonly string NfmCode = "NfmCode";

        }

        public struct FieldsDescription
        {
            public static readonly string AbsEntry = "Nº";
            public static readonly string NfmName = "Nome";
            public static readonly string NfmDescrip = "Descrição";
            public static readonly string UserSign = "Usuário";
            public static readonly string UserSign2 = "Usuário 2";
            public static readonly string UpdateDate = "Date Atualização";
            public static readonly string NfmCode = "Código";
        }

        TableAdapterField m_AbsEntry = new TableAdapterField(FieldsName.AbsEntry, FieldsDescription.AbsEntry, DbType.String, 6, null, true, true);
        TableAdapterField m_NfmName = new TableAdapterField(FieldsName.NfmName, FieldsDescription.NfmName, 20);
        TableAdapterField m_NfmDescrip = new TableAdapterField(FieldsName.NfmDescrip, FieldsDescription.NfmDescrip, 100);
        TableAdapterField m_UserSign = new TableAdapterField(FieldsName.UserSign, FieldsDescription.UserSign, DbType.Int32);
        TableAdapterField m_UserSign2 = new TableAdapterField(FieldsName.UserSign2, FieldsDescription.UserSign2, DbType.Int32);
        TableAdapterField m_UpdateDate = new TableAdapterField(FieldsName.UpdateDate, FieldsDescription.UpdateDate, DbType.DateTime);
        TableAdapterField m_NfmCode = new TableAdapterField(FieldsName.NfmCode, FieldsDescription.NfmCode, 10);


        public DocumentModel()
            : base(Definition.TableName)
        {
        }

        public DocumentModel(string companyDb)
            : base(companyDb, Definition.TableName)
        {
        }

        public DocumentModel(DocumentModel pDocumentModel)
            : this()
        {
            this.CopyBy(pDocumentModel);
        }

        public int AbsEntry
        {
            get { return m_AbsEntry.GetInt32(); }
            set { m_AbsEntry.Value = value; }
        }

        public String NfmName
        {
            get { return m_NfmName.GetString(); }
            set { m_NfmName.Value = value; }
        }

        public String NfmDescrip
        {
            get { return m_NfmDescrip.GetString(); }
            set { m_NfmDescrip.Value = value; }
        }

        public Int32 UserSign
        {
            get { return m_UserSign.GetInt32(); }
            set { m_UserSign.Value = value; }
        }

        public Int32 UserSign2
        {
            get { return m_UserSign2.GetInt32(); }
            set { m_UserSign2.Value = value; }
        }

        public DateTime UpdateDate
        {
            get { return m_UpdateDate.GetDateTime(); }
            set { m_UpdateDate.Value = value; }
        }

        public String NfmCode
        {
            get { return m_NfmCode.GetString(); }
            set { m_NfmCode.Value = value; }
        }

        public List<DocumentModel> GetAll()
        {
            return FillCollection<DocumentModel>(GetData().Rows);
        }

        public bool GetByKey(int absEntry)
        {
            this.AbsEntry = absEntry;
            return GetByKey();
        }
    }
}
