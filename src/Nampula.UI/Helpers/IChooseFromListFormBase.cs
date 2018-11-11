using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Nampula.DI;

namespace Nampula.UI.Helpers
{
    /// <summary>
    /// Interface para desenvolvimento de formulário personalizado de pesquisa de registros 
    /// relacionados chamados de ChooseFromList
    /// </summary>
    public interface IChooseFromListFormBase
    {
        /// <summary>
        /// Nome da Tela de pesquisa
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Registro Selecionado na tela
        /// </summary>
        DataRow Record { get; set; }

        /// <summary>
        /// Quando a seleção for multila serão retornado 2 registros
        /// </summary>
        DataRow[] Records { get; set; }


        /// <summary>
        /// Objeto que representa a consulta a ser realizada na tela
        /// </summary>
        TableQuery Query { get; set; }

        /// <summary>
        /// Texto da pesquisa 
        /// </summary>
        string SearchBy { get; set; }

        /// <summary>
        /// Colunas que serão exibidas ao abrir a tela
        /// </summary>
        List<string> VisbleColumns { get; set; }

        /// <summary>
        /// Colunas que serão pesquiadas
        /// </summary>
        List<TableAdapterField> SearchColumns { get; set; }

        /// <summary>
        /// Permitir multiplas seleções de registros
        /// </summary>
        bool AllowSelectionsMultiples { get; set; }

        /// <summary>
        /// Exibe o formulário de pesquisa e aguarda o mesmo ser fechado
        /// </summary>
        /// <param name="pOwnerForm">Formulário que chamou a pesquisa</param>
        /// <returns>Resultado da pesquisa, cancelado ou selecionado</returns>
        DialogResult ShowDialog(Form pOwnerForm);
    }
}
