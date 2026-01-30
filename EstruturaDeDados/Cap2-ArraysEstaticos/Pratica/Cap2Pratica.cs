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
