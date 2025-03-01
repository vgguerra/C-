using lista.DTOs;

namespace lista.Models;

public class Agenda
{
    private List<Contato> contatos;


    public Agenda()
    {
        contatos = new List<Contato>();
    }

    public void adicionarContato(ContatoDTO contato)
    {
        contatos.Add(new Contato(contato));
    }

    public void apagarContato(int contatoId)
    {
        contatos.RemoveAt(contatoId);
    }

    public List<Contato> listarContatos()
    {
        return this.contatos;
    }

    public void editarContato(ContatoDTO contato,int contatoId)
    {
        this.contatos[contatoId] = new Contato(contato);
    }
    
    
}