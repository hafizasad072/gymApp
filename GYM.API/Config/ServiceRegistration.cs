using GYM.ServiceLayer;
using GYM.ServiceLayer.ClassBookingService;
using GYM.ServiceLayer.ClassScheduleService;
using GYM.ServiceLayer.ClassService;
using GYM.ServiceLayer.GymService;
using GYM.ServiceLayer.MemberService;
using GYM.ServiceLayer.TrainerService;
using GYM.ServiceLayer.UnitOfWork;

namespace GYM.API.Config
{
    public static class ServiceRegistration
    {
        public static void AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<IGymService, GymService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IClassScheduleService, ClassScheduleService>();
            services.AddScoped<IClassBookingService, ClassBookingService>();
        }
    }

}
