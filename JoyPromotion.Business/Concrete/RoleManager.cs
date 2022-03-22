using AutoMapper;
using JoyPromotion.Business.Abstract;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using System.Collections.Generic;

namespace JoyPromotion.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleManager(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public TDto Convert<TDto>(RoleDto roleDto)
        {
            return _mapper.Map<TDto>(roleDto);
        }

        public List<RoleListDto> GetAll()
        {
            return _mapper.Map<List<RoleListDto>>(_roleRepository.GetAll());
        }

        public RoleDto GetById(int id)
        {
            return _mapper.Map<RoleDto>(_roleRepository.GetById(id));
        }

        public RoleUpdateDto Update(RoleUpdateDto roleUpdateDto)
        {
            var updatedRole = _mapper.Map<Role>(roleUpdateDto);
            _roleRepository.Update(updatedRole);
            return roleUpdateDto;
        }
    }
}
