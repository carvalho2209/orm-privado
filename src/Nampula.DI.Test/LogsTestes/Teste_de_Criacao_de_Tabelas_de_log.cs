using System;
using System.Data;
using NUnit.Framework;
using Nampula.DI.Logs;
using SharpTestsEx;

namespace Nampula.DI.Test.LogsTestes
{
    [TestFixture]
    public class Teste_de_Criacao_de_Tabelas_de_log
    {
        private FakeTableWithLog _tableWithlog;

        [Test]
        public void Deve_criar_umaa_tabela_de_log_quando_o_autolog_estiver_habilitado()
        {
            Dado_Uma_TableAdadpter_com_log_ativo();
            Ambas_tabelas_nao_pode_existir_no_banco_de_dados();
            Quando_for_criado_a_tabela_no_banco_de_dados();
            Uma_tabela_de_log_deve_ser_criada_no_banco_de_dados();
        }

        [Test]
        public void Os_objetos_copiados_do_log_nao_pode_ser_os_mesmos_da_tabela_base()
        {
            Dado_Uma_TableAdadpter_com_log_ativo();
            Ambas_tabelas_nao_pode_existir_no_banco_de_dados();
            Quando_for_criado_a_tabela_no_banco_de_dados();
            Os_campos_nao_devem_ser_iguais();
        }

        [Test]
        public void Todo_objeto_de_auto_log_deve_ter_ao_menos_uma_chave_primaria()
        {
            Dado_Uma_TableAdadpter_com_log_ativo_e_sem_chave();
            Nao_pode_ativar_log_sem_chave();
        }

        [Test]
        public void Quando_tabela_base_tiver_seu_esquema_alterado_os_campos_do_log_tambem_devem_ser_alterados()
        {
            Dado_Uma_TableAdadpter_com_log_ativo_criada_no_banco();
            Quando_um_campo_for_adicionado_a_tabela();
            A_tabela_de_log_deve_ter_criar_esse_campo_tambem();
        }

        [Test]
        public void Habilitar_o_log_para_tabelas_existente_deve_criar_a_tabela_de_log()
        {
            Dado_Uma_TableAdadpter_com_log_ativado_depois_de_criada();
            Quando_rodar_atualizacao_no_banco();
            A_tabela_de_log_deve_ser_criada();
        }
        
        [Test]
        public void Nao_deve_criar_nenhuma_tabela_de_log_quando_o_autolog_estiver_habilitado()
        {
            Dado_Uma_TableAdadpter_com_log_desativado();
            Ambas_tabelas_nao_pode_existir_no_banco_de_dados();
            Quando_for_criado_a_tabela_no_banco_de_dados();
            Nao_deve_ser_criado_tabela_de_log();
        }

        private void Dado_Uma_TableAdadpter_com_log_ativado_depois_de_criada()
        {
            Dado_Uma_TableAdadpter_com_log_desativado();
            Ambas_tabelas_nao_pode_existir_no_banco_de_dados();
            Quando_for_criado_a_tabela_no_banco_de_dados();
            Nao_deve_ser_criado_tabela_de_log();

            _tableWithlog.SetAutoLog();
        }
        
        private void Quando_rodar_atualizacao_no_banco()
        {
            var db = new DbTesteNampula();

            Connection.Instance.SqlServerExecute(
                string.Format("DELETE FROM [{0}]..[AppVersion]", db.DataBaseName));

            db.Start(Connection.Instance.ConnectionParameter);
        }

        private void A_tabela_de_log_deve_ser_criada()
        {
            var infosSchema = new InformationSchemaColumn { DBName = _tableWithlog.DBName };

            infosSchema.GetByKey("FakeLog", TableAdapterLog.FieldsName.InstanceLog)
                .Should().Be.True();
        }
        
        private void A_tabela_de_log_deve_ter_criar_esse_campo_tambem()
        {
            var infomationColumn = new InformationSchemaColumn { DBName = _tableWithlog.DBName };

            infomationColumn.GetByKey(_tableWithlog.TableName + "Log", newFeldAdd.Name).Should().Be.True(); ;
        }

        readonly TableAdapterField newFeldAdd = new TableAdapterField("NovoCampo", "NovoCampo", DbType.Decimal);

        private void Quando_um_campo_for_adicionado_a_tabela()
        {
            _tableWithlog.Collumns.Add(newFeldAdd);

            _tableWithlog.TableAdapterLog.Detach();
            _tableWithlog.SetAutoLog();

            var db = new DbTesteNampula();
            db.AlterTable(_tableWithlog, new[] { newFeldAdd });
        }

        private void Dado_Uma_TableAdadpter_com_log_ativo_criada_no_banco()
        {
            Deve_criar_umaa_tabela_de_log_quando_o_autolog_estiver_habilitado();
        }

        private void Nao_pode_ativar_log_sem_chave()
        {
            Assert.Throws<Exception>(() => _tableWithlog.SetAutoLog(),
                                     "Para habilitar o autoLog deve haver ao menos uma chave: *");
        }

        private void Dado_Uma_TableAdadpter_com_log_ativo_e_sem_chave()
        {
            _tableWithlog = DbTesteNampula.CreateObject<FakeTableWithLog>();
            _tableWithlog.TableAdapterLog.Detach();
            _tableWithlog.Collumns.ForEach(c => c.Key = false);
            _tableWithlog.KeyFields.Clear();
        }

        private void Os_campos_nao_devem_ser_iguais()
        {
            foreach (var tableAdapterField in _tableWithlog.TableAdapterLog.GetColumns())
            {
                if (_tableWithlog.Collumns.Exists(c => c.Name == tableAdapterField.Name))
                    tableAdapterField.Should().Not.Be.EqualTo(_tableWithlog.Collumns[tableAdapterField.Name]);
            }
        }


        private void Nao_deve_ser_criado_tabela_de_log()
        {
            var infosSchema = new InformationSchemaColumn() { DBName = _tableWithlog.DBName };

            infosSchema.GetByKey("FakeLog", TableAdapterLog.FieldsName.InstanceLog)
                .Should().Be.False();
        }

        private void Dado_Uma_TableAdadpter_com_log_desativado()
        {
            _tableWithlog = DbTesteNampula.CreateObject<FakeTableWithLog>();
            _tableWithlog.SetAutoLog(false);
        }

        [Test]
        public void As_chaves_da_tabela_de_log_deve_ser_instancia_e_base_id()
        {
            Dado_Uma_TableAdadpter_com_log_ativo();
            Ambas_tabelas_nao_pode_existir_no_banco_de_dados();
            Quando_for_criado_a_tabela_no_banco_de_dados();
            Deve_Haves_Somente_2();
            E_Os_Nomes_das_chaves_dem_ser_Instancia_e_BaseId();
        }

        private void E_Os_Nomes_das_chaves_dem_ser_Instancia_e_BaseId()
        {
            var dataKeys = GetKeysForLog();

            dataKeys.Rows[0].Field<string>("COLUMN_NAME").Should().Be.EqualTo(
                TableAdapterLog.FieldsName.BaseIdLog);

            dataKeys.Rows[1].Field<string>("COLUMN_NAME").Should().Be.EqualTo(
                TableAdapterLog.FieldsName.InstanceLog);
        }

        private void Deve_Haves_Somente_2()
        {
            var dataKeys = GetKeysForLog();

            dataKeys.Rows.Count.Should("Quantidade de chaves devem ser 2").Be.EqualTo(2);
        }

        private DataTable GetKeysForLog()
        {
            var query =
                string.Format(
                    @"SELECT 
	            K.TABLE_NAME,
	            K.COLUMN_NAME,
	            K.CONSTRAINT_NAME
            FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS C
            JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS K
            ON C.TABLE_NAME = K.TABLE_NAME
            AND C.CONSTRAINT_CATALOG = K.CONSTRAINT_CATALOG
            AND C.CONSTRAINT_SCHEMA = K.CONSTRAINT_SCHEMA
            AND C.CONSTRAINT_NAME = K.CONSTRAINT_NAME
            WHERE 
		            C.CONSTRAINT_TYPE = 'PRIMARY KEY' 
	            And k.TABLE_NAME = '{0}Log'",
                    _tableWithlog.TableName);

            return Connection.Instance.SqlServerQuery(query);

        }

        private void Ambas_tabelas_nao_pode_existir_no_banco_de_dados()
        {
            Connection.Instance.DropTable(_tableWithlog.TableName);
            Connection.Instance.DropTable(_tableWithlog.TableName + "Log");
        }

        public void Dado_Uma_TableAdadpter_com_log_ativo()
        {
            _tableWithlog = DbTesteNampula.CreateObject<FakeTableWithLog>();
        }

        public void Quando_for_criado_a_tabela_no_banco_de_dados()
        {
            _tableWithlog.Create();
        }

        private void Uma_tabela_de_log_deve_ser_criada_no_banco_de_dados()
        {
            var infosSchema = new InformationSchemaColumn { DBName = _tableWithlog.DBName };

            infosSchema.GetByKey("FakeLog", TableAdapterLog.FieldsName.InstanceLog)
                .Should().Be.True();
        }

    }
}
