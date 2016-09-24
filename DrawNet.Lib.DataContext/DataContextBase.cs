using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawNet.Lib.DataContext.Tables;

namespace DrawNet.Lib.DataContext
{
    public class ApplicationDbContextBase : IDisposable
    {
        #region Declaration
        private ApplicationDbContext _ApplicationDbContext;
        public ApplicationDbContext ApplicationDbContext
        {
            get
            {
                return _ApplicationDbContext;
            }
            set
            {
                _ApplicationDbContext = value;
            }
        }
        public ApplicationDbContext NewApplicationDbContext
        {
            get
            {
                return new ApplicationDbContext( );
            }
        }
        #endregion
        public ApplicationDbContextBase()
        {
        }
        public ApplicationDbContextBase( ApplicationDbContext applicationDbContext )
        {
            this.ApplicationDbContext = applicationDbContext;
        }
        public void Dispose()
        {
            ApplicationDbContext?.Dispose();
        }
    }
}
