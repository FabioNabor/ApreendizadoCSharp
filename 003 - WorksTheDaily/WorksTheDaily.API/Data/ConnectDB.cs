using Microsoft.EntityFrameworkCore;
using WorksTheDaily.API.Model;

namespace WorksTheDaily.API.Data
{
    public class ConnectDB : DbContext
    {
        public ConnectDB(DbContextOptions<ConnectDB> options ) : base (options) { }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<CommentsModel> Comments { get; set; }

    }
}
