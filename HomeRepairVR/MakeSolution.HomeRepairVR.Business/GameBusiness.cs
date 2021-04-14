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
        public ResponseEntity<SelectGameResponseEntity> SelectGame(UserActivityEntity model)
        {
            ResponseEntity<SelectGameResponseEntity> response = new ResponseEntity<SelectGameResponseEntity>();
            try
            {
                var selectGameResponse = new SelectGameResponseEntity();
                using (var ts = new TransactionScope())
                {
                    var userActivyExist = Context.UserActivity.FirstOrDefault(x => x.UserId == model.UserId && x.ActivityId == model.ActivityId);
                    if (userActivyExist == null) {
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
                       
                        selectGameResponse.UserActivityId = userActivity.UserActivityId;
                        selectGameResponse.Message = ConstantHelper.MESSAGE.SUCCESS_MESSAGE_SAVE;

                        response.Data = selectGameResponse;
                    }
                    else { 
                        selectGameResponse.UserActivityId = userActivyExist.UserActivityId;
                        selectGameResponse.Message = ConstantHelper.MESSAGE.SUCCESS_MESSAGE_CHARGE; 
                    }
                    ts.Complete();
                }
                response.Data = selectGameResponse;
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
        public ResponseEntity<String> ChargeDoneGame(int useractivityid)
        {
            ResponseEntity<String> response = new ResponseEntity<String>();
            try
            {
                using (var ts = new TransactionScope())
                {
                    response.Data = Context.StatisticsDetail.OrderByDescending(x => x.StatisticDetailId).FirstOrDefault(x => x.Statistics.UserActivityId == useractivityid) != null ? Context.StatisticsDetail.OrderByDescending(x => x.StatisticDetailId).FirstOrDefault(x => x.Statistics.UserActivityId == useractivityid).Description : "";
                }
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
