using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff.Domain.Common
{
    public abstract class EntityBase
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
