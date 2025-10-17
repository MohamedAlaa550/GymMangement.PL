using GymMangement.BLL.ViewModels.TrainerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.BLL.Services.IntrerFaces
{
    public interface ITrainerService
    {
        IEnumerable<TrainerViewModel> GetAllTrainers();
        bool CreateTrainer(CreateTrainerViewModel trainer);
        TrainerViewModel? GetTrainerDetails(int TrainerId);
        bool RemoveTrainer(int TrainerId);
        bool UpdateTrainerDetails(int TrainerId, TrainerToUpdateViewModel trainer);
        TrainerToUpdateViewModel? GetTrainerForUpdate(int TrainerId);
    }
}
