using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yucehanEgitim.Models
{
    public interface IAdminRepository
    {
        List<Admin> GetAllAdmins();
    }
}