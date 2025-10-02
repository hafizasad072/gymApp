using GYM.API.Middlewares;
using GYM.EF.Models;
using GYM.ServiceLayer.AttendanceService;
using GYM.ServiceLayer.MemberService;
using GYM.ServiceLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MuscleUpGYMContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
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
