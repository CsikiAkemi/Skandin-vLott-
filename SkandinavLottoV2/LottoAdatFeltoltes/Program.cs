using LottoAdatKapcsolat.Data;
using LottoAdatKapcsolat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoAdatFeltoltes
{
    class Program
    {
        static void Main(string[] arg)
        {
            LottoSzamContext db = new LottoSzamContext();
            if (!db.LottoSzamok.Any())
            {
                string[] sorok = File.ReadAllLines(@"C:\Users\Akemi\Desktop\SkandinavLottoSzamok.csv");
                LottoSzam lsz = null;
                foreach (string sor in sorok)
                {
                    bool sikerult = true;
                    try
                    {
                        lsz = new LottoSzam(sor);
                    }
                    catch (Exception)
                    {
                        sikerult = false;
                    }
                    if (sikerult) db.LottoSzamok.Add(lsz);
                }
                db.SaveChanges();
            }

        }
    }
}
