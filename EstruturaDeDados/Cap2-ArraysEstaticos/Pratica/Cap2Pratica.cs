namespace EstruturaDeDados.Cap2_ArraysEstaticos.Pratica
{
    public static class Cap2Pratica
    {
        public static void DefinirArraySimples()
        {
            int[] arrayDeNumerosSimples = { 1, 2, 3, 4, 5, 6, 7 };
            string[] arrayDeStringsSimples = { "Ana", "Bruno", "Carlos", "Daniela" };
            Console.WriteLine("Array de Números Simples:");
            foreach (var numero in arrayDeNumerosSimples)
            {
                Console.WriteLine(numero);
            }
            Console.WriteLine("\nArray de Strings Simples:");
            foreach (var nome in arrayDeStringsSimples)
            {
                Console.WriteLine(nome);
            }
            Console.WriteLine("Array de pessoas");
            Pessoa[] arrayDePessoas = {
                new Pessoa("Ana", 25),
                new Pessoa("Bruno", 30),
                new Pessoa("Carlos", 28),
                new Pessoa("Daniela", 22)
            };
            foreach (var pessoa in arrayDePessoas)
            {
                Console.WriteLine(pessoa.ToString());
            }

            Console.WriteLine("Array de chocolates");
            Chocolate[] arrayDeChocolates = {
                new Chocolate("Ao Leite", 5.99),
                new Chocolate("Amargo", 6.49),
                new Chocolate("Branco", 4.99),
                new Chocolate("Com Avelã", 7.99)
            };
            foreach (var chocolate in arrayDeChocolates)
            {
                Console.WriteLine(chocolate.ToString());
            }
            var arrayTeste = new int[5];
            Console.WriteLine("""Mesmo não tendo definido "nada" pois os valores serão '0' no array estático, ele vai reservar o espaço na memória""");
            foreach(var item in arrayTeste)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Tamanho do arrayTeste: {arrayTeste.Count()}");
        }

        public static void NumerosMaisRepetidos()
        {
           int[] arrayExemplo = { 1, 2, 3, 4, 5, 1, 2, 1, 3, 4, 1 };
           int numeroMaisRepetido = arrayExemplo
                .GroupBy(n => n)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
            Console.WriteLine("Número mais repetido: " + numeroMaisRepetido);
        }
                
        public static void NumeroRepetidoUtilizandoDictionary()
        {
            var arrayNumeros = new[] {1,1,1,2,2,2,3,3,4,5,5,5,5,5,9,9,9,8,8, };
            var contadorNumeros = new Dictionary<int, int>();
            int numeroMaisRepetido = arrayNumeros[0];
            int maxRepeticoes = 0;

            foreach(var numero in arrayNumeros)
            {
                if(contadorNumeros.ContainsKey(numero))
                {
                    contadorNumeros[numero]++;
                }
                else
                {
                    contadorNumeros[numero] = 1;
                }
                if(contadorNumeros[numero] > maxRepeticoes)
                {
                    maxRepeticoes = contadorNumeros[numero];
                    numeroMaisRepetido = numero;
                }
            }
            Console.WriteLine("Array vazio criado com tamanho: " + numeroMaisRepetido);
        }
    }

    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }
        public override string ToString()
        {
            return $"Nome: {Nome}, Idade: {Idade}";
        }
    }

    public class Chocolate
    {
        public string Sabor { get; set; }
        public double Preco { get; set; }
        public Chocolate(string sabor, double preco)
        {
            Sabor = sabor;
            Preco = preco;
        }
        public override string ToString()
        {
            return $"Sabor: {Sabor}, Preço: {Preco:C}";
        }
    }
}
