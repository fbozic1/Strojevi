using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Strojevi.Models
{
    public class GetStrojevi
    {
        public int strojeviid { get; set; }

        public string? naziv { get; set; }

        public List<KvaroviTest> Kvarovi { get; set; }

        public double ProsjecnoTrajanjeKvarova { get; set; }

    }

    public class KvaroviTest
    {
        public int? kvaroviid { get; set; }

        public string? nazivstroja { get; set; }

        public string? nazivkvara { get; set; }

        public string? prioritet { get; set; }

        public DateTime? datumpocetka { get; set; }

        public DateTime? datumzavrsetka { get; set; }

        public string? opiskvara { get; set; }

        public double ProsjecnoTrajanjeKvarova { get; set; }

        public string? statuskvara { get; set; }


    }
}
