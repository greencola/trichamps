using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classement
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Champ> champs = new List<Champ>();
            champs.Add(new Champ("titre8a","v","a"));
            champs.Add(new Champ("titre5a", "v", "a"));
            champs.Add(new Champ("titre4a", "v", "a"));
            champs.Add(new Champ("titre2a", "v", "a"));
            champs.Add(new Champ("titre1a", "v", "a"));
            champs.Add(new Champ("titre3a", "v", "a"));
            champs.Add(new Champ("titre9a", "v", "a"));
            champs.Add(new Champ("titre7a", "v", "a"));
            champs.Add(new Champ("titre6a", "v", "a"));
            champs.Add(new Champ("titre10a", "v", "a"));

            champs.Add(new Champ("titre8b", "v", "b"));
            champs.Add(new Champ("titre5b", "v", "b"));
            champs.Add(new Champ("titre4b", "v", "b"));
            champs.Add(new Champ("titre2b", "v", "b"));
            champs.Add(new Champ("titre1b", "v", "b"));
            champs.Add(new Champ("titre3b", "v", "b"));
            champs.Add(new Champ("titre9b", "v", "b"));
            champs.Add(new Champ("titre7b", "v", "b"));
            champs.Add(new Champ("titre6b", "v", "b"));
            champs.Add(new Champ("titre10b", "v", "b"));

            List<String> categs = new List<string>();
            foreach(var c in champs)
            {
                //Si categ pas encore inscrite
                if(categs.Where(x=>x==c.categ).ToList().Count()==0)
                {
                    categs.Add(c.categ);
                }
            }

            GenererHTML(champs,categs);
        }
        public static void GenererHTML(List<Champ> champs,List<String> categs)
        {
            List<Position> positions = new List<Position>();
            positions.Add(new Position("titre1a","a"));
            positions.Add(new Position("titre2a", "a"));
            positions.Add(new Position("titre3a", "a"));
            positions.Add(new Position("titre4a", "a"));
            positions.Add(new Position("titre5a", "a"));
            positions.Add(new Position("titre6a", "a"));
            positions.Add(new Position("", "a"));
            positions.Add(new Position("", "a"));
            positions.Add(new Position("", "a"));

            positions.Add(new Position("titre1b", "b"));
            positions.Add(new Position("", "b"));
            positions.Add(new Position("", "b"));
            positions.Add(new Position("titre2b", "b"));
            positions.Add(new Position("", "b"));
            positions.Add(new Position("", "b"));
            positions.Add(new Position("titre3b", "b"));
            positions.Add(new Position("", "b"));
            positions.Add(new Position("", "b"));

            using (StreamWriter writetext = new StreamWriter("result.html"))
            {
                writetext.WriteLine("<html>");
                writetext.WriteLine("<head>");
                writetext.WriteLine("<link href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-alpha/css/bootstrap.css' rel='stylesheet'>");
                writetext.WriteLine("</head>");
                writetext.WriteLine("<body>");
                
                foreach(var cat in categs)
                {
                    //On charge les positions de la categ
                    List<Position> positionsCateg = positions.Where(x => x.Categ == cat).ToList();
                    List<Champ> hautListe = new List<Champ>();

                    //On place les champs positionnes en debut de liste
                    foreach(var pos in positionsCateg)
                    {
                        foreach(var cl in champs)
                        {
                            if(cl.Title==pos.Champ)
                            {
                                hautListe.Add(cl);
                            }
                        }
                        if(pos.Champ=="")
                        {
                            hautListe.Add(new Champ("","",pos.Categ));
                        }
                    }
                    //On supprime les champs positionnes dans la liste normale
                    foreach(var cl in hautListe)
                    {
                        champs.RemoveAll(x=>x.Title==cl.Title);
                    }

                    hautListe=hautListe.Concat(champs).ToList();


                    writetext.WriteLine("<table class='table tbcl'>");
                    writetext.WriteLine("<tr><th colspan='2'><h4 class='titreCateg'><font color ='#3C8BAD'>"+cat+"</font></h4></th></tr>");
                    int cpt = 0;
                    foreach (var c in hautListe)
                    {
                        if(c.categ==cat)
                        {
                            if(cpt==0)
                            {writetext.WriteLine("<tr>");}
                            writetext.Write("<td>");
                            writetext.Write(c.Title);
                            writetext.Write("</td>");
                            writetext.Write("<td>");
                            writetext.Write(c.Value);
                            writetext.Write("</td>");
                            cpt++;
                            if (cpt==3)
                            {writetext.WriteLine("</tr>");cpt = 0; }
                        }
                    }
                    writetext.WriteLine("</table>");
                }
                
                writetext.WriteLine("<body>");
                writetext.WriteLine("</html>");
            }
        }
    }
}
