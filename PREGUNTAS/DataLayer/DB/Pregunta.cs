using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PREGUNTAS.Datalayer.DB
{
    public partial class Pregunta
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, Column(TypeName = "varchar(100)")]
        public string? descripcion_pregunta { get; set; }
         = String.Empty;

        public virtual ICollection<Respuesta>? id_Respuesta { get; set; }
    }
}
