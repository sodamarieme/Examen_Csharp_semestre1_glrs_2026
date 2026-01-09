using ExamenCsharp.Models.Entities;
using ExamenCsharp.Repositories.Interfaces;

namespace ExamenCsharp.Repositories.Implementations;

public class AnneeScolaireRepository : IAnneeScolaireRepository
{
    // Données initialisées
    private static readonly List<AnneeScolaire> _anneesScolaires = new()
    {
        new AnneeScolaire { Code = "2024-2025", Libelle = "Année Scolaire 2024-2025", Statut = Statut.Cloture },
        new AnneeScolaire { Code = "2025-2026", Libelle = "Année Scolaire 2025-2026", Statut = Statut.EnCours }
    };

    public AnneeScolaire? GetAnneeScolaireEnCours()
    {
        return _anneesScolaires.FirstOrDefault(a => a.Statut == Statut.EnCours);
    }

    public IEnumerable<AnneeScolaire> GetAll()
    {
        return _anneesScolaires.ToList();
    }
}
