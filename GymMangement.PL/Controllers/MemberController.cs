using GymMangement.BLL.Services.IntrerFaces;
using GymMangement.BLL.ViewModels.MemberViewModels;
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

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMember(CreateMemberViewModel input) 
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataMissed", "Check Missing Data");
                return View(nameof(Create), input);
            }
               
            var isCreated = _memberService.CreateMember(input);
            if (isCreated)
            {
                TempData["SuccessMessage"] = "Member Created Successfully";
                
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to Create Member. Email or Phone may already exist.";
               
            }
            return RedirectToAction("Index");


        }

        public IActionResult MemberEdit(int id)
        {
            var memmber  = _memberService.GetMemberForUpdate(id);
            if (memmber == null)
                return NotFound();
            return View(memmber);
        }

        [HttpPost]
        public IActionResult MemberEdit([FromRoute] int id,MemberToUpdateViewModel input)
        {
            if (!ModelState.IsValid)
            {
               
                return View(input);
            }

            var result = _memberService.UpdateMemberDetails(id,input);
            if (result)
            {
                TempData["SuccessMessage"] = "Member Created Successfully";

            }
            else
            {
                TempData["ErrorMessage"] = "Member Faild To Update";

            }
            return RedirectToAction("Index");


        }

    }
}
