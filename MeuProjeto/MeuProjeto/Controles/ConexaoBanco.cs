using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace MeuProjeto.ConexaoBanco
{
	//class faz conexao com banco
	public class ConexaoBanco
	{
		private static String connectionString =
		   "Server=localhost;" +
			"Port=3306;" +
			"Database=cadastro_db;" +
			"Uid=root;" +
			"Pwd=;";

		public static MySqlConnection Conectar()
		{
			MySqlConnection conexao = new MySqlConnection(connectionString);

			try
			{
				conexao.Open();
				//Console.WriteLine("Conectado com sucesso!");
				return conexao;
			}
			catch (Exception ex)
			{
				throw new Exception("Erro ao conectar no MySQL: " + ex.Message);
			}
		}
	}

	// class cadastro
	class CadastroDados
	{
		// funçao faz insert no  banco de dados
		public void InserirDados(string nome, string cpf, int idade)
		{
			using (var con = ConexaoBanco.Conectar())
			{
				var sql = "INSERT INTO cadastropessoas (nome, cpf ,idade) VALUES (@nome ,@cpf ,@idade)";

				using (var cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.AddWithValue("@nome", nome);

					cmd.Parameters.AddWithValue("@cpf", cpf);

					cmd.Parameters.AddWithValue("@idade", idade);

					cmd.ExecuteNonQuery();
				}
			}

		}

		// funçao para atualizar dados
		public void AtualzarDados(int id, string nome, string cpf, int idade)
		{
			using (var con = ConexaoBanco.Conectar())
			{
				var sql = @"UPDATE cadastropessoas SET nome = @nome ,cpf = @cpf , idade = @idade  WHERE id = @id";

				using (var cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.AddWithValue("@id", id);

					cmd.Parameters.AddWithValue("@nome", nome);

					cmd.Parameters.AddWithValue("@cpf", cpf);

					cmd.Parameters.AddWithValue("@idade", idade);

					cmd.ExecuteNonQuery();
				}
			}

		}

		public bool DeleteUsuario(int id)
		{
			using (var con = ConexaoBanco.Conectar())
			{
				var sql = "DELETE FROM cadastropessoas WHERE id = @id";

				using (var cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.AddWithValue("@id", id);
					int linhasAfet = cmd.ExecuteNonQuery();
					return linhasAfet > 0;
				}

			}

		}
		public  void ListaDados()
		{
			using (var con = ConexaoBanco.Conectar())
			{
				string sql = "SELECT id, nome, cpf, idade FROM cadastropessoas";

				using (var cmd = new MySqlCommand(sql, con))
				using (var reader = cmd.ExecuteReader())
				{

					Console.WriteLine("\n--- Lista De Pessoas ---");

					if (!reader.HasRows)
					{
						Console.WriteLine("Nenhum registro encontrado.");
						return;
					}

					while (reader.Read())
					{
						Console.WriteLine($"ID: {reader.GetInt32("id")}");
						Console.WriteLine($"Nome: {reader.GetString("nome")}");
						Console.WriteLine($"CPF: {reader.GetString("cpf")}");
						Console.WriteLine($"Idade: {reader.GetInt32("idade")}");
						Console.WriteLine("----------------------");
					}


				}

			}
		}

	}

}
