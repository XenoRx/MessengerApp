using Microsoft.EntityFrameworkCore;
using WebChat.Models;
using WebChat.Repositories;
namespace WebChat.Startup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string stf = Configuration.GetConnectionString("DefaultConnection");
            services.AddControllers();
            services.AddSingleton<ChatContext>(provider => provider.CreateScope().ServiceProvider.GetService<ChatContext>());

            //Регистрация контекста данных
            services.AddDbContext<ChatContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Transient);

            services.AddScoped<IMessageRepository, MessageRepository>();
        }
    }
}

