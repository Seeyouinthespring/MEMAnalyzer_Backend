using Microsoft.AspNetCore.SignalR;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MEMAnalyzer_Backend.DBModels
{
    public class Result : BaseEntity
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string DeviceInfo { get; set; }
        
        public double CategoryOnePercentage { get; set; }
        
        public double CategorytwoPercentage { get; set; }
        
        public double CategoryThreePercentage { get; set; }
        
        public double CategoryFourPercentage { get; set; }
        
        public double CategoryFivePercentage { get; set; }

        [ForeignKey(nameof(Statement))]
        public long StatementId { get; set; }
        public Statement Stetement { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
