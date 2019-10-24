using DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IRoleBUS
    {
        List<RoleDTO> GetRoles();
    }
}
