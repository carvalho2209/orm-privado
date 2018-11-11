using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using Nampula.Framework;

namespace Nampula.UI.Helpers.Extentions
{

    /// <summary>
    /// Utilidades para o objeto ComboBox
    /// </summary>
    public static class ComboBoxExtention
    {

        /// <summary>
        /// Preenche o combobox com os valores de uma tabela de dominio
        /// </summary>
        /// <typeparam name="t">Um TableDomainTbale</typeparam>
        /// <param name="pComboBox">Um combobox</param>
        /// <param name="pDB">Objeto do Banco de dados</param>
        /// <param name="pSelect">Registro que será selecionado por padrão</param>
        public static void FillValues<t, e> ( this Nampula.UI.ComboBox pComboBox, DataBaseAdapter pDB, e pSelect )
            where t : TableAdapterDomain<e>, new( )
        {
            pComboBox.ValidValues.Clear( );

            FillValues<t>(
                pComboBox, pDB,
                TableAdapterDomain<e>.FieldsName.ID,
                TableAdapterDomain<e>.FieldsName.Description,
                pSelect.To<Int32>( ) );
        }

        /// <summary>
        /// Preenche o combobox com os valores de uma tabela ja instanciada e selecione o primeiro registro caso existir
        /// </summary>
        /// <typeparam name="t">Um TableAdapter</typeparam>
        /// <param name="pComboBox">Um combobox</param>
        /// <param name="pDB">Objeto do Banco de dado</param>
        /// <param name="pKey">Nome do Campo chave</param>
        /// <param name="pName">Descrição do Campo chave</param>
        /// <param name="pValue">Valor padrão</param>
        public static void FillValues<t> ( this Nampula.UI.ComboBox pComboBox, DataBaseAdapter pDB, string pKey, string pName, object pValue )
            where t : TableAdapter, new( )
        {            

            var table = pDB.CreateObject<t>( );
            var list = table.FillCollection<t>( table.GetData( ).Rows );

            pComboBox.ValidValues.Clear( );

            foreach ( var item in list )
            {
                pComboBox.ValidValues.Add(
                    item.Collumns[pKey].Value, item.Collumns[pName].GetString( ) );
            }

            if (pValue != null && !String.IsNullOrEmpty(pValue.ToString()))
                pComboBox.Select( pValue, BoSearchKey.psk_ByValue );
            else if ( pComboBox.ValidValues.Count > 0 )
                pComboBox.Select( 0, BoSearchKey.psk_Index );

        }

        /// <summary>
        /// Preenche o combobox 
        /// </summary>
        /// <typeparam name="t">Um TableAdapter do B1</typeparam>
        /// <param name="pComboBox">Um combobox</param>
        /// <param name="pCompanyDb">Nome do banco de dados</param>
        /// <param name="pKey">Nome do Campo chave</param>
        /// <param name="pName">Descrição do Campo chave</param>
        /// <param name="pValue">Valor padrão</param>
        public static void FillValues<t> ( this Nampula.UI.ComboBox pComboBox, string pCompanyDb, string pKey, string pName, object pValue )
            where t : TableAdapter, new( )
        {

            pComboBox.ValidValues.Clear();

            t pTable = new t( ) { DBName = pCompanyDb };

            foreach ( var item in pTable.FillCollection<t>( pTable.GetData( ).Rows ) )
            {
                pComboBox.ValidValues.Add(
                    item.Collumns[pKey].Value, item.Collumns[pName].GetString( ) );
            }

            if ( pValue != null && !String.IsNullOrEmpty(pValue.ToString()) )
                pComboBox.Select( pValue, BoSearchKey.psk_ByValue );
            else if ( pComboBox.ValidValues.Count > 0 )
                pComboBox.Select( 0, BoSearchKey.psk_Index );
        }

        /// <summary>
        /// /Preenche um comboox apartir de um enum
        /// </summary>
        /// <param name="pComboBox">Um vomboBox</param>
        /// <param name="pList">UMa lista de tipos</param>
        public static void FillValues ( this Nampula.UI.ComboBox pComboBox, Dictionary<object, string> pList, object pValue )
        {
            pComboBox.ValidValues.Clear();

            foreach ( var item in pList )
                pComboBox.ValidValues.Add( item.Key, item.Value );

            if (pValue != null && !String.IsNullOrEmpty(pValue.ToString()))
                pComboBox.Select( pValue, BoSearchKey.psk_ByValue );
            else if ( pComboBox.ValidValues.Count > 0 )
                pComboBox.Select( 0, BoSearchKey.psk_Index );
        }

    }

}
