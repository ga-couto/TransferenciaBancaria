using System;
using System.Collections.Generic;

namespace DIO.Bank
{
	class Program
	{
		static List<Conta> listContas = new List<Conta>();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "S")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
					case "L":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado. Estamos sempre com você.");
			Console.ReadLine();
		}

		private static void Depositar()
		{
			Console.Write("Qual o número da conta? ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Qual valor será depositado? ");
			double valorDeposito = double.Parse(Console.ReadLine());

			listContas[indiceConta].Depositar(valorDeposito);
		}

		private static void Sacar()
		{
			Console.Write("Digite o número da sua conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Qual valor deseja sacar? ");
			double valorSaque = double.Parse(Console.ReadLine());

			listContas[indiceConta].Sacar(valorSaque);
		}

		private static void Transferir()
		{
			Console.Write("Qual número da conta de origem? ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

			Console.Write("Para qual conta deseja depositar? Digite o número: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Qual valor deseja transferir? ");
			double valorTransferencia = double.Parse(Console.ReadLine());

			listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
		}

		private static void InserirConta()
		{
			Console.WriteLine("CADASTRAR NOVA CONTA");

			Console.Write("Para conta Pessoa física, digite 1. Para jurídica, digite 2: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Insira o nome do Cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										nome: entradaNome);

			listContas.Add(novaConta);
		}

		private static void ListarContas()
		{
			Console.WriteLine("LISTAR CONTAS");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Ops, não há conta cadastrada! ");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("OLÁ. O MELHOR BANCO A SEU DISPOR!");
			Console.WriteLine("INFORME A OPÇÃO DESEJADA ABAIXO:\n");

			Console.WriteLine("1 - LISTAR CONTAS");
			Console.WriteLine("2 - CADASTRAR UMA NOVA CONTA");
			Console.WriteLine("3 - TRANSFERIR");
			Console.WriteLine("4 - SACAR");
			Console.WriteLine("5 - DEPOSITAR");
			Console.WriteLine("L - LIMPAR TELA");
			Console.WriteLine("S - SAIR");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
