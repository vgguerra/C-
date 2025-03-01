using System;
using System.Text.Json;
using lista.DTOs;
using lista.Models;


namespace lista;

class Program
{
    private Agenda agenda;

    public Program()
    {
        agenda = new Agenda();
    }

    public void adicionarContato(ContatoDTO contato)
    {
        agenda.adicionarContato(contato);
    }

    public void removerContato(int contatoId)
    {
        agenda.apagarContato(contatoId);
    }

    public void editarContato(ContatoDTO contato,int contatoId)
    {
        agenda.editarContato(contato, contatoId);
    }

    public List<Contato> listarContatos()
    {
        return agenda.listarContatos();
    }

    public void imprimirContatos()
    {
        int j = 0;
        foreach (var item in agenda.listarContatos())
        {
            Console.WriteLine($"{j+1}-{item.Nome}-{item.Email}-{item.Telefone}");
            j++;
        }
    }

    static void salvarContato(Agenda agenda)
    {
        try
        {
            string json = JsonSerializer.Serialize(agenda.listarContatos(),
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("C:\\Users\\User\\Estudos\\contatos.json", json);
            Console.WriteLine("Salvo em JSON");
        }
        catch (IOException ioException)
        {
            Console.WriteLine($"❌ Erro ao salvar o arquivo: {ioException.Message}");
        }
        catch (Exception ex) // Captura qualquer outro erro
        {
            Console.WriteLine($"❌ Erro inesperado ao salvar contatos: {ex.Message}");
        }
    }
    
    static List<Contato> CarregarContatos()
    {
        try
        {
            if (!File.Exists("C:\\Users\\User\\Estudos\\contatos.json"))
            {
                Console.WriteLine("⚠️ Arquivo JSON não encontrado. Criando um novo...");
                return new List<Contato>();
            }

            string json = File.ReadAllText("C:\\Users\\User\\Estudos\\contatos.json");
            return JsonSerializer.Deserialize<List<Contato>>(json) ?? new List<Contato>();
        }
        catch (JsonException jsonEx) // Erros ao interpretar o JSON
        {
            Console.WriteLine($"❌ Erro ao ler o JSON: {jsonEx.Message}");
            return new List<Contato>();
        }
        catch (IOException ioEx) // Erros de leitura/escrita do arquivo
        {
            Console.WriteLine($"❌ Erro ao acessar o arquivo: {ioEx.Message}");
            return new List<Contato>();
        }
        catch (Exception ex) // Captura qualquer outro erro
        {
            Console.WriteLine($"❌ Erro inesperado ao carregar contatos: {ex.Message}");
            return new List<Contato>();
        }
    }
    
    public void imprimirAlfabetica()
    {
        var grupos = agenda.listarContatos()
            .GroupBy(c => c.Nome[0]).OrderBy(g => g.Key);

        foreach (var item in grupos)
        {
            Console.WriteLine($"Contatos com '{item.Key}':");
            
            foreach (var contato in item)
            {
                Console.WriteLine($"  - {contato.Nome} ({contato.Telefone})");
            }
        }
        
        
    }
    
    
    public static void Main(string[] args)
    {
        
        Program p = new Program();
       
        Console.WriteLine("Bem vindo ao lista de contatos");

        int i = -1;
        
        var lista = p.listarContatos();
        int contatoId;

        string nome;
        string email;
        string telefone;
        
        while (i != 0)
        {
            Console.WriteLine("Selecione a opção desejada:\n1- Adiconar um contato a lista\n2- Remover um contato\n3- Editar um contato\n4- Listar todos os contatos\n5- Imprimir em ordem alfabética\n6- Salvar arquivo em JSON\n7- Carregar um arquivo Json\n0- Sair");
            i = Convert.ToInt32(Console.ReadLine());

            switch (i)
            {
                case 1:
                    Console.WriteLine("Digite o nome do contato: "); 
                    nome = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Digite o email do contato: ");
                    email = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Digite o telefone do contato: ");
                    telefone = Console.ReadLine() ?? string.Empty;
                    p.adicionarContato(new ContatoDTO(nome, email, telefone));
                    break;
                
                case 2:
                    Console.WriteLine("Qual contato deseja remover?");
                    p.imprimirContatos();
                    
                    contatoId = int.Parse(Console.ReadLine());
                    p.removerContato(contatoId - 1);
                    break;
                
                case 3:
                    Console.WriteLine("Qual contato deseja alterar?");
                    p.imprimirContatos();
                    contatoId = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Digite o nome do contato: ");
                    nome = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Digite o email do contato: "); 
                    email = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Digite o telefone do contato: ");
                    telefone = Console.ReadLine() ?? string.Empty;
                    
                    p.editarContato(new ContatoDTO(nome, email, telefone), contatoId - 1);
                    break;
                case 4:
                    p.imprimirContatos();
                    break;
                case 5:
                    p.imprimirAlfabetica();
                    break;
                case 6:
                    salvarContato(p.agenda);
                    break;
                case 7:
                    List<Contato> contatosCarregados = CarregarContatos();

                    // 🔹 Exibir os contatos carregados
                    Console.WriteLine("📌 Contatos carregados do JSON:");
                    foreach (var contato in contatosCarregados)
                    {
                        Console.WriteLine($"- {contato.Nome}: {contato.Telefone}");
                    }
                    break;
            }
            
        }
        
    }
}

