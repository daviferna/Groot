using grootApi.Context;
using GrootCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrootCore
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context =new GrootContext())
            {
                context.Plants.Add(new Plant() { Name="Muscari Baeticum", Description="Planta blanca", GerminationWater=5, GrowthWater=10, MaturityWater=15, Humidity=20, MinTemperature=10, MaxTemperature=30, Illumination=10 });
                context.Plants.Add(new Plant() { Name = "Dragonaria", Description = "Boca de dragón", GerminationWater = 5, GrowthWater = 10, MaturityWater = 15, Humidity = 20, MinTemperature = 10, MaxTemperature = 30, Illumination = 10 });
                context.Plants.Add(new Plant() { Name = "Tomillo", Description = "Para la cocina", GerminationWater = 5, GrowthWater = 10, MaturityWater = 15, Humidity = 20, MinTemperature = 10, MaxTemperature = 30, Illumination = 10 });

                context.Users.Add(new User() { Name="Daniel", LastName="Avila", Email="daniel.avilaf@outlook.es"});
            }
        }
    }
}
