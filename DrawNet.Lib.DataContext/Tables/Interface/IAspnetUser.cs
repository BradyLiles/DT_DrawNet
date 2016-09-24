using System;

namespace DrawNet.Lib.DataContext.Tables.Interface
{
    public interface IAspnetUser : IDisposable
    {
        string GetUserName(string email);
    }
}
