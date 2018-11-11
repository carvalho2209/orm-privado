using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.ProductTrees
{
    /// <summary>
    /// Tipos de árvore para os itens
    /// </summary>
    public enum ItemTreeType
    {
        NotATree,
        AssemblyTree,
        SalesTree,
        ProductionTree,
        TemplateTree,
        Ingredient
    }

    /// <summary>
    /// Conversão de tipos de árvore de itens
    /// </summary>
    public static class ItemTreeClass
    {
        private const string assembly = "A";
        private const string sales = "S";
        private const string production = "P";
        private const string template = "T";
        private const string ingredient = "I";
        private const string notatree = "N";

        public static string GetName(this ItemTreeType pItemTreeType)
        {
            var name = string.Empty;

            switch (pItemTreeType)
            {
                case ItemTreeType.NotATree:
                    name = "Não é arvore";
                    break;
                case ItemTreeType.AssemblyTree:
                    name = "Árvore de montagem";
                    break;
                case ItemTreeType.SalesTree:
                    name = "Árvore de venda";
                    break;
                case ItemTreeType.ProductionTree:
                    name = "Árvore de produção";
                    break;
                case ItemTreeType.TemplateTree:
                    name = "Árvore de modelo";
                    break;
                case ItemTreeType.Ingredient:
                    name = "Ingrediente";
                    break;
                default:
                    break;
            }

            return name;
        }

        public static string ToStringEnum(this ItemTreeType pItemTreeType)
        {
            var name = string.Empty;

            switch (pItemTreeType)
            {
                case ItemTreeType.AssemblyTree:
                    name = assembly;
                    break;
                case ItemTreeType.SalesTree:
                    name = sales;
                    break;
                case ItemTreeType.ProductionTree:
                    name = production;
                    break;
                case ItemTreeType.TemplateTree:
                    name = template;
                    break;
                case ItemTreeType.Ingredient:
                    name = ingredient;
                    break;
                case ItemTreeType.NotATree:
                default:
                    name = notatree;
                    break;
            }

            return name;
        }

        public static ItemTreeType ToEnum(this string pItemTreeType)
        {
            switch (pItemTreeType)
            {
                case assembly:
                    return ItemTreeType.AssemblyTree;
                case sales:
                    return ItemTreeType.SalesTree;
                case template:
                    return ItemTreeType.TemplateTree;
                case ingredient:
                    return ItemTreeType.Ingredient;
                case production:
                    return ItemTreeType.ProductionTree;
                default:
                    return ItemTreeType.NotATree;
            }
        }

    }
}
