namespace GrootCore.Models
{
    public class Plant
    {
        public Plant() { }

        public int PlantID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GerminationWater { get; set; }
        public int GrowthWater { get; set; }
        public int MaturityWater { get; set; }
        public int MinTemperature { get; set; }
        public int MaxTemperature { get; set; }
        public int Humidity { get; set; }
        public int Illumination { get; set; }
    }
}