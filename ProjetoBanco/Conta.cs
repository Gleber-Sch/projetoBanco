using ProjetoBanco.Enums;
using System;
using System.Collections.Generic;

namespace ProjetoBanco
{
    internal class Conta
    {
        public TipoConta TipoConta { get; private set; }
        public int Agencia { get; private set; }
        public int Numero { get; private set; }
        public decimal Saldo { get; private set; } //Decimal é indicado para tipos monetarios
        public Banco Banco { get; private set; }

        //Tipo genérico
        public List<Transacao> Transacoes { get; private set; }

        public Conta(TipoConta tipoConta, int agencia, int numero, Banco banco)
        {
            TipoConta = tipoConta;
            Agencia = agencia;
            Numero = numero;
            Banco = banco;

            /*instancie a lista no construtor, pois o tipo genérico, assim como todos os ostros
            tipos tem valor default null*/
            Transacoes = new List<Transacao>();
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor solicitado é inválido.");
            if (valor > Saldo)
                throw new Exception("Saldo insuficiente para realizar o saque.");

            Debitar("Retirada", valor);
            Console.WriteLine("Saque realizado com sucesso.");
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("Deposito realizado com sucesso.");
            Creditar("Deposito", valor);
            Console.WriteLine("Deposito realizado com sucesso.");
        }

        public void Transferir(int agencia, int numeroConta, decimal valor)
        {
            if (valor <= 0)
               throw new Exception("O valor solicitado é inválido.");
            if (valor > Saldo)
               throw new Exception("Saldo insuficiente para realizar o saque.");

            var contaDestino = Banco.ObterConta(agencia, numeroConta);

            contaDestino.Creditar("Transferencia", valor);
            Debitar("Tranferencia", valor);
            Console.WriteLine("Transferencia realizada com sucesso.");
        }

        public void TirarExtrato()
        {
            if (Transacoes.Count > 0)
            {
                foreach (var transacao in Transacoes)
                {
                    var cor = transacao.TipoTransacao == TipoTransacao.Debito ?
                        ConsoleColor.Red : ConsoleColor.Green;
                    Console.ForegroundColor = cor;
                    //var descricao = transacao.Descricao.PadRight(20, '-') + transacao.Valor.ToString("C");
                    //Console.WriteLine(descricao);
                    Console.WriteLine($"{transacao.Descricao.PadRight(20, '-')}{transacao.Valor.ToString("C")}");
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(string.Empty);
                var saldoDescricao = "Saldo".PadRight(20, '-') + Saldo.ToString("C");
                Console.WriteLine(saldoDescricao);
            }
        }

        private void Creditar(string descricaco, decimal valor)
        {
            var transacao = new Transacao(descricaco, valor, TipoTransacao.Credito);
            Transacoes.Add(transacao);
            Saldo += valor;
        }

        private void Debitar(string descricaco, decimal valor)
        {
            var transacao = new Transacao(descricaco, valor, TipoTransacao.Debito);
            Transacoes.Add(transacao);
            Saldo -= valor;
        }
    }
}
