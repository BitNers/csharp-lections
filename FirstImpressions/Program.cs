namespace FirstImpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            AsyncTasks testAsync = new AsyncTasks();

            string palavra = testAsync.PontoDeRequest("Assincrono");
            Console.WriteLine(palavra);

            Thread.Sleep(30000);
        }
    }
}