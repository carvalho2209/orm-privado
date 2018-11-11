using System;

namespace Nampula.DI
{

    /// <summary>
    /// Procedure que traz o conteúdo de uma procedure no banco de dados
    /// </summary>
    public class sp_HelpText : StoredProcedure
    {

        public struct FieldsName
        {
            public static readonly string ObjName = "objname";
        }

        public struct FieldsNameResult
        {
            public static readonly string Text = "Text";
        }

        public struct Description
        {
            public static readonly string ObjName = "Nome do objeto no banco";
        }

        public struct Defintion
        {
            public static readonly string Name = "sp_HelpText";
        }

        readonly TableAdapterField m_ObjName = new TableAdapterField(FieldsName.ObjName, Description.ObjName, 256);

        public sp_HelpText()
            : base(Defintion.Name)
        {
        }

        public string ObjName
        {
            get { return m_ObjName.GetString(); }
            set { m_ObjName.Value = value; }
        }

        /// <summary>
        /// Nome do Banco de dados
        /// </summary>
        public string DbName { get; set; }

        public override bool Execute(bool withResult = true)
        {
            var pCurrentDb = Connection.ConnectionParameter.Database;

            try
            {
                if (String.IsNullOrEmpty(DbName))
                    throw new ArgumentNullException("DbName");

                Connection.ConnectionParameter.Database = DbName;

                return base.Execute(withResult);
            }
            finally
            {
                Connection.ConnectionParameter.Database = pCurrentDb;
            }
        }


    }

}
