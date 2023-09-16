using lib;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

try {
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("ConnectionStrings"));

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddSingleton<ICheddarRepository, CheddarRepository>(x => new CheddarRepository(x.GetRequiredService<IOptionsMonitor<AppSettings>>()));
    builder.Services.AddCors(c =>
    {
        c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
    });

    builder.Services.AddControllers();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.UseCors(options => options.AllowAnyOrigin());
    app.MapControllers();

    app.Run();
} catch (Exception ex){
    Console.WriteLine(ex.Message);
}



