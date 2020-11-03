using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Business
{
    public class MemViewModel
    {
        public long Id { get; set; }

        public byte[] ImageBytes { get; set; }

        public string Picture { get; set; }

        public string PictureCode { get; set; }

        public string CategoryCode { get; set; }

        public long CategoryId { get; set; }
    }
}
