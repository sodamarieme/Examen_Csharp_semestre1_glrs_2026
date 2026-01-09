using System.ComponentModel.DataAnnotations;

namespace ExamenCsharp.Models.ViewModels;

public class InscriptionViewModel
{
    [Required(ErrorMessage = "Le matricule est obligatoire")]
    [Display(Name = "Matricule")]
    public string Matricule { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le nom est obligatoire")]
    [Display(Name = "Nom")]
    public string Nom { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le prénom est obligatoire")]
    [Display(Name = "Prénom")]
    public string Prenom { get; set; } = string.Empty;

    [Required(ErrorMessage = "La classe est obligatoire")]
    [Display(Name = "Classe")]
    public string CodeClasse { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le montant est obligatoire")]
    [Range(0, int.MaxValue, ErrorMessage = "Le montant doit être positif")]
    [Display(Name = "Montant")]
    public int Montant { get; set; }
}
