using Microsoft.EntityFrameworkCore;

namespace WebChat.Models
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация модели данных

            modelBuilder.Entity<User>()
              .Property(u => u.Email)
              .IsRequired();

            modelBuilder.Entity<Message>()
              .HasOne(m => m.Sender)
              .WithMany(u => u.SentMessages)
              .HasForeignKey(m => m.SenderId);
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("DefaultConnection");
        }*/
    }
}
