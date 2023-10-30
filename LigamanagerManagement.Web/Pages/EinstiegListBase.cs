using Ligamanager.Components;
using LigamanagerManagement.Web.Services.Contracts;
using LigaManagerManagement.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaManagerManagement.Web.Pages
{
    public class EinstiegListBase : ComponentBase
    {
        protected string sFilename;

        [Inject]
        public ISaisonenService SaisonenService { get; set; }

        public List<DisplaySaison> SaisonenList;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<Verein> Vereine { get; set; }

        [Inject]
        public IVereineService VereineService { get; set; }


        [Inject]
        public ISpieltagService SpieltagService { get; set; }
        public IEnumerable<Saison> Saisonen { get; set; }

        public IEnumerable<Spieltag> Spieltage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            SaisonenList = new List<DisplaySaison>();
            Saisonen = (await SaisonenService.GetSaisonen()).ToList();

            for (int i = 0; i < Saisonen.Count(); i++)
            {
                var columns = Saisonen.ElementAt(i);
                SaisonenList.Add(new DisplaySaison(columns.SaisonID, columns.Saisonname));
            }

            if (DateTime.Now.Month > 6)
            {
                Globals.currentSaison = DateTime.Now.Year + "/" + (DateTime.Now.Year + 1);
            }
            else
            {
                Globals.currentSaison = (DateTime.Now.Year - 1) + "/" + DateTime.Now.Year;
            }
            Globals.currentLiga = "Bundesliga";

        }

        public void SaisonChange(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                Globals.currentSaison = e.Value.ToString();
            }
        }

        public void LigaChange(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                Globals.currentLiga = e.Value.ToString();
            }
        }

        public class DisplaySaison
        {

            public DisplaySaison(int saisonID, string saisonname)
            {
                SaisonID = saisonID;
                Saisonname = saisonname;
            }
            public int SaisonID { get; set; }
            public string Saisonname { get; set; }
        }

        public void OnClickHandlerImport()
        {
            DataTable imported_data = GetDataFromFile();


            if (imported_data == null)
                return;

            SaveImportDataToDatabase(imported_data);
        }

        private DataTable GetDataFromFile()
        {

            DataTable importedData = new DataTable();
            sFilename = "C:\\Users\\gwiss\\source\\repos\\Ligamanager\\Data\\2006.csv";
            try
            {
                using (StreamReader sr = new StreamReader(sFilename, Encoding.GetEncoding("iso-8859-1")))
                {


                    string header = sr.ReadLine();
                    if (string.IsNullOrEmpty(header))
                    {

                        return null;
                    }

                    string[] headerColumns = header.Split(',');
                    foreach (string headerColumn in headerColumns)
                    {
                        importedData.Columns.Add(headerColumn);
                    }



                    while (!sr.EndOfStream)
                    {

                        string line = sr.ReadLine();
                        if (string.IsNullOrEmpty(line)) continue;
                        string[] fields = line.Split(',');
                        DataRow importedRow = importedData.NewRow();

                        for (int i = 0; i < fields.Count(); i++)
                        {

                            importedRow[i] = fields[i];

                        }

                        importedData.Rows.Add(importedRow);
                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("the file could not be read:");
                Console.WriteLine(e.Message);
            }

            return importedData;
        }

        private async void SaveImportDataToDatabase(DataTable imported_data)
        {

            try
            {
                Vereine = await VereineService.GetVereine();

                using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;database=EmployeeDB;Integrated Security=True"))
                {
                    int i = 1;
                    int spieltag = 1;
                    conn.Open();
                    foreach (DataRow importRow in imported_data.Rows)
                    {


                        SqlCommand cmd = new SqlCommand("INSERT INTO spieltage (Saison,SpieltagNr,Verein1,Verein2,Verein1_Nr,Verein2_Nr, Tore1_Nr, Tore2_Nr, Ort,Datum,Available ) " +
                                                          "VALUES (@Saison,@SpieltagNr, @Verein1,@Verein2,@Verein1_Nr,@Verein2_Nr,@Tore1_Nr, @Tore2_Nr,@Ort,@Datum, @Available)", conn);
                        cmd.Parameters.AddWithValue("@Saison", "2006/07"); /*String.Concat(sFilename.Substring(0, 4), "/", (Convert.ToInt32(sFilename.Substring(0, 4)) + 1).ToString())); ;*/
                        cmd.Parameters.AddWithValue("@SpieltagNr", spieltag);
                        cmd.Parameters.AddWithValue("@Verein1", importRow["Hometeam"].ToString().Trim());
                        cmd.Parameters.AddWithValue("@Verein2", importRow["AwayTeam"].ToString().Trim());

                        int iVerein1 = 0;
                        int iVerein2 = 0;
                        string sStadion ="";
                        for (int j = 0; j < Vereine.Count(); j++)
                        {
                            var columns = Vereine.ElementAt(j);

                            iVerein1 = Vereine.FirstOrDefault(a => a.Vereinsname1 == (importRow["Hometeam"].ToString().Trim())).VereinNr;
                            iVerein2 = Vereine.FirstOrDefault(a => a.Vereinsname1 == (importRow["AwayTeam"].ToString().Trim())).VereinNr;
                            sStadion= Vereine.FirstOrDefault(a => a.Vereinsname1 == (importRow["Hometeam"].ToString().Trim())).Stadion;
                            break;
                        }

                        cmd.Parameters.AddWithValue("@Verein1_Nr", iVerein1);
                        cmd.Parameters.AddWithValue("@Verein2_Nr", iVerein2);

                        cmd.Parameters.AddWithValue("@Tore1_Nr", Convert.ToInt32(importRow["FTHG"]));
                        cmd.Parameters.AddWithValue("@Tore2_Nr", Convert.ToInt32(importRow["FTAG"]));
                        cmd.Parameters.AddWithValue("@Ort", sStadion);

                        //DateTime time = Convert.ToDateTime(importRow["Time"]);
                        DateTime dt = new DateTime(Convert.ToInt32(importRow["Date"].ToString().Substring(6, 4)), 
                                                Convert.ToInt32(importRow["Date"].ToString().Substring(3, 2)), 
                                                Convert.ToInt32(importRow["Date"].ToString().Substring(0, 2)), 15, 30, 0);

                        cmd.Parameters.AddWithValue("@Datum", dt);
                        cmd.Parameters.AddWithValue("@Available", true);
                        cmd.ExecuteNonQuery();
                                                
                        int mod = i % 9;

                        if (mod == 0)
                            spieltag++;

                        i++;
                    }

                }
            }
            catch (Exception ex)
            {

                Debug.Print(ex.StackTrace);
            }

        }


        public async void OnClickHandler()
        {
            Vereine = await VereineService.GetVereine();
            //Ligamanager.Components.Globals.VereinAktSaison = (await _VereineService.GetVereine()).Take(18).OrderBy(v => v.Vereinsname1);
            Spieltage = (await SpieltagService.GetSpieltage()).Where(st => st.Saison == Globals.currentSaison).ToList();
            for (int j = 0; j < Spieltage.Count(); j++)
            {
                var columns = Spieltage.ElementAt(j);
                columns.Verein1 = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(columns.Verein1_Nr)).Vereinsname1;
                columns.Verein2 = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(columns.Verein2_Nr)).Vereinsname2;
            }

            int i = 1;
            foreach (var spieltag in Spieltage)
            {

                if (!Globals.VereinAktSaison.ContainsKey(spieltag.Verein1_Nr))
                {
                    Globals.VereinAktSaison.Add(spieltag.Verein1_Nr, spieltag.Verein1);
                }

                var Verein2 = Globals.VereinAktSaison.FirstOrDefault(x => x.Value == spieltag.Verein2_Nr).Key;

                if (!Globals.VereinAktSaison.ContainsKey(spieltag.Verein2_Nr))
                {
                    Globals.VereinAktSaison.Add(spieltag.Verein2_Nr, spieltag.Verein2);
                }

                i++;
            }


            NavigationManager.NavigateTo("spieltage", true);

        }
    }
}
