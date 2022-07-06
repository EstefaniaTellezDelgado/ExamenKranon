﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public List<object> Usuarios { get; set; }
        public ML.Rol Rol { get; set; }
    }
}
