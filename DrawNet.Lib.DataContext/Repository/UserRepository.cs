using System;
using System.Linq;
using DrawNet.Lib.DataContext.Tables;

namespace DrawNet.Lib.DataContext.Repository
{
    public class UserRepository : Repository.RepositoryBase<ApplicationUser>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository()
        {
            _context = new ApplicationDbContext();
        }

        public string GetUserName(string email)
        {
            var baz = _context.Users.SingleOrDefault(a => a.Email == email);
            return baz?.UserName;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
