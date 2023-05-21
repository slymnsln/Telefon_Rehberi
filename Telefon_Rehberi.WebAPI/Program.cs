using Telefon_Rehberi.Business.Abstract;
using Telefon_Rehberi.Business.Concrete;
using Telefon_Rehberi.DataAccess.Abstract;
using Telefon_Rehberi.DataAccess.Concrete;
using Telefon_Rehberi.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPersonService, PersonManager>();
builder.Services.AddSingleton<IPersonDal, EfPersonDal>();

builder.Services.AddSingleton<IContactInformationService, ContactInformationManager>();
builder.Services.AddSingleton<IContactInformationDal, EfContactInformationDal>();

builder.Services.AddSingleton<IReportService, ReportManager>();
builder.Services.AddSingleton<IReportDal, EfReportDal>();

builder.Services.AddSingleton<IRabbitMQService, RabbitMQManager>();

builder.Services.AddHostedService<RabbitMQHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
