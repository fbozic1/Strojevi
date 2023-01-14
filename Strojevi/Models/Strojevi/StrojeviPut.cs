using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Strojevi.Models
{
    public class StrojeviPut
    {
        public int id { get; set; }
        public string naziv { get; set; }
    }
}
