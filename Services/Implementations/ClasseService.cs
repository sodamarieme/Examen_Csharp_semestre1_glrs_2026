using ExamenCsharp.Models.Entities;
using ExamenCsharp.Repositories.Interfaces;
using ExamenCsharp.Services.Interfaces;

namespace ExamenCsharp.Services.Implementations;

public class ClasseService : IClasseService
{
    private readonly IClasseRepository _classeRepository;

    public ClasseService(IClasseRepository classeRepository)
    {
        _classeRepository = classeRepository;
    }

    public IEnumerable<Classe> GetAllClasses()
    {
        return _classeRepository.GetAll();
    }

    public Classe? GetClasseByCode(string code)
    {
        return _classeRepository.GetByCode(code);
    }
}
