using Infrastructure.data;
using Ioc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ConnectionInfoDengue");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Necessário para o Swagger
builder.Services.AddSwaggerGen(); 

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                     policy =>
                     {
                         policy.WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                     });
});

builder.Services.AddInfraStructure(builder.Configuration);
builder.Services.AddServices(builder.Configuration);
 

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
builder.Services.AddHttpClient();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

AppContext.SetSwitch("System.Globalization.Invariant", true);

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InfoDengue"));

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();
 