using System.ComponentModel.DataAnnotations.Schema;

namespace IFootWebProject.Models
{
    public class Evenement
    {
        public int id { get; set; }
        public float Prix { get; set; }
        public DateTime dateEvent { get; set; }
        public int heure { get; set; }
        public string Etat { get; set; }


        [ForeignKey("utilisateur")]
        public int idUtilisateur { get; set; }

        [ForeignKey("Terrain")]
        public int idTerrain { get; set; }

        [ForeignKey("TypeEvenement")]
        public int idTypeEven { get; set; }
        public virtual Terrain Terrain { get; set; }
        public virtual utilisateur  Utilisateur{get; set;}
    }
}
