using Microsoft.EntityFrameworkCore;
using WebChat.Models;
using WebChat.Repositories;
namespace WebChat.Startup
{
    public class Startup
    {
        /*public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ChatContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<MessageService>();
        }*/
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Регистрация контекста данных
            services.AddDbContext<ChatContext>(options =>
               options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection")));

            // Регистрация репозитория
            services.AddScoped<IMessageRepository, MessageRepository>();
        }

    }
    /*public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }*/
}

