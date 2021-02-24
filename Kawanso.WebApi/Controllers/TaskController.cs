using Kawanso.WebApi;
using Kawanso.WebApi.Models;
using Kowanso.DataDTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace KawansoApi.Controllers
{
    [ApiController]
    [System.Web.Http.Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly Kawanso.WebApi.Models.DBContext DbContext;

        public TaskController(Kawanso.WebApi.Models.DBContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [System.Web.Http.HttpGet]
        public ActionResult Get()
        {
            return Ok(MapTaskList(DbContext.Tasks.ToList()));
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("createTask")]
        public ActionResult CreateTask(CommonDto task)
        {
            var result = new CommonDto();
            if (!string.IsNullOrEmpty(task.taskName) && !string.IsNullOrEmpty(task.taskDescription))
            {
                DbContext.Tasks.Add(MapTask(task));
                DbContext.SaveChanges();
                result.ResponseMessage = string.Format("Task {0} added successfully.", task.taskName);
                result = MapTaskToDto(DbContext.Tasks.Where(x => x.Name == task.taskName && x.Description == task.taskDescription).FirstOrDefault());
            }
            else
            {
                result.ResponseMessage = "Please fill neccessary fields";
            }

            return Ok(result);
        }

        private Kawanso.WebApi.Models.Task MapTask(CommonDto task)
        {
            return new Kawanso.WebApi.Models.Task
            {
                Name = task.taskName,
                Description = task.taskDescription,
                Created_At = DateTime.Now,
            };
        }

        private CommonDto MapTaskToDto(Kawanso.WebApi.Models.Task task)
        {
            return new CommonDto
            {
                taskName = task.Name,
                taskDescription = task.Description,
                Created_At = task.Created_At,
            };
        }

        private CommonDto MapTaskList(List<Kawanso.WebApi.Models.Task> tasks)
        {
            CommonDto dto = new CommonDto();

            tasks.ForEach(x =>
            {
                Kowanso.DataDTO.DTO.Task task = new Kowanso.DataDTO.DTO.Task();
                task.Id = x.Id;
                task.Name = x.Name;
                task.Description = x.Description;
                task.Created_At = x.Created_At;
                dto.taskList.Add(task);
            });

            return dto;
        }
    }
}
