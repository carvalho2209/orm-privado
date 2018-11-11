using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI.B1;
using Nampula.DI.B1.UserPermissions;
using Nampula.Framework;
using Nampula.DI.B1.Users;
using Nampula.DI.B1.Helpers;
using Nampula.DI.B1.Version;

namespace Nampula.UI.Permissions
{
    /// <summary>
    /// Gerenciamento de Permissões de Acessos
    /// </summary>
    public static class Permission
    {
        /// <summary>
        /// Verifica se o usuário conectado tem acesso ao recurso
        /// </summary>
        /// <exception cref="Exception">Caso o usuário não tiver autorização dispara uma exçecão</exception>
        /// <param name="pPermId">ID da Permissão</param>
        /// <param name="accessRequest">Permissão requerida</param>
        /// <param name="throwException">Gera Exceção</param>
        public static bool HasPermission(string pPermId, PermissionType accessRequest, bool throwException = true)
        {
            var companyDb = Application.GetInstance().Company.DatabaseName;
            var username = Application.GetInstance().Company.UserName;

            return HasPermission(pPermId, accessRequest, username, companyDb, throwException);
        }

        /// <summary>
        /// Verifica se o usuário tem acesso ao recurso
        /// </summary>
        /// <exception cref="Exception">Caso o usuário não tiver autorização dispara uma exçecão</exception>
        /// <param name="pPermId">ID da Permissão</param>
        /// <param name="accessRequest">Permissão requerida</param>
        /// <param name="userName">Empresa</param>
        /// <param name="companyDb">Banco de dados da empresa</param>
        /// <param name="throwException">Gera Exceção</param>
        public static bool HasPermission(string pPermId, PermissionType accessRequest, string userName,
                                          string companyDb, bool throwException = true)
        {
            var user = B1Helper.GetUser(userName, companyDb);

            if (user.SUPERUSER == eYesNo.Yes)
                return true;

            var permi = new UserAuthorization(companyDb);
            var hasPermission = false;

            if (permi.GetByKey(user.InternalK, pPermId))
            {
                switch (accessRequest)
                {
                    case PermissionType.Full:
                        hasPermission = permi.Permission == PermissionType.Full;
                        break;
                    case PermissionType.ReadOnly:
                        hasPermission = permi.Permission != PermissionType.None;
                        break;
                }
            }

            if (!hasPermission && SboVersion.EqualOrMoreThenSap91Pl04())
            {
                var groupUserAssociation = new GroupUserAssociation(companyDb);
                if (groupUserAssociation.GetByKey(user.UserId))
                {
                    var groupAuthorization = new GroupAuthorization(companyDb);
                    if (groupAuthorization.GetByKey(groupUserAssociation.GroupId, pPermId))
                    {
                        switch (accessRequest)
                        {
                            case PermissionType.Full:
                                hasPermission = groupAuthorization.Permission == PermissionType.Full;
                                break;
                            case PermissionType.ReadOnly:
                                hasPermission = groupAuthorization.Permission != PermissionType.None;
                                break;
                        }
                    }
                }
            }

            if (!hasPermission && throwException)
                throw new Exception("Usuário não tem permissão para acessar esse recurso !");

            return hasPermission;
        }

        /// <summary>
        /// Verifica se é necessáiro adicionar permissões do usuário no SAP
        /// se existirem adiciona novas
        /// </summary>
        /// <param name="pAutorizations">A autorização raiz da aplicação</param>
        public static void CheckForNewPermission(UserAutorizationTree pAutorizations)
        {
            CheckForNewPermission(new List<UserAutorizationTree>() { pAutorizations });
        }

        /// <summary>
        /// Verifica se é necessáiro adicionar permissões do usuário no SAP
        /// se existirem adiciona novas
        /// </summary>
        /// <param name="pAutorizations">Uma lista de autorizações</param>
        public static void CheckForNewPermission(List<UserAutorizationTree> pAutorizations)
        {
            string companyDb = Application.GetInstance().Company.DatabaseName;

            foreach (var autorizarion in pAutorizations)
            {
                var autoExists = new UserAutorizationTree(companyDb);

                if (!autoExists.GetByKey(autorizarion.AbsID))
                {
                    Add(autorizarion);
                }

                if (!Equals(autoExists.Name, autorizarion.Name))
                {
                    UpdateName(autorizarion);
                }

                if (!autorizarion.Children.IsEmpty())
                {
                    autorizarion.Children.ForEach(a => a.FathID = autorizarion.AbsID);
                    CheckForNewPermission(autorizarion.Children);
                }
            }
        }

        private static void UpdateName(UserAutorizationTree autorizarion)
        {
            if (Application.GetInstance().AppType != eAppType.SAPForms)
                throw new Exception("Aplicação não da suporte a atualização de autorizações!");

            if (SboCompany == null)
                SboCompany = ApplicationSAP.GetInstance().SAPApp.Company.GetDICompany() as SAPbobsCOM.Company;

            var userTree = SboCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserPermissionTree) as SAPbobsCOM.UserPermissionTree;

            if (!userTree.GetByKey(autorizarion.AbsID))
                return;

            userTree.Name = autorizarion.Name;

            if (userTree.Update() != 0)
                throw new Exception(
                    "Erro ao tentar atualizar a autorização :\n{0} - {1}".Fmt(
                    SboCompany.GetLastErrorCode(),
                    SboCompany.GetLastErrorDescription()));
        }        

        private static SAPbobsCOM.Company SboCompany { get; set; }

        private static void Add(UserAutorizationTree pAutorization)
        {
            if (Application.GetInstance().AppType != eAppType.SAPForms)
                throw new Exception("Aplicação não da suporte a adição de autorizações!");

            if (pAutorization.Name.Length > 64)
            {
                var message = string.Format("A   autorização [{0}-{1}] tem mais que 64 caracteres.",
                    pAutorization.AbsID, pAutorization.Name);
                throw new Exception(message);
            }

            if (SboCompany == null)
                SboCompany = ApplicationSAP.GetInstance().SAPApp.Company.GetDICompany() as SAPbobsCOM.Company;

            var userTree = SboCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserPermissionTree) as SAPbobsCOM.UserPermissionTree;


            userTree.PermissionID = pAutorization.AbsID;
            userTree.ParentID = pAutorization.FathID;
            userTree.Name = pAutorization.Name;
            userTree.IsItem = pAutorization.IsItem == eYesNo.Yes ? SAPbobsCOM.BoYesNoEnum.tYES : SAPbobsCOM.BoYesNoEnum.tNO;
            userTree.Options = (SAPbobsCOM.BoUPTOptions)pAutorization.Options.To<Int32>();

            if (userTree.Add() != 0)
                throw new Exception(
                    "Erro ao tentar adicionar a autorização :\n{0} - {1}".Fmt(
                    SboCompany.GetLastErrorCode(),
                    SboCompany.GetLastErrorDescription()));
        }

    }
}
