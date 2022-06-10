using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P11
{
    public class Empleado
    {
        public Empleado()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int Id { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public bool Activo { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }

        // public virtual ICollection<Cuenta> Cuenta { get; set; }

        public object GetAll()
        {
            using (var db = new bancoContext())
            {
                return db.Empleados.ToList();
            }
        }

        public object Get(int id)
        {
            using (var db = new bancoContext())
            {
                var empleado = db.Empleados.Find(id);
                if (empleado == null)
                {
                    return null;
                }

                return empleado;
            }
        }

        public object Delete(int id)
        {
            using (var db = new bancoContext())
            {
                var empleado = db.Empleados.Find(id);
                if (empleado == null)
                {
                    return null;
                }

                empleado.Activo = false;
                db.SaveChanges();

                return empleado;
            }
        }

        public object GetPrestamosToAccept()
        {
            using (var db = new bancoContext())
            {
                var solicitudes = db.SolicitudPrestamos.Where(p => p.Estatus == 1 && p.Prestamo.Meses <= 12).ToList();

                if (solicitudes.Count == 0)
                {
                    return null;
                }

                return solicitudes;
            }
        }



        // public object login(int user, string pass)
        // {
        //   using (var db = new bancoContext())
        //   {
        //     var empleado = db.Empleados.Where(u => u.Id == user && u.Password == pass).FirstOrDefault();

        //     if (empleado == null)
        //     {
        //       return new Exception("Usuario o contraseña inválidos");
        //     }

        //     return empleado;
        //   }
        // }
    }

    public class EmpleadoCreate
    {
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
        public string PrimerNombre { get; set; } = null!;
        [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
        public string? SegundoNombre { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
        public string PrimerApellido { get; set; } = null!;
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
        public string SegundoApellido { get; set; } = null!;
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public Empleado Create(EmpleadoCreate empleadoCreate)
        {
            var Pn = empleadoCreate.PrimerNombre;
            var Sn = empleadoCreate.SegundoNombre;
            var Pa = empleadoCreate.PrimerApellido;
            var Sa = empleadoCreate.SegundoApellido;
            var nacimiento = empleadoCreate.FechaNacimiento;
            using (var db = new bancoContext())
            {
                var empleado = new Empleado();

                empleado.PrimerNombre = Pn;
                empleado.SegundoNombre = Sn;
                empleado.PrimerApellido = Pa;
                empleado.SegundoApellido = Sa;
                empleado.Activo = true;
                empleado.FechaNacimiento = nacimiento;
                // empleado.Password = pass;

                db.Empleados.Add(empleado);
                db.SaveChanges();

                // var cuenta = new Cuenta();
                // cuenta.NCuentaEmpleado = empleado.Id;
                // cuenta.Tipo = 2;
                // db.Cuentas.Add(cuenta);
                // db.SaveChanges();

                return empleado;
            }
        }
    }

    public class EmpleadoUpdate
    {
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
        public string? PrimerNombre { get; set; }
        [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
        public string? SegundoNombre { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
        public string? PrimerApellido { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑ]+", ErrorMessage = "Solo se permiten letras")]
        public string? SegundoApellido { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public Empleado Update(int Id, EmpleadoUpdate empleadoUpdate)
        {
            var Pn = empleadoUpdate.PrimerNombre;
            var Sn = empleadoUpdate.SegundoNombre;
            var Pa = empleadoUpdate.PrimerApellido;
            var Sa = empleadoUpdate.SegundoApellido;
            var nacimiento = empleadoUpdate.FechaNacimiento;
            using (var db = new bancoContext())
            {
                var empleado = db.Empleados.Find(Id);

                empleado.PrimerNombre = Pn;
                empleado.SegundoNombre = Sn;
                empleado.PrimerApellido = Pa;
                empleado.SegundoApellido = Sa;
                empleado.FechaNacimiento = nacimiento;

                db.SaveChanges();

                return empleado;
            }
        }
    }

    public class CalculatePrestamo
    {
        [Required]
        public long UsuarioId { get; set; }
        [Required]
        [Range(1, 1000000)]
        public decimal monto { get; set; }
        [Required]
        [Range(6, 36)]
        public int meses { get; set; }

        public object Calculate(CalculatePrestamo calculate)
        {
            var UsuarioId = calculate.UsuarioId;
            var monto = calculate.monto;
            var meses = calculate.meses;

            using (var db = new bancoContext())
            {
                var user = db.Usuarios.Find(UsuarioId);

                if (user == null)
                {
                    return null;
                }

                if (monto > user.Saldo * 0.5m)
                {
                    return "Greater than 50%";
                }

                decimal total;
                decimal cuota;

                switch (meses)
                {
                    case 6:
                        total = ((monto * 0.12m) + monto);
                        cuota = total / 6;
                        break;

                    case 12:
                        total = ((monto * 0.18m) + monto);
                        cuota = total / 12;
                        break;

                    case 24:
                        total = ((monto * 0.279m) + monto);
                        cuota = total / 24;
                        break;

                    case 36:
                        total = ((monto * 0.42m) + monto);
                        cuota = total / 36;
                        break;
                    default:
                        throw new Exception("Cuotas inválidas");
                }

                var res = new
                {
                    Total = total,
                    Cuota = cuota,
                    Saldo = user.Saldo,
                    UsuarioId = user.Id,
                    Meses = meses,
                    Monto = monto
                };

                return res;
            };
        }
    }
}


