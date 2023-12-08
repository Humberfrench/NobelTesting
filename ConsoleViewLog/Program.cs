// See https://aka.ms/new-console-template for more information
internal class Program
{

    async static Task Main(string[] args)
    {
        var dados = await LerArquivo();

        Console.WriteLine(dados.ToString());

        //Connections => 838; Licences => 541; Exits => 2077; ShowTransactions => 3289; 
    }


    private static async Task<DataReads> LerArquivo()
    {
        //formato CSV = linha 1 header => CodItemEf;EanEf;CodItemPgm;EanPgm;DescItem
        //header nao precisa ter exatamente  esses nomes, mas os conteudo dos campos sim

        var connections = 0;
        var licences = 0;
        var exits = 0;
        var showTransactions = 0;
        var dados = new DataReads();

        var linhas = await Task.Run(() => File.ReadAllLines("D:\\Desenvolvimento\\Testing for Jobs\\NobelTesting\\ConsoleViewLog\\EvoServer01Read.log"));

        if (!linhas.Any())
        {
            return dados;
        }

        for (int linha = 1; linha < linhas.Length; linha++)
        {
            var registro = linhas[linha];
            if (registro.Contains("CStrSockSrvr"))
            {
                connections++;
            }
            if (registro.Contains("CLicenseManager"))
            {
                licences++;
            }
            if (registro.Contains("SocketThread"))
            {
                exits++;
            }
            if (registro.Contains("MiscConn"))
            {
                exits++;
            }
            if (registro.Contains("Ktr[32c4]>"))
            {
                showTransactions++;
            }
        }

        dados.Connections = connections;
        dados.Licences = licences;
        dados.Exits = exits;
        dados.ShowTransactions = showTransactions;

        return dados;
    }

    struct DataReads
    {
        public int Connections;
        public int Licences;
        public int Exits;
        public int ShowTransactions;

        public override string ToString()
        {
            return $"Connections => {Connections}; Licences => {Licences}; Exits => {Exits}; ShowTransactions => {ShowTransactions}; ";
        }
    }
}