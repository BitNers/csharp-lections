namespace Aula1601
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0) { 
                Console.WriteLine(args[0].ToString());
            }
            Console.WriteLine("Hello, World!");
        }
    }
}