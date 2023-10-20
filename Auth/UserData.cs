using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingStockingMachine.Auth
{
    public class UserData
    {
        public string UserName;
        public string Role;
        public int UserId;

        public UserData(string name,string role,int id)
        {
            UserName = name;
            Role = role;
            UserId = id;

        }

    }
}
