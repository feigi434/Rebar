using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ThirdParty.Json.LitJson;

namespace Rebar.Models
{
    public record Shakes(Shake Shake, string size, int price);
    
    public class Order
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("shakes")]
        public List<Shakes> Shakes { get; set; }
        

        [BsonElement("sum")]
        public int Sum { get; set; }

        [BsonElement("coustomer_name")]
        public string CustomerName { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("discount")]
        public List<Discount> Discounts { get; set; } 


        public Order(List<Shakes> shakes, string customerName, List<Discount> discounts)
        {
            this.Id = Guid.NewGuid();
            this.Shakes = shakes;
            this.CustomerName = customerName;
            this.Date = DateTime.Now;
            this.Discounts = discounts;
        }

        //public override string ToString()
        //{
        //    string shakesInfo = null!;
        //    foreach (var shake in Shakes)
        //    {
        //        shakesInfo += shake.ToString() + "\n";
        //    }

        //    string discountsInfo = null!;
        //    foreach (var discount in Discounts)
        //    {
        //        discountsInfo += discount.ToString() + "\n";
        //    }

        //    return "Order Information:\nId: " + this.Id + "\n" + shakesInfo + "Customer Name: " + this.CustomerName + "\nDate: " + this.Date + "\n" + discountsInfo;
        //}

    }
}
