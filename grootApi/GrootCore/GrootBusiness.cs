using grootApi.Context;
using grootApi.Dtos;
using GrootCore.Models;
using GrootTypes.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace GrootCore
{
    public static class GrootBusiness
    {

        public static List<DtoPlant> getPlantsInfo()
        {
            using (var context = new GrootContext())
            {
                return context.Plants.Select(x=> new DtoPlant() {PlantID= x.PlantID, Name = x.Name, Description = x.Description }).ToList<DtoPlant>();
            }
        }
        public static List<DtoSnapshot> getSnapshots()
        {
            using (var context = new GrootContext())
            {
                return context.Snapshots.Select(x=>new DtoSnapshot() {Data = x.Data}).ToList<DtoSnapshot>();
            }
        }

        public static List<DtoSnapshot> getSnapshotsById(int grootId)
        {
            using (var context = new GrootContext())
            {
                return context.Snapshots.Where(x=> x.Groot.GrootId == grootId).Select(x => new DtoSnapshot() { Data = x.Data }).ToList<DtoSnapshot>();
            }
        }

        public static List<DtoAction> getActions()
        {
            using (var context = new GrootContext())
            {
                return context.Actions.Select(x=> new DtoAction() { ActionContent = x.ActionContent, Done = x.Done}).ToList<DtoAction>();
            }
        }

        public static void addAction(int pos, int side)
        {
            using (var context = new GrootContext())
            {
                Action action = new Action() { ActionContent = "{Side:"+side+", Position:"+pos+"}", Done = true};
                context.Actions.Add(action);
                context.SaveChanges();
            }
        }

        public static void addSample()
        {
            using (var ctx = new GrootContext())
            {
                Plant p = new Plant() { Name = "Garbanzo común", Description = "Planta fea de narices usada en el cocido madrileño", GerminationWater = 5, GrowthWater = 10, MaturityWater = 15, Humidity = 10, Illumination = 20, MinTemperature = 10, MaxTemperature = 10 };

                ctx.Plants.Add(p);
                ctx.SaveChanges();
            }
        }

    }
}
