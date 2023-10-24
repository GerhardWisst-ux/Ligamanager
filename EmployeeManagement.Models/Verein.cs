using System;
using System.ComponentModel.DataAnnotations;

namespace LigaManagerManagement.Models
{
    public class Verein
    {
        public int Id { get; set; }
        
        [Required]
        public int VereinNr { get; set; }

        [Required]
        public string Vereinsname1 { get; set; }

        [Required]
        public string Vereinsname2 { get; set; }


    }
}
