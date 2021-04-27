using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DigiBank.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int op = 0;
        // criando o metodo tela
        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("                                   ");
            Console.WriteLine("Digite a opção desejada:           ");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1 - Criar Conta                    ");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("2 - Entrar com CPF e senha         ");
            Console.WriteLine("-----------------------------------");

            op = int.Parse(Console.ReadLine());
            switch(op)
            {
                case 1: CriarConta(); break;
                case 2: TelaLogin(); break;
                default: Console.WriteLine("Opção inválida"); break;

            }
        }

        private static void CriarConta()
        {
            Console.Clear();
            Console.WriteLine("                                   ");
            Console.WriteLine("Digite seu nome:                   ");
            string nome = Console.ReadLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Digite teu CPF:                    ");
            string cpf = Console.ReadLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Digite tua senha                   ");
            string senha = Console.ReadLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(nome);
            Console.WriteLine(cpf);
            Console.WriteLine(senha);

            // criando a conta
            ContaCorrente contaCorrente = new ContaCorrente(); //instanciando a conta corrente
            Pessoa pessoa = new Pessoa(); // instanciando a classe pessoa

            pessoa.SetNome(nome); // atribuindo os dados coletados acima aos metodos
            pessoa.SetCPF(cpf);// atribuindo os dados coletados acima aos metodos
            pessoa.SetSenha(senha);// atribuindo os dados coletados acima aos metodos
            pessoa.Conta = contaCorrente; // atribuindo à conta a conta corrente. Dessa forma podemos criar uma conta poupança e atribuir sempre à classe Conta.

            pessoas.Add(pessoa); //adicionando a pessoa cadastrada na lista

            Console.Clear();

            Console.WriteLine("   Conta cadastrada com sucesso.   ");
            Console.WriteLine("-----------------------------------");
            Thread.Sleep(2000);
            TelaContaLogada(pessoa);

        }

        private static void TelaLogin()
        
        {
            Console.Clear();
            Console.WriteLine("                                   ");
            Console.WriteLine("Digite o CPF:                      ");
            string cpf = Console.ReadLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Digite a senha                     ");
            string senha = Console.ReadLine();
            Console.WriteLine("-----------------------------------");

            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha); //firstOrDefault vai procurar na lista o primeiro ou unico cadastrao
            if(pessoa != null)
            {
                // chamada para telas de boas vindas
                TelaBoasVindas(pessoa); // passar parametro pessoa entre parentesis para buscar o objeto
                // e para tela Conta Logada
                TelaContaLogada(pessoa);

            }else
            {
                Console.Clear();
                Console.WriteLine("Pessoa não cadastrada!             ");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();
                Console.WriteLine();
            }
            
        }
    
        private static void TelaBoasVindas(Pessoa pessoa) // necessário passar o parametro entre parenteses para conseguir chamar o nome logo abaixo
        {
            string msgTelaBoasVindas = // criando uma variável para armazenar os dados e exibir
            $"{pessoa.Nome} | Banco: {pessoa.Conta.GetCodigoBanco()} " +
            $"| Agencia: {pessoa.Conta.GetNumeroAgencia()} | Conta: {pessoa.Conta.GetNumeroConta()}";

            Console.WriteLine();
            Console.WriteLine($"Seja bem vindo, {msgTelaBoasVindas}");
            Console.WriteLine();
        }

        private static void TelaContaLogada (Pessoa pessoa)// necessário passar o parametro entre parenteses para conseguir chamar o nome logo abaixo
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("Digite a opção desejada:           ");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1 - Realizar deposito              ");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("2 - Realizar saque                 ");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("3 - Consultar saldo                ");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("4 - Extrato                        ");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("5 - Sair                           ");
            Console.WriteLine("-----------------------------------");

            op = int.Parse(Console.ReadLine());

            switch(op)
            {
                case 1:
                break;

                case 2:
                break;

                case 3:
                break;

                case 4:
                break;

                case 5: TelaPrincipal();
                break;

                default: Console.Clear();
                         Console.WriteLine(" OPÇÃO INVÁLIDA.                   ");
                         Console.WriteLine("-----------------------------------");

                break;
            }
        }
    }
}
