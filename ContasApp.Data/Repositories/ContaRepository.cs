using ContasApp.Data.Entities;
using ContasApp.Data.Settings;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasApp.Data.Repositories
{
    public class ContaRepository
    {
        //Método para cadastar uma conta na tabela do banco.
        public void Add(Conta conta)
        {
            //Escrevendo o comando SQL.
            var query = @"
                INSERT INTO CONTA(ID, NOME, DATACRIACAO, VALOR, OBSERVACAO)
                VALUES(@Id, @Nome, @DataCriacao, @Valor, @Observacao)
            ";

            //Conectando ao banco de dados.
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, conta);
            }
        }

        //Método para atualizar uma conta na tabela do banco.
        public void Update(Conta conta) 
        {
            //Escrevendo o comando SQL.
            var query = @"
                UPDATE CONTA
                SET
                    NOME = @Nome,
                    DATACRIACAO = @DataCriacao,
                    VALOR = @Valor,                    
                    OBSERVACAO = @Observacao                    
                WHERE
                    ID = @Id
            ";

            //Conectando ao banco de dados.
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, conta);
            }
        }

        //Método para excluir uma conta na tabela do banco.
        public void Delete(Conta conta)
        {
            //Escrevendo o Comando SQL.
            var query = @"
                DELETE FROM CONTA
                WHERE ID = @Id
            ";

            //Conectando ao banco de dados.
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, conta);
            }
        }        

        //Método para consultar uma conta no banco de Dados através do ID.
        public Conta? GetById(Guid? id)
        {
            //Escrevendo o comando SQL.
            var query = @"
                SELECT * FROM CONTA
                WHERE ID = @Id
            ";

            //Conectando ao banco de dados.
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Conta>(query, new { @Id = id }).FirstOrDefault();
            }
        }

        //Método para consultar todas as conta no banco de Dados.
        public List<Conta?> GetAll()
        {
            //Escrevendo o comando SQL.
            var query = @"
                SELECT * FROM CONTA
                
            ";

            //Conectando ao banco de dados.
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Conta>(query).ToList();
            }
        }
    }
}
