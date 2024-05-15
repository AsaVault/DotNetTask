
using AssessmentTask.Profiles;

namespace AssessmentTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            //string connectionString = configuration["CosmosDb:Account"];

            builder.Services.AddSwaggerGen();
            builder.Services.AddCosmosRepository(options =>
            {
                options.CosmosConnectionString = configuration["CosmosDb:ConnectionString"];
                options.DatabaseId = configuration["CosmosDb:DatabaseName"];
                options.ContainerId = configuration["CosmosDb:ContainerName"];
                options.ContainerPerItemType = true;

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
