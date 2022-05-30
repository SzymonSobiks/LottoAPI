using System;

namespace LottoAPI.Models
{
    public class Draw
    {
        public int Id { get; set; }
        public int[] Numbers { get; set; }
        public DateTime Timestamp { get; set; }

        public string GetTimestampAsString() { return Timestamp.ToString(); }
    }
}
