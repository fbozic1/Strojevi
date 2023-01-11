using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Strojevi.Models
{
    public class Strojevi
    {
        public int strojeviid { get; set; }

        public string naziv { get; set; }
    }
}
