using AiWebGymTracker.DAL;
using AiWebGymTracker.DAL.Repositories.Abstractions;
using AiWebGymTracker.Infrastructure.Abstractions;
using AiWebGymTracker.Models.Entities;
using AiWebGymTracker.Models.Enums;

namespace AiWebGymTracker.Infrastructure.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Training>> GetAllTrainingsAsync()
        {
            return await _unitOfWork.TrainingRepository.GetAllAsync();
        }

        public async Task<Training> GetTrainingByIdAsync(int id)
        {
            return await _unitOfWork.TrainingRepository.GetByIdAsync(id);
        }

        public async Task CreateTrainingAsync(Training training)
        {
            await _unitOfWork.TrainingRepository.AddAsync(training);
            await _unitOfWork.SavedChangedAsync();
        }

        public async Task CancelTrainingAsync(int id)
        {
            var training = await _unitOfWork.TrainingRepository.GetByIdAsync(id);
            if (training != null)
            {
                training.TrainingType = TrainingType.Canceled;
                await _unitOfWork.TrainingRepository.UpdateAsync(training);
                await _unitOfWork.SavedChangedAsync();
            }
        }

        public async Task UpdateExercisesAsync(int id, List<Exercise> exercises)
        {
            var training = await _unitOfWork.TrainingRepository.GetByIdAsync(id);
            if (training != null)
            {
                training.Exercises = exercises;
                await _unitOfWork.TrainingRepository.UpdateAsync(training);
                await _unitOfWork.SavedChangedAsync();
            }
        }

        public async Task UpdateTrainingDateAsync(int id, DateTime dateTimeStart)
        {
            var training = await _unitOfWork.TrainingRepository.GetByIdAsync(id);
            if (training != null)
            {
                training.DateTimeStart = dateTimeStart;
                training.TrainingType = TrainingType.Delayed;
                await _unitOfWork.TrainingRepository.UpdateAsync(training);
                await _unitOfWork.SavedChangedAsync();
            }
        }

        public async Task CompleteTrainingAsync(int id)
        {
            var training = await _unitOfWork.TrainingRepository.GetByIdAsync(id);
            if (training != null)
            {
                training.DateTimeEnd = DateTime.Now;
                training.TrainingType = TrainingType.Completed;
                await _unitOfWork.TrainingRepository.UpdateAsync(training);
                await _unitOfWork.SavedChangedAsync();
            }
        }
    }
}
