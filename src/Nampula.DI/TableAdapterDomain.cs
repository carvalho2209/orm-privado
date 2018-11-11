using System;
using System.Linq;
using System.Data;
using Nampula.Framework;

namespace Nampula.DI
{

    /// <summary>
    /// Classe base para uma tabela de domninio
    /// </summary>
    /// <typeparam name="T">Deve ser um enum</typeparam>
    [Serializable]
    public abstract class TableAdapterDomain<T> : TableAdapter
    {
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string ID = "ID";
            public static readonly string Description = "Description";
        }
        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string ID = "Código";
            public static readonly string Description = "Descrição";
        }

        readonly TableAdapterField m_ID = new TableAdapterField(FieldsName.ID, FieldsDescription.ID, DbType.Int32, 11, 0, true, false);
        readonly TableAdapterField m_Description = new TableAdapterField(FieldsName.Description, FieldsDescription.Description, 200);

        protected TableAdapterDomain(string pTableName)
            : base(pTableName)
        {
            InicialValue = true;
        }

        /// <summary>
        /// Id do Registro
        /// </summary>
        public T ID
        {
            get { return (T)m_ID.Value; }
            set { m_ID.Value = value.To<Int32>(); }
        }

        /// <summary>
        /// Descrição do Registro
        /// </summary>
        public string Description
        {
            get { return m_Description.GetString(); }
            set { m_Description.Value = value; }
        }
        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pId">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(T pId)
        {
            ID = pId;
            return GetByKey();
        }
        

        
        /// <summary>
        /// Pega todos os registro que tem na tabela ordenado por código
        /// </summary>
        /// <returns></returns>
        protected DataRowCollection GetAllOrder()
        {
            var tableQuery = new TableQuery(this);

            tableQuery.OrderBy.Add(
                new OrderBy(
                    new QueryParam(m_ID), eOrder.eoASC));

            return GetData(tableQuery).Rows;
        }


        /// <summary>
        /// Inseire/Atualiza/Remove os registros da tabela verificando as diferenças entre o enum e  o
        /// banco de dados
        /// </summary>
        public new void UpdateValues()
        {
            RaiseBeforeLoadValues();

            var dblist = from obj in GetData().AsEnumerable()
                         select new
                         {
                             ID = obj.Field<Int32>(KeyFields.First().Name),
                             Description = obj.Field<string>(FieldsName.Description)
                         };

            var newList = InicialValues
                .Where(c => dblist.All(d => d.ID != c.Collumns[FieldsName.ID].GetInt32()))
                .ToList();

            newList.SetState(eState.eAdd);

            var upList = InicialValues
                .Where( c => newList.All(p => c.Collumns[FieldsName.ID].GetInt32() != p.Collumns[FieldsName.ID].GetInt32()) 
                    && dblist.All(d => d.Description != c.Collumns[FieldsName.Description].GetString())).ToList();

            upList.SetState(eState.eUpdate);
            newList.AddRange(upList);
            
            SaveLines(newList);

            RaiseAfterLoadValues();

        }
        

    }
}

