using System;

namespace ProjetoBanco
{
    internal class Program
    {
        private static readonly Banco banco = new Banco();
        private static Conta contaDestino;

        static Program()
        {
            var cidade = new Cidade("Jundiaí", "SP");
            var endereco = new Endereco("Rua Gen. Osório", "Centro", "13219-000", 100, cidade);
            var cliente = new Cliente("Grillo", "123124", new DateTime(1985, 7, 2), endereco);

            contaDestino = banco.Abrirconta(cliente);
        }

        private static void Main(string[] args)
        {
            try
            {
                var cidade = new Cidade("Jundiaí", "SP");
                var endereco = new Endereco("Rua Uncilla Lorenzini", "Terra da Uva", "13219-100", 100, cidade);
                var cliente = new Cliente("Ricardo", "123124", new DateTime(1985, 7, 2), endereco);

                var contaRicardo = banco.Abrirconta(cliente);
                contaRicardo.Depositar(2500);
                contaRicardo.Sacar(350);
                contaRicardo.TirarExtrato();
                contaRicardo.Transferir(1, 1, 1200);
                contaRicardo.TirarExtrato();
                contaDestino.TirarExtrato();   
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }

            Console.ResetColor();
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
