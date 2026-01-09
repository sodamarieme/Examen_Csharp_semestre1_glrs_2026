using ExamenCsharp.Models.Entities;

namespace ExamenCsharp.Repositories.Interfaces;

public interface IAnneeScolaireRepository
{
    AnneeScolaire? GetAnneeScolaireEnCours();
    IEnumerable<AnneeScolaire> GetAll();
}
