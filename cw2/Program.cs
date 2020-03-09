using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace cw2
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string adres;
            string sciezkaDoceleowa;
            string format;
            if (args.Length == 2)
            {

            }
            String komunikatyBledow = "";
            String path;

            try {
                path = @"D:\dane.csv";
                var lines = File.ReadLines(path);
                var indeksy = new ArrayList();
                var today = DateTime.Today;
                var trescXML = "<uczelnia \ncreatedAt=\" " + today + "\"\nauthor=\"Dominika Wojtanowska\">\n\t<studenci>\n";

                var hash = new HashSet<Student>(new OwnComparer());

                foreach (var line in lines)
                {
                    var slowa = line.Split(",");
                    if (slowa.Length != 9)
                    {
                        komunikatyBledow += "Pominieto studenta z lini: \n" + line;
                        continue;
                    }
                    foreach (var ind in indeksy)
                    {
                        if (ind.ToString() == slowa[4] )
                        {
                            komunikatyBledow += "Pominieto studenta z lini: \n" + line;
                            break; //beda throwy

                        }
                    }

                    indeksy.Add(slowa[4]);
                    for(int i =0; i<9; i++)
                    {
                        if (slowa[i] == " " || slowa[i] == "")
                        {
                            komunikatyBledow += "Pominieto studenta z lini z pwoodu brakujacej pewnej wartosci: \n" + line;
                            break;
                        }
                    }

                    trescXML = "<sudent indexNumber=\"s" + slowa[4] + "\"";
                }







            } catch (Exception e)
            {
                
                komunikatyBledow += "ArgumentException: Podana sciezka jest niepoprawna + \n";

                komunikatyBledow += " plik nie istnieje + \n";
            }
            

            


        }
    }
}
