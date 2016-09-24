using Microsoft.AspNet.Identity.EntityFramework;

namespace DrawNet.Lib.DataContext.Tables
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }
    }
}