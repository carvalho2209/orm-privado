using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nampula.Framework;

namespace Nampula.DI.B1.UserPermissions
{
    /// <summary>
    /// Classe para gerenciamento da tabela do SAP : OUTP 
    /// </summary>
    public class UserAutorizationTree : TableAdapter
    {



        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OUPT";
        }



        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string AbsID = "AbsID";
            public static readonly string Name = "Name";
            public static readonly string Options = "Options";
            public static readonly string FathID = "FathID";
            public static readonly string VisOrder = "VisOrder";
            public static readonly string Levels = "Levels";
            public static readonly string IsItem = "IsItem";
            public static readonly string Action = "Action";
        }



        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string AbsID = "ID";
            public static readonly string Name = "Nome";
            public static readonly string Options = "Opções";
            public static readonly string FathID = "Superior ID";
            public static readonly string VisOrder = "Orderm";
            public static readonly string Levels = "Nivel";
            public static readonly string IsItem = "É item";
            public static readonly string Action = "Ação";
        }




        TableAdapterField m_AbsID = new TableAdapterField(FieldsName.AbsID, FieldsDescription.AbsID, DbType.String, 20, 0, true, false);
        TableAdapterField m_Name = new TableAdapterField(FieldsName.Name, FieldsDescription.Name, 40);
        TableAdapterField m_Options = new TableAdapterField(FieldsName.Options, FieldsDescription.Options, DbType.Int32);
        TableAdapterField m_FathID = new TableAdapterField(FieldsName.FathID, FieldsDescription.FathID, 20);
        TableAdapterField m_Levels = new TableAdapterField(FieldsName.Levels, FieldsDescription.Levels, DbType.Int32);
        TableAdapterField m_VisOrder = new TableAdapterField(FieldsName.VisOrder, FieldsDescription.VisOrder, DbType.Int32);
        TableAdapterField m_IsItem = new TableAdapterField(FieldsName.IsItem, FieldsDescription.IsItem, 1);
        TableAdapterField m_Action = new TableAdapterField(FieldsName.Action, FieldsDescription.Action, DbType.Int32);







        public UserAutorizationTree()
            : base(Definition.TableName)
        {
            Children = new List<UserAutorizationTree>();

            this.Options = OptionsType.FullNone;
        }

        public UserAutorizationTree(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public UserAutorizationTree(UserAutorizationTree pUserAutorizationTree)
            : this()
        {
            this.CopyBy(pUserAutorizationTree);
        }





        public string AbsID
        {
            get { return m_AbsID.GetString(); }
            set { m_AbsID.Value = value; }
        }

        public string Name
        {
            get { return m_Name.GetString(); }
            set { m_Name.Value = value; }
        }

        public OptionsType Options
        {
            get { return (OptionsType)m_Options.GetInt32(); }
            set { m_Options.Value = value.To<Int32>(); }
        }

        public string FathID
        {
            get { return m_FathID.GetString(); }
            set { m_FathID.Value = value; }
        }

        public int VisOrder
        {
            get { return m_VisOrder.GetInt32(); }
            set { m_VisOrder.Value = value; }
        }

        public int Levels
        {
            get { return m_Levels.GetInt32(); }
            set { m_Levels.Value = value; }
        }

        public eYesNo IsItem
        {
            get { return m_IsItem.GetString().ToYesNoEnum(); }
            set { m_IsItem.Value = value.ToYesNoString(); }
        }

        public int Action
        {
            get { return m_Action.GetInt32(); }
            set { m_Action.Value = value; }
        }

        /// <summary>
        /// Lista de autorizações filhas
        /// </summary>
        public List<UserAutorizationTree> Children { get; set; }




        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }


        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(string pAbsID)
        {
            this.AbsID = pAbsID;
            return GetByKey();
        }



        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de UserAutorizationTree.</returns>
        public List<UserAutorizationTree> GetAll()
        {
            return FillCollection<UserAutorizationTree>(this.GetData().Rows);
        }



    }
}
