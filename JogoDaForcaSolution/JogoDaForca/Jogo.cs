namespace JogoDaForca
{
    using Dados;
    using Biblioteca;
    internal class Jogo
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                var numAleatorio = new Random().Next(0, DadosParaUso.dictPalavraTipo.Count);
                var aleatorio = DadosParaUso.dictPalavraTipo.ElementAt(numAleatorio);

                var palavra = aleatorio.Key;
                var temaPalavra = aleatorio.Value;

                string palavraVazia = new('_', palavra.Length);
                char[] palavraVaziaVetor = palavraVazia.ToCharArray();

                bool acabou = false;
                bool entrada, resultadoEntrada;
                int tentativas = 5;
                List<char> letrasDigitadas = [];

                do
                {
                    Console.WriteLine($"Tema da palavra: {temaPalavra}");
                    Console.WriteLine($"Tentativas restantes: {tentativas}\n");
                    
                    Utilidade.ImprimirPalavra(palavraVaziaVetor);
                    Console.WriteLine();

                    entrada = char.TryParse(Console.ReadLine(), out char caractere);
                    resultadoEntrada = Utilidade.VerificarEntrada(entrada, caractere, letrasDigitadas);

                    if (resultadoEntrada)
                    {
                        continue;
                    }

                    letrasDigitadas.Add(caractere);

                    Utilidade.VerificarLetraExiste(palavra, ref tentativas, caractere, palavraVaziaVetor);

                    acabou = Utilidade.VerificarFim(tentativas, palavraVaziaVetor);

                } while (!acabou);

                Console.WriteLine($"A palavra era -> {palavra}\n");
               
                Console.WriteLine("Deseja jogar novamente?\nSim[1]\t\tNão[0]\n");
                _ = char.TryParse(Console.ReadLine(), out char respostaSaida);
                if(respostaSaida != '1')
                {
                    break;
                }
                continue;
            }
        }
    }
}
