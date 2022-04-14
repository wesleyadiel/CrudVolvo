using Volvo.Data;

namespace CrudVolvo
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host) 
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<VolvoDBContext>();
            context.Database.EnsureCreated();
        }

        private static void AddCaminhoes(VolvoDBContext context)
        {
            var caminhao = context.Caminhoes.FirstOrDefault();
            if (caminhao != null)
            {
                return;
            }
        }
    }
}
