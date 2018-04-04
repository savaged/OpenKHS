using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    public abstract class Weeks<T> : ModelBase where T : ISchedule
    {
        public Weeks()
        {
            Schedules = new List<T>();
        }

        public IList<T> Schedules { get; set; }
    }
}
