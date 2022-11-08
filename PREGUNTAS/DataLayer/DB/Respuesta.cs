using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PREGUNTAS.Datalayer.DB
{
    public partial class Respuesta
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Column(TypeName = "varchar(100)")]
        public string? descripcion_respuesta { get; set; } = String.Empty;
        public int? id_pregunta { get; set; }

        [ForeignKey("id_pregunta")]
        public virtual Pregunta? IdPreguntaNavigation { get; set; }


    }
}
