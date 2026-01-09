namespace ExamenCsharp.Models.Entities;

public class AnneeScolaire
{
    public string Code { get; set; } = string.Empty;
    public string Libelle { get; set; } = string.Empty;
    public Statut Statut { get; set; }
}
