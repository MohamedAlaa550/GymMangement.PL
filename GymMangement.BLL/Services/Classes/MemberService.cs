using GymMangement.BLL.Services.IntrerFaces;
using GymMangement.BLL.ViewModels.MemberViewModels;
using GymMangement.DAL.Models;
using GymMangement.DAL.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.BLL.Services.Classes
{
    public class MemberService : IMemberService
    {
        private readonly IGenericRepository<Member> _memberRepo;
        private readonly IGenericRepository<MemberShip> _membershipRipo;
        private readonly IGenericRepository<Plan> _planRepo;
        private readonly IGenericRepository<HealthRecord> _healthRecordRepo;

        public MemberService(
            IGenericRepository<Member> memberRepo,
            IGenericRepository<MemberShip> membershipRipo,
            IGenericRepository<Plan> planRepo,
            IGenericRepository<HealthRecord> healthRecordRepo
            ) 
        {
            _memberRepo = memberRepo;
            _membershipRipo = membershipRipo;
            _planRepo = planRepo;
            _healthRecordRepo = healthRecordRepo;
        }

        public bool CreateMember(CreateMemberViewModel member)
        {
            try
            {
                if (IsEmailExists(member.Email))
                    return false;
                if (IsPhoneExists(member.Phone))
                    return false;

                var newMember = new Member
                {
                    Name = member.Name,
                    Email = member.Email,
                    Phone = member.Phone,
                    DateOfBirth = member.DateOfBirth,
                    Gender=member.Gender,
                    Adress = new Adress
                    {
                        BuldingNo = member.BuldingNo,
                        City = member.City,
                        Street = member.Street ?? string.Empty,
                    },
                    HealthRecord = new HealthRecord
                    {
                        Height = member.HealthRecordViewModel.Height,
                        Weight = member.HealthRecordViewModel.Weight,
                        BloodType = member.HealthRecordViewModel.BloodType ?? string.Empty,
                        Notes = member.HealthRecordViewModel.Note ?? string.Empty,
                    }

                };
                _memberRepo.Add(newMember);
                return true;


            }
            catch
            {

                return false;
            }
            
        }

        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var members = _memberRepo.GetAll();

            if (members == null || !members.Any())
                return [];
            var memberViewModels = members.Select(m => new MemberViewModel
            {
                Id = m.id,
                Photo = m.photo ?? string.Empty,
                Name = m.Name,
                Email = m.Email,
                Phone = m.Phone,
                DateOfBirth = m.DateOfBirth.ToShortDateString(),
                Gender = m.Gender.ToString(),
            });
            return memberViewModels;
        }

        public MemberViewModel GetMemberDetails(int MemberId)
        {
            var member = _memberRepo.GetById(MemberId);
            if (member == null)
                return null!;
            var memberViewModel = new MemberViewModel
            {
                Id = member.id,
                Photo = member.photo ?? string.Empty,
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                DateOfBirth = member.DateOfBirth.ToShortDateString(),
                Address = FormatAdress(member.Adress),
            };
            var activeMembership= _membershipRipo
                .GetAll(ms=> ms.MemberId == MemberId && ms.Status == "Active")
                .FirstOrDefault();

            if (activeMembership != null)
                {
                memberViewModel.MembershipStartDate = activeMembership.CreatedAt.ToShortDateString();
                memberViewModel.MembershipEndDate = activeMembership.EndDate.ToShortDateString();
                var plan = _planRepo.GetById(activeMembership.PlanId);
                if (plan != null)
                    memberViewModel.PlanName = plan.Name;
            }
            return memberViewModel;
        }

        public MemberToUpdateViewModel? GetMemberForUpdate(int MemberId)
        {
            var member = _memberRepo.GetById(MemberId);
            if (member == null)
                return null!;
            var memberToUpdateViewModel = new MemberToUpdateViewModel
            {
              
                Photo = member.photo ?? string.Empty,
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                BuldingNo= member.Adress.BuldingNo,
                City= member.Adress.City,
                Street=member.Adress.Street,

            };
            return memberToUpdateViewModel;
        }

        public HealthRecordViewModel? GetMemberHealthRecord(int MemberId)
        {
            var memberHealthRecord = _healthRecordRepo.GetById(MemberId);
            if (memberHealthRecord == null)
                return null;
            var healthRecordViewModel = new HealthRecordViewModel
                {
                Height = memberHealthRecord.Height,
                Weight = memberHealthRecord.Weight,
                BloodType = memberHealthRecord.BloodType ?? "N/A",
                Note = memberHealthRecord.Notes ?? "N/A",
            };
            return healthRecordViewModel;

        }

        public bool UpdateMemberDetails(int MemberId, MemberToUpdateViewModel memberViewModel)
        {
            var member = _memberRepo.GetById(MemberId);
            if (member == null)
                return false;
            if (IsEmailExists(member.Email))
                return false;
            if (IsPhoneExists(member.Phone))
                return false;
    
            member.Email = memberViewModel.Email;
            member.Phone = memberViewModel.Phone;
           member.Adress.BuldingNo = memberViewModel.BuldingNo;
            member.Adress.City = memberViewModel.City;
            member.Adress.Street = memberViewModel.Street ?? string.Empty;
            member.UpdatedAt = DateTime.Now;
            _memberRepo.Update(member);
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
            var existingMember = _memberRepo.GetAll(m=> m.Email == email);
            return existingMember != null && existingMember.Any();

        }

        private bool IsPhoneExists(string phone)
        {
            var existingMember = _memberRepo.GetAll(m => m.Phone == phone);
            return existingMember != null && existingMember.Any();
        }

        #endregion
    }
}
