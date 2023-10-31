namespace Rebar.Models
{
    public class Discount
    {
        private string _name = null!;
        private int _percent;

        public string Name
        {
            get { return _name; } 
            set { _name = value; }
        }

        public int Percent
        {
            get { return _percent; }
            set { _percent = value; }
        }

        public Discount(string name, int percent)
        {
           if(name == null)
                throw new ArgumentNullException("name");
           this.Name = name;
           
            if(Enumerable.Range(1, 100).Contains(percent))
                this.Percent = percent;
        }
    }
}
