using JoyPromotion.Dtos.Dtos;
using System.Collections.Generic;

namespace JoyPromotion.Business.Abstract
{
    public interface IRoleService
    {
        List<RoleListDto> GetAll();
        RoleDto GetById(int id);
        TDto Convert<TDto>(RoleDto roleDto);
    }
}
