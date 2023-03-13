using Diff.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff.Domain.Entities
{
    public class Difference : EntityBase
    {
        [Key]
        public int Index { get; set; }
        public int Id { get; set; }
        public string Text { get; set; }

        public string Way { get; set; }
    }
}
