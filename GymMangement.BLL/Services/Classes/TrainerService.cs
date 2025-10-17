using GymMangement.BLL.Services.IntrerFaces;
using GymMangement.BLL.ViewModels.TrainerViewModels;
using GymMangement.DAL.Models;
using GymMangement.DAL.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.BLL.Services.Classes
{
    public class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateTrainer(CreateTrainerViewModel trainer)
        {
            try
            {
                if (IsEmailExists(trainer.Email))
                    return false;
                if (IsPhoneExists(trainer.Phone))
                    return false;
                var newTrainer = new Trainer
                {
                    Name = trainer.Name,
                    Email = trainer.Email,
                    Phone = trainer.Phone,
                    DateOfBirth = trainer.DateOfBirth,
                    Gender = trainer.Gender,
                    Adress = new Adress
                    {
                        BuldingNo = trainer.BuldingNo,
                        City = trainer.City,
                        Street = trainer.Street ?? string.Empty,
                    },
                    specialties = trainer.Specialties
                };
                _unitOfWork.GetRepository<Trainer>().Add(newTrainer);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public IEnumerable<TrainerViewModel> GetAllTrainers()
        {
            var trainers = _unitOfWork.GetRepository<Trainer>().GetAll();
            if (trainers == null || !trainers.Any())
                return [];
            var trainerViewModels = trainers.Select(t => new TrainerViewModel
            {
                Id = t.id,
                Name = t.Name,
                Email = t.Email,
                Phone = t.Phone,
                DateOfBirth = t.DateOfBirth.ToShortDateString(),
                specialties = t.specialties.ToString(),
            });
            return trainerViewModels;
        }

        public TrainerViewModel? GetTrainerDetails(int TrainerId)
        {
            var trainer = _unitOfWork.GetRepository<Trainer>().GetById(TrainerId);
            if (trainer == null)
                return null;
            var trainerViewModel = new TrainerViewModel
            {
                Id = trainer.id,
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                DateOfBirth = trainer.DateOfBirth.ToShortDateString(),
                Address = FormatAdress(trainer.Adress),
                specialties = trainer.specialties.ToString() ?? "N/A",
            };
            return trainerViewModel;
        }

        public TrainerToUpdateViewModel? GetTrainerForUpdate(int TrainerId)
        {
            var trainer = _unitOfWork.GetRepository<Trainer>().GetById(TrainerId);
            if (trainer == null)
                return null;
            var trainerToUpdate = new TrainerToUpdateViewModel
                {
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                DateOfBirth = trainer.DateOfBirth,
                City = trainer.Adress?.City ?? string.Empty,
                Street = trainer.Adress?.Street ?? string.Empty,
                BuldingNo = trainer.Adress?.BuldingNo ?? 0,
                Specialties = trainer.specialties 
            };
            return trainerToUpdate;
        }

        public bool RemoveTrainer(int TrainerId)
        {
            var existingTrainer = _unitOfWork.GetRepository<Trainer>().GetById(TrainerId);
            if (existingTrainer == null)
                return false;
            var assignedSessions = _unitOfWork.GetRepository<Session>()
                .GetAll(s => s.TrainerId == TrainerId && s.StartDate > DateTime.Now);
            if (assignedSessions != null && assignedSessions.Any())
                return false;
            _unitOfWork.GetRepository<Trainer>().Delete(existingTrainer);
            return true;



        }

        public bool UpdateTrainerDetails(int TrainerId, TrainerToUpdateViewModel trainer)
        {
            var existingTrainer = _unitOfWork.GetRepository<Trainer>().GetById(TrainerId);
            if (existingTrainer == null)
                return false;
            if (existingTrainer.Email != trainer.Email && IsEmailExists(trainer.Email))
                return false;
            if (existingTrainer.Phone != trainer.Phone && IsPhoneExists(trainer.Phone))
                return false;
            existingTrainer.Name = trainer.Name ?? "N/a";
            existingTrainer.Email = trainer.Email;
            existingTrainer.Phone = trainer.Phone;
            existingTrainer.Adress.City = trainer.City;
            existingTrainer.Adress.Street = trainer.Street ?? string.Empty;
            existingTrainer.Adress.BuldingNo = trainer.BuldingNo;
            existingTrainer.specialties = trainer.Specialties;
            _unitOfWork.GetRepository<Trainer>().Update(existingTrainer);
            return true;
        }



        #region Helper Methods
        private string FormatAdress(Adress adress)
        {
            if (adress is null)
                return "N/A";
            else
                return $"{adress.BuldingNo}, {adress.Street} , {adress.City}";
        }

        private bool IsEmailExists(string email)
        {
            var existingTrainer = _unitOfWork.GetRepository<Trainer>().GetAll(m => m.Email == email);
            return existingTrainer != null && existingTrainer.Any();

        }

        private bool IsPhoneExists(string phone)
        {
            var existingTrainer = _unitOfWork.GetRepository<Trainer>().GetAll(m => m.Phone == phone);
            return existingTrainer != null && existingTrainer.Any();
        }

        #endregion
    }
}
    

