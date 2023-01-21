using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstImpressions
{
    internal class AsyncTasks
    {

        async void TarefaDemorada() {

            var tarefa1 = Task.Run(() =>
            {
                Console.WriteLine("[Async] Rodando por 15 segundos...");
                Thread.Sleep(15000);
                Console.WriteLine("[Async] Terminei :)");

                return;
            });

            await tarefa1;
            
        }

        public string PontoDeRequest(string palavra) {
            TarefaDemorada();
            return "[Sync] Retornei " + palavra;
        }
    }
}
