using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace PREGUNTAS.DataLayer.DB.Entities.Seguridad
{
    public class Seguridad_usuarios
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required, Column(TypeName = "varchar(80)")]
        public string name { get; set; }

        [Required, Column(TypeName = "varchar(80)")]
        public string login { get; set; }

        [Required, Column(TypeName = "varchar(100)")]
        public string password
        {
            get { return Encoding.ASCII.GetString(Convert.FromBase64String(password)); }
            set { password = Convert.ToBase64String(Encoding.ASCII.GetBytes(value)); }
        }

        [JsonIgnore()]
        public virtual ICollection<Seguridad_sesiones> history_sessions { get; set; }
    }
}
