using FermerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermerProject.Data.Repository
{
    public class SQLRepository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUser(Register users)
        {
            _context.RegisterItems.Add(users);
            _context.SaveChanges();
        }
    }
}
