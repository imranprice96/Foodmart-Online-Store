using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using Microsoft.Owin;
using System.ComponentModel.DataAnnotations;
using System;
namespace Foodmart.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        static ApplicationDbContext()
        {
            //set the database initializer which is run once during application start
            //This seeds teh database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore) : base(roleStore)
        {
        }
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
        }
    }
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }
        private static void InitializeIdentityForEF(ApplicationDbContext context)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name = "admin1@Foodmart.com";
            const string password = "Admin1@Foodmart.com";
            const string roleName = "Admin";
            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }
            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = name,
                    Email = name,
                    FirstName = "Admin",
                    LastName = "Admin",
                    DateOfBirth = new DateTime(2015, 1, 1),
                    Address = new Address
                    {
                        AddressLine1 = "1 Admin Road",
                        Town = "Town",
                        Country = "Country",
                        PostCode = "PostCode"
                    }
                };
                var result = userManager.Create(user, password);
                const string userRoleName = "Users";
                role = roleManager.FindByName(userRoleName);
                if (role == null)
                {
                    role = new IdentityRole(userRoleName);
                    var roleresult = roleManager.Create(role);
                }
            }
            //add user admin to role admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}