using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registro.Entidades
{
    public class Carrera
    {
        [Key]
        public int CarreraId { get; set; }
        public string Nombre { get; set; }
    }
}


