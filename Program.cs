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
            using (StreamWriter writetext = new StreamWriter("result.html"))
            {
                writetext.WriteLine("<html>");
                writetext.WriteLine("<head>");
                writetext.WriteLine("<link href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-alpha/css/bootstrap.css' rel='stylesheet'>");
                writetext.WriteLine("</head>");
                writetext.WriteLine("<body>");
                
                foreach(var cat in categs)
                {
                    writetext.WriteLine("<table class='table tbcl'>");
                    writetext.WriteLine("<tr><th colspan='1'><h4 class='titreCateg'><font color ='#3C8BAD'>"+cat+"</font></h4></th></tr>");
                    foreach (var c in champs)
                    {
                        if(c.categ==cat)
                        { 
                            writetext.WriteLine("<tr>");
                            writetext.WriteLine("<td>");
                            writetext.WriteLine(c.Title);
                            writetext.WriteLine("</td>");
                            writetext.WriteLine("</tr>");
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
