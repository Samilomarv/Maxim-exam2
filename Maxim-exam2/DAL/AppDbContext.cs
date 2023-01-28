using Maxim_exam2.Models;
using Maxim_exam2.Models.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Maxim_exam2.DAL
{
	public class AppDbContext : IdentityDbContext
	{
		public AppDbContext(DbContextOptions options) : base(options) { }
		public DbSet<Service> Services { get; set; }
		public DbSet<AppUser> AppUsers { get; set; }
	}
}
