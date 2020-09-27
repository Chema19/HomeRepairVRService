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
    [RoutePrefix("apiactivities")]
    public class ActivityApiController : ApiController
    {
        [HttpGet]
        [Route("newactivities/{userid}")]
        public IHttpActionResult ListNewActivities(int? userid)
        {
            try
            {
                ActivityBusiness activityBusiness = new ActivityBusiness();
                ResponseEntity<List<ActivityEntity>> response = activityBusiness.ListNewActivities(userid);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpGet]
        [Route("doneactivities/{userid}")]
        public IHttpActionResult ListDoneActivities(int? userid)
        {
            try
            {
                ActivityBusiness activityBusiness = new ActivityBusiness();
                ResponseEntity<List<UserActivityDoneEntity>> response = activityBusiness.ListActivitiesDone(userid);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpGet]
        [Route("viewactivities/{activityid}")]
        public IHttpActionResult ViewActivities(int? activityid)
        {
            try
            {
                ActivityBusiness activityBusiness = new ActivityBusiness();
                ResponseEntity<ActivityEntity> response = activityBusiness.DetailActivity(activityid);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
    }
}
