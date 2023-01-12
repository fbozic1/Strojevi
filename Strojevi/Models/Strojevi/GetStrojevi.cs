using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Strojevi.Models
{
    public class GetStrojevi
    {
        public int strojeviid { get; set; }

        public string? naziv { get; set; }
    }
}
