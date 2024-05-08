using FTorrent.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FTorrent.API.Data
{
	public class ConnApplication : DbContext
	{
		public ConnApplication(DbContextOptions<ConnApplication> options) : base(options){}

		public DbSet<FilesModel> Files { get; set; }
		public DbSet<UserModel> Users { get; set; }
	}
}
