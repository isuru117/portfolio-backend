using dotenv.net;
using PortfolioBackend.Services;

namespace PortfolioBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DotEnv.Load();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var allowedOrigins = Environment.GetEnvironmentVariable("ALLOWED_ORIGINS")?.Split(',');

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowReactApp",
                    builder =>
                    {
                        if (allowedOrigins != null)
                        {
                            builder.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
                        }
                    }
                );
            });

            services.AddControllers();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseCors("AllowReactApp");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
