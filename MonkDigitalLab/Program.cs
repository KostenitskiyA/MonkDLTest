using Microsoft.EntityFrameworkCore;
using MonkDigitalLab.Interfaces;
using MonkDigitalLab.Models;
using MonkDigitalLab.Models.Configurations;
using MonkDigitalLab.Services;

var builder = WebApplication.CreateBuilder(args);

// Connection settings
var connection = builder.Configuration.GetConnectionString("DefaultDatabase");
builder.Services.AddDbContext<ApplicationContext>(options => { 
    options.UseSqlServer(connection);
});

// Mail settings
var mailSettingsConfiguration = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailSettingsConfiguration);

// Services
builder.Services.AddTransient<IMailSenderService, MailSenderService>();
builder.Services.AddTransient<IMailStoreService, MailStoreService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
