
using DataLayer.DTO.Routine2;
using DataLayer.SSOT.Routine2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface.Routin2
{
    public interface IGeneralRoutin2<T> where T : IRoutine2Entity
    {
        /// <summary>
        /// از این تابع برای تغییر وضعیت یک رکورد در یک جدول استفاده می شود.
        /// </summary>
        /// <param name="RoutinId"></param>
        /// <param name="EntityId"></param>
        /// <param name="TableName"></param>
        /// <param name="Action"></param>
        /// <returns></returns>
        Task<Routine2ChangeStepResult> ChangeStep(int userId, int RoutinId, int EntityId, Routine2Actions Action, String Description);


        /// <summary>
        /// مرحله بعدی بر اساس نوع اکشنی که میخواهد انجام دهد را این تابع مشخص میکند
        /// </summary>
        /// <param name="action">نوع اکشن</param>
        /// <param name="entity">موجودیتی که باید با توجه به آن مرحله بعدی انتخاب شود</param>
        /// <param name="rouitneId">شماره روتین</param>
        /// <returns></returns>
        Task<int> GetNextStep(Routine2Actions action, T entity, int rouitneId);

    }
}
