using LigaManagerManagement.Models;
using System.Collections.Generic;

namespace Ligamanager.Components
{
    public class Globals
    {
        public static string currentSaison;
        public static string currentLiga;
        public static IEnumerable<Verein> VereinAktSaison { get; set; }
    }
}
