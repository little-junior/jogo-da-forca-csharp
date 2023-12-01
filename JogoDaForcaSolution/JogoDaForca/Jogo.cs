namespace JogoDaForca
{
    internal class Jogo
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new()
            {
                {"Brasil", "País" },
                {"Carne", "Comida" },
                {"Cachorro", "Animal"},
                {"Maçã", "Fruta"},
                {"Computador", "Eletrônico"},
                {"Montanha", "Geografia"},
                {"Avião", "Meio de Transporte"},
                {"Livro", "Objeto"},
                {"Piano", "Instrumento Musical"},
                {"Sapato", "Vestuário"},
                {"Oceano", "Geografia"},
                {"Elefante", "Animal"},
                {"Bicicleta", "Meio de Transporte"},
                {"Árvore", "Vegetal"},
                {"Telefone", "Eletrônico"},
                {"Pintura", "Arte"},
                {"Pizza", "Comida"},
                {"Sol", "Corpo Celeste"},
                {"Óculos", "Acessório"},
                {"Rio", "Geografia"},
                {"Foguete", "Meio de Transporte"},
                {"Relógio", "Acessório"}
            };
            while (true)
            {
                Console.Clear();
                var numAleatorio = new Random().Next(0, dict.Count);
                var aleatorio = dict.ElementAt(numAleatorio);

                var palavra = aleatorio.Key;
                var temaPalavra = aleatorio.Value;

                string palavraVazia = new('_', palavra.Length);
                char[] palavraVaziaVetor = palavraVazia.ToCharArray();

                bool acertou = false, tentativasAcabaram = false;
                bool verificarEntrada;
                int tentativas = 5;
                List<char> letrasDigitadas = [];

                do
                {
                    Console.WriteLine($"Tema da palavra: {temaPalavra}");
                    Console.WriteLine($"Tentativas restantes: {tentativas}\n");
                    Array.ForEach(palavraVaziaVetor, x => Console.Write(x + " "));
                    Console.WriteLine();
                    verificarEntrada = char.TryParse(Console.ReadLine(), out char caractere);

                    if (!verificarEntrada || !char.IsLetter(caractere))
                    {
                        Console.Clear();
                        Console.WriteLine("Digite uma letra válida\n");
                        continue;
                    }

                    if (letrasDigitadas.Contains(caractere))
                    {
                        Console.Clear();
                        Console.WriteLine("Letra já inserida anteriormente\n");
                        continue;
                    }

                    letrasDigitadas.Add(caractere);

                    if (palavra.Contains(caractere))
                    {
                        for (int i = 0; i < palavra.Length; i++)
                        {
                            if (palavra[i] == caractere)
                            {
                                palavraVaziaVetor[i] = caractere;
                            }
                        }
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("A letra digitada não existe na palavra-chave\n");
                        tentativas--;
                        
                    }

                    if (tentativas == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Que pena! Suas tentativas acabaram e você não acertou a palavra!\n");
                        acertou = true;
                    }

                    if (!palavraVaziaVetor.Contains('_'))
                    {
                        Console.Clear();
                        Console.WriteLine($"Parabéns! Você acertou\n");
                        acertou = true;
                    }

                } while (!acertou);

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
