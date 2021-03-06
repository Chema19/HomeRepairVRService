﻿using MakeSolution.HomeRepairVR.Business;
using MakeSolution.HomeRepairVR.Entity.Entities;
using System;
using System.Web.Http;

namespace MakeSolution.HomeRepairVR.Service.Controllers
{
    public class GameApiController : BaseApiController
    {
        [HttpPost]
        [Route("apigames/savegames")]
        public IHttpActionResult SaveGames(SaveLoadGameEntity model)
        {
            try
            {
                GameBusiness gameBusiness = new GameBusiness();
                ResponseEntity<String> response = gameBusiness.SaveGame(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        [Route("apigames/selectgames")]
        public IHttpActionResult SelectGames(UserActivityEntity model)
        {
            try
            {
                GameBusiness gameBusiness = new GameBusiness();
                ResponseEntity<SelectGameResponseEntity> response = gameBusiness.SelectGame(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpGet]
        [Route("apigames/chargedonegames/{useractivityid}")]
        public IHttpActionResult ChargeDoneGames(int useractivityid)
        {
            try
            {
                GameBusiness gameBusiness = new GameBusiness();
                ResponseEntity<SaveLoadGameEntity> response = gameBusiness.ChargeDoneGame(useractivityid);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
    }
}
