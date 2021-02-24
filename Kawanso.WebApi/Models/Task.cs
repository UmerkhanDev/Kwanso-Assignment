using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kawanso.WebApi.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
    }
}
