using FluentValidation;
using Mediator.CQRS.Extenstions;
using Mediator.CQRS.Interfaces;
using Mediator.CQRS.RequestPiplineBehaviour;
using Mediator.CQRS.Services;
using MediatR;

namespace Mediator.CQRS
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

            //Note:
            // We are using the MediatR library to implement the CQRS pattern in our application.
            //Question:
            // what is the difference between RegisterServicesFromAssembly and The Ordinary Register?
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


            //Note:
            // We are using a custom pipeline behavior to handle the execution of our commands and queries.
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPipeline<,>));

            //Note:
            // We are using the FluentValidation library to validate our commands and queries.
            builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            builder.Services.AddScoped<IUserServices,UserServices>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //Note:
            // We are using a custom middleware to handle exceptions globally in our application.
            app.HandleException();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
