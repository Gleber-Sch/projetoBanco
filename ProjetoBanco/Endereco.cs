namespace ProjetoBanco
{
    internal class Endereco
    {
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public short Numero { get; private set; }
        public Cidade Cidade { get; private set; }

        public Endereco(string logradouro, string bairro, string cep, short numero, Cidade cidade)
        {
            //'this.' encherga os atributos do escopo da classe e não do método
            Logradouro = logradouro;
            Bairro = bairro;
            Cep = cep;
            Numero = numero;
            Cidade = cidade;
        }

    }
}
