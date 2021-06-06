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
        [HttpGet]
        [Route("statisticsactivities/{activityid}/users/{userid}")]
        public IHttpActionResult StatistisActivities(int? activityid, int? userid)
        {
            try
            {
                ActivityBusiness activityBusiness = new ActivityBusiness();
                ResponseEntity<StatisticsEntity> response = activityBusiness.StatisticsActivity(userid, activityid);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpGet]
        [Route("liststatisticsactivities/{activityId}/users/{usuarioId}")]
        public IHttpActionResult ListStatistics(int? activityId, int? usuarioId)
        {
            try
            {
                ActivityBusiness activityBussiness = new ActivityBusiness();
                ResponseEntity<List<StatisticsEntity>> response = activityBussiness.ListStatistics(usuarioId, activityId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpGet]
        [Route("liststatisticsdetail/{statisticsId}")]
        public IHttpActionResult ListStatisticsDetail(int? statisticsId)
        {
            try
            {
                ActivityBusiness activityBussiness = new ActivityBusiness();
                ResponseEntity<List<StatisticDetailEntity>> response = activityBussiness.ListStatisticsDetail(statisticsId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

    }
}
