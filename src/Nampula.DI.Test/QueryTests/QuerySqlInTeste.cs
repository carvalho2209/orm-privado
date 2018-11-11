using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Nampula.DI.ScriptWizard;
using NUnit.Framework;

namespace Nampula.DI.Test.QueryTests
{
    [TestFixture]
    public class QuerySqlInTeste
    {

        private readonly SqlServerScriptWizard _scriptWizard = new SqlServerScriptWizard();

        [Test]
        public void Deve_Permitir_Consultar_Sql_In()
        {
            Criar20Registros();
            var fakeTable = DbTesteNampula.CreateObject<FakeTableForQuery>();
            var tableQuery = new TableQuery(fakeTable);

            tableQuery.Where.Add(
                new QueryParam(fakeTable.Collumns["Id"], eCondition.ecIn, new[] { 1, 2 }));

            var resultOfConsult = _scriptWizard.GetSelectComplexStatment(tableQuery);

            Console.WriteLine("Query : \n{0}", resultOfConsult.Item1);

            Console.WriteLine("Parameters : ");

            foreach (var paramter in resultOfConsult.Item2)
            {
                Console.WriteLine("{0}:{1}", paramter.Name, paramter.Value);
            }

            var data = fakeTable.FillCollection<FakeTableForQuery>(tableQuery);

            Assert.AreEqual(2, data.Count);
            Assert.AreEqual(1, data[0].Id);
            Assert.AreEqual(2, data[1].Id);
        }

        [Test]
        public void Deve_Permitir_Consultar_Sql_Not_In()
        {
            Criar20Registros();
            var fakeTable = DbTesteNampula.CreateObject<FakeTableForQuery>();
            var tableQuery = new TableQuery(fakeTable);

            tableQuery.Where.Add(
                new QueryParam(fakeTable.Collumns["Id"], eCondition.ecNotIn, new[] { 1, 2 }));

            var resultOfConsult = _scriptWizard.GetSelectComplexStatment(tableQuery);

            Console.WriteLine("Query : \n{0}", resultOfConsult.Item1);

            Console.WriteLine("Parameters : ");

            foreach (var paramter in resultOfConsult.Item2)
            {
                Console.WriteLine("{0}:{1}", paramter.Name, paramter.Value);
            }

            var data = fakeTable.FillCollection<FakeTableForQuery>(tableQuery);

            Assert.AreEqual(18, data.Count);
            Assert.AreEqual(false, data.Any(c=> c.Id == 1));
            Assert.AreEqual(false, data.Any(c=> c.Id == 2));
        }

        [Test]
        public void Passar_Listas_Vazias_Para_Sql_In_Nao_Deve_Retornar_Nenhum_Registro()
        {
            Criar20Registros();

            var fakeTable = DbTesteNampula.CreateObject<FakeTableForQuery>();
            var tableQuery = new TableQuery(fakeTable);

            tableQuery.Where.Add(
                new QueryParam(fakeTable.Collumns["Id"], eCondition.ecIn, new object[] {}));

            var resultOfConsult = _scriptWizard.GetSelectComplexStatment(tableQuery);

            Console.WriteLine("Query : \n{0}", resultOfConsult.Item1);
            Console.WriteLine("Parameters : ");

            foreach (var paramter in resultOfConsult.Item2)
            {
                Console.WriteLine("{0}:{1}", paramter.Name, paramter.Value);
            }

            var data = fakeTable.FillCollection<FakeTableForQuery>(tableQuery);

            Assert.AreEqual(0, data.Count);
        }

        [Test]
        public void Passar_Listas_Vazias_Para_Sql_NotIn_Nao_Deve_Retornar_Nenhum_Registro()
        {
            Criar20Registros();

            var fakeTable = DbTesteNampula.CreateObject<FakeTableForQuery>();
            var tableQuery = new TableQuery(fakeTable);

            tableQuery.Where.Add(
                new QueryParam(fakeTable.Collumns["Id"], eCondition.ecNotIn, new object[] { }));

            var resultOfConsult = _scriptWizard.GetSelectComplexStatment(tableQuery);

            Console.WriteLine("Query : \n{0}", resultOfConsult.Item1);

            Console.WriteLine("Parameters : ");

            foreach (var paramter in resultOfConsult.Item2)
            {
                Console.WriteLine("{0}:{1}", paramter.Name, paramter.Value);
            }

            var data = fakeTable.FillCollection<FakeTableForQuery>(tableQuery);

            Assert.AreEqual(20, data.Count);

            fakeTable = DbTesteNampula.CreateObject<FakeTableForQuery>();
            tableQuery = new TableQuery(fakeTable);

            tableQuery.Where.Add(
                new QueryParam(fakeTable.Collumns["Id"], eCondition.ecNotIn, null));            

            data = fakeTable.FillCollection<FakeTableForQuery>(tableQuery);

            Assert.AreEqual(20, data.Count);
        }

        private void Criar20Registros()
        {
            Connection.Instance.SqlServerExecute("DELETE FROM DbTesteNampula..FakeTableForQuery");

            foreach (var i in Enumerable.Range(1,20))
            {
                var fakeTable = DbTesteNampula.CreateObject<FakeTableForQuery>();
                fakeTable.Id = i;
                fakeTable.Description = "Teste " + i;
                fakeTable.Add();   
            }            
        }
    }
}
