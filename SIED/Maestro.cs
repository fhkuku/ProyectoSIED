//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIED
{
    using System;
    using System.Collections.Generic;
    
    public partial class Maestro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Maestro()
        {
            this.Avisoes = new HashSet<Aviso>();
            this.DepartamentosEscuelas = new HashSet<DepartamentosEscuela>();
            this.MaestroGrupos = new HashSet<MaestroGrupos>();
        }
    
        public int IDMaestro { get; set; }
        public string NomMaestro { get; set; }
        public string ApePatMaestro { get; set; }
        public string ApeMatMaestro { get; set; }
        public string TelMaestro { get; set; }
        public string CorreoMaestro { get; set; }
        public string CedulaMaestro { get; set; }
        public Nullable<System.DateTime> IngresoMaestro { get; set; }
        public string FotoMaestro { get; set; }
        public string FotoMaestroCredencial { get; set; }
        public string CurriculumMaestro { get; set; }
        public Nullable<int> IDTipoMaestro { get; set; }
        public string GradoAcademicoMaestro { get; set; }
        public string DireccionMaestro { get; set; }
        public Nullable<int> IDMunicipioMaestro { get; set; }
        public Nullable<byte> StatusMaestro { get; set; }
        public string UsuarioMaestro { get; set; }
        public string ContraseñaMaestro { get; set; }
        public Nullable<int> Sexo { get; set; }
        public string UltimoGrado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aviso> Avisoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartamentosEscuela> DepartamentosEscuelas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaestroGrupos> MaestroGrupos { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual TipoMaestro TipoMaestro { get; set; }
    }
}
