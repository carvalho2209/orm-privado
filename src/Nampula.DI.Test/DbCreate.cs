using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Nampula.DI.Test
{
    [SetUpFixture]
    public class DbCreate
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            // ...
            Console.WriteLine("Inicio");
            
            Connection.Instance.ConnectionParameter.Server = @"localhost\Fullfit";
            Connection.Instance.ConnectionParameter.UserName = "ontime";
            Connection.Instance.ConnectionParameter.UserName = "timeon";

            var db = new DbTesteNampula();

            //Connection.Instance.SqlServerExecute(
            //            string.Format("DELETE FROM [{0}]..[AppVersion]", db.DataBaseName));

            try
            {
                Connection.Instance.SqlServerExecute(
                        string.Format("DROP DATABASE {0}", db.DataBaseName));

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exceção ao deletar versões das tabelas: {0}", ex.Message);
            }

            db.Start(Connection.Instance.ConnectionParameter);            
        }

        [TearDown]
        public void RunAfterAnyTests()
        {            
            // ...
            Console.WriteLine("Término");
        }

    }
}
