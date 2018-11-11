using Nampula.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.UI.SqlUserLoggin
{
    /// <summary>
    /// Dados do Usuário
    /// </summary>
    internal class UserFieldsData
    {
        /// <summary>
        /// Dados do Usuário
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Senha do Usuário
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// Valida os campos de usuário e senha
        /// </summary>
        public void Validate()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                throw new Exception("Informe o usuário!");
            }

            if (string.IsNullOrEmpty(PassWord))
            {
                throw new Exception("Informe a senha!");
            }

            if (UserName.Length > 60)
            {
                throw new Exception("Usuário não pode ter mais de 60 caracteres!");
            }

            if (PassWord.Length > 60)
            {
                throw new Exception("Senha não pode ter mais de 60 caracteres!");
            }

        }
    }
}
