using FermerProject.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermerProject.Data
{
    public class Db
    {
        private readonly ApplicationDbContext _context;

        public Db(ApplicationDbContext context)
        {
            _context = context;
        }


        public bool ExistUser(string existUser) //Проверяем, существует ли юзер с таким логином
        {
            return _context.RegisterItems.Any(i => i.Name.Contains(existUser));
        }




        public bool ExistPassword(string existUser, string existPassword) //Проверяем соответствие логина и пароля
        {
            return _context.RegisterItems.Any(i => i.Name == existUser && i.Password == existPassword);
        }
    }
}
