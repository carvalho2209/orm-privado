using Nampula.Framework;
using System;
using SAPbobsCOM;
using Nampula.UI.DataServeAccess.Exceptions;

namespace Nampula.UI.SqlUserLoggin
{
    internal class UserRepository
    {
        private SAPbobsCOM.Company _sboCompany;
        private const string _tableUserName = "IN_DATAUSER";
        private const string _recordId = "USERID";
        private const string _userNameFieldName = "Field1";
        private const string _passwordFIeldName = "Field2";
        private PasswordEncrypter _userService = new PasswordEncrypter();
        private string _installationId;

        public UserRepository(SAPbobsCOM.Company company, string installationId)
        {
            _installationId = installationId;
            _sboCompany = company;
        }

        public bool ExistsTable()
        {

            var userTable = _sboCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserTables) as SAPbobsCOM.UserTablesMD;

            try
            {
                return userTable.GetByKey(_tableUserName);
            }
            finally
            {
                if (userTable != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(userTable);
            }

        }

        public void CreateTable()
        {
            CreateUserTable();
            AddFieldsUserName(_userNameFieldName);
            AddFieldsUserName(_passwordFIeldName);
        }

        private void CreateUserTable()
        {
            var userTable = _sboCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserTables) as SAPbobsCOM.UserTablesMD;

            try
            {
                userTable.TableName = _tableUserName;
                userTable.TableDescription = "INV: User Table Loggin";

                if (userTable.Add() == 0)
                    return;

                var message = "Erro ao criar nova tabela de usuário. [{0}] - [{1}:{2}]"
                    .Fmt(_tableUserName, _sboCompany.GetLastErrorCode(), _sboCompany.GetLastErrorDescription());

                throw new CreateDataUserException(message);
            }
            finally
            {
                if (userTable != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(userTable);
            }
        }

        public void AddFieldsUserName(string fieldName)
        {

            var userFieldName = _sboCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserFields) as SAPbobsCOM.UserFieldsMD;

            try
            {
                userFieldName.TableName = _tableUserName;
                userFieldName.Name = fieldName;
                userFieldName.Description = fieldName;
                userFieldName.Type = SAPbobsCOM.BoFieldTypes.db_Memo;

                if (userFieldName.Add() == 0)
                    return;

                var message = "Erro ao criar campo de usuário . [{0}:{1}] - [{2}:{3}]"
                    .Fmt(_tableUserName, fieldName, _sboCompany.GetLastErrorCode(), _sboCompany.GetLastErrorDescription());

                throw new Exception(message);
            }
            finally
            {
                if (userFieldName != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(userFieldName);
            }

        }

        public void Save(UserFieldsData user)
        {
            var userTableItem = _sboCompany.UserTables.Item(_tableUserName);

            try
            {

                var isUpdate = userTableItem.GetByKey(_recordId);

                userTableItem.Code = _recordId;
                userTableItem.Name = user.UserName;
                userTableItem.UserFields.Fields.Item("U_{0}".Fmt(_userNameFieldName)).Value = user.UserName;
                userTableItem.UserFields.Fields.Item("U_{0}".Fmt(_passwordFIeldName)).Value = _userService.GetEncryptUserPassword(user.PassWord, _installationId);

                var saveResult = isUpdate
                    ? userTableItem.Update()
                    : userTableItem.Add();

                if (saveResult == 0)
                    return;

                var message = "Erro ao salvar os dados do usuário. [{0}]  - [{1}:{2}]"
                    .Fmt(user.UserName, _sboCompany.GetLastErrorCode(), _sboCompany.GetLastErrorDescription());

                throw new Exception(message);
                
            }
            finally
            {
                if (userTableItem != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(userTableItem);
            }

        }

        public UserFieldsData GetUser()
        {
            var userTableItem = _sboCompany.UserTables.Item(_tableUserName);

            try
            {
                var _user = new UserFieldsData();

                if (!userTableItem.GetByKey(_recordId))
                    return _user;

                _user.UserName = (string)userTableItem.UserFields.Fields.Item(0).Value;
                _user.PassWord = _userService.GetDencryptUserPassword((string)userTableItem.UserFields.Fields.Item(1).Value, _installationId);

                return _user;
            }
            finally
            {
                if (userTableItem != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(userTableItem);
            }

        }


    }
}
