using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExamenCsharp.Models.ViewModels;
using ExamenCsharp.Services.Interfaces;

namespace ExamenCsharp.Controllers;

public class InscriptionController : Controller
{
    private readonly IInscriptionService _inscriptionService;
    private readonly IClasseService _classeService;

    public InscriptionController(IInscriptionService inscriptionService, IClasseService classeService)
    {
        _inscriptionService = inscriptionService;
        _classeService = classeService;
    }

    // GET: Inscription/Enregistrer
    public IActionResult Enregistrer()
    {
        ChargerListeClasses();
        return View(new InscriptionViewModel());
    }

    // POST: Inscription/Enregistrer
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Enregistrer(InscriptionViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ChargerListeClasses();
            return View(model);
        }

        try
        {
            _inscriptionService.EnregistrerInscription(
                model.Matricule,
                model.Nom,
                model.Prenom,
                model.CodeClasse,
                model.Montant
            );

            TempData["SuccessMessage"] = "Inscription enregistrée avec succès!";
            return RedirectToAction(nameof(Enregistrer));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            ChargerListeClasses();
            return View(model);
        }
    }

    // GET: Inscription/Liste
    public IActionResult Liste(string? codeClasse)
    {
        ChargerListeClasses();

        if (string.IsNullOrEmpty(codeClasse))
        {
            // Afficher toutes les inscriptions par défaut
            var toutesInscriptions = _inscriptionService.ListerToutesInscriptions();
            return View(new ListeInscriptionsViewModel
            {
                CodeClasse = "TOUTES",
                LibelleClasse = "Toutes les classes",
                Inscriptions = toutesInscriptions
            });
        }

        var classe = _classeService.GetClasseByCode(codeClasse);
        var inscriptions = _inscriptionService.ListerInscriptionsParClasse(codeClasse);

        var viewModel = new ListeInscriptionsViewModel
        {
            CodeClasse = codeClasse,
            LibelleClasse = classe?.Libelle ?? codeClasse,
            Inscriptions = inscriptions
        };

        return View(viewModel);
    }

    private void ChargerListeClasses()
    {
        var classes = _classeService.GetAllClasses();
        ViewBag.Classes = new SelectList(classes, "Code", "Libelle");
    }
}
