namespace IFootWebProject.Models
{
    public class Terrain
    {
        public Terrain()
        {
            Evenements = new HashSet<Evenement>();

        }
        public int id { set; get;}
        public string Nom { get; set; }
        public string Localisation { get; set; }
        public float Prix { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Evenement> Evenements { get; set; }

    }
}
