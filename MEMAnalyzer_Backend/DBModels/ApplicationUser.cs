using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.DBModels
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedDate { get; set; }

        [ForeignKey("IdentityRole")]
        public string RoleId { get; set; }
        public IdentityRole IdentityRole { get; set; }

        public string ProfilePic { get; set; }

        public string FullName { get; set; }

        public bool Gender { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
