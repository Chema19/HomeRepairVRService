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
    public class UserBusiness: BaseBusiness
    {
       
        public ResponseEntity<String> AddEditUser(UserEntity model)
        {
            ResponseEntity<String> response = new ResponseEntity<String>();
            try
            {
                using (var ts = new TransactionScope())
                {
                    var user = new User();
                    if (model.UserId.HasValue)
                    {
                        user = Context.User.FirstOrDefault(x => x.UserId == model.UserId);
                        user.DateUpdate = DateTime.Now;
                    }
                    else
                    {
                        Context.User.Add(user);
                        user.DateCreate = DateTime.Now;
                    }

                    user.UserName = model.UserName;
                    if (!String.IsNullOrEmpty(model.UserUrlPicture))
                    {
                        user.UserUrlPicture = "";
                    }
                   
                    user.Status = ConstantHelper.ESTADO.ACTIVO;

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
        public ResponseEntity<String> DeleteUser(Int32? UserId)
        {
            ResponseEntity<String> response = new ResponseEntity<String>();
            try
            {

                using(var ts = new TransactionScope())
                {
                    var user = new User();
                    user = Context.User.FirstOrDefault(x => x.UserId == UserId);

                    user.Status = ConstantHelper.ESTADO.INACTIVO;
                    user.DateUpdate = DateTime.Now;
                    Context.SaveChanges();

                    ts.Complete();
                }
                response.Data = ConstantHelper.MESSAGE.SUCCESS_MESSAGE_DELETE;
                response.Error = false;
                response.Message = "SUCCESS";
            }
            catch(Exception ex)
            {
                response.Data = null;
                response.Error = true;
                response.Message = "ERROR: " + ex.Message;
            }
            return response;
        }
        public ResponseEntity<UserEntity> ViewUser(Int32? UserId)
        {
            ResponseEntity<UserEntity> response = new ResponseEntity<UserEntity>();
            try
            {
                var userEntity = new UserEntity();
                using (var ts = new TransactionScope())
                {
                    var user = new User();
                  
                    user = Context.User.FirstOrDefault(x => x.UserId == UserId);

                    userEntity.UserId = user.UserId;
                    userEntity.UserName = user.UserName;
                    userEntity.UserUrlPicture = user.UserUrlPicture;
                    userEntity.DateCreate = user.DateCreate;
                    userEntity.Status = user.Status;

                    ts.Complete();
                }
                response.Data = userEntity;
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
