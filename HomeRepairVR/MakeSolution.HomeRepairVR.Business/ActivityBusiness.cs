using MakeSolution.HomeRepairVR.DataAccess.Model;
using MakeSolution.HomeRepairVR.Entity.Entities;
using MakeSolution.HomeRepairVR.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                        Scene = x.Scene
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
                        Scene = x.Activity.Scene
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
                        Scene = x.Scene
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
        public ResponseEntity<StatisticsEntity> StatisticsActivity(Int32? UsuarioId, Int32? ActivityId)
        {
            ResponseEntity<StatisticsEntity> response = new ResponseEntity<StatisticsEntity>();
            try
            {
                StatisticsEntity statisticsEntity = new StatisticsEntity();
                using (var ts = new TransactionScope())
                {
                    var userActivity = Context.UserActivity.FirstOrDefault(x => x.UserId == UsuarioId && x.ActivityId == ActivityId);
                    var statistics = Context.Statistics.FirstOrDefault(x => x.UserActivityId == userActivity.UserActivityId);
        
                    statisticsEntity.Titulo = userActivity.Activity.ActivityName;
                    statisticsEntity.Correctas = Context.StatisticsDetail.Where(x=>x.StatisticsId == statistics.StatisticsId).OrderByDescending(x=>x.StatisticDetailId).FirstOrDefault().StepsCorrects;
                    statisticsEntity.Incorrectas = Context.StatisticsDetail.Where(x => x.StatisticsId == statistics.StatisticsId).OrderByDescending(x => x.StatisticDetailId).FirstOrDefault().StepsIncorrects;
                    statisticsEntity.TiempoTranscurrido = Context.StatisticsDetail.Where(x => x.StatisticsId == statistics.StatisticsId).OrderByDescending(x => x.StatisticDetailId).FirstOrDefault().StatisticTimeElapsed;
                    statisticsEntity.StepTutorial = Context.StatisticsDetail.Where(x => x.StatisticsId == statistics.StatisticsId).OrderByDescending(x => x.StatisticDetailId).FirstOrDefault().StepTutorial;
                    ts.Complete();
                }
                response.Data = statisticsEntity;
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
        public ResponseEntity<List<StatisticsEntity>> ListStatistics(Int32? UsuarioId, Int32? ActivityId)
        {
            ResponseEntity<List<StatisticsEntity>> response = new ResponseEntity<List<StatisticsEntity>>();
            try
            {
                List<StatisticsEntity> listStatistics = new List<StatisticsEntity>();
                using (var ts = new TransactionScope())
                    {
                    listStatistics = Context.Statistics.Where(x => x.UserActivity.UserId == UsuarioId && x.UserActivity.ActivityId == ActivityId).Select(x=> new StatisticsEntity {
                        Correctas = x.StatisticsDetail.OrderByDescending(y=>y.StatisticDetailId).FirstOrDefault().StepsCorrects, 
                        Incorrectas = x.StatisticsDetail.OrderByDescending(y=>y.StatisticDetailId).FirstOrDefault().StepsIncorrects, 
                        Titulo = x.UserActivity.Activity.ActivityName, 
                        TiempoTranscurrido = x.StatisticsDetail.OrderByDescending(y => y.StatisticDetailId).FirstOrDefault().StatisticTimeElapsed,
                        StepTutorial = x.StatisticsDetail.OrderByDescending(y => y.StatisticDetailId).FirstOrDefault().StepTutorial
                    } 
                    ).ToList();

                    ts.Complete();
                }
                response.Data = listStatistics;
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
        public ResponseEntity<List<StatisticDetailEntity>> ListStatisticsDetail(Int32? StatisticId)
        {
            ResponseEntity<List<StatisticDetailEntity>> response = new ResponseEntity<List<StatisticDetailEntity>>();
            try
            {
                List<StatisticDetailEntity> listStatisticsDetail = new List<StatisticDetailEntity>();
                using (var ts = new TransactionScope())
                {
                    listStatisticsDetail = Context.StatisticsDetail.Where(x => x.StatisticsId == StatisticId).Select(x => new StatisticDetailEntity { 
                        StatusActivity = x.StatusActivity, 
                        DateCreate = x.DateCreate, 
                        Description = x.Description, 
                        StatisticTimeElapsed = x.StatisticTimeElapsed, 
                        StepsCorrects = x.StepsCorrects, 
                        StepIncorrects = x.StepsIncorrects, 
                        StepTutorial = x.StepTutorial
                    }).ToList();
                    ts.Complete();
                }
                response.Data = listStatisticsDetail;
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
