using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Zival;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Seminarska_Naloga
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pes> ziv = new List<Pes>();

            do
            {
                try
                {
                    Pes.Meni();
                    int x = int.Parse(Console.ReadLine());

                    switch (x)
                    {
                        case 1: //Dodajanje
                            Pes z = new Pes();
                            Console.WriteLine();
                            try
                            {
                                Console.Write("Ime Psa: ");
                                z.ImeZivali = Console.ReadLine();
                                Console.Write("Starost Psa: ");
                                z.StarostZivali = int.Parse(Console.ReadLine());
                                Console.Write("Pasma: ");
                                z.VrstaZivali = Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Napačno ste vnesli podatke. Vrsta Napaake:");
                                Console.WriteLine(e.Message);
                            }
                            finally
                            {
                                ziv.Add(z);
                            }
                            break;
                        case 2: //Izbris izbrane zivali  
                            try
                            {
                                Console.Write("Izbrises lahko psa med 0 in {0}.Katerega zelis izbrisat? ", ziv.Count - 1);
                                int izbris = int.Parse(Console.ReadLine());
                                if (izbris > ziv.Count || izbris < 0)
                                {
                                    Console.WriteLine("Pes ne tem mestu ne obstaja!!!");
                                }
                                else
                                {
                                    ziv.RemoveAt(izbris);
                                    Console.WriteLine("Izbran pes je bil izbrisan!");
                                }
                            }
                            catch (Exception e)
                            {

                                Console.WriteLine();
                                Console.WriteLine("Napačno ste vnesli podatke. Vrsta Napaake:");
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 3: //Spremeni izbran objekt
                            try
                            {
                                Console.Write("Spremenis lahko psa med 0 in {0}.Katero zelis spremenit? ", ziv.Count - 1);
                                int spremeni = int.Parse(Console.ReadLine());
                                if (spremeni > ziv.Count || spremeni < 0)
                                {
                                    Console.WriteLine("Pes ne tem mestu ne obstaja!");
                                    break;
                                }
                                else
                                {
                                    ziv.RemoveAt(spremeni);
                                    Pes z1 = new Pes();
                                    Console.Write("Ime Psa: ");
                                    z1.ImeZivali = Console.ReadLine();
                                    Console.Write("Starost Psa: ");
                                    z1.StarostZivali = int.Parse(Console.ReadLine());
                                    Console.Write("Vrsta Psa: ");
                                    z1.VrstaZivali = Console.ReadLine();
                                    ziv.Insert(spremeni, z1);
                                    Console.WriteLine("Pes na mestu {0} je bil spremenjen!", spremeni);
                                    break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Napačno ste vnesli podatke. Vrsta Napaake:");
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 4: //Nalozi list v datoteko !! (Serializacija Binary)
                            string path = @"C:\\temp\\IzListVDatoteko.txt";

                            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
                            BinaryFormatter serializer = new BinaryFormatter();
                            serializer.Serialize(stream, ziv);
                            stream.Close();

                            Console.WriteLine("Psi so bili nalozeni v datoteko!");
                            break;
                        case 5: //Nalozi datoteko v list !! (Deserializacija XML) 
                            Console.WriteLine();
                            Console.WriteLine("Za vstavljanje psa v list more biti datoteka v XML strukturi!");

                            string pathDat = @"C:\\temp\\IzDatotekeVList.txt";
                            ziv = null;

                            XmlSerializer des = new XmlSerializer(typeof(List<Pes>));
                            StreamReader instream = new StreamReader(pathDat);

                            instream.ReadLine();
                            ziv = (List<Pes>)des.Deserialize(instream);
                            instream.Close();

                            Console.WriteLine("Psi so bili nalozeni iz datoteke!");
                            break;
                        case 6: //Izpis vseh zivali
                                int i = 1;
                                if (ziv.Count <= 0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("List Pes je prazen, nemorem nic izpisati!");
                                }
                                else
                                {
                                    Console.WriteLine("Izpis vseh Psov: ");
                                    foreach (var zival in ziv)
                                    {
                                        Console.WriteLine("{0}. Pes:", i);
                                        zival.IzpisiZival();
                                        Console.WriteLine();
                                        i++;
                                    }
                                }
                            break;
                        case 7: //Izpis izbrane zivali
                            try
                            {
                                Console.Write("Izpises lahko psa med 0 in {0}.Katerega zelis izpisat? ", ziv.Count - 1);
                                int izpisi = int.Parse(Console.ReadLine());
                                if (izpisi > ziv.Count || izpisi < 0)
                                {
                                    Console.WriteLine("Pes ne tem mestu ne obstaja!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Pes na {0}. mestu: ", izpisi);
                                    ziv[izpisi].IzpisiZival();
                                    break;
                                }
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Napačno ste vnesli podatke. Vrsta Napaake:");
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 8: //Izbrisi vse objekte
                            ziv.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Vsi Psi v listu so bili izbrisani. Zdaj je list prazen");
                            break;
                        case 9: //Izpis stevila objektov
                            Console.WriteLine();
                            Console.WriteLine("V list je trenutno {0} shranjenih psov.", ziv.Count());
                            break;
                        case 10: //Sortiranje objektov po dolocenem kriteriju
                            try
                            {
                                Zivali.Sortiranja();
                                int sort = int.Parse(Console.ReadLine());
                                switch (sort)
                                {
                                    case 1: //Starost naracajoce
                                        ziv.Sort((j, y) => j.StarostZivali.CompareTo(y.StarostZivali));
                                        Console.WriteLine("List zivali je zdaj sortirano po starosti narascajoce.");
                                        break;
                                    case 2: //Startost padajoce
                                        ziv = ziv.OrderByDescending(t => t.StarostZivali).ToList();
                                        Console.WriteLine("List zivali je zdaj sortirano po starosti padajoce.");
                                        break;
                                    case 3: //Ime A->Z
                                        ziv.Sort((j, y) => j.ImeZivali.CompareTo(y.ImeZivali));
                                        Console.WriteLine("List zivali je zdaj sortirano po imenih A->Z.");
                                        break;
                                    case 4://Ime Z->A
                                        ziv.Sort((j, y) => y.ImeZivali.CompareTo(j.ImeZivali));
                                        Console.WriteLine("List zivali je zdaj sortirano po imenih Z->A.");
                                        break;
                                    //Sortiranje po vecih atributih
                                    case 5: //To sortiranje pride v upostev ce je vec zivali z istim imenom ali isto starostjo
                                        ziv = ziv.OrderBy(y => y.StarostZivali).ThenBy(y => y.ImeZivali).ToList();
                                        Console.WriteLine("Zivali bodo prvo sortirane po strosti padajoce potem po imenih A-Z.");
                                        break;
                                    case 6: //To sortiranje pride v upostev ce je vec zivali z istim imenom ali isto starostjo
                                        ziv = ziv.OrderBy(y => y.ImeZivali).ThenBy(y => y.StarostZivali).ToList();
                                        Console.WriteLine("Zivali bodo prvo sortirane po imenu A-Z potem po letih padajoce.");
                                        break;
                                    default:
                                        Console.WriteLine("Sortiranje z to predstevilko ne obstaja!!!");
                                        break;
                                }
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Napačno ste vnesli podatke. Vrsta Napaake:");
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 11: //Zakljuci program
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Moznost z to stevilko ne obsataja!");
                            break;

                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Napačno ste vnesli podatke. Vrsta Napaake:");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine();
                    Console.WriteLine("Po pregledu rezultata pritisnite katerokoli tipko za nadaljevanje!");
                    Console.WriteLine();
                    Console.ReadKey(true);
                }
                
            } while (true);
        }
    }
}
