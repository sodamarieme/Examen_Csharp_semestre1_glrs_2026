using ExamenCsharp.Models.Entities;

namespace ExamenCsharp.Services.Interfaces;

public interface IInscriptionService
{
    Inscription EnregistrerInscription(string matricule, string nom, string prenom, string codeClasse, int montant);
    IEnumerable<Inscription> ListerInscriptionsParClasse(string codeClasse);
    IEnumerable<Inscription> ListerToutesInscriptions();
}
