using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "x"){
               switch(opcaoUsuario){
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
                    case "c":
                        Console.Clear();
                    break;
                    default: 
                        throw new ArgumentOutOfRangeException();
               }
               opcaoUsuario = ObterOpcaoUsuario();
           }
           Console.WriteLine("Obrigado por utilizar nossos serviços.");
           Console.WriteLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser tranferido: ");
            double valorTranferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTranferencia, listaContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado:");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");
            if(listaContas.Count == 0){
                Console.WriteLine("Nenhuma conta encontrada");
                return;
            } else {
                for(int i = 0; i < listaContas.Count; i++){
                    Conta conta = listaContas[i];
                    Console.WriteLine("#{0} - ", i);
                    Console.WriteLine(conta);
                }
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir Nova Conta");

            Console.WriteLine("Digite 1 para conta Fisica e 2 para conta Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito: ");
            double entraCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entraCredito,
                                        nome: entradaNome);
            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao DioBank!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar contas.");
            Console.WriteLine("2 - Inserir uma nova conta.");
            Console.WriteLine("3 - Transferir.");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("c - Limpar tela");
            Console.WriteLine("x - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
