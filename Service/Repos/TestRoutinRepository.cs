using DataLayer.DTO.Routine2;
using DataLayer.Entities;
using DataLayer.Interface.Routin2;
using DataLayer.SSOT.Routine2;
using DataLayer.ViewModels.Routine2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repos
{
    public class TestRoutinRepository : GenericRepository<TestRoutin>, IGeneralRoutin2<TestRoutin>
    {

        private readonly Routine2Repository _routine2Repository;

        public TestRoutinRepository(DatabaseContext db,
            Routine2Repository routine2Repository) : base(db)
        {
            _routine2Repository = routine2Repository;
        }

        public async Task<Routine2ChangeStepResult> ChangeStep(int userId, int RoutinId, int EntityId, Routine2Actions Action, string Description)
        {
            // گرفتن رکورد مورد نظر
            var entity = Entities.Find(EntityId);


            // درصورتی که رکورد مورد نظر وجود نداشت باید خطا برگردانده شود
            if (entity == null)
                throw new Exception($"داده‌ای با شناسه {EntityId} یافت نشد");


            // مرحله بعدی فرآیند دراین قسمت به دست می‌آید
            var nextStep = await GetNextStep(Action, entity, RoutinId);

            // درصورتی که مرحله بعدی -1 باشد باید خطا نمایش داده شود
            if (nextStep == -1)
                throw new Exception("Something went wrong, next dashboard couldn't be -1");


            //=========================================================
            var fromStep = entity.RoutineStep;
            //=========================================================


            // ثبت لاگ جدید برای این کاربر که رکورد مورد را از یک مرحله به مرحله دیگر انتقال داده است
            _routine2Repository.CreateLog(new CreateRoutine2LogViewModel
            {
                RoutineId = RoutinId,
                EntityId = EntityId,
                Description = Description,
                Action = await _routine2Repository.GetActionTitle(RoutinId, fromStep, Action),
                Step = fromStep,
                ToStep = nextStep,
                UserId = userId,
                CreatorUserId = userId,
                RoutineRoleTitle = _routine2Repository.GetRoutineRoleTitle(RoutinId, entity.RoutineStep),
            });


            var routineVm = new EditRoutine2ViewModel(nextStep, entity.RoutineFlownDate);

            // اگر در مرحله آخر باشیم، باید به روال برچست تمام شده بزنیم
            if (entity.DoneSteps.Contains(nextStep))
                routineVm.RoutineIsDone = true;

            // به صورت پیش‌فرض طرح رد شده است، مگر اینکه در مراحل تایید باشیم
            if (entity.SucceededSteps.Contains(nextStep))
                routineVm.RoutineIsSucceeded = true;


            entity.RoutineStep = nextStep;
            entity.RoutineFlownDate = DateTime.Now;
            entity.RoutineStepChangeDate = DateTime.Now;

            await DbContext.SaveChangesAsync();

            var changeStepResult = new Routine2ChangeStepResult
            {
                Action = Action,
                Description = Description,
                UserId = userId,
                ToStep = nextStep,
                FromStep = fromStep,
                EntityId = EntityId,
                RoutineId = RoutinId,
            };

            //TODO
            //try { await _routine2Repository.SendNoticeAsync(changeStepResult); } catch (Exception) { }

            return changeStepResult;
        }

        public async Task<int> GetNextStep(Routine2Actions action, TestRoutin entity, int rouitneId)
        {
            var currentStep = await GetStep(rouitneId, entity.RoutineStep);

            int? nextStep = null;

            switch (action)
            {
                case Routine2Actions.F1:
                    nextStep = currentStep.F1;
                    break;
                case Routine2Actions.F2:
                    nextStep = currentStep.F2;
                    break;
                case Routine2Actions.F3:
                    nextStep = currentStep.F3;
                    break;
                case Routine2Actions.F4:
                    nextStep = currentStep.F4;
                    break;
                case Routine2Actions.F5:
                    nextStep = currentStep.F5;
                    break;
                case Routine2Actions.F6:
                    nextStep = currentStep.F6;
                    break;
                case Routine2Actions.F7:
                    nextStep = currentStep.F7;
                    break;
            }

            return nextStep ?? -1;
        }
    }
}
