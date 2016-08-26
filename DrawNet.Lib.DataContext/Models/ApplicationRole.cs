using Microsoft.AspNet.Identity.EntityFramework;

namespace DrawNet.Lib.DataContext.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string name) : base(name)
        {

        }
    }
}