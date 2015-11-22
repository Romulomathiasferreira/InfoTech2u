using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersRegistrationWebAPI.Models
{
    public class User
    {
        public int idUser { get; set; }
        public string emailUser { get; set; }
        public string passwordUser { get; set; }
        public DateTime registrationDateUser { get; set; }
        public int registrationUserUser { get; set; }
        public DateTime changeDateUser { get; set; }
        public int changeUserUser { get; set; }
        public string statusUser { get; set; }
    }
}
