using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.IO;



public struct Pessoa
{
    public string CPF;
    public string Nome;
    public string Telefone;

    public Pessoa(string cpf, string nome, string telefone) {
        CPF = cpf;
        Nome = nome;
        Telefone = telefone;
    }
}

public class Abordagem
{
    private static List<Pessoa> ListaPessoas = new List<Pessoa>();
    public static void Opcoes() {
        Console.WriteLine("Escolha a opcao desejada:");
        Console.WriteLine("1 - Cadatrar");
        Console.WriteLine("2 - Gerar Lista");
        Console.WriteLine("3 - Consultar ");
        Console.WriteLine("4 - Sair");

        Console.Write("Digite o número da opção desejada: ");
        string entrada = Console.ReadLine();

        switch (entrada) {
            case "1":
                Cadastrar();
                break;
            case "2":
                GerarLista();
                break;
            case "3":
                Consultar();
                break;
            case "4":
                return;
            default:
                Console.WriteLine("Opção inválida");
                break;

        }
    }

        private static void Cadastrar() {
        Console.WriteLine("Opção selecionada: Cadastrar");

        Console.Write("Digite o CPF:");
        string cpf = Console.ReadLine();
        string cpfC = cpf.ToUpper();

        Console.WriteLine("Digite o seu Nome:");
        string nome = Console.ReadLine();
        string nomeC = nome.ToUpper();

        Console.WriteLine("Digite o seu Telefone:");
        string telefone = Console.ReadLine();
        string telefoneC = telefone.ToUpper();

        Pessoa NovaPessoa = new Pessoa(cpfC, nomeC, telefoneC);
        ListaPessoas.Add(NovaPessoa);

        SalvarNoArquivo();

        Console.WriteLine("Cadastro realizado com sucesso!");


    }

    private static void SalvarNoArquivo() {
        string path = @"C:\Users\CM-0000\Documents\teste.txt";
        using (StreamWriter sw = new StreamWriter(path, true)) {
            foreach (var pessoa in ListaPessoas) {
                sw.WriteLine($"{pessoa.CPF}|{pessoa.Nome}|{pessoa.Telefone}|");
            }
        }
    }

    private static void GerarLista() {
        string path = @"C:\Users\CM-0000\Documents\teste.txt";
        using (StreamReader sr = new StreamReader(path, true)) {
            var linha = sr.ReadLine();

            while (linha != null) {
                Console.WriteLine(linha);
                linha = sr.ReadLine();
            }
            
        }

            Console.WriteLine(path);
    }
    private static void Consultar() {
        string path = @"C:\Users\CM-0000\Documents\teste.txt";
        Console.WriteLine("Digite o nome ou CPF que deseja consultar");

      
        string busca = Console.ReadLine();
        string buscaMaior = busca.ToUpper();

        using (StreamReader sr = new StreamReader(path)) {
            string linha;
            while ((linha = sr.ReadLine()) != null) {
                if (linha.Contains(busca)) {
                    Console.WriteLine(linha);
                }
            }
        }
        

    }
    public static void Main() {
        Abordagem.Opcoes();
    }

}
