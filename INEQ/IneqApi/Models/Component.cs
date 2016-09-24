namespace IneqWebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Component")]
    public partial class Component
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public int? ComponentTypeId { get; set; }

        public int? Equipment_Id { get; set; }

        public int? EquipmentType_Id { get; set; }

        public virtual ComponentType ComponentType { get; set; }

        public virtual Equipment Equipment { get; set; }

        public virtual EquipmentType EquipmentType { get; set; }
    }
}
