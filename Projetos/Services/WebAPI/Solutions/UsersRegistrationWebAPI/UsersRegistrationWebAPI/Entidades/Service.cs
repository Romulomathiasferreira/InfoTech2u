using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersRegistrationWebAPI.Entidades
{
    public class Service
    {
        [Key]
        public int IdService { get; set; }
        public string NameService { get; set; }
        public string DescriptionService { get; set; }
        public DateTime RegistrationDateService { get; set; }
        public int RegistrationUserService { get; set; }
        public DateTime ChangeDateService { get; set; }
        public int ChangeUserService { get; set; }
        public string StatusService { get; set; }
        public int FunctionalityId { get; set; }
        public virtual Functionality Functionality { get; set; }
    }
}
