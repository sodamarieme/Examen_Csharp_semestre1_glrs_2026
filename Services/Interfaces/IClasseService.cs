using ExamenCsharp.Models.Entities;

namespace ExamenCsharp.Services.Interfaces;

public interface IClasseService
{
    IEnumerable<Classe> GetAllClasses();
    Classe? GetClasseByCode(string code);
}
