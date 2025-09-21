using AiWebGymTracker.Infrastructure.Abstractions;
using AiWebGymTracker.Models.Entities;
using AiWebGymTracker.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AiWebGymTracker.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainings = await _trainingService.GetAllTrainingsAsync();
            return View(trainings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Training model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.TrainingType = TrainingType.New;
            await _trainingService.CreateTrainingAsync(model);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            await _trainingService.CancelTrainingAsync(id);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        public async Task<IActionResult> EditExercises(int id)
        {
            var training = await _trainingService.GetTrainingByIdAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        [HttpPost]
        public async Task<IActionResult> EditExercises(int id, List<Exercise> exercises)
        {
            if (!ModelState.IsValid)
            {
                var training = await _trainingService.GetTrainingByIdAsync(id);
                return View(training);
            }

            await _trainingService.UpdateExercisesAsync(id, exercises);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        public async Task<IActionResult> EditDate(int id)
        {
            var training = await _trainingService.GetTrainingByIdAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        [HttpPost]
        public async Task<IActionResult> EditDate(int id, DateTime dateTimeStart)
        {
            if (!ModelState.IsValid)
            {
                var training = await _trainingService.GetTrainingByIdAsync(id);
                return View(training);
            }

            await _trainingService.UpdateTrainingDateAsync(id, dateTimeStart);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        public async Task<IActionResult> Complete(int id)
        {
            await _trainingService.CompleteTrainingAsync(id);
            return RedirectToAction(nameof(GetAll));
        }
    }
}