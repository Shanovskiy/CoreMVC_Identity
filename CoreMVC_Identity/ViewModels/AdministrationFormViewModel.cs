using CoreMVC_Identity.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace CoreMVC_Identity.ViewModels
{
    public class AdministrationFormViewModel
    {
        public List<IdentityRole> Roles { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}
