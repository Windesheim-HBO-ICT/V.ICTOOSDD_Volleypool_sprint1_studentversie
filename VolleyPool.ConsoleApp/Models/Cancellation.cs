using System;
using System.Collections.Generic;
using System.Text;

namespace VolleyPool.Core.Models
{
    public class Cancellation
    {
        public int Id { get; set; }
        public string MemberId { get; set; }
        public int MatchDayId { get; set; }
    }
}
