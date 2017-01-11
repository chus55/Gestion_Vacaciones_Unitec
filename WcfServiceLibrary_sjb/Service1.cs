using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary_sjb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void agregarUsuario(string talentoH, string correo, string password, string nombre1, string nombre2, string apellido1, string apellido2, string fechaIngreso, string fechaCreacion, bool activo)
        {
            try
            {
                vsystem_sjbEntities ent = new vsystem_sjbEntities();
                tbl_usuarios newUsuario = new tbl_usuarios();
                newUsuario.talento_humano = Int32.Parse(talentoH);
                newUsuario.password = password;
                newUsuario.email = correo;
                newUsuario.primer_nombre = nombre1;
                newUsuario.segundo_nombre = nombre2;
                newUsuario.primer_apellido = apellido1;
                newUsuario.segundo_apellido = apellido2;
                newUsuario.fecha_ingreso = Convert.ToDateTime(fechaIngreso);
                newUsuario.fecha_creacion = Convert.ToDateTime(fechaCreacion);
                newUsuario.activo = activo;

                ent.tbl_usuarios.Add(newUsuario);

                ent.SaveChanges();
            }
            catch(Exception e){
            }
        }

        public Usuario LogInUsuario(string email, string password)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            //tbl_usuarios newUsuario = new tbl_usuarios();

            var query = (from u in ent.tbl_usuarios
                        where u.email == email && u.password == password
                        select u).FirstOrDefault();

            if(query == null)
                return null;
            tbl_usuarios user2 = query;
            List<tbl_roles> miListitaDeRoles = new List<tbl_roles>();
            List<tbl_permisos> miListitaDePermisos = new List<tbl_permisos>();

            for(int x = 0; x<user2.tbl_roles.ToList<tbl_roles>().Count; x++)
            {
                tbl_roles miRol = new tbl_roles();
                miRol.descripcion = user2.tbl_roles.ToList<tbl_roles>().ElementAt(x).descripcion;
                miRol.activo = user2.tbl_roles.ToList<tbl_roles>().ElementAt(x).activo;
                miRol.rolesid = user2.tbl_roles.ToList<tbl_roles>().ElementAt(x).rolesid;
                miListitaDeRoles.Add(miRol);
            }

            for (int x = 0; x < miListitaDeRoles.Count; x++)
            {

                tbl_roles miRolActual = user2.tbl_roles.ToList<tbl_roles>().ElementAt(x);
                int numeroDePermisos = miRolActual.tbl_permisos.ToList<tbl_permisos>().Count;

                for (int y = 0; y < numeroDePermisos; y++)
                {
                    tbl_permisos miPermiso = new tbl_permisos();
                    miPermiso.activo = miRolActual.tbl_permisos.ToList<tbl_permisos>().ElementAt(y).activo;
                    miPermiso.descripcion = miRolActual.tbl_permisos.ToList<tbl_permisos>().ElementAt(y).descripcion;
                    miPermiso.permisosid = miRolActual.tbl_permisos.ToList<tbl_permisos>().ElementAt(y).permisosid;
                    if(!miListitaDePermisos.Contains(miPermiso))
                        miListitaDePermisos.Add(miPermiso);
                }
            }

            Usuario user = new Usuario()
            {
                activo = query.activo,
                email = query.email,
                fecha_creacion = query.fecha_creacion,
                fecha_ingreso = query.fecha_ingreso,
                primer_apellido = query.primer_apellido,
                primer_nombre = query.primer_nombre,
                segundo_apellido = query.segundo_apellido,
                segundo_nombre = query.segundo_apellido,
                talento_humano = query.talento_humano,
                listaDeRoles = miListitaDeRoles,
                listaDePermisos = miListitaDePermisos
            };

            //newUsuario = query;

            return user; 
        }

        public void agregarDepartamento(string ID, string descripcion, bool activo)
        {
            try
            {
                vsystem_sjbEntities ent = new vsystem_sjbEntities();
                tbl_departamento newDepartamento = new tbl_departamento();
                //newDepartamento.departamentoid = Int32.Parse(ID);
                newDepartamento.descripcion = descripcion;
                newDepartamento.activo = true;

                ent.tbl_departamento.Add(newDepartamento);
                ent.SaveChanges();
            }
            catch (Exception e) { }
        }

        public void agregarRol(string ID, string descripcion, bool activo)
        {
            try
            {
                vsystem_sjbEntities ent = new vsystem_sjbEntities();
                tbl_roles newRol = new tbl_roles();
                //newRol.rolesid = Int32.Parse(ID);
                newRol.descripcion = descripcion;
                newRol.activo = true;

                ent.tbl_roles.Add(newRol);
                ent.SaveChanges();
            }
            catch (Exception e) { }
        }

        public void Rol_Permiso(string ID_rol, string ID_permiso)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
        }

        public void Usuario_Departamento(string Talento_Humano, string descripcion_departamento)
        {
            try { 
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            int _Talento_Humano = Int32.Parse(Talento_Humano);
            var query = (from u in ent.tbl_usuarios
                         where u.talento_humano == _Talento_Humano
                         select u).FirstOrDefault();
            
            var query2 = (from u in ent.tbl_departamento
                          where u.descripcion == descripcion_departamento
                          select u).FirstOrDefault();
            tbl_usuarios user = query;
            tbl_departamento departamento = query2;
            user.tbl_departamento.Add(departamento);
            ent.SaveChanges();
            }
            catch (Exception e) { }
        }

        public void Usuario_Rol(string Talento_Humano, string descripcion_rol)
        {
            try
            {
                vsystem_sjbEntities ent = new vsystem_sjbEntities();
                int _talentoHumano = Int32.Parse(Talento_Humano);
                var query = (from u in ent.tbl_usuarios
                             where u.talento_humano == _talentoHumano
                             select u).FirstOrDefault();

                var query2 = (from u in ent.tbl_roles
                              where u.descripcion == descripcion_rol
                              select u).FirstOrDefault();
                tbl_usuarios user = query;
                tbl_roles rol = query2;

                user.tbl_roles.Add(rol);
                ent.SaveChanges();
            }
            catch (Exception e) { }
        }

        public int LogIn2(string email, string password)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();

            string _email = email;
            string _password = password;

            var query = (from u in ent.tbl_usuarios
                         where u.email == email && u.password == password
                         select u).FirstOrDefault();

            if (query == null)
                return 0;
            return 1;
        }

        public tbl_usuarios LogInUsuario2(string email, string password)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            var query = (from u in ent.tbl_usuarios
                         where u.email == email && u.password == password
                         select u).FirstOrDefault();

            if (query == null)
                return null;
            return query; 
        }

        public List<tbl_departamento> ListaDeDepartamentos()
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            var query = (from u in ent.tbl_departamento
                         select u).ToList();
            List<tbl_departamento> miListaDeDepartamentos = new List<tbl_departamento>();
            for (int y = 0; y < query.Count; y++)
            {
                tbl_departamento miDepartamento = new tbl_departamento();
                miDepartamento.activo = query.ElementAt(y).activo;
                miDepartamento.descripcion = query.ElementAt(y).descripcion;
                miDepartamento.departamentoid = query.ElementAt(y).departamentoid;
                miListaDeDepartamentos.Add(miDepartamento);
            }
            return miListaDeDepartamentos;
        }

        public List<tbl_roles> ListaDeRoles()
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            var query = (from u in ent.tbl_roles
                         select u).ToList();
            List<tbl_roles> miListaDeRoles = new List<tbl_roles>();
            for (int y = 0; y < query.Count; y++)
            {
                tbl_roles miRol = new tbl_roles();
                miRol.activo = query.ElementAt(y).activo;
                miRol.descripcion = query.ElementAt(y).descripcion;
                miRol.rolesid = query.ElementAt(y).rolesid;
                miListaDeRoles.Add(miRol);
            }
            return miListaDeRoles;
        }

        public tbl_roles[] ListaDeRolesPorUsuario(string talento_humano)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            int numero = Int32.Parse(talento_humano);
            List<string> miListaDeIDs = new List<string>();
            var query = (from u in ent.tbl_usuarios
                         where u.talento_humano == numero
                         select u).FirstOrDefault();
            tbl_usuarios user = query;
            List<tbl_roles> miListaDeRoles = user.tbl_roles.ToList();
            int numeroDeRoles = miListaDeRoles.Count();

            tbl_roles[] miArregloDeRoles = new tbl_roles[numeroDeRoles];
            for(int x=0; x<numeroDeRoles; x++)
            {
                miArregloDeRoles[x] = miListaDeRoles.ElementAt(x);
            }
            return miArregloDeRoles;
        }

        public void agregarVacaciones(string talento_humano, string year, string fecha_entrada, string fecha_salida, string dias_solicitados, string fecha_solicitud, string fecha_aprobacion, string estatus)
        {
            try { 
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            tbl_vacaciones newVacaciones = new tbl_vacaciones();

            //newVacaciones.vacacionesid = Int32.Parse(vacacionesID);
            newVacaciones.talento_humano = Int32.Parse(talento_humano);
            newVacaciones.year = Int32.Parse(year);
            newVacaciones.fecha_entrada = Convert.ToDateTime(fecha_entrada);
            newVacaciones.fecha_salida = Convert.ToDateTime(fecha_salida);
            newVacaciones.dias_solicitados = Int32.Parse(dias_solicitados);
            newVacaciones.fecha_solicitud = Convert.ToDateTime(fecha_solicitud);
            newVacaciones.fecha_de_aprobacion = Convert.ToDateTime(fecha_aprobacion);

            var query = (from u in ent.tbl_estatus
                         where u.descripcion == estatus
                         select u).FirstOrDefault();

            tbl_estatus miEstatus = query;
            newVacaciones.estatusid = miEstatus.estatusid;
            newVacaciones.tbl_estatus = miEstatus;

            int miNumerito = Int32.Parse(talento_humano);
            var query2 = (from u in ent.tbl_usuarios
                         where u.talento_humano == miNumerito
                         select u).FirstOrDefault();

            tbl_usuarios miUsuario = query2;
            newVacaciones.tbl_usuarios = miUsuario;
            ent.tbl_vacaciones.Add(newVacaciones);
            ent.SaveChanges();
            }
            catch (Exception e) { }
        }

        public void agregarJerarquia(string talento_humano, string jefe_talento_humano, string departamento_descripcion)
        {
            try { 
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            tbl_jerarquia newJerarquia = new tbl_jerarquia();

            var query2 = (from u in ent.tbl_departamento
                          where u.descripcion == departamento_descripcion
                          select u).FirstOrDefault();
            tbl_departamento miDepartamento = query2;

            newJerarquia.departamentoid = miDepartamento.departamentoid;
            newJerarquia.jefe_talentohumano = Int32.Parse(jefe_talento_humano);
            newJerarquia.talento_humano = Int32.Parse(talento_humano);

            ent.tbl_jerarquia.Add(newJerarquia);
            ent.SaveChanges();
            }
            catch (Exception e) { }
        }

        public string[] ListaDeJefesPosibles(string departamento_descripcion, string talento_humano_actual)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            List<tbl_usuarios> miListaDeUsuariosJefesPosibles = new List<tbl_usuarios>();
            var query = (from u in ent.tbl_usuarios
                         select u).ToList();
            var query2 = (from u in ent.tbl_departamento
                          where u.descripcion == departamento_descripcion
                          select u).FirstOrDefault();
            tbl_departamento miDepartamento = query2;
            for (int x = 0; x < query.Count; x++)
            {
                tbl_usuarios miUsuarioActual = query.ElementAt(x);
                if (miUsuarioActual.talento_humano != Int32.Parse(talento_humano_actual))
                {
                    for (int r = 0; r < miUsuarioActual.tbl_departamento.Count; r++)
                    {
                        if (miUsuarioActual.tbl_departamento.ElementAt(r).descripcion == departamento_descripcion)
                               miListaDeUsuariosJefesPosibles.Add(miUsuarioActual);
                    }
                }
            }
            string[] miArregloDeJefes = new string[miListaDeUsuariosJefesPosibles.Count];
            for (int y = 0; y < miListaDeUsuariosJefesPosibles.Count; y++)
            {
                string miString = miListaDeUsuariosJefesPosibles.ElementAt(y).primer_nombre + " " +
                    miListaDeUsuariosJefesPosibles.ElementAt(y).primer_apellido;
                miArregloDeJefes[y] = miString;
            }
            return miArregloDeJefes;
        }
    }
}
