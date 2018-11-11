

using System.Drawing.Printing;
using Nampula.DI;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using SAPbobsCOM;

namespace Nampula.UI.SqlUserLoggin
{
    /// <summary>
    /// Provedor e atualizador de usuários de conexão com o banco de dados
    /// </summary>
    internal class SqlUserProvider
    {
        private UserRepository _userRepository;
        private SAPbobsCOM.Company _sboCompany;
        private string _installationId;


        /// <summary>
        /// Construtor Padrão do Provedor de SqlServer Login
        /// </summary>
        /// <param name="sboCompany">Classe de Conexão com o SAP</param>
        public SqlUserProvider(SAPbobsCOM.Company sboCompany, string installationId)
        {
            _sboCompany = sboCompany;
            _installationId = installationId;
            _userRepository = new UserRepository(_sboCompany, _installationId);
        }

        public void UpdateSqlUserLoggin()
        {
            var user = new UserFieldsData();

            var userFieldDataForm = new UserFieldsDataForm(user, this);

            if (userFieldDataForm.ShowDialog() != DialogResult.OK)
            {
                return;
                //throw new Exception("Não foi possível alterar os dados de conexão do banco de dados.");
            }

            _userRepository.Save(user);

        }

        public void SetOrCreateSqlUserLoggin()
        {
            var user = new UserFieldsData();

            if (ThereIsUserSaved(out user) && TestConnection(user))
            {
                return;
            }

            var userFieldDataForm = new UserFieldsDataForm(user, this);

            if (userFieldDataForm.ShowDialog() != DialogResult.OK)
            {
                throw new Exception("Não foi possível conectar ao banco de dados.");
            }

            _userRepository.Save(user);
        }

        private void CreateTableIfNotExists()
        {
            if (!_userRepository.ExistsTable())
                _userRepository.CreateTable();
        }

        public bool TestConnection(UserFieldsData user = null)
        {
            try
            {
                var connectionClone = Connection.Instance;

                CreateTableIfNotExists();

                user = user ?? _userRepository.GetUser();

                connectionClone.ConnectionParameter.DBUser = user.UserName;
                connectionClone.ConnectionParameter.DBPassword = user.PassWord;
                connectionClone.ConnectionParameter.Server = _sboCompany.Server;
                connectionClone.ConnectionParameter.CompanyDb = _sboCompany.CompanyDB;
                connectionClone.ConnectionParameter.UserName = _sboCompany.UserName;

                return connectionClone.Connect();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
                //Debug.Fail("ERRO AO TENTAR LOGAR NO SQL SERVER",ex.ToString());
                return false;
            }
            finally
            {
                var connectionClone = Connection.Instance;

                var userSaved = GetParam(null);

                connectionClone.ConnectionParameter.DBUser = userSaved.DBUser;
                connectionClone.ConnectionParameter.DBPassword = userSaved.DBPassword;
            }

        }

        public bool ThereIsUserSaved(out UserFieldsData user)
        {
            CreateTableIfNotExists();

            user = _userRepository.GetUser();

            return !string.IsNullOrEmpty(user.UserName);
        }

        public void SaveUser(UserFieldsData user)
        {
            CreateTableIfNotExists();

            _userRepository.Save(user);
        }

        public ConnectionParameter GetParam(UserFieldsData user = null)
        {

            CreateTableIfNotExists();

            user = user ?? _userRepository.GetUser();

            var param = Connection.Instance.ConnectionParameter;

            param.Server = _sboCompany.Server;
            param.DBUser = user.UserName;
            param.DBPassword = user.PassWord;
            param.CompanyDb = _sboCompany.CompanyDB;
            param.UserName = _sboCompany.UserName;

            return param;
        }


    }
}
