using Application.DailyStatus.DataAccessEntities;
using Application.DailyStatus.DataAccessInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.DataAccess
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DatabaseConnection context = null;
        private GenericRepository<User> userRepository;
        private GenericRepository<Role> roleRepository;
        private DailyStatusRepository dailyStatusRepository;

        private bool disposed = false;

        public UnitOfWork()
        {
            this.context = new DatabaseConnection();
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new GenericRepository<User>(context);
                return userRepository;
            }
        }

        public GenericRepository<Role> RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                    this.roleRepository = new GenericRepository<Role>(context);
                return roleRepository;
            }
        }

        public DailyStatusRepository DailyStatusRepository
        {
            get
            {
                if (this.dailyStatusRepository == null)
                    this.dailyStatusRepository = new DailyStatusRepository(context);
                return dailyStatusRepository;
            }
        }

        public void Save()
        {
            try
            {
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                //System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
