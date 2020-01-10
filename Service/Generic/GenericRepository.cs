using Core.Utilities;
using DataLayer.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.SSOT.Routine2;
using DataLayer.DTO.Routine2;
using DataLayer.ViewModels.Routine2;
using DataLayer.Interface.Routin2;
using DataLayer.Entities.ExireRoutine;
using DataLayer.SSOT.Routine2.DashBoards;
using DataLayer.Entities.Users;

namespace Service
{

    public class GenericRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DatabaseContext DbContext;
        protected DbSet<TEntity> Entities { get; }
        public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();


        public GenericRepository(DatabaseContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>(); // City => Cities
        }




        #region Routin


        /// <summary>
        /// درصورتی از این توابع استفاده شود که جدول مورد نظر به صورت روتین باشد
        ///  در این تابع با استفاده از شماره روتین و همچنین 
        /// مرحله ایی که الان روتین در آن قرار دارد 
        /// کل اطلاعات آن مرحله را میگیریم
        /// </summary>
        /// <param name="routineId"></param>
        /// <param name="currentStep"></param>
        /// <returns></returns>
        public async Task<Routine2Step> GetStep(int routineId, int currentStep)
        {
            var step = await DbContext.Routine2Step.AsNoTracking()
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.RoutineId == routineId && q.Step == currentStep);

            return step;
        }


        /// <summary>
        /// درصورتی از این توابع استفاده شود که جدول مورد نظر به صورت روتین باشد
        /// مرحله بعدی مربوط به یک آیتم به همراه شماره روتین آن را برمیگرداند
        /// </summary>
        /// <param name="id">شماره رکورد مورد نظر</param>
        /// <param name="RoutineId">شماره روتین</param>
        /// <param name="action">اکشن فعلی</param>
        /// <returns></returns>
        public async Task<int> GetNextStep(int id, int RoutineId, Routine2Actions action)
        {
            // آیتم مورد نظر را به دست می‌اوریم
            var entity = Entities
                .Find(id);

            // درصورتی که رکورد مورد نظر وجود نداشت باید خطا برگردانده شود
            if (entity == null)
                throw new Exception($"داده‌ای با شناسه {id} یافت نشد");

            // مرحله فعلی آن را به دست می‌آوریم
            var currentStep = await GetStep(RoutineId, Convert.ToInt32(entity.GetPropertyValue("RoutineStep")) );

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

        /// <summary>
        /// درصورتی از این توابع استفاده شود که جدول مورد نظر به صورت روتین باشد
        /// ثبت یک لاگ جدید
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public int CreateLog(CreateRoutine2LogViewModel vm)
        {
            // map the ViewModel to a new entity

            var entity = Mapper.Map<Routine2Log>(vm);

            // Add it to database
            DbContext.Routine2Log.Add(entity);
            DbContext.SaveChanges();

            // return the new id
            return entity.Id;
        }

        /// <summary>
        /// درصورتی از این توابع استفاده شود که جدول مورد نظر به صورت روتین باشد
        /// عنوان مربوط به این یک روتین از یک مرحله تحت عمل فلان را به دست می‌آوریم
        /// </summary>
        /// <param name="routineId">شماره روتین</param>
        /// <param name="fromStep">از مرحله</param>
        /// <param name="action">عمل</param>
        /// <returns></returns>
        public async Task<string> GetActionTitle(int routineId, int fromStep, Routine2Actions action)
        {
            try
            {
                var routine2Action = await DbContext.Routine2Action
                    .AsNoTracking()
                    .Where(q => q.RoutineId == routineId)
                    .Where(q => q.Step == fromStep)
                    .Where(q => q.Action == action.ToString())
                    .FirstOrDefaultAsync();

                return routine2Action == null
                    ? action.ToString()
                    : routine2Action.Title;
            }
            catch (Exception)
            {
                return action.ToString();
            }
        }


        /// <summary>
        /// گرفتن عنوان مربوط به یک روتین
        /// </summary>
        /// <param name="routineId">شماره روتین</param>
        /// <param name="step">شماره مرحله مورد نظر</param>
        /// <returns></returns>
        public async Task<string> GetRoutineRoleTitle(int routineId, int step)
        {
            var routineRole = await DbContext.Routine2Role.AsNoTracking()
                .FirstOrDefaultAsync(q => q.RoutineId == routineId && q.StepsJson.Contains($"\"{step}\""));

            return routineRole?.Title;
        }





        /// <summary>
        /// درصورتی از این توابع استفاده شود که جدول مورد نظر به صورت روتین باشد
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="RoutinId"></param>
        /// <param name="EntityId"></param>
        /// <param name="Action"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public async Task<Routine2ChangeStepResult> ChangeStep(int userId, int RoutinId, int EntityId, Routine2Actions Action, string Description)
        {
            // گرفتن رکورد مورد نظر
            var entity = Entities.Find(EntityId);

            // زمان فعلی
            DateTime NowDateTime = DateTime.Now;


            // درصورتی که رکورد مورد نظر وجود نداشت باید خطا برگردانده شود
            if (entity == null)
                throw new Exception($"داده‌ای با شناسه {EntityId} یافت نشد");


            // مرحله بعدی فرآیند دراین قسمت به دست می‌آید
            var nextStep = await GetNextStep(1, RoutinId, Action);
            // درصورتی که مرحله بعدی -1 باشد باید خطا نمایش داده شود
            if (nextStep == -1)
                throw new Exception("Something went wrong, next dashboard couldn't be -1");


            // مرحله فعلی به دست آمده تا بتوان در ادامه با استفاده از آن تارخچه ثبت کنیم
            int fromStep = Convert.ToInt32(entity.GetPropertyValue("RoutineStep"));
            int RoutineStep = fromStep;

            #region  ثبت لاگ جدید برای این کاربر که رکورد مورد را از یک مرحله به مرحله دیگر انتقال داده است

            CreateLog(new CreateRoutine2LogViewModel
            {
                RoutineId = RoutinId,
                EntityId = EntityId,
                Description = Description,
                Action = await GetActionTitle(RoutinId, fromStep, Action),
                Step = fromStep,
                ToStep = nextStep,
                UserId = userId,
                CreatorUserId = userId,
                RoutineRoleTitle = await GetRoutineRoleTitle(RoutinId, RoutineStep),
            });

            #endregion

            var routineVm = new EditRoutine2ViewModel(nextStep, Convert.ToDateTime(entity.GetPropertyValue("RoutineFlownDate").ToString()));

            // اگر در مرحله آخر باشیم، باید به روال برچست تمام شده بزنیم
            //if (entity.DoneSteps.Contains(nextStep))
            //    routineVm.RoutineIsDone = true;

            //// در صورتی که این آیتم مقدار درستی را اختیار کند، یعنی روتین به اتمام رسیده است
            //if (entity.SucceededSteps.Contains(nextStep))
            //    routineVm.RoutineIsSucceeded = true;

            entity.SetPropertyValue("RoutineStep", nextStep);
            entity.SetPropertyValue("RoutineFlownDate", NowDateTime);
            entity.SetPropertyValue("RoutineStepChangeDate", NowDateTime);

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





        /// <summary>
        /// /// درصورتی از این توابع استفاده شود که جدول مورد نظر به صورت روتین باشد
        /// زمانی که مدیر یا کسی که دسترسی دارد به صورت آنی یک رکورد را به مرحله ایی خاص ببرد
        /// </summary>
        /// <param name="entityId">شماره رکوردی که باید مرحله آن تغییر کند</param>
        /// <param name="toStep">به کدام مرحله برود</param>
        /// <param name="userId">شماره کاربری که دارد تغییر مرحله میدهد</param>
        /// <param name="routinId">شماره روال مورد نظر</param>
        /// <returns></returns>
        public SweetAlertExtenstion UpdateStep(int entityId, int toStep, int userId, int routinId)
        {
            var entity = Entities.Find(entityId);

            if (entity == null) return SweetAlertExtenstion.Error();

            entity.SetPropertyValue("RoutineIsDone", false);
            entity.SetPropertyValue("RoutineIsSucceeded", false);

            //if (UpgradeLicenseRoutine.DoneSteps.Contains(toStep))
            //    entity.SetPropertyValue("RoutineIsDone", true);

            //if (UpgradeLicenseRoutine.SucceededSteps.Contains(toStep))
            //    entity.SetPropertyValue("RoutineIsSucceeded", true);

            entity.SetPropertyValue("RoutineStep", toStep);
            entity.SetPropertyValue("RoutineStepChangeDate", DateTime.Now);

            DbContext.Update(entity);
            DbContext.SaveChanges();


            CreateLog(new CreateRoutine2LogViewModel
            {
                UserId = userId,
                CreatorUserId = userId,
                RoutineId = routinId,
                EntityId = entityId,
                Description = "تغییر کارتابل توسط مدیر ارشد سیستم",
                Action = "تغییر کارتابل",
                ActionDate = DateTime.Now,
                RoutineRoleTitle = "مدیر ارشد سیستم"
            });



            return SweetAlertExtenstion.Ok();
        }





        //private bool IsPermitted(IDashBoard currentDashboard, int userId)
        //{
        //    #region روال test
        //    if (currentDashboard == TestDashBoard.Applicant)
        //    {
        //        if (!User.HasRole(AuthorityCode.UpgradeLicenseApplicant))
        //        {
        //            return false;
        //        }
        //    }
        //    #endregion



        //    return true;
        //}



        #endregion















        #region By Mobasher : خوب حالا  :)

        #region Sync Method



        /// <summary>
        /// گرفتن تمام اطلاعات به‌صورت یک جا
        /// </summary>
        /// <returns></returns>
        public List<IDestination> Load<IDestination>(
            int skip = -1,
            int take = -1,
            Expression<Func<IDestination, bool>> condition = null)
        {
            var query = Entities
                .ProjectTo<IDestination>();

            if (condition != null)
                query = query.Where(condition);


            if (skip != -1)
                query = query.Skip(skip);

            if (take != -1)
                query = query.Take(take);


            return query
                .ToList();
        }

        #endregion

        #region Async Method


        /// <summary>
        /// گرفتن تمام اطلاعات به‌صورت یک جا
        /// </summary>
        /// <returns></returns>
        public async Task<List<IDestination>> LoadAsync<IDestination>(
            int skip = -1,
            int take = -1,
            Expression<Func<IDestination, bool>> condition = null)
        {
            var query = Entities

                .ProjectTo<IDestination>();

            if (condition != null)
                query = query.Where(condition);

            if (skip != -1)
                query = query.Skip(skip);

            if (take != -1)
                query = query.Take(take);




            return await query
                .ToListAsync();
        }


        public async Task<Tuple<int, List<IDestination>>> LoadAsyncCount<IDestination>(
            int skip = -1,
            int take = -1,
            Expression<Func<IDestination, bool>> condition = null)
        {
            var query = Entities.ProjectTo<IDestination>();



            // درصورتی که شرطی وجود داشته باشد آن را اعمال میکند
            if (condition != null)
                query = query.Where(condition);


            int Count = query.Count();


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<IDestination>>(Count, await query.ToListAsync());
        }

        #endregion

        #endregion


        #region Async Method
        public virtual Task<TEntity> GetByIdAsync(params object[] ids)
        {
            return Entities.FindAsync(ids);
        }

        public virtual Task<TEntity> GetByConditionAsync(Expression<Func<TEntity, bool>> where = null)
        {
            var query = TableNoTracking;

            if (where != null) query = query.Where(where);

            return query.FirstOrDefaultAsync();
        }

        public virtual Task<TEntity> GetByConditionAsyncTracked(Expression<Func<TEntity, bool>> where = null)
        {
            var query = Table;

            if (where != null) query = query.Where(where);

            return query.FirstOrDefaultAsync();
        }

        public virtual async Task AddAsync(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            await Entities.AddAsync(entity).ConfigureAwait(false);
            if (saveNow)
                await DbContext.SaveChangesAsync();
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            await Entities.AddRangeAsync(entities).ConfigureAwait(false);
            if (saveNow)
                await DbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Update(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.UpdateRange(entities);
            if (saveNow)
                await DbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Remove(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.RemoveRange(entities);
            if (saveNow)
                await DbContext.SaveChangesAsync();
        }
        #endregion

        #region Sync Methods
        public virtual TEntity GetById(params object[] ids)
        {
            return Entities.Find(ids);
        }

        public TEntity GetByCondition(Expression<Func<TEntity, bool>> where = null)
        {
            var query = TableNoTracking;

            if (where != null) query = query.Where(where);

            return query.FirstOrDefault();
        }

        public TEntity GetByConditionTracked(Expression<Func<TEntity, bool>> where = null)
        {
            var query = Table;

            if (where != null) query = query.Where(where);

            return query.FirstOrDefault();
        }

        public virtual void Add(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Add(entity);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.AddRange(entities);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Update(entity);
            DbContext.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.UpdateRange(entities);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Remove(entity);
            if (saveNow)
                DbContext.SaveChanges();
        }


        public virtual void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Assert.NotNull(entities, nameof(entities));
            Entities.RemoveRange(entities);
            if (saveNow)
                DbContext.SaveChanges();
        }
        #endregion

        #region Attach & Detach
        public virtual void Detach(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            var entry = DbContext.Entry(entity);
            if (entry != null)
                entry.State = EntityState.Detached;
        }

        public virtual void Attach(TEntity entity)
        {
            Assert.NotNull(entity, nameof(entity));
            if (DbContext.Entry(entity).State == EntityState.Detached)
                Entities.Attach(entity);
        }
        #endregion

        #region Explicit Loading
        public virtual async Task LoadCollectionAsync<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty)
            where TProperty : class
        {
            Attach(entity);

            var collection = DbContext.Entry(entity).Collection(collectionProperty);
            if (!collection.IsLoaded)
                await collection.LoadAsync().ConfigureAwait(false);
        }

        public virtual void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty)
            where TProperty : class
        {
            Attach(entity);
            var collection = DbContext.Entry(entity).Collection(collectionProperty);
            if (!collection.IsLoaded)
                collection.Load();
        }

        public virtual async Task LoadReferenceAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty)
            where TProperty : class
        {
            Attach(entity);
            var reference = DbContext.Entry(entity).Reference(referenceProperty);
            if (!reference.IsLoaded)
                await reference.LoadAsync().ConfigureAwait(false);
        }

        public virtual void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty)
            where TProperty : class
        {
            Attach(entity);
            var reference = DbContext.Entry(entity).Reference(referenceProperty);
            if (!reference.IsLoaded)
                reference.Load();
        }
        #endregion


        #region SyncMapping

        public virtual void MapAdd<TProject>(TProject mapEntity, bool saveNow = true)
        {
            var mapModel = Map(mapEntity);

            Add(mapModel, saveNow);
        }

        public virtual void MapAddRange<TProject>(List<TProject> mapEntity, bool saveNow = true)
        {
            var mapModel = MapToList(mapEntity);

            AddRange(mapModel, saveNow);
        }

        public virtual void MapUpdate<TProject>(TProject mapEntity, bool saveNow = true)
        {
            var mapModel = Map(mapEntity);

            Update(mapModel, saveNow);
        }

        public virtual void MapUpdateRange<TProject>(List<TProject> mapEntity, bool saveNow = true)
        {
            var mapModel = MapToList(mapEntity);

            UpdateRange(mapModel, saveNow);
        }

        #endregion

        #region AsyncMapping

        public async Task MapAddAsync<TProject>(TProject project, bool saveNow = true)
        {
            var mapModel = Map(project);

            await AddAsync(mapModel, saveNow);
        }


        public async Task MapAddRangeAsync<TProject>(List<TProject> project, bool saveNow = true)
        {
            var mapModel = MapToList(project);

            await AddRangeAsync(mapModel, saveNow);
        }

        public async Task MapUpdateAsync<TProject>(TProject project, int id, bool saveNow = true)
        {
            var oldEntity = GetById(id);

            Mapper.Map(project, oldEntity);

            if (saveNow)
                await DbContext.SaveChangesAsync();
        }

        public async Task MapUpdateRangeAsync<TProject>(List<TProject> project, bool saveNow = true)
        {
            var mapModel = MapToList(project);

            await UpdateRangeAsync(mapModel, saveNow);
        }

        #endregion

        #region MappingFactory
        /// <summary>
        /// مپ کردن یک لیست به انتیتی مد نظر
        /// </summary>
        /// <typeparam name="TProject"></typeparam>
        /// <param name="mapEntity"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> MapToList<TProject>(List<TProject> mapEntity)
        {
            foreach (var item in mapEntity)
                yield return Mapper.Map<TEntity>(item);

        }

        /// <summary>
        /// مپ کردن به انتیتی مورد نظر
        /// </summary>
        /// <typeparam name="TProject"></typeparam>
        /// <param name="project"></param>
        /// <returns></returns>
        public TEntity Map<TProject>(TProject project)
            => Mapper.Map<TEntity>(project);

        #endregion

        #region Save

        public async Task<SweetAlertExtenstion> SaveAsync()
        {
            return await DbContext.SaveChangesAsync() > 0 ? SweetAlertExtenstion.Ok() : SweetAlertExtenstion.Error();
        }

        public SweetAlertExtenstion Save()
        {
            return DbContext.SaveChanges() > 0 ? SweetAlertExtenstion.Ok() : SweetAlertExtenstion.Error();
        }

        #endregion
    }

}
