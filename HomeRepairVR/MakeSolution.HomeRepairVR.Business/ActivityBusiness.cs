using MakeSolution.HomeRepairVR.DataAccess.Model;
using MakeSolution.HomeRepairVR.Entity.Entities;
using MakeSolution.HomeRepairVR.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MakeSolution.HomeRepairVR.Business
{
    public class ActivityBusiness: BaseBusiness
    {
        public ResponseEntity<List<ActivityEntity>> ListNewActivities(Int32? UserId)
        {
            ResponseEntity<List<ActivityEntity>> response = new ResponseEntity<List<ActivityEntity>>();
            try
            {
                List<ActivityEntity> listNewActivities = new List<ActivityEntity>();
                using (var ts = new TransactionScope())
                {
                    var listActivitiesDone = Context.UserActivity.Where(x => x.UserId == UserId).Select(x=>x.ActivityId).ToList();
                    listNewActivities = Context.Activity.Where(x => !listActivitiesDone.Contains(x.ActivityId)).Select(x=>new ActivityEntity
                    {
                        ActivityId = x.ActivityId,
                        ActivityName = x.ActivityName,
                        ActivityTime = x.ActivityTime,
                        ActivityUrlPicture = x.ActivityUrlPicture,
                        ActivityDescription = x.ActivityDescription,
                        DateCreate = x.DateCreate,
                        DateUpdate = x.DateUpdate,
                    }).ToList();
                    ts.Complete();
                }
                response.Data = listNewActivities;
                response.Error = false;
                response.Message = "SUCCESS";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Error = true;
                response.Message = "ERROR: " + ex.Message;
            }
            return response;
        }
        public ResponseEntity<List<UserActivityDoneEntity>> ListActivitiesDone(Int32? UserId)
        {
            ResponseEntity<List<UserActivityDoneEntity>> response = new ResponseEntity<List<UserActivityDoneEntity>>();
            try
            {
                List<UserActivityDoneEntity> listActivitiesDone = new List<UserActivityDoneEntity>();
                using (var ts = new TransactionScope())
                {
                    listActivitiesDone = Context.UserActivity.Where(x => x.UserId == UserId).Select(x => new UserActivityDoneEntity
                    {
                        UserActivityId = x.UserActivityId,
                        ActivityId = x.ActivityId,
                        ActivityName = x.Activity.ActivityName,
                        ActivityTime = x.Activity.ActivityTime,
                        ActivityUrlPicture = x.Activity.ActivityUrlPicture,
                        ActivityDescription = x.Activity.ActivityDescription,
                        DateCreate = x.DateCreate,
                        DateUpdate = x.DateUpdate,
                    }).ToList();
                    ts.Complete();
                }
                response.Data = listActivitiesDone;
                response.Error = false;
                response.Message = "SUCCESS";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Error = true;
                response.Message = "ERROR: " + ex.Message;
            }
            return response;
        }
        
        public ResponseEntity<ActivityEntity> DetailActivity(Int32? ActivityId)
        {
            ResponseEntity<ActivityEntity> response = new ResponseEntity<ActivityEntity>();
            try
            {
                ActivityEntity Activity = new ActivityEntity();
                using (var ts = new TransactionScope())
                {
                    Activity = Context.Activity.Where(x=>x.ActivityId == ActivityId).Select(x => new ActivityEntity
                    {
                        ActivityId = x.ActivityId,
                        ActivityName = x.ActivityName,
                        ActivityTime = x.ActivityTime,
                        ActivityUrlPicture = x.ActivityUrlPicture,
                        ActivityDescription = x.ActivityDescription,
                        DateCreate = x.DateCreate,
                        DateUpdate = x.DateUpdate,
                    }).FirstOrDefault();
                    ts.Complete();
                }
                response.Data = Activity;
                response.Error = false;
                response.Message = "SUCCESS";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Error = true;
                response.Message = "ERROR: " + ex.Message;
            }
            return response;
        }
    }
}
