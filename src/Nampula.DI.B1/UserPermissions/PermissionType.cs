using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.UserPermissions
{
    
    /// <summary>
    /// Tipos de permissões
    /// </summary>
    public enum PermissionType
    {
        None,
        Various,
        Full,
        ReadOnly,
        UndifinedType
    }
    

    
    /// <summary>
    /// Conversões do Enumerador PermissionType para string
    /// </summary>
    public static class PermissionTypeClass
    {

        
        private const string none = "N";
        private const string various = "V";
        private const string full = "F";
        private const string readOnly = "R";
        private const string undifinedType = "U";
        

        
        /// <summary>
        /// Converte o enum PermissionType para a string do banco
        /// </summary>
        /// <param name="pPermission">Um Enum</param>
        /// <returns>Um String </returns>
        public static string ToPermString ( this PermissionType pPermission )
        {
            switch ( pPermission )
            {
                case PermissionType.Various:
                    return various;
                case PermissionType.Full:
                    return full;
                case PermissionType.ReadOnly:
                    return readOnly;
                case PermissionType.UndifinedType:
                    return undifinedType;
                case PermissionType.None:
                default:
                    return none;
            }
        }
        

        
        /// <summary>
        /// Convert um string com o valor N,V,F,R ou U em um enumerador PermissionType
        /// </summary>
        /// <param name="pPermission">um string</param>
        /// <returns>Um Enumerador PermissionType</returns>
        public static PermissionType ToPermEnum ( this string pPermission )
        {
            switch ( pPermission )
            {
                case various:
                    return PermissionType.Various;
                case full:
                    return PermissionType.Full;
                case readOnly:
                    return PermissionType.ReadOnly;
                case undifinedType:
                    return PermissionType.UndifinedType;
                case none:
                default:
                    return PermissionType.None;
            }
        }
        

    }
    
}
