﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LigaManagerManagement.Models
{
    public class Verein
    {
        public int Id { get; set; }
        
        [Required]
        public int VereinNr { get; set; }

        [Required(ErrorMessage = "Vereinsanme erforderlich.")]
        public string Vereinsname1 { get; set; }

        [Required(ErrorMessage = "Vereinsanme erforderlich.")]
        public string Vereinsname2 { get; set; }

        [Required(ErrorMessage = "Stadion erforderlich.")]
        public string Stadion { get; set; }

        public string Fassungsvermoegen { get; set; }

        public string Erfolge { get; set; }

        public int Gegruendet { get; set; }


    }
}
