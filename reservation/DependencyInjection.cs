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
