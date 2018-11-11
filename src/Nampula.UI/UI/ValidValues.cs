using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.UI
{

    /// <summary>
    /// Classe responsável por mantes uma lista de valores válidos
    /// </summary>
    public class ValidValues
    {
        
        ValidValuesCollection valuesCollection = new ValidValuesCollection();
        

        internal event CollectionEventHandler OnAdd;
        internal event CollectionEventHandler OnRemove;
        internal event CollectionEventHandler OnClear;

        internal ValidValues()
        {
            valuesCollection.OnAdd += new CollectionEventHandler(valuesCollection_OnAdd);
            valuesCollection.OnRemove += new CollectionEventHandler(valuesCollection_OnRemove);
            valuesCollection.OnClear += new CollectionEventHandler(valuesCollection_OnClear);
        }

        void valuesCollection_OnClear(object sender, ManagerCollectionEventHargs<ValidValue> e)
        {
            if (OnClear != null)
                OnClear(this, e);
        }

        void valuesCollection_OnRemove(object sender, ManagerCollectionEventHargs<ValidValue> e)
        {
            if (OnRemove != null)
                OnRemove(this, e);
        }

        void valuesCollection_OnAdd(object sender, ManagerCollectionEventHargs<ValidValue> e)
        {
            if (OnAdd != null)
                OnAdd(this, e);
        }

        /// <summary>
        /// Quantidad de itens na coleção
        /// </summary>
        public int Count
        {
            get { return valuesCollection.Count; }
        }

        /// <summary>
        /// Adiciona um novo elemento a coleção
        /// </summary>
        /// <param name="Value">Chave</param>
        /// <param name="Description">Descrição</param>
        /// <returns>O novo item que foi adicionado</returns>
        public ValidValue Add(object Value, string Description)
        {
            var value = new ValidValue(Value, Description);
            valuesCollection.Add(value);
            return value;
        }

        /// <summary>
        /// Pego o item pelo indice da coleção
        /// </summary>
        /// <param name="Index">Indice da coleção</param>
        /// <returns>Retorna o valor da colecão</returns>
        public ValidValue Item(int Index)
        {
            return valuesCollection[Index];
        }

        /// <summary>
        /// Remove um elemento da coleção
        /// </summary>
        /// <param name="Index">Chave ou Indice</param>
        /// <param name="pSearchKey">Método de pesquisa da chave</param>
        public void Remove(object Index, BoSearchKey SearchKey)
        {
            valuesCollection.RemoveAt(GetIndex(Index, SearchKey));
        }

        /// <summary>
        /// Pega o íncido do elemento da coleção
        /// </summary>
        /// <param name="pIndex">Indice ou chave</param>
        /// <param name="pSearchKey">Método de pesquisa da chave</param>
        /// <returns>Um inteiro contendo o indice da coleção</returns>
        public int GetIndex(object pIndex, BoSearchKey pSearchKey)
        {
            var index = -1;

            switch (pSearchKey)
            {
                case BoSearchKey.psk_ByValue:

                    var value = valuesCollection.FirstOrDefault(
                            c => c.Value.ToString() == pIndex.ToString());

                    if (value != null)
                        index = valuesCollection.IndexOf(value);

                    break;
                case BoSearchKey.psk_ByDescription:

                    var valueDesc = valuesCollection.FirstOrDefault(
                            c => c.Description == pIndex.ToString());

                    if (valueDesc != null)
                        index = valuesCollection.IndexOf(valueDesc);

                    break;
                case BoSearchKey.psk_Index:
                    index = (int)pIndex;
                    break;
                default:
                    throw new NotSupportedException("Valor para BoSearchKey não suportado");
            }

            return index;
        }

        /// <summary>
        /// Limpa todos os elementos da coleção
        /// </summary>
        public void Clear()
        {
            valuesCollection.Clear();
        }

    }
}
