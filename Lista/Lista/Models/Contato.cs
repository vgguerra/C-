using System.Collections;
using lista.DTOs;

namespace lista.Models;

public class Contato
{
    private string nome;
    private string email;
    private string telefone;

    public Contato(ContatoDTO contato)
    {
        this.nome = contato.nome;
        this.email = contato.email;
        this.telefone = contato.telefone;
    }

    public string Nome
    {
        get => nome;
        set => nome = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Email
    {
        get => email;
        set => email = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Telefone
    {
        get => telefone;
        set => telefone = value ?? throw new ArgumentNullException(nameof(value));
    }
}