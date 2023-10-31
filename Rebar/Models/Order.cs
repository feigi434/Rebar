using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rebar.Models
{
    public class Order
    {
        [BsonElement("shakes_list")]
        private List<Shake> _shakes = null!;

        [BsonElement("sum")]
        private int _sum;

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        private Guid id;

        [BsonElement("coustomer_name")]
        private string _customerName = null!;

        [BsonElement("date")]
        private DateTime _date;

        [BsonElement("discount")]
        private List<Discount> _discount = null!; 

        public List<Shake> Shakes
        {
            get { return _shakes; }
            set { _shakes = value; }
        }

        public int Sum
        {
            get { return _sum; }
            set { _sum = value; }
        }

        public Guid Id
        {
            get { return id; }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public List<Discount> Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        public Order(List<Shake> shakes, string customerName, List<Discount> discount)
        {
            this.id = new Guid();

            if (customerName.All(Char.IsLetter))
                this.CustomerName = customerName;
            else
                throw new ArithmeticException("The customer name is invalid!");

            this.Shakes = shakes;

            this.Date = DateTime.Now;   

            this.Discount = discount;

        }

    }
}
