using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reservation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddHotelServices(this IServiceCollection services)
        {
            services.AddScoped<IHotelReservation, HotelReservation>();
            services.AddScoped<IValidateService, ValidateService>();
            return services;
        }
    }
}
