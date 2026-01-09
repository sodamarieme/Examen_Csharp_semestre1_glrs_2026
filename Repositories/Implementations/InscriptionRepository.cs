using ExamenCsharp.Models.Entities;
using ExamenCsharp.Repositories.Interfaces;

namespace ExamenCsharp.Repositories.Implementations;

public class InscriptionRepository : IInscriptionRepository
{
    private static readonly List<Inscription> _inscriptions = new();
    private static int _nextId = 1;

    public void Ajouter(Inscription inscription)
    {
        inscription.Id = _nextId++;
        _inscriptions.Add(inscription);
    }

    public IEnumerable<Inscription> GetByClasse(string codeClasse)
    {
        return _inscriptions.Where(i => i.Classe.Code == codeClasse).ToList();
    }

    public IEnumerable<Inscription> GetAll()
    {
        return _inscriptions.ToList();
    }
}
