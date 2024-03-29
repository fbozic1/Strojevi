﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;

namespace Strojevi.Models
{
    public class KvaroviPost
    {
        [DefaultValue(null)]
        public string nazivstroja { get; set; }

        [DefaultValue(null)]
        public string? nazivkvara { get; set; }

        [DefaultValue("nizak")]
        public string prioritet { get; set; }

        public DateTime datumpocetka { get; set; }

        [DefaultValue(null)]
        public DateTime? datumzavrsetka { get; set; }

        [DefaultValue(null)]
        public string opiskvara { get; set; }

        [DefaultValue("ne")]
        public string? statuskvara { get; set; }

    }
}
