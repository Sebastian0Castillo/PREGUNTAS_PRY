
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    namespace PREGUNTAS.DataLayer.DB.Entities.Preguntas_Respuestas
    {
        public class Respuestas
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }

            [Required, Column(TypeName = "varchar(100)")]
            public string descripcion_pregunta
            {
                get; set;
            } = String.Empty;

            public int id_pregunta { get; set; }

            [ForeignKey("id_pregunta")]
            public virtual Preguntas? preguntas { get; set; }
        }


    }

