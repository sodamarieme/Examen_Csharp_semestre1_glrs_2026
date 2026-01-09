using ExamenCsharp.Models.Entities;

namespace ExamenCsharp.Repositories.Interfaces;

public interface IInscriptionRepository
{
    void Ajouter(Inscription inscription);
    IEnumerable<Inscription> GetByClasse(string codeClasse);
    IEnumerable<Inscription> GetAll();
}
