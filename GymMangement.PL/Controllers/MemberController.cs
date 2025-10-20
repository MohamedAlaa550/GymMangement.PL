using GymMangement.BLL.Services.IntrerFaces;
using Microsoft.AspNetCore.Mvc;

namespace GymMangement.PL.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Index()
        {
            var members = _memberService.GetAllMembers();
            return View(members);
        }

        public IActionResult MemberDetails(int id) 
        {
            var member =  _memberService.GetMemberDetails(id);
            if (member == null)
                return NotFound();
            return View(member);
        }

        public IActionResult HealthRecordDetails(int id) 
        {
            var member = _memberService.GetMemberHealthRecord(id);
            if (member == null)
                return NotFound();
            return View(member);
        }
    }
}
