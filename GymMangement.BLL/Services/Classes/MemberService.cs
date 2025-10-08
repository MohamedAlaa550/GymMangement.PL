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

        public MemberService(IGenericRepository<Member> memberRepo) 
        {
            _memberRepo = memberRepo;
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
