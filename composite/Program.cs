using System;
using System.Collections.Generic;

abstract class Empregado
{
    protected string nome;

    public Empregado(string nome)
    {
        this.nome = nome;
    }

    public abstract void MostrarEstrutura(int nivel);
}

class EmpregadoInd : Empregado
{
    public EmpregadoInd(string nome) : base(nome) { }

    public override void MostrarEstrutura(int nivel)
    {
        Console.WriteLine(new string('-', nivel) + nome);
    }
}

class Gerente : Empregado
{
    private List<Empregado> empregados = new List<Empregado>();

    public Gerente(string nome) : base(nome) { }

    public void AdicionarEmpregado(Empregado empregado)
    {
        empregados.Add(empregado);
    }

    public void RemoverEmpregado(Empregado empregado)
    {
        empregados.Remove(empregado);
    }

    public override void MostrarEstrutura(int nivel)
    {
        Console.WriteLine(new string('-', nivel) + nome);
        foreach (var empregado in empregados)
        {
            empregado.MostrarEstrutura(nivel + 1);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando empregados individuais
        Empregado empregado1 = new EmpregadoInd("Alice");
        Empregado empregado2 = new EmpregadoInd("Ana");

        // Criando um gerente
        Gerente gerente = new Gerente("Carlos");
        gerente.AdicionarEmpregado(empregado1);
        gerente.AdicionarEmpregado(empregado2);

        // Criando um outro gerente
        Gerente gerente2 = new Gerente("Diana");
        Empregado empregado3 = new EmpregadoInd("Lucas");
        gerente2.AdicionarEmpregado(empregado3);

        // Criando o gerente principal e adicionando gerentes
        Gerente gerentePrincipal = new Gerente("Fernando");
        gerentePrincipal.AdicionarEmpregado(gerente);
        gerentePrincipal.AdicionarEmpregado(gerente2);

        // Mostrando a estrutura da organização
        gerentePrincipal.MostrarEstrutura(0);
    }
}
