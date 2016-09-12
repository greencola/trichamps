namespace classement
{
    public class Champ
    {
        public string Value;
        public string Title;
        public string categ;
        public string LineCateg;
        public Champ(string _t,string _v,string _c)
        {
            this.Value = _v;
            this.Title = _t;
            this.categ = _c;
        }

    }
}