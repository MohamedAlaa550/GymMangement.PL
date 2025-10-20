using GymMangement.BLL.Services.IntrerFaces;
using GymMangement.BLL.ViewModels.AnalyticsVM;
using GymMangement.DAL.Models;
using GymMangement.DAL.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.BLL.Services.Classes
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnalyticsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AnalyticsViewModel GetAnalyticsData()
        {
           return new AnalyticsViewModel
            {
                TotalMembers = _unitOfWork.GetRepository<Member>().GetAll().Count(),
                ActiveMembers = _unitOfWork.GetRepository<MemberShip>().GetAll(x=> x.Status == "Active").Count(),
                TotalTrainers = _unitOfWork.GetRepository<Trainer>().GetAll().Count(),
                UpCommingSessions = _unitOfWork.GetRepository<Session>().GetAll(s => s.StartDate > DateTime.Now).Count(),
                OnGoingSessions = _unitOfWork.GetRepository<Session>().GetAll(s => s.StartDate <= DateTime.Now && s.EndDate >= DateTime.Now).Count(),
                ComletedSessions = _unitOfWork.GetRepository<Session>().GetAll(s => s.EndDate < DateTime.Now).Count()
            };
        }
    }
}
