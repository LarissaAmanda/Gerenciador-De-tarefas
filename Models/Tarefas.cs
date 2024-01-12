using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.Design.Serialization;

namespace GerenciadorDeTarefas.Models
{
    public class Tarefas{
    
        List<Tarefa> listaDeTarefas = new List<Tarefa>();


        public void AdicionarTarefa(){
            Console.WriteLine("Digite uma tarefa");
            string tarefa1 = Console.ReadLine();

            if(!String.IsNullOrWhiteSpace(tarefa1)){
                Console.Write("Digite a data de execução da primeira tarefa (formato dd/MM/yyyy): ");
                DateTime dataExecucaoTarefa1 = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Tarefa tarefaLista = new Tarefa { Descricao = tarefa1, DataExecucao = dataExecucaoTarefa1 };
                listaDeTarefas.Add(tarefaLista);

                Console.WriteLine("A tarefa foi adicionada");

            }else{
                Console.WriteLine("Digite uma tarefa válida");
            }
           
        }
       
        public void ListarTarefa(){
            
            foreach (Tarefa tarefa in listaDeTarefas){
                TimeSpan diferenca = tarefa.DataExecucao - DateTime.Now;

                string status = diferenca.TotalDays < 0 ? "Atrasada" : "No prazo";

                Console.WriteLine($"Tarefa: {tarefa.Descricao}, Data de Execução: {tarefa.DataExecucao:dd/MM/yyyy}, Status: {status}");
             }
            
        }

        public void ListarTarefasAtrasadas(){
            foreach (Tarefa tarefa in listaDeTarefas){

                    if (tarefa.DataExecucao < DateTime.Now){

                        Console.WriteLine($" A tarefa {tarefa.Descricao} está em atraso. Data de execução: {tarefa.DataExecucao:dd/MM/yyyy}");
                    } else {
                        Console.WriteLine("Não há tarefa em atraso");
                    }
            
         }
        }

        public void RemoverTarefa(){

            Console.WriteLine("Tarefas Cadastradas:");
             foreach (Tarefa tarefa in listaDeTarefas){
                Console.WriteLine($"Tarefa: {tarefa.Descricao}");
             }
            
            
            Console.WriteLine("Digite qual tarefa quer remover.");
            string tarefaParaRemover = Console.ReadLine();

            bool descricaoExiste = listaDeTarefas.Any(tarefa => tarefa.Descricao.Contains(tarefaParaRemover));

            if(descricaoExiste){

                listaDeTarefas.RemoveAll(tarefa => tarefa.Descricao.Contains(tarefaParaRemover));
                Console.WriteLine($"A tarefa: {tarefaParaRemover}, foi removida.");
             } else{
                Console.WriteLine($"A tarefa{tarefaParaRemover} não foi encontrada.");
             }

        }
    }  
}