//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceLibrary_sjb
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_estatus
    {
        public tbl_estatus()
        {
            this.tbl_log_vacaciones = new HashSet<tbl_log_vacaciones>();
            this.tbl_log_vacaciones1 = new HashSet<tbl_log_vacaciones>();
            this.tbl_vacaciones = new HashSet<tbl_vacaciones>();
        }
    
        public int estatusid { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
    
        public virtual ICollection<tbl_log_vacaciones> tbl_log_vacaciones { get; set; }
        public virtual ICollection<tbl_log_vacaciones> tbl_log_vacaciones1 { get; set; }
        public virtual ICollection<tbl_vacaciones> tbl_vacaciones { get; set; }
    }
}
