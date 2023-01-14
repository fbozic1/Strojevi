using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;

namespace Strojevi.Models
{
    public class KvaroviPost
    {
        public string imestroja { get; set; }

        public string? nazivkvara { get; set; }

        [DefaultValue("nizak")]
        public string prioritet { get; set; }

        public DateTime datumpocetka { get; set; }

        public DateTime? datumzavrsetka { get; set; }

        public string opiskvara { get; set; }

        [DefaultValue("ne")]
        public string? statuskvara { get; set; }

    }
}
