using LigamanagerManagement.Web.Services.Contracts;
using LigaManagerManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LigaManagerManagement.Web.Services
{
    public class TabelleService : ITabelleService
    {
        public IEnumerable<Spieltag> Spieltag { get; set; }

        public IEnumerable<Verein> Verein { get; set; }

        private readonly HttpClient httpClient;

        public TabelleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
                

        public Task<Tabelle> CreateTabelle(Tabelle newTabelle)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTabelle(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tabelle> GetTabelle(int id)
        {
            return await httpClient.GetJsonAsync<Tabelle>($"api/Tabellen/{id}");
        }

        public async Task<IEnumerable<Tabelle>> GetTabellen()
        {
            return await httpClient.GetJsonAsync<Tabelle[]>("api/Tabellen");
        }

        public async Task<Tabelle> UpdateTabelle(Tabelle updatedTabelle)
        {
            return await httpClient.PutJsonAsync<Tabelle>("api/Tabellen", updatedTabelle);
        }         
              

        public async Task<IEnumerable<Tabelle>> BerechneTabelle(ISpieltagService spieltagService, IEnumerable<Verein> Vereine, int spieltag)
        {
            Tabelle tabelleneintrag1;
            Tabelle tabelleneintrag2;
            var myList = new List<Tabelle>();
            int paarung = 1;
                                    
            for (int i = 1; i <= spieltag; i++)
            {
                Spieltag = (await spieltagService.GetSpieltage()).Where(st => st.SpieltagNr == i.ToString() 
                                                                    && st.Saison == Ligamanager.Components.Globals.currentSaison)
                                                                 .ToList();

                Spieltag = (await spieltagService.GetSpieltage()).Where(st => st.SpieltagNr == i.ToString()
                                                                   && st.Saison == Ligamanager.Components.Globals.currentSaison)
                                                                .ToList();

                foreach (var item in Spieltag)
                {
                    //if (Convert.ToInt32(item.Verein1_Nr) == 17 || Convert.ToInt32(item.Verein2_Nr) == 17)
                    //    Debug.Print("Darmstadt");

                    Tabelle tabelleneintragF = myList.FirstOrDefault(element => element.VereinNr == Convert.ToInt32(item.Verein1_Nr));
                    Tabelle tabelleneintragF2 = myList.FirstOrDefault(element => element.VereinNr == Convert.ToInt32(item.Verein2_Nr));

                    if (i == 1)
                    {
                        tabelleneintrag1 = new Tabelle();
                        tabelleneintrag2 = new Tabelle();
                        if (item.Tore1_Nr > item.Tore2_Nr)
                        {
                            tabelleneintrag1.VereinNr = Convert.ToInt32(item.Verein1_Nr);
                            tabelleneintrag1.Verein = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(item.Verein1_Nr)).Vereinsname1;
                            tabelleneintrag1.TorePlus = Convert.ToInt32(item.Tore1_Nr);
                            tabelleneintrag1.ToreMinus = Convert.ToInt32(item.Tore2_Nr);
                            tabelleneintrag1.Spiele = 1;
                            tabelleneintrag1.Punkte = 3;
                            tabelleneintrag1.Gewonnen = 1;
                            tabelleneintrag1.Untentschieden = 0;
                            tabelleneintrag1.Verloren = 0;
                            tabelleneintrag1.Platz = 0;
                            tabelleneintrag1.Tab_Sai_Id =61;
                            tabelleneintrag1.Liga = "Bundesliga";
                            
                            tabelleneintrag2.VereinNr = Convert.ToInt32(item.Verein2_Nr);
                            tabelleneintrag2.Verein = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(item.Verein2_Nr)).Vereinsname1;
                            tabelleneintrag2.TorePlus = Convert.ToInt32(item.Tore2_Nr);
                            tabelleneintrag2.ToreMinus = Convert.ToInt32(item.Tore1_Nr);
                            tabelleneintrag2.Spiele = 1;
                            tabelleneintrag2.Punkte = 0;
                            tabelleneintrag2.Gewonnen = 0;
                            tabelleneintrag2.Untentschieden = 0;
                            tabelleneintrag2.Verloren = 1;
                            tabelleneintrag2.Platz = 0;
                            tabelleneintrag2.Tab_Sai_Id = 61;
                            tabelleneintrag2.Liga = "Bundesliga";

                        }
                        else if (item.Tore1_Nr == item.Tore2_Nr)
                        {
                            tabelleneintrag1.VereinNr = Convert.ToInt32(item.Verein1_Nr);
                            tabelleneintrag1.Verein = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(item.Verein1_Nr)).Vereinsname1;
                            tabelleneintrag1.TorePlus = Convert.ToInt32(item.Tore1_Nr);
                            tabelleneintrag1.ToreMinus = Convert.ToInt32(item.Tore2_Nr);
                            tabelleneintrag1.Spiele = 1;
                            tabelleneintrag1.Punkte = 1;
                            tabelleneintrag1.Gewonnen = 0;
                            tabelleneintrag1.Untentschieden = 1;
                            tabelleneintrag1.Verloren = 0;
                            tabelleneintrag1.Platz = 0;
                            tabelleneintrag1.Tab_Sai_Id = 61;
                            tabelleneintrag1.Liga = "Bundesliga";

                            tabelleneintrag2.VereinNr = Convert.ToInt32(item.Verein2_Nr);
                            tabelleneintrag2.Verein = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(item.Verein2_Nr)).Vereinsname1;
                            tabelleneintrag2.TorePlus = Convert.ToInt32(item.Tore2_Nr);
                            tabelleneintrag2.ToreMinus = Convert.ToInt32(item.Tore1_Nr);
                            tabelleneintrag2.Spiele = 1;
                            tabelleneintrag2.Punkte = 1;
                            tabelleneintrag2.Gewonnen = 0;
                            tabelleneintrag2.Untentschieden = 1;
                            tabelleneintrag2.Verloren = 0;
                            tabelleneintrag2.Platz = 0;
                            tabelleneintrag2.Tab_Sai_Id = 61;
                            tabelleneintrag2.Liga = "Bundesliga";
                        }
                        else if (item.Tore1_Nr < item.Tore2_Nr)
                        {
                            tabelleneintrag1.VereinNr = Convert.ToInt32(item.Verein1_Nr);
                            tabelleneintrag1.Verein = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(item.Verein1_Nr)).Vereinsname1;
                            tabelleneintrag1.TorePlus = Convert.ToInt32(item.Tore1_Nr);
                            tabelleneintrag1.ToreMinus = Convert.ToInt32(item.Tore2_Nr);
                            tabelleneintrag1.Spiele = 1;
                            tabelleneintrag1.Punkte = 0;
                            tabelleneintrag1.Gewonnen = 0;
                            tabelleneintrag1.Untentschieden = 0;
                            tabelleneintrag1.Verloren = 1;
                            tabelleneintrag1.Platz = 0;
                            tabelleneintrag1.Tab_Sai_Id = 61;
                            tabelleneintrag1.Liga = "Bundesliga";

                            tabelleneintrag2.VereinNr = Convert.ToInt32(item.Verein2_Nr);
                            tabelleneintrag2.Verein = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(item.Verein2_Nr)).Vereinsname1;
                            tabelleneintrag2.TorePlus = Convert.ToInt32(item.Tore2_Nr);
                            tabelleneintrag2.ToreMinus = Convert.ToInt32(item.Tore1_Nr);
                            tabelleneintrag2.Spiele = 1;
                            tabelleneintrag2.Punkte = 3;
                            tabelleneintrag2.Gewonnen = 1;
                            tabelleneintrag2.Untentschieden = 0;
                            tabelleneintrag2.Verloren = 0;
                            tabelleneintrag2.Platz = 0;
                            tabelleneintrag2.Tab_Sai_Id = 61;
                            tabelleneintrag2.Liga = "Bundesliga";
                        }
                        paarung++;
                        myList.Add(tabelleneintrag1);
                        myList.Add(tabelleneintrag2);                        
                    }
                    else
                    {
                        tabelleneintrag1 = new Tabelle();
                        tabelleneintrag2 = new Tabelle();

                        if ((tabelleneintragF != null) && (tabelleneintragF2 != null))
                        {
                            if (item.Tore1_Nr > item.Tore2_Nr)
                            {
                                tabelleneintrag1.VereinNr = Convert.ToInt32(item.Verein1_Nr);
                                tabelleneintrag1.Verein = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(tabelleneintragF.VereinNr)).Vereinsname1;
                                tabelleneintrag1.TorePlus = tabelleneintragF.TorePlus + item.Tore1_Nr;
                                tabelleneintrag1.ToreMinus = tabelleneintragF.ToreMinus + item.Tore2_Nr;
                                tabelleneintrag1.Spiele = tabelleneintragF.Spiele + 1;
                                tabelleneintrag1.Gewonnen = tabelleneintragF.Gewonnen + 1;
                                tabelleneintrag1.Untentschieden = tabelleneintragF.Untentschieden;
                                tabelleneintrag1.Verloren = tabelleneintragF.Verloren;
                                tabelleneintrag1.Punkte = tabelleneintragF.Punkte + 3;
                                tabelleneintrag1.Platz = 0;
                                tabelleneintrag1.Tab_Sai_Id = 61;
                                tabelleneintrag1.Liga = "Bundesliga";

                                tabelleneintrag2.VereinNr = Convert.ToInt32(item.Verein2_Nr);
                                tabelleneintrag2.Verein = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(tabelleneintragF2.VereinNr)).Vereinsname1;
                                tabelleneintrag2.TorePlus = tabelleneintragF2.TorePlus + item.Tore2_Nr;
                                tabelleneintrag2.ToreMinus = tabelleneintragF2.ToreMinus + item.Tore1_Nr;
                                tabelleneintrag2.Spiele = tabelleneintragF2.Spiele + 1;
                                tabelleneintrag2.Gewonnen = tabelleneintragF2.Gewonnen;
                                tabelleneintrag2.Untentschieden = tabelleneintragF2.Untentschieden;
                                tabelleneintrag2.Verloren = tabelleneintragF2.Verloren + 1;
                                tabelleneintrag2.Punkte = tabelleneintragF2.Punkte; 
                                tabelleneintrag2.Platz = 0;
                                tabelleneintrag2.Tab_Sai_Id = 61;
                                tabelleneintrag2.Liga = "Bundesliga";

                            }
                            else if (item.Tore1_Nr == item.Tore2_Nr)
                            {
                                tabelleneintrag1.VereinNr = Convert.ToInt32(item.Verein1_Nr);
                                tabelleneintrag1.Verein = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(tabelleneintragF.VereinNr)).Vereinsname1;
                                tabelleneintrag1.TorePlus = tabelleneintragF.TorePlus + item.Tore1_Nr;
                                tabelleneintrag1.ToreMinus = tabelleneintragF.ToreMinus + item.Tore2_Nr;
                                tabelleneintrag1.Spiele = tabelleneintragF.Spiele + 1;
                                tabelleneintrag1.Gewonnen = tabelleneintragF.Gewonnen;
                                tabelleneintrag1.Untentschieden = tabelleneintragF.Untentschieden + 1;
                                tabelleneintrag1.Verloren = tabelleneintragF.Verloren;
                                tabelleneintrag1.Punkte = tabelleneintragF.Punkte + 1;
                                tabelleneintrag1.Platz = 0;
                                tabelleneintrag1.Tab_Sai_Id = 61;
                                tabelleneintrag1.Liga = "Bundesliga";

                                tabelleneintrag2.VereinNr = Convert.ToInt32(item.Verein2_Nr);
                                tabelleneintrag2.Verein = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(tabelleneintragF2.VereinNr)).Vereinsname1;
                                tabelleneintrag2.TorePlus = tabelleneintragF2.TorePlus + item.Tore2_Nr;
                                tabelleneintrag2.ToreMinus = tabelleneintragF2.ToreMinus + item.Tore1_Nr;
                                tabelleneintrag2.Spiele = tabelleneintragF2.Spiele + 1;
                                tabelleneintrag2.Gewonnen = tabelleneintragF2.Gewonnen;
                                tabelleneintrag2.Untentschieden = tabelleneintragF2.Untentschieden + 1;
                                tabelleneintrag2.Verloren = tabelleneintragF2.Verloren;
                                tabelleneintrag2.Punkte = tabelleneintragF2.Punkte + 1;
                                tabelleneintrag2.Platz = 0;
                                tabelleneintrag2.Tab_Sai_Id = 61;
                                tabelleneintrag2.Liga = "Bundesliga";
                            }
                            else if (item.Tore1_Nr < item.Tore2_Nr)
                            {
                                tabelleneintrag1.VereinNr = Convert.ToInt32(item.Verein1_Nr);
                                tabelleneintrag1.Verein = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(tabelleneintragF.VereinNr)).Vereinsname1;
                                tabelleneintrag1.TorePlus = tabelleneintragF.TorePlus + item.Tore1_Nr;
                                tabelleneintrag1.ToreMinus = tabelleneintragF.ToreMinus + item.Tore2_Nr;
                                tabelleneintrag1.Spiele = tabelleneintragF.Spiele + 1;
                                tabelleneintrag1.Gewonnen = tabelleneintragF.Gewonnen;
                                tabelleneintrag1.Untentschieden = tabelleneintragF.Untentschieden;
                                tabelleneintrag1.Verloren = tabelleneintragF.Verloren + 1;
                                tabelleneintrag1.Punkte = tabelleneintragF.Punkte;
                                tabelleneintrag1.Platz = 0;
                                tabelleneintrag1.Tab_Sai_Id = 61;
                                tabelleneintrag1.Liga = "Bundesliga";

                                tabelleneintrag2.VereinNr = Convert.ToInt32(item.Verein2_Nr);
                                tabelleneintrag2.Verein = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(tabelleneintragF2.VereinNr)).Vereinsname1;
                                tabelleneintrag2.TorePlus = tabelleneintragF2.TorePlus + item.Tore2_Nr;
                                tabelleneintrag2.ToreMinus = tabelleneintragF2.ToreMinus + item.Tore1_Nr;
                                tabelleneintrag2.Spiele = tabelleneintragF2.Spiele + 1;
                                tabelleneintrag2.Gewonnen = tabelleneintragF2.Gewonnen + 1;
                                tabelleneintrag2.Untentschieden = tabelleneintragF2.Untentschieden;
                                tabelleneintrag2.Verloren = tabelleneintragF2.Verloren;
                                tabelleneintrag2.Punkte = tabelleneintragF2.Punkte + 3;
                                tabelleneintrag2.Platz = 0;
                                tabelleneintrag2.Tab_Sai_Id = 61;
                                tabelleneintrag2.Liga = "Bundesliga";                                                              
                            }

                            var item1 = myList.Find(r => r.VereinNr == Convert.ToInt32(item.Verein1_Nr));
                            var item2 = myList.Find(r => r.VereinNr == Convert.ToInt32(item.Verein2_Nr));
                            myList.Remove(item1);
                            myList.Remove(item2);
                            myList.Add(tabelleneintrag1);
                            myList.Add(tabelleneintrag2);
                        }
                        else
                        {
                            Debug.Print("null");
                        }                     
                                               
                    }
                    
                }
                myList = myList.OrderByDescending(o => o.TorePlus - o.ToreMinus).OrderByDescending(o => o.Punkte).ToList();

                for (int j = 0; j < myList.Count; j++)
                {
                    myList[j].Platz = j + 1;
                }
            }

            return myList; // httpClient.GetJsonAsync<Tabelle[]>("api/Tabellen");
        }
    }
}
