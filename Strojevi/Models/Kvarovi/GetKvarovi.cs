using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;

namespace Strojevi.Models
{
    public class GetKvarovi
    {
        public int? kvaroviid { get; set; }

        public string? nazivstroja { get; set; }

        public string? nazivkvara { get;set; }

        public string? prioritet { get;set; }

        public DateTime? datumpocetka { get;set; }

        public DateTime? datumzavrsetka { get; set; }

        public string? opiskvara { get;set; }
        public string? statuskvara { get; set; }


    }
}
