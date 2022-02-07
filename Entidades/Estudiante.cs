using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registro.Entidades
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public int CarreraId { get; set; }
        public bool Activo { get; set; }

    }
}


