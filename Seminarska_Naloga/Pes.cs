using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zival;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Seminarska_Naloga
{
    [Serializable()]
    public class Pes : Zivali, ISerializable //Dedovanje iz knjiznice Zivali
    {
        //Konstruktorji
        public Pes() //Prevzeti
        {
            ImeZivali = null;
            StarostZivali = 0;
            VrstaZivali = null;
        }
        public Pes(string imeZivali, int startostZivali, string vrstaZivali) //Pretvorbeni
        {
            ImeZivali = imeZivali;
            StarostZivali = starostZivali;
            VrstaZivali = vrstaZivali;
        }
        public Pes(Pes p) //Kopirni
        {
            ImeZivali = p.imeZivali;
            StarostZivali = p.starostZivali;
            VrstaZivali = p.vrstaZivali;
        }
        //Override ToString()
        public override string ToString()
        {
            return "Ime psa: " + ImeZivali + " Startost psa: " + StarostZivali.ToString() + " Pasma: " + VrstaZivali;
        }
        //Serializacija (Binarno)
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Ime Psa: ", ImeZivali);
            info.AddValue("Starost Psa: ", StarostZivali);
            info.AddValue("Pasma: ", vrstaZivali);
        }


        new public static void Meni() //Nov meni
        {
            Console.WriteLine("1. Dodaj novega psa.");
            Console.WriteLine("2. Izbrisi izbranega psa.");
            Console.WriteLine("3. Spremeni izbranega psa.");
            Console.WriteLine("4. Shrani pse v datoteko (Binarna Serializacija).");
            Console.WriteLine("5. Nalozi datoteko v list psov (XML Deserializacija).");
            Console.WriteLine("6. Izpis vseh psov.");
            Console.WriteLine("7. Izpis izbranega psa.");
            Console.WriteLine("8. Izbrisi vse pse iz lista.");
            Console.WriteLine("9. Izpis stevilo vpisanih psov.");
            Console.WriteLine("10. Uporaba podmenija za sortiranje.");
            Console.WriteLine("11. Koncaj program.");
            Console.WriteLine();
            Console.Write("Vpisi stevilko pred izbrano moznostjo: ");
        }

    }
}
