using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersRegistrationWebAPI.Entidades
{
    public class ApplicationModule
    {
        [Key]
        public int IdApplicationModule { get; set; }
        public string NameApplicationModule { get; set; }
        public string DescriptionApplicationModule { get; set; }
        public DateTime RegistrationDateApplicationModule { get; set; }
        public int RegistrationUserApplicationModule { get; set; }
        public DateTime ChangeDateApplicationModule { get; set; }
        public int ChangeUserApplicationModule { get; set; }
        public string StatusApplicationModule { get; set; }
    }
}
