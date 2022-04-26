using System;
using System.Collections.Generic;

namespace P9.Models2
{
    public partial class Cuenta
    {
        public long Id { get; set; }
        public long? NCuentaGerente { get; set; }
        public long? NCuentaEmpleado { get; set; }
        public long? NCuentaUsuario { get; set; }
        public long Tipo { get; set; }

        public virtual Empleado? NCuentaEmpleadoNavigation { get; set; }
        public virtual Gerente? NCuentaGerenteNavigation { get; set; }
        public virtual Usuario? NCuentaUsuarioNavigation { get; set; }
    }
}
