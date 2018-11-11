using Nampula.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NampulaDemo.DI
{

    /// <summary>
    /// Tabela de Gender
    /// </summary>
    public class Gender : TableAdapterDomain<GenderEnum>
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "Gender";
        }

       

        public Gender()
            : base(Definition.TableName)
        {
            this.OnBeforeLoadValues += Gender_OnBeforeLoadValues;
        }

        void Gender_OnBeforeLoadValues(object Sender, TableAdapterEventArgs e)
        {
            this.InicialValues = new List<TableAdapter>() {
                new Gender(){ID = GenderEnum.Male, Description = "Masculino"},
                new Gender(){ID = GenderEnum.Female, Description = "Feminino"}
            };
        }

        public Gender(Gender pGender)
            : this()
        {
            this.CopyBy(pGender);
        }

       
    }

    public enum GenderEnum
    {
        Male,
        Female
    }
}
