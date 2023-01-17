using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PREGUNTAS.DataLayer.DB.Entities.Seguridad
{
    public class Seguridad_sesiones
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required, Column(TypeName = "varchar(100)")]
        public string Jti { get; set; }

        [Required]
        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual Seguridad_usuarios user { get; set; }
    }
}
