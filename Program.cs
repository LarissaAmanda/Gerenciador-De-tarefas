using GerenciadorDeTarefas.Models;
using System.Globalization;
internal class Program
{
    private static void Main(string[] args)
    {
        Tarefas t1 = new Tarefas();

        bool exibirMenu = true;

        while (exibirMenu)
        {
            Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Adicionar Tarefa");
            Console.WriteLine("2 - Listar Tarefa");
            Console.WriteLine("3 - Tarefas Atrasadas");
            Console.WriteLine("4 - Remover Tarefas");
            Console.WriteLine("5 - Encerrar");

            switch (Console.ReadLine())
            {
                case "1":
                    t1.AdicionarTarefa();
                    break;

                case "2":
                    t1.ListarTarefa();
                    break;

                case "3":
                    t1.ListarTarefasAtrasadas();
                    break;
                case "4":
                    t1.RemoverTarefa();
                    break;

                case "5":
                    exibirMenu = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadKey();
            
        }

        Console.WriteLine("O programa se encerrou");
    }
}