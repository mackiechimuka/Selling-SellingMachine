using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace SellingStockingMachine.Auth
{
    public class PasswordHash
    {
        public string HashPassword(string password)
        {
           
                return BCryptNet.HashPassword(password);
            
            
        }


    }
}
