using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Nampula.DI.Logs;
using SharpTestsEx;

namespace Nampula.DI.Test.LogsTestes
{
    [TestFixture]
    public class Teste_de_Analise_De_Difrencas_Entre_Instancias_Log
    {
        private FakeTableWithLogWithThreFields _tableWithlog;
        private List<LogDifferences> _differenceses;
        private TableAdapter _tableWith2Keys;

        [Test]
        public void Deve_retornar_a_diferenca_entre_a_primeira_instancia_e_a_ultima()
        {
            Dado_uma_tabela_com_log_de_2_instancias();
            Quando_pedir_para_analisar_as_duas_instancia();
            Deve_retornar_a_diferenca_entre_as_duas_instancias_no_campo_descricao();
        }

        [Test]
        public void Deve_retornar_a_diferenca_entre_2_campos()
        {
            Dado_uma_tabela_com_log_de_2_instancias_com_data();
            Quando_pedir_para_analisar_as_duas_instancia();
            Deve_retornar_a_diferenca_entre_as_duas_instancias_no_campo_descricao_e_data();
        }

        [Test]
        public void Nao_deve_retornar_um_campo_que_nao_foi_alterado()
        {
            Dado_uma_tabela_com_log_de_2_instancias();
            Quando_pedir_para_analisar_as_duas_instancia();
            Deve_retornar_somente_diferenca_de_descricao();
        }

        [Test]
        public void Deve_armazenar_permitir_armazenar_diferencas_entre_registro_quando_houver_mais_de_uma()
        {
            Dado_uma_tabela_com_mais_de_uma_chave_e_log_ativado();
            Quando_adicionar_ou_atualizar_registro_base();
            Deve_armazenar_os_valores_das_duas_chaves_divido_por_tab();
        }

        private void Deve_armazenar_os_valores_das_duas_chaves_divido_por_tab()
        {
            var tableLog = _tableWith2Keys.TableAdapterLog.GetByBaseId();

            tableLog.Rows.Count.Should().Be.EqualTo(2);

            var tabKeyChar = Convert.ToChar(9);

            tableLog.Rows[0].Field<string>(TableAdapterLog.FieldsName.BaseIdLog)
                .Should()
                .StartWith("1")
                .And
                .Contain(tabKeyChar.ToString(CultureInfo.InvariantCulture))
                .And
                .EndWith("2");

            _differenceses =_tableWith2Keys.TableAdapterLog.GetDiff(tableLog, tableLog.Rows[0], tableLog.Rows[1]);
                 
            _differenceses.Count.Should().Be.EqualTo(1);

            var first = _differenceses.First();

            first.Instance.Should().Be.EqualTo(2);
            first.Date.ToShortTimeString().Should().Not.Be.Empty();
            first.MachineName.Should().Be.EqualTo(Environment.MachineName);
            first.UserName.Should().Be.EqualTo(_tableWith2Keys.Connection.ConnectionParameter.UserName);
            first.FieldName.Should().Be.EqualTo("Record");
            first.OldValue.Should().Be.EqualTo("Teste 1");
            first.NewValue.Should().Be.EqualTo("Fabio Teste 2");
        }

        private void Quando_adicionar_ou_atualizar_registro_base()
        {
            _tableWith2Keys.Collumns["Record"].Value = "Teste 1";
            _tableWith2Keys.Collumns["Key1"].Value = "1";
            _tableWith2Keys.Collumns["Key2"].Value = "2";
            _tableWith2Keys.Add();

            _tableWith2Keys.Collumns["Record"].Value = "Fabio Teste 2";
            _tableWith2Keys.Update();
        }

        private void Dado_uma_tabela_com_mais_de_uma_chave_e_log_ativado()
        {
            _tableWith2Keys = new TableAdapter(new DbTesteNampula().DataBaseName,"Fke2Keys");
            _tableWith2Keys.Collumns.Add(new TableAdapterField("Key1", "Key1", DbType.Int32, 11, null, true, false));
            _tableWith2Keys.Collumns.Add(new TableAdapterField("Key2", "Key2", DbType.Int32, 11, null, true, false));
            _tableWith2Keys.Collumns.Add(new TableAdapterField("Record", "Record", 120));

            _tableWith2Keys.KeyFields.Add(_tableWith2Keys.Collumns[0]);
            _tableWith2Keys.KeyFields.Add(_tableWith2Keys.Collumns[1]);

            _tableWith2Keys.SetAutoLog();

            _tableWith2Keys.Create();

        }

        private void Deve_retornar_somente_diferenca_de_descricao()
        {
            _differenceses.Single().FieldName.Should().Be.EqualTo("Descrição");
        }

        private void Deve_retornar_a_diferenca_entre_as_duas_instancias_no_campo_descricao()
        {
            _differenceses.Count.Should().Be.EqualTo(1);

            var first = _differenceses.First();

            first.Instance.Should().Be.EqualTo(2);
            first.Date.ToShortTimeString().Should().Not.Be.Empty();
            first.MachineName.Should().Be.EqualTo(Environment.MachineName);
            first.UserName.Should().Be.EqualTo(_tableWithlog.Connection.ConnectionParameter.UserName);
            first.FieldName.Should().Be.EqualTo("Descrição");
            first.OldValue.Should().Be.EqualTo("Fábio Oliveira");
            first.NewValue.Should().Be.EqualTo("Fabio Nascimento 2");
        }

        private void Quando_pedir_para_analisar_as_duas_instancia()
        {
            var tableLog = _tableWithlog.TableAdapterLog.GetByBaseId();

            _differenceses = _tableWithlog
                .TableAdapterLog
                .GetDiff(tableLog, tableLog.Rows[0], tableLog.Rows[1]);
        }

        private void Dado_uma_tabela_com_log_de_2_instancias()
        {
            _tableWithlog = DbTesteNampula.CreateObject<FakeTableWithLogWithThreFields>();

            Connection.Instance.DropTable(_tableWithlog.TableName);
            Connection.Instance.DropTable(_tableWithlog.TableName + "Log");

            _tableWithlog.Create();

            AdicionarRegistro("Fábio Oliveira");
            AtualizarRegistra("Fabio Nascimento 2");

            var instances = _tableWithlog.TableAdapterLog.GetByBaseId();

            instances.Rows.Count.Should().Be.EqualTo(2);
        }

        private void AtualizarRegistra(string description, DateTime? dateAdd = null)
        {
            _tableWithlog.GetByKey();
            _tableWithlog.Description = description;

            if (dateAdd.HasValue)
                _tableWithlog.DateAdd = dateAdd.Value;

            _tableWithlog.Update();
        }

        private void AdicionarRegistro(string description, DateTime? dateAdd = null)
        {
            _tableWithlog.Description = description;

            if (dateAdd.HasValue)
                _tableWithlog.DateAdd = dateAdd.Value;

            _tableWithlog.Add();
        }

        private void Dado_uma_tabela_com_log_de_2_instancias_com_data()
        {
            _tableWithlog = DbTesteNampula.CreateObject<FakeTableWithLogWithThreFields>();

            Connection.Instance.DropTable(_tableWithlog.TableName);
            Connection.Instance.DropTable(_tableWithlog.TableName + "Log");

            _tableWithlog.Create();

            AdicionarRegistro("Fábio Oliveira", DateTime.Now.AddDays(-2));
            AtualizarRegistra("Fabio Nascimento 2", DateTime.Now);

            var instances = _tableWithlog.TableAdapterLog.GetByBaseId();

            instances.Rows.Count.Should().Be.EqualTo(2);
        }

        private void Deve_retornar_a_diferenca_entre_as_duas_instancias_no_campo_descricao_e_data()
        {
            _differenceses.Count.Should().Be.EqualTo(2);

            var first = _differenceses.First();
            var second = _differenceses.Last();

            first.Instance.Should().Be.EqualTo(2);
            first.Date.ToShortTimeString().Should().Not.Be.Empty();
            first.MachineName.Should().Be.EqualTo(Environment.MachineName);
            first.UserName.Should().Be.EqualTo(_tableWithlog.Connection.ConnectionParameter.UserName);
            first.FieldName.Should().Be.EqualTo("Descrição");
            first.OldValue.Should().Be.EqualTo("Fábio Oliveira");
            first.NewValue.Should().Be.EqualTo("Fabio Nascimento 2");


            second.Date.ToShortTimeString().Should().Not.Be.Empty();
            second.MachineName.Should().Be.EqualTo(Environment.MachineName);
            second.UserName.Should().Be.EqualTo(_tableWithlog.Connection.ConnectionParameter.UserName);
            second.FieldName.Should().Be.EqualTo("Data de Adição");
            second.OldValue.Should().StartWith(DateTime.Now.AddDays(-2).Date.ToShortDateString());
            second.NewValue.Should().StartWith(DateTime.Now.Date.ToShortDateString());
        }
    }
}
