namespace FitnessAPI.Models {
    public class Exercise {
        public string name { get; set; }
        public string type { get; set; }
        public string muscle { get; set; }
        public string equipment { get; set; }
        public string difficulty { get; set; }
        public string instructions { get; set; }
        public int id { get; set; }
        public long userid { get; set; }
    }
}
