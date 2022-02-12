namespace registration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class events
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name_event { get; set; }

        [StringLength(50)]
        public string type_event { get; set; }

        [StringLength(50)]
        public string description { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string data { get; set; }
    }
}
