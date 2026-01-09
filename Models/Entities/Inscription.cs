namespace ExamenCsharp.Models.Entities;

public class Inscription
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Montant { get; set; }
    
    // Relations
    public Etudiant Etudiant { get; set; } = null!;
    public Classe Classe { get; set; } = null!;
    public AnneeScolaire AnneeScolaire { get; set; } = null!;
}
