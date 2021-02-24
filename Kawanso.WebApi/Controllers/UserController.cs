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
    public class UserController : ControllerBase
    {
        private readonly Kawanso.WebApi.Models.DBContext DbContext;

        public UserController(Kawanso.WebApi.Models.DBContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<Kawanso.WebApi.Models.User> Get()
        {
            return DbContext.Users.ToList();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("register")]
        public ActionResult Register(CommonDto user)
        {
            var result = new CommonDto();
            if (!string.IsNullOrEmpty(user.email) && !string.IsNullOrEmpty(user.password))
            {
                if (DbContext.Users.Where(x => x.Email == user.email).FirstOrDefault() != null)
                {
                    DbContext.Users.Add(MapUser(user));
                    DbContext.SaveChanges();
                    result.ResponseMessage = string.Format("User {0} registered successfully.", user.email);
                    result = MapUserToDto(DbContext.Users.Where(x => x.Email.ToLower() == user.email.ToLower()).FirstOrDefault());
                }
                else
                {
                    result.ResponseMessage = string.Format("User {0} already exists.", user.email);
                }
            }
            else
            {
                result.ResponseMessage = "Please fill neccessary fields";
            }

            return Ok(result);
        }

        private User MapUser(CommonDto user)
        {
            return new User
            {
                Email = user.email,
                Password = user.password,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,
            };
        }

        private CommonDto MapUserToDto(User user)
        {
            return new CommonDto
            {
                email = user.Email,
                password = user.Password,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,
            };
        }
    }
}
