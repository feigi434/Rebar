namespace Rebar.Models
{
    public class Discount
    {
        public string Name { get; set; }
        public int Percent { get; set; }
        
        public Discount(string name, int percent)
        {
            this.Name = name;
            this.Percent = percent;
        }

        public override string ToString()
        {
            return "Discount Information:\nName: " + this.Name + "\nPercent: " + this.Percent + "\n";
        }
    }
}
