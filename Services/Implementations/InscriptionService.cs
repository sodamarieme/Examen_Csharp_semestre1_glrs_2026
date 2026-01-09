using ExamenCsharp.Models.Entities;
using ExamenCsharp.Repositories.Interfaces;
using ExamenCsharp.Services.Interfaces;

namespace ExamenCsharp.Services.Implementations;

public class InscriptionService : IInscriptionService
{
    private readonly IInscriptionRepository _inscriptionRepository;
    private readonly IClasseRepository _classeRepository;
    private readonly IAnneeScolaireRepository _anneeScolaireRepository;

    public InscriptionService(
        IInscriptionRepository inscriptionRepository,
        IClasseRepository classeRepository,
        IAnneeScolaireRepository anneeScolaireRepository)
    {
        _inscriptionRepository = inscriptionRepository;
        _classeRepository = classeRepository;
        _anneeScolaireRepository = anneeScolaireRepository;
    }

    public Inscription EnregistrerInscription(string matricule, string nom, string prenom, string codeClasse, int montant)
    {
        var classe = _classeRepository.GetByCode(codeClasse) 
            ?? throw new ArgumentException($"Classe avec le code '{codeClasse}' introuvable.");

        var anneeScolaire = _anneeScolaireRepository.GetAnneeScolaireEnCours() 
            ?? throw new InvalidOperationException("Aucune année scolaire en cours.");

        var etudiant = new Etudiant
        {
            Matricule = matricule,
            Nom = nom,
            Prenom = prenom
        };

        var inscription = new Inscription
        {
            Date = DateTime.Now,
            Montant = montant,
            Etudiant = etudiant,
            Classe = classe,
            AnneeScolaire = anneeScolaire
        };

        _inscriptionRepository.Ajouter(inscription);

        return inscription;
    }

    public IEnumerable<Inscription> ListerInscriptionsParClasse(string codeClasse)
    {
        return _inscriptionRepository.GetByClasse(codeClasse);
    }

    public IEnumerable<Inscription> ListerToutesInscriptions()
    {
        return _inscriptionRepository.GetAll();
    }
}
