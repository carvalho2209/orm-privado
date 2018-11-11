using System;
using Nampula.UI.Permissions;
using Nampula.DI.B1.UserPermissions;
using Nampula.DI.B1;

namespace NampulaDemo
{
    public class Security
    {
        public static readonly string RouteNamespace = "RT";
        public static readonly string Packinlist = String.Format("{0}_{1}", RouteNamespace, "PL");
        public static readonly string PackinlistAdd = String.Format("{0}_{1}", Packinlist, 001);
        public static readonly string PackinlistEdit = String.Format("{0}_{1}", Packinlist, 002);
        public static readonly string PackinlistRemove = String.Format("{0}_{1}", Packinlist, 003);

        public Security()
        {
            Permission.CheckForNewPermission( GetApplicationAutorTree());
        }

        private UserAutorizationTree GetApplicationAutorTree()
        {

            var route = new UserAutorizationTree()
            {
                AbsID = RouteNamespace,
                Name = "Roterizador",
                Options = OptionsType.FullNone
            };

            #region PackingList
            var rom = new UserAutorizationTree()
            {
                AbsID = Packinlist,
                Name = "Romaneio",
                Options = OptionsType.FullNone
            };

            rom.Children.Add(
                new UserAutorizationTree()
                {
                    AbsID = PackinlistRemove,
                    Name = "Remover",
                    Options = OptionsType.FullNone,
                    IsItem = eYesNo.Yes
                });

            rom.Children.Add(
                new UserAutorizationTree()
                {
                    AbsID = PackinlistEdit,
                    Name = "Editar",
                    Options = OptionsType.FullNone,
                    IsItem = eYesNo.Yes
                });

            rom.Children.Add(
                new UserAutorizationTree()
                {
                    AbsID = PackinlistAdd,
                    Name = "Adicionar",
                    Options = OptionsType.FullNone,
                    IsItem = eYesNo.Yes
                });

            route.Children.Add(rom);
            #endregion

            return route;
        }
    }
}
