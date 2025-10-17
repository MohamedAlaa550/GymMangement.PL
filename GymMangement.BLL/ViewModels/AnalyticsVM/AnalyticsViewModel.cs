using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.BLL.ViewModels.AnalyticsVM
{
    public class AnalyticsViewModel
    {
        public int TotalMembers { get; set; }
        public int ActiveMembers { get; set; }
        public int TotalTrainers { get; set; }
        public int UpCommingSessions { get; set; }
        public int OnGoingSessions { get; set; }
        public int ComletedSessions { get; set; }

    }
}
