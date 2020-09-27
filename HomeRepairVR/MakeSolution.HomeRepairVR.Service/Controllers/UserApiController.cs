using MakeSolution.HomeRepairVR.Business;
using MakeSolution.HomeRepairVR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MakeSolution.HomeRepairVR.Service.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("apiusers")]
    public class UserApiController : ApiController
    {
        [HttpPost]
        [Route("addeditusers")]
        public IHttpActionResult AddUsers(UserEntity model)
        {
            try
            {
                UserBusiness userBussiness = new UserBusiness();
                ResponseEntity<String> response = userBussiness.AddEditUser(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpGet]
        [Route("deleteusers/{userid}")]
        public IHttpActionResult DeleteUsers(Int32? userid)
        {
            try
            {
                UserBusiness userBussiness = new UserBusiness();
                ResponseEntity<String> response = userBussiness.DeleteUser(userid);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpGet]
        [Route("viewusers/{userid}")]
        public IHttpActionResult ViewUsers(Int32? userid)
        {
            try
            {
                UserBusiness userBussiness = new UserBusiness();
                ResponseEntity<UserEntity> response = userBussiness.ViewUser(userid);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpGet]
        [Route("listusers")]
        public IHttpActionResult ListUsers()
        {
            try
            {
                UserBusiness userBussiness = new UserBusiness();
                ResponseEntity<List<UserEntity>> response = userBussiness.ListUser();                
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
    }
}
