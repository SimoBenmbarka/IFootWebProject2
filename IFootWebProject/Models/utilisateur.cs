using NuGet.Common;

namespace IFootWebProject.Models
{
    public class utilisateur
    {
        
        public utilisateur() {
            Evenements = new HashSet<Evenement>();

        }
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float longueur { get; set; }
        public string Pied { get; set; }
        public string Role { get; set; }
        public string tel { get; set; }
        public string Email { get; set; }


        public virtual ICollection<Evenement> Evenements { get; set; }

    }
}
