using System.IO;
namespace AvaliacaoD3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repositories _user = new();
            Console.WriteLine("SEJA BEM-VINDO!!");
            Console.WriteLine("--------------------------");
            string option = "2";
            string email;
            string senha;



            while (option != "0")
            {
                if (option == "2")
                {
                    Console.WriteLine("\nEscolha  abaixo:\n");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("1 - Acessar");
                    Console.WriteLine("0 - Cancelar\n");
                    option = Console.ReadLine();
                }


                if (option == "1")
                {
                    Console.WriteLine(" e-mail:\n");
                    email = Console.ReadLine();
                    Console.WriteLine(" senha:\n");
                    senha = Console.ReadLine();
                    var usertList = _user.ReadAll();

                    if (email == usertList[0].Email && senha == usertList[0].Senha)
                    {
                        Console.WriteLine("sucesso!");

                        string registro = "O usuário " + usertList[0].Name + " entrou no sistema às " + DateTime.Now.ToString("hh:mm:ss tt") + "do dia " + DateTime.Now.ToString("dd/MM/yyyy") + "\n";

                        System.IO.File.WriteAllText("Registro.txt", registro);
                        string readText = File.ReadAllText("Registro.txt");
                        Console.WriteLine(readText);
                        Console.WriteLine("\nEscolha uma das opções abaixo:\n");
                        Console.WriteLine("2 - deslogar");
                        Console.WriteLine("0 - encerrar o sistema\n");



                        option = Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("Login estar errado! ");
                        option = "1";
                    }
                }



            }
        }
    }
}