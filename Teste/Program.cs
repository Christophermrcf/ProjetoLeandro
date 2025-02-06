using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text.RegularExpressions;



//public struct Pessoa
//{
//    public string CPF;
//    public string Nome;
//    public string Telefone;

//    public Pessoa(string cpf, string nome, string telefone) {
//        CPF = cpf;
//        Nome = nome;
//        Telefone = telefone;
//    }
//}

public record struct Pessoa(string CPF, string Nome, string Telefone);
public class Abordagem
{
    private static List<Pessoa> ListaPessoas = new List<Pessoa>();
    public static void Opcoes() {
        Console.WriteLine("Escolha a opcao desejada:");
        Console.WriteLine("1 - Cadastrar");
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
                Console.WriteLine("Opção inválida, tente novamente");
                Console.WriteLine("______________________________________________");
                Opcoes();


                break;

        }
    }

    private static void Cadastrar() {
        Console.WriteLine("Opção selecionada: Cadastrar");
        Console.Write("Digite o CPF:");
        string cpf = Console.ReadLine().Replace(".", "").Replace("-", "").Trim();


        bool ehValidoCpf = Regex.IsMatch(cpf, @"^\d{11}$");

        while (ehValidoCpf != true) {
            Console.WriteLine("Formatação incoerente com o padrão CPF");
            cpf = Console.ReadLine();
            ehValidoCpf = Regex.IsMatch(cpf, @"^\d{11}$");
        };


        //string apenasNumeros = RetornarNumeros(cpf);

        //while (apenasNumeros.Length != 11) {
        //    Console.WriteLine("Não segue o padrão CPF, digite novamente");
        //    cpf = Console.ReadLine();
        //    apenasNumeros = RetornarNumeros(cpf);


        //};


        Console.WriteLine("Digite o seu Nome:");
        string nome = Console.ReadLine();


        Console.WriteLine("Digite o seu Telefone:");
        string telefone = Console.ReadLine();


        Pessoa NovaPessoa = new Pessoa(cpf, nome, telefone);
        ListaPessoas.Add(NovaPessoa);

        SalvarNoArquivo();

        Console.WriteLine("Cadastro realizado com sucesso!");


    }

    //private static bool CpfEhValido(string texto) {
    //    texto.Replace(".", "").Replace("-", "").Trim();
    //}

    private static string RetornarNumeros(string texto) {

        //while (cpf.Length != 11) {
        //    Console.WriteLine("cpf não esta seguindo o tamanho padrão");
        //    Console.WriteLine("digite o cpf novamente, lembrando que o tamanho padrão contem 11 digitos");
        //    cpf = Console.ReadLine();
        //} 


        return string.Join("", texto.ToCharArray().Where(caractere => Char.IsDigit(caractere)).ToList());
    }

    private static void SalvarNoArquivo() {
        string path = @"C:\Users\CM-0000\Documents\teste.txt";
        using (StreamWriter sw = new StreamWriter(path, true)) {
            foreach (var pessoa in ListaPessoas) {
                sw.WriteLine($"|{pessoa.CPF}|{pessoa.Nome}|{pessoa.Telefone}|");

                Console.WriteLine("Arquivo salvo");
                Console.WriteLine("retornando ao menu inicial");
                Console.WriteLine("_____________________________________________________________");
            }
        }
        Opcoes();

    }

    private static void GerarLista() {
        string path = @"C:\Users\CM-0000\Documents\teste.txt";
        using (StreamReader sr = new StreamReader(path, true)) {
            var linha = sr.ReadLine();
            Console.WriteLine("Nome                              | CPF               | Telefone            ");

            while (linha != null) {
                string[] separada = linha.Split('|', StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine($"{separada[1].PadRight(30)}| {separada[0].PadRight(11)} | {separada[2].PadRight(11)}");

                Console.WriteLine("-----------------------------------------------------------------------------------");


                linha = sr.ReadLine();
            }

        }

        Console.WriteLine(path);
    }
    private static void Consultar() {
        string path = @"C:\Users\CM-0000\Documents\teste.txt";
        Console.WriteLine("Digite o nome ou CPF que deseja consultar");


        string busca = Console.ReadLine();
        //string buscaMaior = busca.ToUpper();

        using (StreamReader sr = new StreamReader(path)) {
            string linha;
            while ((linha = sr.ReadLine()) != null) {
                if (linha.Contains(busca, StringComparison.OrdinalIgnoreCase)) {
                    Console.WriteLine(linha.ToUpper());
                }
            }
        }


    }
    public static void Main() {
        Abordagem.Opcoes();
    }

}
