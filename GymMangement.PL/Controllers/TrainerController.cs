using GymMangement.BLL.Services.IntrerFaces;
using GymMangement.BLL.ViewModels.TrainerViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymMangement.PL.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        public IActionResult Index()
        {
            var trainers= _trainerService.GetAllTrainers();
            return View(trainers);
        }

        public IActionResult TrainerDetails(int id)
        {
            var trainer = _trainerService.GetTrainerDetails(id);
            if (trainer == null)
                return NotFound();
            return View(trainer);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTrainer(CreateTrainerViewModel input)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataMissed", "Check Missing Data");
                return View(nameof(Create), input);
            }
            var isCreated = _trainerService.CreateTrainer(input);
            if (isCreated)
            {
                TempData["SuccessMessage"] = "Trainer Created Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to Create Trainer. Email or Phone may already exist.";
                return View(nameof(Create), input);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditTrainer( int id)
        {
             var trainer = _trainerService.GetTrainerForUpdate(id);
            if (trainer == null)
                return NotFound();
            return View(trainer);
        }
        [HttpPost]
        public IActionResult EditTrainer([FromRoute]int id, TrainerToUpdateViewModel input)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataMissed", "Check Missing Data");
                return View(nameof(EditTrainer), input);
            }
            var isUpdated = _trainerService.UpdateTrainerDetails(id, input);
            if (isUpdated)
            {
                TempData["SuccessMessage"] = "Trainer Updated Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to Update Trainer. Email or Phone may already exist.";
                return View(nameof(EditTrainer), input);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]

        public IActionResult DeleteTrainer([FromRoute]int id)
        {
            var isDeleted = _trainerService.RemoveTrainer(id);
            if (isDeleted)
            {
                TempData["SuccessMessage"] = "Trainer Deleted Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to Delete Trainer. Trainer may have active sessions.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
