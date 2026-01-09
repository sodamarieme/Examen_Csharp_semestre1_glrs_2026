using ExamenCsharp.Models.Entities;
using ExamenCsharp.Repositories.Interfaces;

namespace ExamenCsharp.Repositories.Implementations;

public class ClasseRepository : IClasseRepository
{
    // Données initialisées
    private static readonly List<Classe> _classes = new()
    {
        new Classe { Code = "L1-INFO", Libelle = "Licence 1 Informatique" },
        new Classe { Code = "L2-INFO", Libelle = "Licence 2 Informatique" },
        new Classe { Code = "L3-INFO", Libelle = "Licence 3 Informatique" },
        new Classe { Code = "M1-INFO", Libelle = "Master 1 Informatique" },
        new Classe { Code = "M2-INFO", Libelle = "Master 2 Informatique" }
    };

    public Classe? GetByCode(string code)
    {
        return _classes.FirstOrDefault(c => c.Code == code);
    }

    public IEnumerable<Classe> GetAll()
    {
        return _classes.ToList();
    }
}
