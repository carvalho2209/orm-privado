using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace Nampula.DI
{

    /// <summary>
    /// Classe para gerenciamento das colunas das classe de TableAdapters e StoredProcedures
    /// </summary>
    internal class TableAdapterColumns
    {        
        /// <summary>
        /// Pega as colunas de um objeto DataObjec
        /// </summary>
        /// <param name="pObject">Um Objeto</param>
        /// <returns>Uma lista de campis</returns>
        public static TableAdapterFieldCollection GetCollumns(DataObject pObject)
        {
            var fields = new TableAdapterFieldCollection();

            foreach (var property in GetFields(pObject.GetType()))
            {
                var prop = property.GetValue(pObject) as TableAdapterField;
                
                if (prop == null)
                    continue;
                prop.TableAdapter = pObject as TableAdapter;
                fields.Add(prop);
            }

            return fields;
        }

        /// <summary>
        /// Pega as informações de propriedades dos campos
        /// </summary>
        /// <param name="pObject">Um Objeto</param>
        /// <returns>Uma lista de variáveis locais</returns>
        private static IEnumerable<FieldInfo> GetFields(Type pObject)
        {
            var listInfo = new List<FieldInfo>();

            if ((pObject.BaseType.Name != "TableAdapter" & pObject.Name != "TableAdapter") && (pObject.BaseType.Name != "StoredProcedure" & pObject.Name != "StoredProcedure"))
                listInfo.AddRange(GetFields(pObject.BaseType));

            listInfo.AddRange(pObject.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public));

            return listInfo;
        }

    }
}
