namespace EstruturaDeDados.Cap1_Intro.Pratica
{
    public static class Cap1Pratica
    {
        public static void CriarNovoAtendimentoFilaOrdenado()
        {
            FilaAtendimento filaAtendimento = new FilaAtendimento();
            Atendimento atendimento1 = new Atendimento("João", DateTime.Now, Prioridade.Alta);
            atendimento1.Animal = new Animal("Rex", "Cachorro");
            filaAtendimento.AdicionarAtendimento(atendimento1);
            Atendimento atendimento2 = new Atendimento("Maria", DateTime.Now.AddMinutes(10), Prioridade.Baixa);
            atendimento2.Animal = new Animal("Mimi", "Gato");
            filaAtendimento.AdicionarAtendimento(atendimento2);
            Atendimento atendimento3 = new Atendimento("Sofia", DateTime.Now.AddMinutes(20), Prioridade.Media);
            atendimento3.Animal = new Animal("Tweety", "Pássaro");
            filaAtendimento.AdicionarAtendimento(atendimento3);
            Console.WriteLine($"Total de atendimentos na fila: {filaAtendimento.ContarAtendimentos()}");
            Console.WriteLine("#####ATENDIMENTO ORDENADO SEM PRIORIDADE#####");
            foreach (var atendimento in filaAtendimento.ObterAtendimentos())
            {
                Atendimento atendimentoProcessado = filaAtendimento.ProcessarAtendimento();
                Console.WriteLine($"Atendimento processado para o cliente: {atendimentoProcessado.NomeCliente}, Animal: {atendimentoProcessado.Animal.Nome} , Prioridade: {atendimentoProcessado.Prioridade}");
                Console.WriteLine($"Total de atendimentos na fila após processamento: {filaAtendimento.ContarAtendimentos()}");
            }
            Console.WriteLine();
        }
        public static void CriarNovoAtendimentoFilaPrioritaria()
        {
            FilaPrioritariaAtendimento filaPrioritaria = new FilaPrioritariaAtendimento();
            Atendimento atendimento1 = new Atendimento("Pedro", DateTime.Now, Prioridade.Media);
            atendimento1.Animal = new Animal("Bob", "Peixe");
            filaPrioritaria.AdicionarAtendimento(atendimento1);
            Atendimento atendimento2 = new Atendimento("Luiza", DateTime.Now.AddMinutes(15), Prioridade.Alta);
            atendimento2.Animal = new Animal("Nina", "Hamster");
            filaPrioritaria.AdicionarAtendimento(atendimento2);
            Atendimento atendimento3 = new Atendimento("Marcos", DateTime.Now.AddMinutes(5), Prioridade.Baixa);
            atendimento3.Animal = new Animal("Coco", "Papagaio");
            filaPrioritaria.AdicionarAtendimento(atendimento3);
            Console.WriteLine($"Total de atendimentos na fila prioritária: {filaPrioritaria.ContarAtendimentos()}");
            Console.WriteLine("#####ATENDIMENTO POR PRIORIDADE E HORÁRIO#####");
            foreach (var atendimento in filaPrioritaria.ObterAtendimentos())
            {
                Atendimento atendimentoProcessado = filaPrioritaria.ProcessarAtendimento();
                Console.WriteLine($"Atendimento processado para o cliente: {atendimentoProcessado.NomeCliente}, Animal: {atendimentoProcessado.Animal.Nome} , Prioridade: {atendimentoProcessado.Prioridade}");
                Console.WriteLine($"Total de atendimentos na fila prioritária após processamento: {filaPrioritaria.ContarAtendimentos()}");
            }
            Console.WriteLine();
        }

        public static void CriarBagAtendimentoNaoOrdenado()
        {
            BagNaoOrdenada bagAtendimento = new BagNaoOrdenada();
            Atendimento atendimento1 = new Atendimento("Carlos", DateTime.Now, Prioridade.Media);
            atendimento1.Animal = new Animal("Luna", "Coelho");
            bagAtendimento.Adicionar(atendimento1);
            Atendimento atendimento2 = new Atendimento("Ana", DateTime.Now.AddMinutes(5), Prioridade.Alta);
            atendimento2.Animal = new Animal("Kiki", "Pássaro");
            bagAtendimento.Adicionar(atendimento2);
            Atendimento atendimento3 = new Atendimento("Beatriz", DateTime.Now.AddMinutes(10), Prioridade.Baixa);
            atendimento3.Animal = new Animal("Max", "Cachorro");
            bagAtendimento.Adicionar(atendimento3);

            Console.WriteLine("#####ATENDIMENTO DESORDENADO#####");
            foreach (var atendimento in bagAtendimento.ObterAtendimentos())
            {
                
                Console.WriteLine(
                    $"Atendimento processado para o cliente: {atendimento.NomeCliente}, Animal: {atendimento.Animal.Nome}, Prioridade: {atendimento.Prioridade}, Hora: {atendimento.HoraAtendimento}"
                );
            }
            Console.WriteLine();
        }
    }

}

public class Animal
{
    public string Nome { get; set; }
    public string Especie { get; set; }
    public Animal(string nome, string especie)
    {
        Nome = nome;
        Especie = especie;
    }
}

public class Atendimento
{
    public string NomeCliente { get; set; }
    public DateTime HoraAtendimento { get; set; }
    public Animal Animal { get; set; }
    public Prioridade Prioridade { get; set; }
    public Atendimento(string nomeCliente, DateTime horaAtendimento, Prioridade prioridade)
    {
        NomeCliente = nomeCliente;
        HoraAtendimento = horaAtendimento;
        Prioridade = prioridade;
    }
}

public enum Prioridade
{
    Baixa,
    Media,
    Alta
}
public class AtendimentoComparer : IComparer<Atendimento>
{
    public int Compare(Atendimento x, Atendimento y)
    {
        if (x.Prioridade != y.Prioridade)
        {
            return y.Prioridade.CompareTo(x.Prioridade);
        }
        return x.HoraAtendimento.CompareTo(y.HoraAtendimento);
    }
}
public class FilaPrioritariaAtendimento
{
    private SortedSet<Atendimento> filaPrioritaria;
    public FilaPrioritariaAtendimento()
    {
        filaPrioritaria = new SortedSet<Atendimento>(new AtendimentoComparer());
    }
    public void AdicionarAtendimento(Atendimento atendimento)
    {
        filaPrioritaria.Add(atendimento);
    }
    public Atendimento ProcessarAtendimento()
    {
        if (filaPrioritaria.Count == 0)
            throw new InvalidOperationException("Nenhum atendimento na fila.");
        var atendimento = filaPrioritaria.Min;
        filaPrioritaria.Remove(atendimento!);
        return atendimento!;
    }
    public int ContarAtendimentos()
    {
        return filaPrioritaria.Count;
    }
    public List<Atendimento> ObterAtendimentos()
    {
        return filaPrioritaria.ToList();
    }
}


public class FilaAtendimento
{
    private Queue<Atendimento> fila;
    public FilaAtendimento()
    {
        fila = new Queue<Atendimento>();
    }
    public void AdicionarAtendimento(Atendimento atendimento)
    {
        fila.Enqueue(atendimento);
    }
    public Atendimento ProcessarAtendimento()
    {
        if (fila.Count == 0)
            throw new InvalidOperationException("Nenhum atendimento na fila.");
        return fila.Dequeue();
    }
    public int ContarAtendimentos()
    {
        return fila.Count;
    }
    public List<Atendimento> ObterAtendimentos()
    {
        return fila.ToList();
    }
}

public class BagNaoOrdenada
{
    private List<Atendimento> Atendimentos;
    public BagNaoOrdenada()
    {
        Atendimentos = new List<Atendimento>();
    }
    public void Adicionar(Atendimento item)
    {
        Atendimentos.Add(item);
    }
    public int Contar()
    {
        return Atendimentos.Count;
    }
    public List<Atendimento> ObterAtendimentos()
    {
        return Atendimentos.OrderBy(a => Random.Shared.Next()).ToList();
    }

}