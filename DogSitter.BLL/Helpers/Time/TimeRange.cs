using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Helpers.Time
{
    public class TimeRange
    {
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        public TimeRange(TimeOnly start, TimeOnly end)
        {
            Start = start;
            End = end;
        }

        public bool CheckTimeCrossing(TimeRange timeRange)
        {
           return this.Start < timeRange.End && timeRange.Start < this.End;
        }

        public override bool Equals(object obj)
        {
            return obj is TimeRange range &&
                   Start.Equals(range.Start) &&
                   End.Equals(range.End);
        }
    }
}
