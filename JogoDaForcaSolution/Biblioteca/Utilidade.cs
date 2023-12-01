namespace Biblioteca
{
    public class Utilidade
    {
        public static void ImprimirPalavra(char[] palavraVaziaVetor)
        {
            Array.ForEach(palavraVaziaVetor, x => Console.Write(x + " "));
            Console.WriteLine();
        }
        
        public static bool VerificarEntrada(bool entrada, char caractere, List<char> letrasDigitadas)
        {
            if (!entrada || !char.IsLetter(caractere))
            {
                Console.Clear();
                Console.WriteLine("Digite uma letra válida\n");
                return true;
            }

            if (letrasDigitadas.Contains(caractere))
            {
                Console.Clear();
                Console.WriteLine("Letra já inserida anteriormente\n");
                return true;
            }

            return false;
        }

        public static bool VerificarFim(int tentativas, char[] palavraVaziaVetor)
        {
            if (tentativas == 0)
            {
                Console.Clear();
                Console.WriteLine("Que pena! Suas tentativas acabaram e você não acertou a palavra!\n");
                return true;
            }

            if (!palavraVaziaVetor.Contains('_'))
            {
                Console.Clear();
                Console.WriteLine($"Parabéns! Você acertou\n");
                return true;
            }

            return false;
        }

        public static void VerificarLetraExiste(string palavra, ref int tentativas, char caractere, char[] palavraVaziaVetor)
        {
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
        }
    }
}
