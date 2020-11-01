using System;

namespace MEMAnalyzer_Backend.Business.BusinessModels
{
    public class ApplicationUserViewModel
    {
        public string UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Boolean Gender { get; set; }
    }
}
