using System;
using System.Data;
using System.Collections.Generic;
using Nampula.Framework;

namespace Nampula.DI.B1.Itens
{
    /// <summary>
    /// Gerenciamento dos Itens do SAP
    /// </summary>
    public class Item : TableAdapter
    {

        /// <summary>
        /// Definições da Tabela
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OITM";
        }



        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName
        {
            public static readonly string ItemCode = "ItemCode";              //String(20)
            public static readonly string ItemName = "ItemName";              //String(100)
            public static readonly string SellItem = "SellItem";              //varchar(1)
            public static readonly string ItemType = "ItemType";              //varchar(1)
            public static readonly string InvntItem = "InvntItem";            //varchar(1)
            public static readonly string ValidFor = "ValidFor";              //varchar(1)
            public static readonly string ValidFrom = "ValidFrom";            //datetime
            public static readonly string ValidTo = "ValidTo";                //datetime
            public static readonly string ValidComm = "ValidComm";            //String(200)
            public static readonly string FrozenFor = "FrozenFor";            //varchar(1)
            public static readonly string FrozenFrom = "FrozenFrom";          //datetime
            public static readonly string FrozenTo = "FrozenTo";              //datetime
            public static readonly string FrozenComm = "FrozenComm";            //String(200)
            public static readonly string NumInSale = "NumInSale";
            public static readonly string ItmsGrpCod = "ItmsGrpCod";
            public static readonly string DfltWH = "DfltWH";
            public static readonly string AvgPrice = "AvgPrice";
            public static readonly string NumInBuy = "NumInBuy";
            public static readonly string OrdrMulti = "OrdrMulti";
            public static readonly string QryGroup1 = "QryGroup1";
            public static readonly string QryGroup2 = "QryGroup2";
            public static readonly string QryGroup3 = "QryGroup3";
            public static readonly string QryGroup4 = "QryGroup4";
            public static readonly string QryGroup5 = "QryGroup5";
            public static readonly string QryGroup6 = "QryGroup6";
            public static readonly string QryGroup7 = "QryGroup7";
            public static readonly string QryGroup8 = "QryGroup8";
            public static readonly string QryGroup9 = "QryGroup9";
            public static readonly string QryGroup10 = "QryGroup10";
            public static readonly string QryGroup11 = "QryGroup11";
            public static readonly string QryGroup12 = "QryGroup12";
            public static readonly string QryGroup13 = "QryGroup13";
            public static readonly string QryGroup14 = "QryGroup14";
            public static readonly string QryGroup15 = "QryGroup15";
            public static readonly string QryGroup16 = "QryGroup16";
            public static readonly string QryGroup17 = "QryGroup17";
            public static readonly string QryGroup18 = "QryGroup18";
            public static readonly string QryGroup19 = "QryGroup19";
            public static readonly string QryGroup20 = "QryGroup20";
            public static readonly string QryGroup21 = "QryGroup21";
            public static readonly string QryGroup22 = "QryGroup22";
            public static readonly string QryGroup23 = "QryGroup23";
            public static readonly string QryGroup24 = "QryGroup24";
            public static readonly string QryGroup25 = "QryGroup25";
            public static readonly string QryGroup26 = "QryGroup26";
            public static readonly string QryGroup27 = "QryGroup27";
            public static readonly string QryGroup28 = "QryGroup28";
            public static readonly string QryGroup29 = "QryGroup29";
            public static readonly string QryGroup30 = "QryGroup30";
            public static readonly string QryGroup31 = "QryGroup31";
            public static readonly string QryGroup32 = "QryGroup32";
            public static readonly string QryGroup33 = "QryGroup33";
            public static readonly string QryGroup34 = "QryGroup34";
            public static readonly string QryGroup35 = "QryGroup35";
            public static readonly string QryGroup36 = "QryGroup36";
            public static readonly string QryGroup37 = "QryGroup37";
            public static readonly string QryGroup38 = "QryGroup38";
            public static readonly string QryGroup39 = "QryGroup39";
            public static readonly string QryGroup40 = "QryGroup40";
            public static readonly string QryGroup41 = "QryGroup41";
            public static readonly string QryGroup42 = "QryGroup42";
            public static readonly string QryGroup43 = "QryGroup43";
            public static readonly string QryGroup44 = "QryGroup44";
            public static readonly string QryGroup45 = "QryGroup45";
            public static readonly string QryGroup46 = "QryGroup46";
            public static readonly string QryGroup47 = "QryGroup47";
            public static readonly string QryGroup48 = "QryGroup48";
            public static readonly string QryGroup49 = "QryGroup49";
            public static readonly string QryGroup50 = "QryGroup50";
            public static readonly string QryGroup51 = "QryGroup51";
            public static readonly string QryGroup52 = "QryGroup52";
            public static readonly string QryGroup53 = "QryGroup53";
            public static readonly string QryGroup54 = "QryGroup54";
            public static readonly string QryGroup55 = "QryGroup55";
            public static readonly string QryGroup56 = "QryGroup56";
            public static readonly string QryGroup57 = "QryGroup57";
            public static readonly string QryGroup58 = "QryGroup58";
            public static readonly string QryGroup59 = "QryGroup59";
            public static readonly string QryGroup60 = "QryGroup60";
            public static readonly string QryGroup61 = "QryGroup61";
            public static readonly string QryGroup62 = "QryGroup62";
            public static readonly string QryGroup63 = "QryGroup63";
            public static readonly string QryGroup64 = "QryGroup64";
            public static readonly string SWW = "SWW";

            public static readonly string SHeight1 = "SHeight1";
            public static readonly string SHght1Unit = "SHght1Unit";

            public static readonly string SLength1 = "SLength1";
            public static readonly string SLen1Unit = "SLen1Unit";

            public static readonly string SWidth1 = "SWidth1";
            public static readonly string SWdth1Unit = "SWdth1Unit";

            public static readonly string SVolume = "SVolume";
            public static readonly string SVolUnit = "SVolUnit";

            public static readonly string SWeight1 = "SWeight1";
            public static readonly string SWght1Unit = "SWght1Unit";

            public static readonly string PrchseItem = "PrchseItem";
            public static readonly string PurPackUn = "PurPackUn";
            public static readonly string SuppCatNum = "SuppCatNum";
            public static readonly string ByWh = "ByWh";
            public static readonly string LastPurPrc = "LastPurPrc";
            public static readonly string FirmCode = "FirmCode";
            public static readonly string LeadTime = "LeadTime";
            public static readonly string ManBtchNum = "ManBtchNum";
            public static readonly string UserText = "UserText";
            public static readonly string ProductSrc = "ProductSrc";
            public static readonly string NCMCode = "NCMCode";
            public static readonly string SalPackUn = "SalPackUn";
            public static readonly string OnHand = "OnHand";
            public static readonly string CodeBars = "CodeBars";
            public static readonly string ItemClass = "ItemClass";
            public static readonly string SalUnitMsr = "SalUnitMsr";
            public static readonly string MatGrp = "MatGrp";

            public static readonly string CardCode = "CardCode";

            public static readonly string OSvcCode = "OSvcCode";
            public static readonly string ISvcCode = "ISvcCode";
            public static readonly string ManSerNum = "ManSerNum";
            public static readonly string BuyUnitMsr = "BuyUnitMsr";
            public static readonly string InvntryUom = "InvntryUom";
            public static readonly string MatType = "MatType";

            public static readonly string BVolume = "BVolume";
            public static readonly string BWeight1 = "BWeight1";
            public static readonly string FuelCode = "FuelCode";
        }



        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string ItemCode = "Código";              //String(20)
            public static readonly string ItemName = "Nome";              //String(100)
            public static readonly string SellItem = "Item de Venda";              //varchar(1)
            public static readonly string ItemType = "Tipo";
            public static readonly string InvntItem = "Item de Estoque";            //varchar(1)
            public static readonly string ValidFor = "Válido";              //varchar(1)
            public static readonly string ValidFrom = "Válido de";            //datetime
            public static readonly string ValidTo = "Válido até";                //datetime
            public static readonly string ValidComm = "Obs de Validade";            //String(200)
            public static readonly string FrozenFor = "Pendente";            //varchar(1)
            public static readonly string FrozenFrom = "Pendente de";          //datetime
            public static readonly string FrozenTo = "Pendente até";              //datetime
            public static readonly string FrozenComm = "Obs. de Pendencia";            //String(200)
            public static readonly string NumInSale = "Número de itens por unidade de venda";
            public static readonly string ItmsGrpCod = "Grupo de Itens";
            public static readonly string DfltWH = "Depósito Padrão";
            public static readonly string AvgPrice = "Preço de Custo";
            public static readonly string NumInBuy = "Itens por Unidade de Compra";
            public static readonly string OrdrMulti = "OrdrMulti";
            public static readonly string QryGroup1 = "Característica 1";
            public static readonly string QryGroup2 = "Característica 2";
            public static readonly string QryGroup3 = "Característica 3";
            public static readonly string QryGroup4 = "Característica 4";
            public static readonly string QryGroup5 = "Característica 5";
            public static readonly string QryGroup6 = "Característica 6";
            public static readonly string QryGroup7 = "Característica 7";
            public static readonly string QryGroup8 = "Característica 8";
            public static readonly string QryGroup9 = "Característica 9";
            public static readonly string QryGroup10 = "Característica 10";
            public static readonly string QryGroup11 = "Característica 11";
            public static readonly string QryGroup12 = "Característica 12";
            public static readonly string QryGroup13 = "Característica 13";
            public static readonly string QryGroup14 = "Característica 14";
            public static readonly string QryGroup15 = "Característica 15";
            public static readonly string QryGroup16 = "Característica 16";
            public static readonly string QryGroup17 = "Característica 17";
            public static readonly string QryGroup18 = "Característica 18";
            public static readonly string QryGroup19 = "Característica 19";
            public static readonly string QryGroup20 = "Característica 20";
            public static readonly string QryGroup21 = "Característica 21";
            public static readonly string QryGroup22 = "Característica 22";
            public static readonly string QryGroup23 = "Característica 23";
            public static readonly string QryGroup24 = "Característica 24";
            public static readonly string QryGroup25 = "Característica 25";
            public static readonly string QryGroup26 = "Característica 26";
            public static readonly string QryGroup27 = "Característica 27";
            public static readonly string QryGroup28 = "Característica 28";
            public static readonly string QryGroup29 = "Característica 29";
            public static readonly string QryGroup30 = "Característica 30";
            public static readonly string QryGroup31 = "Característica 31";
            public static readonly string QryGroup32 = "Característica 32";
            public static readonly string QryGroup33 = "Característica 33";
            public static readonly string QryGroup34 = "Característica 34";
            public static readonly string QryGroup35 = "Característica 35";
            public static readonly string QryGroup36 = "Característica 36";
            public static readonly string QryGroup37 = "Característica 37";
            public static readonly string QryGroup38 = "Característica 38";
            public static readonly string QryGroup39 = "Característica 39";
            public static readonly string QryGroup40 = "Característica 40";
            public static readonly string QryGroup41 = "Característica 41";
            public static readonly string QryGroup42 = "Característica 42";
            public static readonly string QryGroup43 = "Característica 43";
            public static readonly string QryGroup44 = "Característica 44";
            public static readonly string QryGroup45 = "Característica 45";
            public static readonly string QryGroup46 = "Característica 46";
            public static readonly string QryGroup47 = "Característica 47";
            public static readonly string QryGroup48 = "Característica 48";
            public static readonly string QryGroup49 = "Característica 49";
            public static readonly string QryGroup50 = "Característica 50";
            public static readonly string QryGroup51 = "Característica 51";
            public static readonly string QryGroup52 = "Característica 52";
            public static readonly string QryGroup53 = "Característica 53";
            public static readonly string QryGroup54 = "Característica 54";
            public static readonly string QryGroup55 = "Característica 55";
            public static readonly string QryGroup56 = "Característica 56";
            public static readonly string QryGroup57 = "Característica 57";
            public static readonly string QryGroup58 = "Característica 58";
            public static readonly string QryGroup59 = "Característica 59";
            public static readonly string QryGroup60 = "Característica 60";
            public static readonly string QryGroup61 = "Característica 61";
            public static readonly string QryGroup62 = "Característica 62";
            public static readonly string QryGroup63 = "Característica 63";
            public static readonly string QryGroup64 = "Característica 64";

            public static readonly string SWW = "Identificador Adicional";

            public static readonly string SHeight1 = "SHeight1";
            public static readonly string SHght1Unit = "SHght1Unit";

            public static readonly string SLength1 = "SLength1";
            public static readonly string SLen1Unit = "SLen1Unit";

            public static readonly string SWidth1 = "SWidth1";
            public static readonly string SWdth1Unit = "SWdth1Unit";

            public static readonly string SVolume = "SVolume";
            public static readonly string SVolUnit = "SVolUnit";

            public static readonly string SWeight1 = "SWeight1";
            public static readonly string SWght1Unit = "SWght1Unit";

            public static readonly string PurPackUn = "Qtd. por UM Embalagem";

            public static readonly string PrchseItem = "PrchseItem";
            public static readonly string SuppCatNum = "SuppCatNum";
            public static readonly string ByWh = "ByWh";
            public static readonly string LastPurPrc = "Último Preço de Compra";
            public static readonly string FirmCode = "Fabricante";
            public static readonly string LeadTime = "LeadTime";
            public static readonly string ManBtchNum = "Controlado por Lote";
            public static readonly string UserText = "UserText";
            public static readonly string ProductSrc = "Origem";
            public static readonly string NCMCode = "NCMCode";
            public static readonly string SalPackUn = "SalPackUn";
            public static readonly string OnHand = "Estoque";
            public static readonly string CodeBars = "Código de Barras";
            public static readonly string ItemClass = "Classificação Item";
            public static readonly string SalUnitMsr = "Unidade Medida de Vendas";
            public static readonly string CardCode = "CardCode";
            public static readonly string OSvcCode = "Código do Serviço Prestado";
            public static readonly string ISvcCode = "Código do Serviço Contratado";
            public static readonly string ManSerNum = "Gerenciar por serie";

            public static readonly string MatGrp = "Grupo Material";

            public static readonly string BuyUnitMsr = "Unidade de Compra";
            public static readonly string InvntryUom = "Unidade de Estoque";
            public static readonly string MatType = "Tipo de Material";

            public static readonly string BVolume = "Volume";
            public static readonly string BWeight1 = "Largura";
            public static readonly string FuelCode = "Código de Combustível";
        }



        TableAdapterField m_ItemCode = new TableAdapterField(FieldsName.ItemCode, FieldsDescription.ItemCode, DbType.String, 20, null, true, false);
        TableAdapterField m_ItemName = new TableAdapterField(FieldsName.ItemName, FieldsDescription.ItemName, 200);
        TableAdapterField m_SellItem = new TableAdapterField(FieldsName.SellItem, FieldsDescription.SellItem, 1);
        TableAdapterField m_InvntItem = new TableAdapterField(FieldsName.InvntItem, FieldsDescription.InvntItem, 1);
        TableAdapterField m_ValidFor = new TableAdapterField(FieldsName.ValidFor, FieldsDescription.ValidFor, 1);
        TableAdapterField m_ValidFrom = new TableAdapterField(FieldsName.ValidFrom, FieldsDescription.ValidFrom, DbType.DateTime);
        TableAdapterField m_ValidTo = new TableAdapterField(FieldsName.ValidTo, FieldsDescription.ValidTo, DbType.DateTime);
        TableAdapterField m_ValidComm = new TableAdapterField(FieldsName.ValidComm, FieldsDescription.ValidComm, 200);
        TableAdapterField m_FrozenFor = new TableAdapterField(FieldsName.FrozenFor, FieldsDescription.FrozenFor, 1);
        TableAdapterField m_FrozenFrom = new TableAdapterField(FieldsName.FrozenFrom, FieldsDescription.FrozenFrom, DbType.DateTime);
        TableAdapterField m_FrozenTo = new TableAdapterField(FieldsName.FrozenTo, FieldsDescription.FrozenTo, DbType.DateTime);
        TableAdapterField m_FrozenComm = new TableAdapterField(FieldsName.FrozenComm, FieldsDescription.FrozenComm, 200);
        TableAdapterField m_NumInSale = new TableAdapterField(FieldsName.NumInSale, FieldsDescription.NumInSale, DbType.Decimal, 19, 6);
        TableAdapterField m_ItmsGrpCod = new TableAdapterField(FieldsName.ItmsGrpCod, FieldsDescription.ItmsGrpCod, DbType.Int32);
        TableAdapterField m_DfltWH = new TableAdapterField(FieldsName.DfltWH, FieldsDescription.DfltWH, 8);
        TableAdapterField m_AvgPrice = new TableAdapterField(FieldsName.AvgPrice, FieldsDescription.AvgPrice, DbType.Decimal, 19, 6);
        TableAdapterField m_NumInBuy = new TableAdapterField(FieldsName.NumInBuy, FieldsDescription.NumInBuy, DbType.Decimal, 19, 6);
        TableAdapterField m_PurPackUn = new TableAdapterField(FieldsName.PurPackUn, FieldsDescription.PurPackUn, DbType.Decimal, 19, 6);
        TableAdapterField m_ItemType = new TableAdapterField(FieldsName.ItemType, FieldsDescription.ItemType, 2);
        TableAdapterField m_MatGrp = new TableAdapterField(FieldsName.MatGrp, FieldsDescription.MatGrp, DbType.Int32);
        TableAdapterField m_SWW = new TableAdapterField(FieldsName.SWW, FieldsDescription.SWW, 16);
        TableAdapterField m_OrdrMulti = new TableAdapterField(FieldsName.OrdrMulti, FieldsDescription.OrdrMulti, DbType.Decimal, 19, 6);
        TableAdapterField m_QryGroup1 = new TableAdapterField(FieldsName.QryGroup1, FieldsDescription.QryGroup1, 1);
        TableAdapterField m_QryGroup2 = new TableAdapterField(FieldsName.QryGroup2, FieldsDescription.QryGroup2, 1);
        TableAdapterField m_QryGroup3 = new TableAdapterField(FieldsName.QryGroup3, FieldsDescription.QryGroup3, 1);
        TableAdapterField m_QryGroup4 = new TableAdapterField(FieldsName.QryGroup4, FieldsDescription.QryGroup4, 1);
        TableAdapterField m_QryGroup5 = new TableAdapterField(FieldsName.QryGroup5, FieldsDescription.QryGroup5, 1);
        TableAdapterField m_QryGroup6 = new TableAdapterField(FieldsName.QryGroup6, FieldsDescription.QryGroup6, 1);
        TableAdapterField m_QryGroup7 = new TableAdapterField(FieldsName.QryGroup7, FieldsDescription.QryGroup7, 1);
        TableAdapterField m_QryGroup8 = new TableAdapterField(FieldsName.QryGroup8, FieldsDescription.QryGroup8, 1);
        TableAdapterField m_QryGroup9 = new TableAdapterField(FieldsName.QryGroup9, FieldsDescription.QryGroup9, 1);
        TableAdapterField m_QryGroup10 = new TableAdapterField(FieldsName.QryGroup10, FieldsDescription.QryGroup10, 1);
        TableAdapterField m_QryGroup11 = new TableAdapterField(FieldsName.QryGroup11, FieldsDescription.QryGroup11, 1);
        TableAdapterField m_QryGroup12 = new TableAdapterField(FieldsName.QryGroup12, FieldsDescription.QryGroup12, 1);
        TableAdapterField m_QryGroup13 = new TableAdapterField(FieldsName.QryGroup13, FieldsDescription.QryGroup13, 1);
        TableAdapterField m_QryGroup14 = new TableAdapterField(FieldsName.QryGroup14, FieldsDescription.QryGroup14, 1);
        TableAdapterField m_QryGroup15 = new TableAdapterField(FieldsName.QryGroup15, FieldsDescription.QryGroup15, 1);
        TableAdapterField m_QryGroup16 = new TableAdapterField(FieldsName.QryGroup16, FieldsDescription.QryGroup16, 1);
        TableAdapterField m_QryGroup17 = new TableAdapterField(FieldsName.QryGroup17, FieldsDescription.QryGroup17, 1);
        TableAdapterField m_QryGroup18 = new TableAdapterField(FieldsName.QryGroup18, FieldsDescription.QryGroup18, 1);
        TableAdapterField m_QryGroup19 = new TableAdapterField(FieldsName.QryGroup19, FieldsDescription.QryGroup19, 1);
        TableAdapterField m_QryGroup20 = new TableAdapterField(FieldsName.QryGroup20, FieldsDescription.QryGroup20, 1);
        TableAdapterField m_QryGroup21 = new TableAdapterField(FieldsName.QryGroup21, FieldsDescription.QryGroup21, 1);
        TableAdapterField m_QryGroup22 = new TableAdapterField(FieldsName.QryGroup22, FieldsDescription.QryGroup22, 1);
        TableAdapterField m_QryGroup23 = new TableAdapterField(FieldsName.QryGroup23, FieldsDescription.QryGroup23, 1);
        TableAdapterField m_QryGroup24 = new TableAdapterField(FieldsName.QryGroup24, FieldsDescription.QryGroup24, 1);
        TableAdapterField m_QryGroup25 = new TableAdapterField(FieldsName.QryGroup25, FieldsDescription.QryGroup25, 1);
        TableAdapterField m_QryGroup26 = new TableAdapterField(FieldsName.QryGroup26, FieldsDescription.QryGroup26, 1);
        TableAdapterField m_QryGroup27 = new TableAdapterField(FieldsName.QryGroup27, FieldsDescription.QryGroup27, 1);
        TableAdapterField m_QryGroup28 = new TableAdapterField(FieldsName.QryGroup28, FieldsDescription.QryGroup28, 1);
        TableAdapterField m_QryGroup29 = new TableAdapterField(FieldsName.QryGroup29, FieldsDescription.QryGroup29, 1);
        TableAdapterField m_QryGroup30 = new TableAdapterField(FieldsName.QryGroup30, FieldsDescription.QryGroup30, 1);
        TableAdapterField m_QryGroup31 = new TableAdapterField(FieldsName.QryGroup31, FieldsDescription.QryGroup31, 1);
        TableAdapterField m_QryGroup32 = new TableAdapterField(FieldsName.QryGroup32, FieldsDescription.QryGroup32, 1);
        TableAdapterField m_QryGroup33 = new TableAdapterField(FieldsName.QryGroup33, FieldsDescription.QryGroup33, 1);
        TableAdapterField m_QryGroup34 = new TableAdapterField(FieldsName.QryGroup34, FieldsDescription.QryGroup34, 1);
        TableAdapterField m_QryGroup35 = new TableAdapterField(FieldsName.QryGroup35, FieldsDescription.QryGroup35, 1);
        TableAdapterField m_QryGroup36 = new TableAdapterField(FieldsName.QryGroup36, FieldsDescription.QryGroup36, 1);
        TableAdapterField m_QryGroup37 = new TableAdapterField(FieldsName.QryGroup37, FieldsDescription.QryGroup37, 1);
        TableAdapterField m_QryGroup38 = new TableAdapterField(FieldsName.QryGroup38, FieldsDescription.QryGroup38, 1);
        TableAdapterField m_QryGroup39 = new TableAdapterField(FieldsName.QryGroup39, FieldsDescription.QryGroup39, 1);
        TableAdapterField m_QryGroup40 = new TableAdapterField(FieldsName.QryGroup40, FieldsDescription.QryGroup40, 1);
        TableAdapterField m_QryGroup41 = new TableAdapterField(FieldsName.QryGroup41, FieldsDescription.QryGroup41, 1);
        TableAdapterField m_QryGroup42 = new TableAdapterField(FieldsName.QryGroup42, FieldsDescription.QryGroup42, 1);
        TableAdapterField m_QryGroup43 = new TableAdapterField(FieldsName.QryGroup43, FieldsDescription.QryGroup43, 1);
        TableAdapterField m_QryGroup44 = new TableAdapterField(FieldsName.QryGroup44, FieldsDescription.QryGroup44, 1);
        TableAdapterField m_QryGroup45 = new TableAdapterField(FieldsName.QryGroup45, FieldsDescription.QryGroup45, 1);
        TableAdapterField m_QryGroup46 = new TableAdapterField(FieldsName.QryGroup46, FieldsDescription.QryGroup46, 1);
        TableAdapterField m_QryGroup47 = new TableAdapterField(FieldsName.QryGroup47, FieldsDescription.QryGroup47, 1);
        TableAdapterField m_QryGroup48 = new TableAdapterField(FieldsName.QryGroup48, FieldsDescription.QryGroup48, 1);
        TableAdapterField m_QryGroup49 = new TableAdapterField(FieldsName.QryGroup49, FieldsDescription.QryGroup49, 1);
        TableAdapterField m_QryGroup50 = new TableAdapterField(FieldsName.QryGroup50, FieldsDescription.QryGroup50, 1);
        TableAdapterField m_QryGroup51 = new TableAdapterField(FieldsName.QryGroup51, FieldsDescription.QryGroup51, 1);
        TableAdapterField m_QryGroup52 = new TableAdapterField(FieldsName.QryGroup52, FieldsDescription.QryGroup52, 1);
        TableAdapterField m_QryGroup53 = new TableAdapterField(FieldsName.QryGroup53, FieldsDescription.QryGroup53, 1);
        TableAdapterField m_QryGroup54 = new TableAdapterField(FieldsName.QryGroup54, FieldsDescription.QryGroup54, 1);
        TableAdapterField m_QryGroup55 = new TableAdapterField(FieldsName.QryGroup55, FieldsDescription.QryGroup55, 1);
        TableAdapterField m_QryGroup56 = new TableAdapterField(FieldsName.QryGroup56, FieldsDescription.QryGroup56, 1);
        TableAdapterField m_QryGroup57 = new TableAdapterField(FieldsName.QryGroup57, FieldsDescription.QryGroup57, 1);
        TableAdapterField m_QryGroup58 = new TableAdapterField(FieldsName.QryGroup58, FieldsDescription.QryGroup58, 1);
        TableAdapterField m_QryGroup59 = new TableAdapterField(FieldsName.QryGroup59, FieldsDescription.QryGroup59, 1);
        TableAdapterField m_QryGroup60 = new TableAdapterField(FieldsName.QryGroup60, FieldsDescription.QryGroup60, 1);
        TableAdapterField m_QryGroup61 = new TableAdapterField(FieldsName.QryGroup61, FieldsDescription.QryGroup61, 1);
        TableAdapterField m_QryGroup62 = new TableAdapterField(FieldsName.QryGroup62, FieldsDescription.QryGroup62, 1);
        TableAdapterField m_QryGroup63 = new TableAdapterField(FieldsName.QryGroup63, FieldsDescription.QryGroup63, 1);
        TableAdapterField m_QryGroup64 = new TableAdapterField(FieldsName.QryGroup64, FieldsDescription.QryGroup64, 1);



        TableAdapterField m_SHeight1 = new TableAdapterField(FieldsName.SHeight1, FieldsDescription.SHeight1, DbType.Decimal);
        TableAdapterField m_SHght1Unit = new TableAdapterField(FieldsName.SHght1Unit, FieldsDescription.SHght1Unit, DbType.Int16);

        TableAdapterField m_SLength1 = new TableAdapterField(FieldsName.SLength1, FieldsDescription.SLength1, DbType.Decimal);
        TableAdapterField m_SLen1Unit = new TableAdapterField(FieldsName.SLen1Unit, FieldsDescription.SLen1Unit, DbType.Int16);

        TableAdapterField m_SWidth1 = new TableAdapterField(FieldsName.SWidth1, FieldsDescription.SWidth1, DbType.Decimal);
        TableAdapterField m_SWdth1Unit = new TableAdapterField(FieldsName.SWdth1Unit, FieldsDescription.SWdth1Unit, DbType.Int16);

        TableAdapterField m_SVolume = new TableAdapterField(FieldsName.SVolume, FieldsDescription.SVolume, DbType.Decimal);
        TableAdapterField m_SVolUnit = new TableAdapterField(FieldsName.SVolUnit, FieldsDescription.SVolUnit, DbType.Int16);

        TableAdapterField m_SWeight1 = new TableAdapterField(FieldsName.SWeight1, FieldsDescription.SWeight1, DbType.Decimal);
        TableAdapterField m_SWght1Unit = new TableAdapterField(FieldsName.SWght1Unit, FieldsDescription.SWght1Unit, DbType.Int16);

        TableAdapterField m_PrchseItem = new TableAdapterField(FieldsName.PrchseItem, FieldsDescription.PrchseItem, 1);
        TableAdapterField m_SuppCatNum = new TableAdapterField(FieldsName.SuppCatNum, FieldsDescription.SuppCatNum, 17);
        TableAdapterField m_ByWh = new TableAdapterField(FieldsName.ByWh, FieldsDescription.ByWh, 1);
        TableAdapterField m_SalUnitMsr = new TableAdapterField(FieldsName.SalUnitMsr, FieldsDescription.SalUnitMsr, 20);

        TableAdapterField m_LastPurPrc = new TableAdapterField(FieldsName.LastPurPrc, FieldsDescription.LastPurPrc, DbType.Decimal);
        TableAdapterField m_FirmCode = new TableAdapterField(FieldsName.FirmCode, FieldsDescription.FirmCode, DbType.Int32);
        TableAdapterField m_LeadTime = new TableAdapterField(FieldsName.LeadTime, FieldsDescription.LeadTime, DbType.Int32);
        TableAdapterField m_ManBtchNum = new TableAdapterField(FieldsName.ManBtchNum, FieldsDescription.ManBtchNum, 1);
        TableAdapterField m_UserText = new TableAdapterField(FieldsName.UserText, FieldsDescription.UserText, 4000);
        TableAdapterField m_ProductSrc = new TableAdapterField(FieldsName.ProductSrc, FieldsDescription.ProductSrc, DbType.Int32);
        TableAdapterField m_NCMCode = new TableAdapterField(FieldsName.NCMCode, FieldsDescription.NCMCode, DbType.Int32);
        TableAdapterField m_SalPackUn = new TableAdapterField(FieldsName.SalPackUn, FieldsDescription.SalPackUn, DbType.Decimal);
        TableAdapterField m_OnHand = new TableAdapterField(FieldsName.OnHand, FieldsDescription.OnHand, DbType.Decimal);
        TableAdapterField m_CodeBars = new TableAdapterField(FieldsName.CodeBars, FieldsDescription.CodeBars, 40);
        TableAdapterField m_ItemClass = new TableAdapterField(FieldsName.ItemClass, FieldsDescription.ItemClass, 1);
        TableAdapterField m_CardCode = new TableAdapterField(FieldsName.CardCode, FieldsDescription.CardCode, 400);
        TableAdapterField m_OSvcCode = new TableAdapterField(FieldsName.OSvcCode, FieldsDescription.OSvcCode, DbType.Int32);
        TableAdapterField m_ISvcCode = new TableAdapterField(FieldsName.ISvcCode, FieldsDescription.ISvcCode, DbType.Int32);
        TableAdapterField m_ManSerNum = new TableAdapterField(FieldsName.ManSerNum, FieldsDescription.ManSerNum, 1);

        TableAdapterField m_InvntryUom = new TableAdapterField(FieldsName.InvntryUom, FieldsDescription.InvntryUom, 20);
        TableAdapterField m_BuyUnitMsr = new TableAdapterField(FieldsName.BuyUnitMsr, FieldsDescription.BuyUnitMsr, 20);
        TableAdapterField m_MatType = new TableAdapterField(FieldsName.MatType, FieldsDescription.MatType, 6);
        TableAdapterField m_BVolume = new TableAdapterField(FieldsName.BVolume, FieldsDescription.BVolume, DbType.Decimal, 19, 6);
        TableAdapterField m_BWeight1 = new TableAdapterField(FieldsName.BWeight1, FieldsDescription.BWeight1, DbType.Decimal, 19, 6);
        TableAdapterField m_FuelCode = new TableAdapterField(FieldsName.FuelCode, FieldsDescription.FuelCode, DbType.Int32);

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Item()
            : base(Definition.TableName)
        {
        }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="pCompanyDb">Nome do Banco</param>
        public Item(String pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        /// <summary>
        /// Cria um novo objeto com base em outro
        /// </summary>
        /// <param name="pItem">Objeto de Origem</param>
        public Item(Item pItem)
            : this(pItem.DBName)
        {
            this.CopyBy(pItem);
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public string ItemCode
        {
            get { return m_ItemCode.GetString(); }
            set { m_ItemCode.Value = value; }
        }

        public string ItemName
        {
            get { return m_ItemName.GetString(); }
            set { m_ItemName.Value = value; }
        }
        public eYesNo SellItem
        {
            get { return m_SellItem.GetString().ToYesNoEnum(); }
            set { m_SellItem.Value = value.ToYesNoString(); }
        }

        /// <summary>
        /// Tipo de item
        /// I - Item
        /// L - Mão de obra
        /// T - Viagens
        /// </summary>
        public String ItemType
        {
            get { return m_ItemType.GetString(); }
            set { m_ItemType.Value = value; }
        }


        public eYesNo InvntItem
        {
            get { return m_InvntItem.GetString().ToYesNoEnum(); }
            set { m_InvntItem.Value = value.ToYesNoString(); }
        }

        public Int32 MatGrp
        {
            get { return m_MatGrp.GetInt32(); }
            set { m_MatGrp.Value = value; }
        }


        public eYesNo PrchseItem
        {
            get { return m_PrchseItem.GetString().ToYesNoEnum(); }
            set { m_PrchseItem.Value = value.ToYesNoString(); }
        }

        public Decimal PurPackUn
        {
            get { return m_PurPackUn.GetDecimal(); }
            set { m_PurPackUn.Value = value; }
        }

        public string ValidFor
        {
            get { return m_ValidFor.GetString(); }
            set { m_ValidFor.Value = value; }
        }

        public DateTime ValidFrom
        {
            get { return m_ValidFrom.GetDateTime(); }
            set { m_ValidFrom.Value = value; }
        }

        public DateTime ValidTo
        {
            get { return m_ValidTo.GetDateTime(); }
            set { m_ValidTo.Value = value; }
        }

        public string ValidComm
        {
            get { return m_ValidComm.GetString(); }
            set { m_ValidComm.Value = value; }
        }

        public string FrozenFor
        {
            get { return m_FrozenFor.GetString(); }
            set { m_FrozenFor.Value = value; }
        }

        public DateTime FrozenFrom
        {
            get { return m_FrozenFrom.GetDateTime(); }
            set { m_FrozenFrom.Value = value; }
        }

        public DateTime FrozenTo
        {
            get { return m_FrozenTo.GetDateTime(); }
            set { m_FrozenTo.Value = value; }
        }

        public string FrozemComm
        {
            get { return m_FrozenComm.GetString(); }
            set { m_FrozenComm.Value = value; }
        }

        public decimal NumInSale
        {
            get { return m_NumInSale.GetDecimal(); }
            set { m_NumInSale.Value = value; }
        }

        public int ItmsGrpCod
        {
            get { return m_ItmsGrpCod.GetInt32(); }
            set { m_ItmsGrpCod.Value = value; }
        }

        public String SalUnitMsr
        {
            get { return m_SalUnitMsr.GetString(); }
            set { m_SalUnitMsr.Value = value; }
        }

        public Decimal OrdrMulti
        {
            get { return m_OrdrMulti.GetDecimal(); }
            set { m_OrdrMulti.Value = value; }
        }


        public eYesNo QryGroup1
        {
            get { return m_QryGroup1.GetString().ToYesNoEnum(); }
            set { m_QryGroup1.Value = value.ToYesNoString(); }
        }

        public eYesNo QryGroup2
        {
            get { return m_QryGroup2.GetString().ToYesNoEnum(); }
            set { m_QryGroup2.Value = value.ToYesNoString(); }
        }

        public eYesNo QryGroup3
        {
            get { return m_QryGroup3.GetString().ToYesNoEnum(); }
            set { m_QryGroup3.Value = value.ToYesNoString(); }
        }

        public eYesNo QryGroup4
        {
            get { return m_QryGroup4.GetString().ToYesNoEnum(); }
            set { m_QryGroup4.Value = value.ToYesNoString(); }
        }

        public eYesNo QryGroup5
        {
            get { return m_QryGroup5.GetString().ToYesNoEnum(); }
            set { m_QryGroup5.Value = value.ToYesNoString(); }
        }

        public eYesNo QryGroup6
        {
            get { return m_QryGroup6.GetString().ToYesNoEnum(); }
            set { m_QryGroup6.Value = value.ToYesNoString(); }
        }

        public eYesNo QryGroup7
        {
            get { return m_QryGroup7.GetString().ToYesNoEnum(); }
            set { m_QryGroup7.Value = value.ToYesNoString(); }
        }

        public eYesNo QryGroup8
        {
            get { return m_QryGroup8.GetString().ToYesNoEnum(); }
            set { m_QryGroup8.Value = value.ToYesNoString(); }
        }

        public eYesNo QryGroup9
        {
            get { return m_QryGroup9.GetString().ToYesNoEnum(); }
            set { m_QryGroup9.Value = value.ToYesNoString(); }
        }

        public eYesNo QryGroup10
        {
            get { return m_QryGroup10.GetString().ToYesNoEnum(); }
            set { m_QryGroup10.Value = value.ToYesNoString(); }
        }


        public eYesNo QryGroup11
        {
            get { return m_QryGroup11.GetString().ToYesNoEnum(); }
            set { m_QryGroup11.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup12
        {
            get { return m_QryGroup12.GetString().ToYesNoEnum(); }
            set { m_QryGroup12.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup13
        {
            get { return m_QryGroup13.GetString().ToYesNoEnum(); }
            set { m_QryGroup13.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup14
        {
            get { return m_QryGroup14.GetString().ToYesNoEnum(); }
            set { m_QryGroup14.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup15
        {
            get { return m_QryGroup15.GetString().ToYesNoEnum(); }
            set { m_QryGroup15.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup16
        {
            get { return m_QryGroup16.GetString().ToYesNoEnum(); }
            set { m_QryGroup16.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup17
        {
            get { return m_QryGroup17.GetString().ToYesNoEnum(); }
            set { m_QryGroup17.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup18
        {
            get { return m_QryGroup18.GetString().ToYesNoEnum(); }
            set { m_QryGroup18.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup19
        {
            get { return m_QryGroup19.GetString().ToYesNoEnum(); }
            set { m_QryGroup19.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup20
        {
            get { return m_QryGroup20.GetString().ToYesNoEnum(); }
            set { m_QryGroup20.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup21
        {
            get { return m_QryGroup21.GetString().ToYesNoEnum(); }
            set { m_QryGroup21.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup22
        {
            get { return m_QryGroup22.GetString().ToYesNoEnum(); }
            set { m_QryGroup22.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup23
        {
            get { return m_QryGroup23.GetString().ToYesNoEnum(); }
            set { m_QryGroup23.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup24
        {
            get { return m_QryGroup24.GetString().ToYesNoEnum(); }
            set { m_QryGroup24.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup25
        {
            get { return m_QryGroup25.GetString().ToYesNoEnum(); }
            set { m_QryGroup25.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup26
        {
            get { return m_QryGroup26.GetString().ToYesNoEnum(); }
            set { m_QryGroup26.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup27
        {
            get { return m_QryGroup27.GetString().ToYesNoEnum(); }
            set { m_QryGroup27.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup28
        {
            get { return m_QryGroup28.GetString().ToYesNoEnum(); }
            set { m_QryGroup28.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup29
        {
            get { return m_QryGroup29.GetString().ToYesNoEnum(); }
            set { m_QryGroup29.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup30
        {
            get { return m_QryGroup30.GetString().ToYesNoEnum(); }
            set { m_QryGroup30.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup31
        {
            get { return m_QryGroup31.GetString().ToYesNoEnum(); }
            set { m_QryGroup31.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup32
        {
            get { return m_QryGroup32.GetString().ToYesNoEnum(); }
            set { m_QryGroup32.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup33
        {
            get { return m_QryGroup33.GetString().ToYesNoEnum(); }
            set { m_QryGroup33.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup34
        {
            get { return m_QryGroup34.GetString().ToYesNoEnum(); }
            set { m_QryGroup34.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup35
        {
            get { return m_QryGroup35.GetString().ToYesNoEnum(); }
            set { m_QryGroup35.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup36
        {
            get { return m_QryGroup36.GetString().ToYesNoEnum(); }
            set { m_QryGroup36.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup37
        {
            get { return m_QryGroup37.GetString().ToYesNoEnum(); }
            set { m_QryGroup37.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup38
        {
            get { return m_QryGroup38.GetString().ToYesNoEnum(); }
            set { m_QryGroup38.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup39
        {
            get { return m_QryGroup39.GetString().ToYesNoEnum(); }
            set { m_QryGroup39.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup40
        {
            get { return m_QryGroup40.GetString().ToYesNoEnum(); }
            set { m_QryGroup40.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup41
        {
            get { return m_QryGroup41.GetString().ToYesNoEnum(); }
            set { m_QryGroup41.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup42
        {
            get { return m_QryGroup42.GetString().ToYesNoEnum(); }
            set { m_QryGroup42.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup43
        {
            get { return m_QryGroup43.GetString().ToYesNoEnum(); }
            set { m_QryGroup43.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup44
        {
            get { return m_QryGroup44.GetString().ToYesNoEnum(); }
            set { m_QryGroup44.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup45
        {
            get { return m_QryGroup45.GetString().ToYesNoEnum(); }
            set { m_QryGroup45.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup46
        {
            get { return m_QryGroup46.GetString().ToYesNoEnum(); }
            set { m_QryGroup46.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup47
        {
            get { return m_QryGroup47.GetString().ToYesNoEnum(); }
            set { m_QryGroup47.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup48
        {
            get { return m_QryGroup48.GetString().ToYesNoEnum(); }
            set { m_QryGroup48.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup49
        {
            get { return m_QryGroup49.GetString().ToYesNoEnum(); }
            set { m_QryGroup49.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup50
        {
            get { return m_QryGroup50.GetString().ToYesNoEnum(); }
            set { m_QryGroup50.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup51
        {
            get { return m_QryGroup51.GetString().ToYesNoEnum(); }
            set { m_QryGroup51.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup52
        {
            get { return m_QryGroup52.GetString().ToYesNoEnum(); }
            set { m_QryGroup52.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup53
        {
            get { return m_QryGroup53.GetString().ToYesNoEnum(); }
            set { m_QryGroup53.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup54
        {
            get { return m_QryGroup54.GetString().ToYesNoEnum(); }
            set { m_QryGroup54.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup55
        {
            get { return m_QryGroup55.GetString().ToYesNoEnum(); }
            set { m_QryGroup55.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup56
        {
            get { return m_QryGroup56.GetString().ToYesNoEnum(); }
            set { m_QryGroup56.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup57
        {
            get { return m_QryGroup57.GetString().ToYesNoEnum(); }
            set { m_QryGroup57.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup58
        {
            get { return m_QryGroup58.GetString().ToYesNoEnum(); }
            set { m_QryGroup58.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup59
        {
            get { return m_QryGroup59.GetString().ToYesNoEnum(); }
            set { m_QryGroup59.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup60
        {
            get { return m_QryGroup60.GetString().ToYesNoEnum(); }
            set { m_QryGroup60.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup61
        {
            get { return m_QryGroup61.GetString().ToYesNoEnum(); }
            set { m_QryGroup61.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup62
        {
            get { return m_QryGroup62.GetString().ToYesNoEnum(); }
            set { m_QryGroup62.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup63
        {
            get { return m_QryGroup63.GetString().ToYesNoEnum(); }
            set { m_QryGroup63.Value = value.ToYesNoString(); }
        }
        public eYesNo QryGroup64
        {
            get { return m_QryGroup64.GetString().ToYesNoEnum(); }
            set { m_QryGroup64.Value = value.ToYesNoString(); }
        }


        public string DfltWH
        {
            get { return m_DfltWH.GetString(); }
            set { m_DfltWH.Value = value; }
        }

        public Decimal AvgPrice
        {
            get { return m_AvgPrice.GetDecimal(); }
            set { m_AvgPrice.Value = value; }
        }

        public Decimal NumInBuy
        {
            get { return m_NumInBuy.GetDecimal(); }
            set { m_NumInBuy.Value = value; }
        }

        public Decimal SHeight1
        {
            get { return m_SHeight1.GetDecimal(); }
            set { m_SHeight1.Value = value; }
        }

        public Int16 SHght1Unit
        {
            get { return m_SHght1Unit.GetInt16(); }
            set { m_SHght1Unit.Value = value; }
        }

        public Decimal SLength1
        {
            get { return m_SLength1.GetDecimal(); }
            set { m_SLength1.Value = value; }
        }

        public Int16 SLen1Unit
        {
            get { return m_SLen1Unit.GetInt16(); }
            set { m_SLen1Unit.Value = value; }
        }

        public Decimal SWidth1
        {
            get { return m_SWidth1.GetDecimal(); }
            set { m_SWidth1.Value = value; }
        }

        public Int16 SWdth1Unit
        {
            get { return m_SWdth1Unit.GetInt16(); }
            set { m_SWdth1Unit.Value = value; }
        }

        public Decimal SVolume
        {
            get { return m_SVolume.GetDecimal(); }
            set { m_SVolume.Value = value; }
        }

        public Int16 SVolUnit
        {
            get { return m_SVolUnit.GetInt16(); }
            set { m_SVolUnit.Value = value; }
        }

        public Decimal SWeight1
        {
            get { return m_SWeight1.GetDecimal(); }
            set { m_SWeight1.Value = value; }
        }

        public Int16 SWght1Unit
        {
            get { return m_SWght1Unit.GetInt16(); }
            set { m_SWght1Unit.Value = value; }
        }

        public string SuppCatNum
        {
            get { return m_SuppCatNum.GetString(); }
            set { m_SuppCatNum.Value = value; }
        }

        public eYesNo ByWh
        {
            get { return m_ByWh.GetString().ToYesNoEnum(); }
            set { m_ByWh.Value = value.ToYesNoString(); }
        }

        public Decimal LastPurPrc
        {
            get { return m_LastPurPrc.GetDecimal(); }
            set { m_LastPurPrc.Value = value; }
        }

        public Int32 FirmCode
        {
            get { return m_FirmCode.GetInt32(); }
            set { m_FirmCode.Value = value; }
        }

        public Int32 LeadTime
        {
            get { return m_LeadTime.GetInt32(); }
            set { m_LeadTime.Value = value; }
        }

        public eYesNo ManBtchNum
        {
            get { return m_ManBtchNum.GetString().ToYesNoEnum(); }
            set { m_ManBtchNum.Value = value.ToYesNoString(); }
        }

        public string SWW
        {
            get { return m_SWW.GetString(); }
            set { m_SWW.Value = value; }
        }

        public string UserText
        {
            get { return m_UserText.GetString(); }
            set { m_UserText.Value = value; }
        }

        public Int32 ProductSrc
        {
            get { return m_ProductSrc.GetInt32(); }
            set { m_ProductSrc.Value = value; }
        }

        public Int32 NCMCode
        {
            get { return m_NCMCode.GetInt32(); }
            set { m_NCMCode.Value = value; }
        }

        public Decimal SalPackUn
        {
            get { return m_SalPackUn.GetDecimal(); }
            set { m_SalPackUn.Value = value; }
        }

        public Decimal OnHand
        {
            get { return m_OnHand.GetDecimal(); }
            set { m_OnHand.Value = value; }
        }

        public string CodeBars
        {
            get { return m_CodeBars.GetString(); }
            set { m_CodeBars.Value = value; }
        }

        public ItemClassType ItemClass
        {
            get { return (ItemClassType)m_ItemClass.GetString().To<int>(); }
            set { m_ItemClass.Value = value.To<int>().ToString(); }
        }

        public String CardCode
        {
            get { return m_CardCode.GetString(); }
            set { m_CardCode.Value = value; }
        }

        public Int32 OSvcCode
        {
            get { return m_OSvcCode.GetInt32(); }
            set { m_OSvcCode.Value = value; }
        }

        public Int32 ISvcCode
        {
            get { return m_ISvcCode.GetInt32(); }
            set { m_ISvcCode.Value = value; }
        }

        public eYesNo ManSerNum
        {
            get { return m_ManSerNum.GetString().ToYesNoEnum(); }
            set { m_ManSerNum.Value = value.ToYesNoString(); }
        }

        public String InvntryUom
        {
            get { return m_InvntryUom.GetString(); }
            set { m_InvntryUom.Value = value; }
        }

        public String BuyUnitMsr
        {
            get { return m_BuyUnitMsr.GetString(); }
            set { m_BuyUnitMsr.Value = value; }
        }

        public String MatType
        {
            get { return m_MatType.GetString(); }
            set { m_MatType.Value = value; }
        }

        public decimal BVolume
        {
            get { return m_BVolume.GetDecimal(); }
            set { m_BVolume.Value = value; }
        }

        public decimal BWeight1
        {
            get { return m_BWeight1.GetDecimal(); }
            set { m_BWeight1.Value = value; }
        }

        public Int32 FuelCode
        {
            get { return m_FuelCode.GetInt32(); }
            set { m_FuelCode.Value = value; }
        }

        /// <summary>
        /// Pega o objeto pela chave
        /// </summary>
        /// <param name="pItemCode">Código do item</param>
        /// <returns></returns>
        public bool GetByKey(string pItemCode)
        {
            this.ItemCode = pItemCode;
            return base.GetByKey();
        }



        /// <summary>
        /// Pega todos os registros da base
        /// </summary>
        /// <returns>Lista de Objetos</returns>
        public List<Item> GetAll()
        {
            return FillCollection<Item>();
        }

    }
}
