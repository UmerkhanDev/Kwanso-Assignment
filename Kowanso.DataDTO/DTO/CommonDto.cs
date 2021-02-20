using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kowanso.DataDTO.DTO
{
    public class CommonDto
    {
        public string email { get; set; }
        public string password { get; set; }
        public string taskName { get; set; }
        public string taskDescription { get; set; }
        public List<Task> taskList { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
    }
}
