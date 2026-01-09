using ExamenCsharp.Models.Entities;

namespace ExamenCsharp.Repositories.Interfaces;

public interface IClasseRepository
{
    Classe? GetByCode(string code);
    IEnumerable<Classe> GetAll();
}
