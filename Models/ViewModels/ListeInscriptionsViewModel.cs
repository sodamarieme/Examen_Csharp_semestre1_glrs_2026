using ExamenCsharp.Models.Entities;

namespace ExamenCsharp.Models.ViewModels;

public class ListeInscriptionsViewModel
{
    public string CodeClasse { get; set; } = string.Empty;
    public string LibelleClasse { get; set; } = string.Empty;
    public IEnumerable<Inscription> Inscriptions { get; set; } = new List<Inscription>();
}
