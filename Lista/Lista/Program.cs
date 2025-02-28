using System;
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
            Console.WriteLine("Selecione a opção desejada:\n1- Adiconar um contato a lista\n2- Remover um contato\n3- Editar um contato\n4- Listar todos os contatos\n0- Sair");
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
            }
            
        }
        
    }
}

