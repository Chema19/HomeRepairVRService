using MakeSolution.HomeRepairVR.DataAccess.Model;
using MakeSolution.HomeRepairVR.Entity.Entities;
using MakeSolution.HomeRepairVR.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MakeSolution.HomeRepairVR.Business
{
    public class GameBusiness : BaseBusiness
    {
        public ResponseEntity<String> SaveGame(SaveGameEntity model)
        {
            ResponseEntity<String> response = new ResponseEntity<String>();
            try
            {
                using (var ts = new TransactionScope())
                {
                    var statistics = Context.Statistics.FirstOrDefault(x => x.UserActivityId == model.UserActivityId);
                    var statisticsDetail = new StatisticsDetail();

                    statistics.StatisticTimeElapsed = statistics.StatisticTimeElapsed + model.TimeElapse;
                    statistics.DateUpdate = DateTime.Now;

                    Context.StatisticsDetail.Add(statisticsDetail);

                    statisticsDetail.StepId = model.StepId;
                    statisticsDetail.MaterialId = model.MaterialId;
                    statisticsDetail.Status = model.Status;
                    statisticsDetail.StatisticsId = statistics.StatisticsId;
                    statisticsDetail.DateCreate = DateTime.Now;
                    statisticsDetail.Description = model.Description;

                    Context.SaveChanges();
                    ts.Complete();
                }
                response.Data = ConstantHelper.MESSAGE.SUCCESS_MESSAGE_SAVE;
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
        public ResponseEntity<String> SelectGame(UserActivityEntity model)
        {
            ResponseEntity<String> response = new ResponseEntity<String>();
            try
            {
                using (var ts = new TransactionScope())
                {
                    var userActivity = new UserActivity();

                    Context.UserActivity.Add(userActivity);

                    userActivity.ActivityId = model.ActivityId;
                    userActivity.UserId = model.UserId;
                    userActivity.DateCreate = DateTime.Now;
                    userActivity.DateUpdate = DateTime.Now;

                    Context.SaveChanges();

                    var statistic = new Statistics();

                    Context.Statistics.Add(statistic);

                    statistic.UserActivityId = userActivity.UserActivityId;
                    statistic.StatisticTimeElapsed = 0;
                    statistic.DateCreate = DateTime.Now;
                    
                    Context.SaveChanges();
                    ts.Complete();
                }
                response.Data = ConstantHelper.MESSAGE.SUCCESS_MESSAGE_SAVE;
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
