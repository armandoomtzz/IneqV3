namespace IneqWebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Equipment")]
    public partial class Equipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipment()
        {
            Component = new HashSet<Component>();
        }

        public int Id { get; set; }

        public int? EquipmentTypeId { get; set; }

        public int? ModelId { get; set; }

        public int? BrandId { get; set; }

        public int? StatusId { get; set; }

        public int? WarehouseId { get; set; }

        public DateTime? EntryDate { get; set; }

        public string Serie { get; set; }

        public string SofttekId { get; set; }

        public bool Active { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Component> Component { get; set; }

        public virtual EquipmentType EquipmentType { get; set; }

        public virtual Model Model { get; set; }

        public virtual Status Status { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
