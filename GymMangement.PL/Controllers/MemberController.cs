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
    }
}
