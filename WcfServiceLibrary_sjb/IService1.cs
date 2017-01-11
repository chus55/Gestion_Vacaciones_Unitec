using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary_sjb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        void agregarUsuario(string talentoH, string correo, string password, string nombre1, string nombre2, string apellido1, string apellido2, string fechaIngreso, string fechaCreacion, bool activo);

        [OperationContract]
        Usuario LogInUsuario(string email , string password);

        [OperationContract]
        int LogIn2(string email, string password);

        [OperationContract]
        void agregarDepartamento(string ID, string descripcion, bool activo);

        [OperationContract]
        void agregarRol(string ID, string descripcion, bool activo);

        [OperationContract]
        void Rol_Permiso(string ID_rol, string ID_permiso);

        [OperationContract]
        void Usuario_Departamento(string Talento_Humano, string descripcion_departamento);

        [OperationContract]
        void Usuario_Rol(string Talento_Humano, string descripcion_rol);

        [OperationContract]
        tbl_usuarios LogInUsuario2(string email, string password);

        [OperationContract]
        List<tbl_departamento> ListaDeDepartamentos();

        [OperationContract]
        List<tbl_roles> ListaDeRoles();

        [OperationContract]
        tbl_roles[] ListaDeRolesPorUsuario(string talento_humano);

        [OperationContract]
        void agregarVacaciones(string talento_humano, string year, string fecha_entrada, string fecha_salida, string dias_solicitados, string fecha_solicitud, string fecha_aprobacion, string estatus);

        [OperationContract]
        void agregarJerarquia(string talento_humano, string jefe_talento_humano, string departamento_descripcion);

        [OperationContract]
        string[] ListaDeJefesPosibles(string departamento_descripcion, string talento_humano_actual);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfServiceLibrary_sjb.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class Usuario
    {
        public int talento_humano { get; set; }
        public string email { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public System.DateTime fecha_ingreso { get; set; }
        public System.DateTime fecha_creacion { get; set; }
        public bool activo { get; set; }
        public List<tbl_roles> listaDeRoles { get; set; }
        public List<tbl_permisos> listaDePermisos { get; set; }


        [DataMember]
        public int Talento_Humano
        {
            get { return talento_humano; }
            set { talento_humano = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string Primer_Nombre
        {
            get { return primer_nombre; }
            set { primer_nombre = value; }
        }

        [DataMember]
        public string Segundo_Nombre
        {
            get { return segundo_nombre; }
            set { segundo_nombre = value; }
        }

        [DataMember]
        public string Primer_Apellido
        {
            get { return primer_apellido; }
            set { primer_apellido = value; }
        }

        [DataMember]
        public string Segundo_Apellido
        {
            get { return segundo_apellido; }
            set { segundo_apellido = value; }
        }

        [DataMember]
        public System.DateTime Fecha_Ingreso
        {
            get { return fecha_ingreso; }
            set { fecha_ingreso = value; }
        }

        [DataMember]
        public System.DateTime Fecha_Creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        [DataMember]
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        [DataMember]
        public List<tbl_roles> ListaDeRoles
        {
            get { return listaDeRoles; }
            set { listaDeRoles = value;}
        }

        [DataMember]
        public List<tbl_permisos> ListaDePermisos
        {
            get { return listaDePermisos; }
            set { listaDePermisos = value; }
        }
    }
}
