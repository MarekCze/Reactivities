using Application.Activities;
using Application.Core;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services,
			IConfiguration config)
		{
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			services.AddDbContext<DataContext>(opt =>
			{
				opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
			});
			services.AddCors(opt =>
			{
				opt.AddPolicy("CorsPolicy", policy =>
				{
					policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
				});
			});

			// have to use Action type config with new MediatR version instead of what's in the Udemy course
			// tutorial with code: https://code-maze.com/cqrs-mediatr-in-aspnet-core/
			services.AddMediatR(cfg =>
			cfg.RegisterServicesFromAssembly(typeof(List.Handler).Assembly));

			services.AddAutoMapper(typeof(MappingProfiles).Assembly);

			return services;
		}
	}
}
