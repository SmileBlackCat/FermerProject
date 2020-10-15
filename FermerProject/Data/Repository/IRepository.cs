using FermerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermerProject.Data.Repository
{
    public interface IRepository
    {
        void AddUser(Register users);
    }
}
