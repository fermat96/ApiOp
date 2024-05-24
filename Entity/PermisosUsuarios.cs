using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class PermisosUsuarios
    {
        public int IdRegistro { get; set; }
        public string IdUsuario { get; set; }
        public int IdArea { get; set; }
        public bool EsAdmin { get; set; }
        public bool EsActivo { get; set; }
        public string UsuarioERP { get; set; }

    }
}
