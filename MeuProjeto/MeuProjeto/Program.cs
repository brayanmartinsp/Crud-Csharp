using System;
using System.Collections.Generic;
using System.Text;
using MeuProjeto.ConexaoBanco;
using MySql.Data.MySqlClient;

class Program
{
	enum menuCadastro
	{
		Cadastrar = 1,
		ListarDados = 2,
		Atualizar = 3,
		Deletar = 4,
		Sair = 5
	}
	static void Main(string[] args)
	{
		MySqlConnection conexao = ConexaoBanco.Conectar(); 

		int opcao;
		Console.WriteLine("Conectado!");
	
		do
		{
            Console.WriteLine("");
			Console.WriteLine("|===================================|");
			Console.WriteLine("|         MENU DE CADASTRO          |");
			Console.WriteLine("|===================================|");
			Console.WriteLine("|         1   Cadastrar             |");
			Console.WriteLine("|         2  Listar Dados           |");
			Console.WriteLine("|         3   Atualizar             |");
			Console.WriteLine("|         4    Deletar              |");
			Console.WriteLine("|         5     Sair                |");
			Console.WriteLine("|===================================|");
            Console.WriteLine("");

			opcao = int.Parse(Console.ReadLine());

			switch ((menuCadastro)opcao)
			{
				case menuCadastro.Cadastrar:
					CadastroDados Cadastrar = new CadastroDados();
                   

					Console.Write("Digite o nome: ");
					string nome = Console.ReadLine();


					Console.Write("Digite o CPF: ");
					string cpf = Console.ReadLine();

					Console.Write("Digite a idade: ");
					int idade = int.Parse(Console.ReadLine());

					Cadastrar.InserirDados(nome, cpf, idade);
                    Console.WriteLine("");
					Console.Write("Dados inseridos com sucesso!");
                    Console.WriteLine("");
					break;

				case menuCadastro.Atualizar:
					CadastroDados atualizar = new CadastroDados();
					Console.Write("\nDigite o ID para atualizar: ");
					Console.WriteLine();
					int id = int.Parse(Console.ReadLine());

					Console.Write("Digite o nome: ");
					string atnome = Console.ReadLine();


					Console.Write("Digite o CPF: ");
					string atcpf = Console.ReadLine();

					Console.Write("Digite a idade: ");
					int atidade = int.Parse(Console.ReadLine());

					atualizar.AtualzarDados(id, atnome, atcpf, atidade);
                    Console.WriteLine("");
					Console.Write("Atualizado com sucesso!");
					Console.WriteLine("");
					break;

				case menuCadastro.ListarDados:
					CadastroDados Listar = new CadastroDados();
					Listar.ListaDados();
					break;
				case menuCadastro.Deletar:
					CadastroDados deletar = new CadastroDados();

					Console.Write("Digite o ID para deletar: ");
					Console.WriteLine();
					int idDelete = int.Parse(Console.ReadLine());
					deletar.DeleteUsuario(idDelete);

                    Console.WriteLine("");
					Console.Write("Deletado com sucesso!");
                    Console.WriteLine("");
					break;
				case menuCadastro.Sair:
					Console.WriteLine("Saindo...");
					break;

				default:
					Console.WriteLine("Opção inválida!");
					break;
			}

		} while (opcao != 5);



	}
}
