using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;

namespace Strojevi.Models
{
    public class KvaroviPut
    {
        [Required]
        public int kvaroviid { get; set; }

        [DefaultValue(null)]
        public string? nazivstroja { get; set; }

        [DefaultValue(null)]
        public string? nazivkvara { get; set; }

        [DefaultValue("nizak")]
        public string? prioritet { get; set; }

        public DateTime? datumpocetka { get; set; }

        [DefaultValue(null)]
        public DateTime? datumzavrsetka { get; set; }

        [DefaultValue(null)]
        public string? opiskvara { get; set; }

    }
}
