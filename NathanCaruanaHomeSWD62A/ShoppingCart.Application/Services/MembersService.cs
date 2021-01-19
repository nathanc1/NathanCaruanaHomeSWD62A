using AutoMapper;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class MembersService : IMembersService
    {
        private IMembersRepository _membersRepo;
        private IMapper _mapper;
        public MembersService(IMembersRepository memberRepo, IMapper mapper)
        {
            _membersRepo = memberRepo;
            _mapper = mapper;
        }
        public void AddMember(MemberViewModel m)
        {
            var p = _mapper.Map<Member>(m);
            _membersRepo.AddMember(p);
           /*
            Member newMember = new Member()
            {
                Email = m.Email,
                FirstName = m.FirstName,
                LastName = m.LastName

            };
            _membersRepo.AddMember(newMember);      
           */
        }
    }
}
