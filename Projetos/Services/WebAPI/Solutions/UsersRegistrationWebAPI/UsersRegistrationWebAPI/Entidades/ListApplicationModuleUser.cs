using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersRegistrationWebAPI.Entidades
{
    public class ListApplicationModuleUser
    {
        [Key]
        public int IdListApplicationModuleUser { get; set; }
        public DateTime RegistrationDateListApplicationModuleUser { get; set; }
        public int RegistrationUserListApplicationModuleUser { get; set; }
        public DateTime ChangeDateListApplicationModuleUser { get; set; }
        public int ChangeUserListApplicationModuleUser { get; set; }
        public string StatusListApplicationModuleUser { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ApplicationModuleId { get; set; }
        public virtual ApplicationModule ApplicationModule { get; set; }
    }
}
