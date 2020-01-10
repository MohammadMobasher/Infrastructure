using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Repos;
using Service.Repos.User;
using WebFramework.Base;

namespace ElevatorAdmin.Controllers
{
    public class Routine2Controller : BaseAdminController
    {
        private readonly UserRepository _userRepository;
        private readonly Routine2Repository _routine2Repository;

        public Routine2Controller(Routine2Repository routinRepository,
            UserRepository userRepository,
            UsersAccessRepository usersAccessRepository) : base(usersAccessRepository)
        {
            _userRepository = userRepository;
            _routine2Repository = routinRepository;
            
        }

        public IActionResult GetLogs(string routineIdE, string entityIdE)
        {
            //var entityId = Convert.ToInt32(AESGCM.SimpleDecryptWithPassword(entityIdE, AppConfiguration.EncryptionSalt));
            //var routineId = Convert.ToInt32(AESGCM.SimpleDecryptWithPassword(routineIdE, AppConfiguration.EncryptionSalt));
            //ViewBag.steps = _routine2Repository.GetRoutineStepsByRoutineId(InternshipRoutine.RoutineId);

            //var model = _routine2Repository.GetLogs(routineId, entityId);
            var model = _routine2Repository.GetLogs(1, 1);
            //ViewBag.RoutineId = routineId;
            return View(model);
        }

        public IActionResult GetRoutineStepsByRoutineId(int routineId)
        {
            var model = _routine2Repository.GetRoutineStepsByRoutineId(routineId);
            return Json(model);
        }

        public IActionResult GetRoutine(int routineId)
        {
            var model = _routine2Repository.GetRoutineFull(routineId);
            return Json(model);
        }


        /// <summary>
        /// ارسال
        /// Notice, SMS, Email
        /// برای تست در همه روال‌ها
        /// </summary>
        //public async Task<IActionResult> SendNotice(int RoutineId, int EntityId, int FromStep, int ToStep, bool realSend = false)
        //{
        //    var Params = new
        //    {
        //        RoutineId,
        //        EntityId,
        //        FromStep,
        //        ToStep,
        //    };

        //    var userId = _contextAccessor.HttpContext.User.Identity.GetUserId();

        //    try
        //    {
        //        var Result = await _routine2Repository.SendNoticeAsync(new Routine2ChangeStepResult
        //        {
        //            RoutineId = RoutineId,
        //            EntityId = EntityId,
        //            FromStep = FromStep,
        //            ToStep = ToStep,
        //            UserId = userId,
        //        }, realSend);

        //        return Json(new { Params, Result });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Params, ex.Message });
        //    }
        //}


        //public IActionResult Autodash()
        //{
        //    _routine2Repository.Authodash();
        //    return Content("DONE Authodash");
        //}

        //public IActionResult Reminder()
        //{
        //    _routine2Repository.Reminder();
        //    return Content("DONE Reminder");
        //}
    }
}