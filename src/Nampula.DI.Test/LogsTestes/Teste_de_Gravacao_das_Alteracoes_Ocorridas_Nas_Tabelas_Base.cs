using System;
using System.Data;
using System.Linq;
using NUnit.Framework;
using Nampula.DI.Logs;
using SharpTestsEx;

namespace Nampula.DI.Test.LogsTestes
{
    [TestFixture]
    public class Teste_de_Registro_das_Alteracoes_Ocorridas_Nas_Tabelas_Base
    {
        private FakeTableWithLog _tableWithlog;

        [Test]
        public void Sempre_que_adicionar_um_registro_na_tabela_base_deve_adicionar_um_registro_no_log()
        {
            Dado_uma_tabela_com_log_ativado_criada_no_banco_dados();
            Quando_for_adicionado_um_registro_na_tabela_base();
            Um_novo_registro_na_tabela_de_log_com_os_mesmos_dados_do_log();
        }

        [Test]
        public void Sempre_que_atualizar_um_registro_na_tabela_base_deve_adicionar_um_novo_registro_no_log()
        {
            Dado_uma_tabela_com_log_ativado_criada_no_banco_dados();
            Quando_for_adicionado_um_registro_na_tabela_base();
            Um_novo_registro_na_tabela_de_log_com_os_mesmos_dados_do_log();
            Quando_for_atualizar_um_registro_na_tabela_base();
            Devem_haver_2_registros_na_tabela_log_com_a_nova_alteracao_com_2_instancias();
        }

        [Test]
        public void Toda_atualizacao_no_registro_base_deve_atualizar_o_log()
        {
            Dado_uma_tabela_com_log_ativado_criada_no_banco_dados();
            Quando_for_adicionado_um_registro_na_tabela_base();
            Um_novo_registro_na_tabela_de_log_com_os_mesmos_dados_do_log();
            Quando_for_atualizar_10_um_registro_na_tabela_base();
            Deve_haver_10_registros_na_tabela_log_com_as_novas_alteracoes_com_10_instancias_diferentes();
        }

        private void Deve_haver_10_registros_na_tabela_log_com_as_novas_alteracoes_com_10_instancias_diferentes()
        {
            var tableLog = _tableWithlog.TableAdapterLog;

            var logRecords = tableLog.GetByBaseId();

            logRecords.Rows.Count.Should().Be.EqualTo(11);

            foreach (var i in Enumerable.Range(1, 10))
            {
                logRecords.Rows[i].Field<string>("Description").Should().Be.EqualTo(string.Format("Fábio Nascimento {0}", i));
                logRecords.Rows[i].Field<string>(TableAdapterLog.FieldsName.BaseIdLog).Should().Be.EqualTo("1");
                logRecords.Rows[i].Field<int>(TableAdapterLog.FieldsName.InstanceLog).Should().Be.EqualTo(i + 1);
                logRecords.Rows[i].Field<string>(TableAdapterLog.FieldsName.MachineLog).Should().Be.EqualTo(Environment.MachineName);
                logRecords.Rows[i].Field<string>(TableAdapterLog.FieldsName.UserNameLog).Should().Be.EqualTo(Connection.Instance.ConnectionParameter.UserName);
                logRecords.Rows[i].Field<DateTime>(TableAdapterLog.FieldsName.DateAddLog).ToShortDateString().Should().Not.Be.Empty();
            }
        }

        private void Quando_for_atualizar_10_um_registro_na_tabela_base()
        {
            foreach (var i in Enumerable.Range(1, 10))
            {
                _tableWithlog.Description = string.Format("Fábio Nascimento {0}", i);
                _tableWithlog.Update();
                _tableWithlog.Id.Should().Be.EqualTo(1);
            }
        }

        private void Devem_haver_2_registros_na_tabela_log_com_a_nova_alteracao_com_2_instancias()
        {
            var tableLog = _tableWithlog.TableAdapterLog;

            var logRecords = tableLog.GetByBaseId();

            logRecords.Rows.Count.Should().Be.EqualTo(2);

            logRecords.Rows[0].Field<string>("Description").Should().Be.EqualTo("Fábio Nascimento");
            logRecords.Rows[0].Field<string>(TableAdapterLog.FieldsName.BaseIdLog).Should().Be.EqualTo("1");
            logRecords.Rows[0].Field<int>(TableAdapterLog.FieldsName.InstanceLog).Should().Be.EqualTo(1);
            logRecords.Rows[0].Field<string>(TableAdapterLog.FieldsName.MachineLog).Should().Be.EqualTo(Environment.MachineName);
            logRecords.Rows[0].Field<string>(TableAdapterLog.FieldsName.UserNameLog).Should().Be.EqualTo(Connection.Instance.ConnectionParameter.UserName);
            logRecords.Rows[0].Field<DateTime>(TableAdapterLog.FieldsName.DateAddLog).ToShortDateString().Should().Not.Be.Empty();

            logRecords.Rows[1].Field<string>("Description").Should().Be.EqualTo("Fábio Nascimento Novo Registro");
            logRecords.Rows[1].Field<string>(TableAdapterLog.FieldsName.BaseIdLog).Should().Be.EqualTo("1");
            logRecords.Rows[1].Field<int>(TableAdapterLog.FieldsName.InstanceLog).Should().Be.EqualTo(2);
            logRecords.Rows[1].Field<string>(TableAdapterLog.FieldsName.MachineLog).Should().Be.EqualTo(Environment.MachineName);
            logRecords.Rows[1].Field<string>(TableAdapterLog.FieldsName.UserNameLog).Should().Be.EqualTo(Connection.Instance.ConnectionParameter.UserName);
            logRecords.Rows[1].Field<DateTime>(TableAdapterLog.FieldsName.DateAddLog).Should().Be.GreaterThan(
                logRecords.Rows[0].Field<DateTime>(TableAdapterLog.FieldsName.DateAddLog));
        }

        private void Quando_for_atualizar_um_registro_na_tabela_base()
        {
            _tableWithlog.GetByKey().Should().Be.True();

            _tableWithlog.Description = "Fábio Nascimento Novo Registro";

            _tableWithlog.Update();
        }

        private void Um_novo_registro_na_tabela_de_log_com_os_mesmos_dados_do_log()
        {
            var tableLog = _tableWithlog.TableAdapterLog;

            var logRecords = tableLog.GetByBaseId();

            logRecords.Rows.Count.Should().Be.EqualTo(1);

            logRecords.Rows[0].Field<string>("Description").Should().Be.EqualTo(_tableWithlog.Description);
            logRecords.Rows[0].Field<string>(TableAdapterLog.FieldsName.BaseIdLog).Should().Be.EqualTo("1");
            logRecords.Rows[0].Field<int>(TableAdapterLog.FieldsName.InstanceLog).Should().Be.EqualTo(1);
            logRecords.Rows[0].Field<string>(TableAdapterLog.FieldsName.MachineLog).Should().Be.EqualTo(Environment.MachineName);
            logRecords.Rows[0].Field<string>(TableAdapterLog.FieldsName.UserNameLog).Should().Be.EqualTo(Connection.Instance.ConnectionParameter.UserName);
            logRecords.Rows[0].Field<DateTime>(TableAdapterLog.FieldsName.DateAddLog).ToShortDateString().Should().Not.Be.Empty();

        }

        private void Quando_for_adicionado_um_registro_na_tabela_base()
        {
            _tableWithlog.Description = "Fábio Nascimento";
            _tableWithlog.Add();
            _tableWithlog.Id.Should().Be.EqualTo(1);
        }

        private void Dado_uma_tabela_com_log_ativado_criada_no_banco_dados()
        {
            _tableWithlog = DbTesteNampula.CreateObject<FakeTableWithLog>();

            Connection.Instance.DropTable(_tableWithlog.TableName);
            Connection.Instance.DropTable(_tableWithlog.TableName + "Log");

            _tableWithlog.Create();
        }


    }
}
