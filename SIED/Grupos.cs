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
    
    public partial class Grupos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grupos()
        {
            this.Alumnos = new HashSet<Alumno>();
            this.Calificaciones = new HashSet<Calificacione>();
            this.GrupoAsignaturas = new HashSet<GrupoAsignatura>();
            this.MaestroGrupos = new HashSet<MaestroGrupos>();
        }
    
        public int IDGrupo { get; set; }
        public string NombreGrupo { get; set; }
        public Nullable<int> IDPeriodo { get; set; }
        public Nullable<int> IDPlanEstudio { get; set; }
        public Nullable<int> IDSemestre { get; set; }
        public Nullable<byte> Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumno> Alumnos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrupoAsignatura> GrupoAsignaturas { get; set; }
        public virtual PeriodoEscolar PeriodoEscolar { get; set; }
        public virtual PlanesEstudio PlanesEstudio { get; set; }
        public virtual Semestre Semestre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaestroGrupos> MaestroGrupos { get; set; }
    }
}