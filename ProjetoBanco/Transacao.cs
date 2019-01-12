using ProjetoBanco.Enums;
using System;

namespace ProjetoBanco
{
   internal class Transacao
   {
        public TipoTransacao TipoTransacao { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataHora { get; private set; }

        public Transacao(string descricao, decimal valor, TipoTransacao tipoTransacao)
        {
            TipoTransacao = tipoTransacao;
            Descricao = descricao;
            Valor = valor;
            DataHora = DateTime.Now;
        }
    }
}
