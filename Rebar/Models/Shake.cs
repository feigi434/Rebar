using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ThirdParty.Json.LitJson;

namespace Rebar.Models
{
    public class Shake
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("price_L")]
        public int PriceL { get; set; }

        [BsonElement("price_M")]
        public int PriceM { get; set; }

        [BsonElement("price_S")]
        public int PriceS { get; set; }
              
        public Shake(string name, string description, int priceL, int priceM, int priceS)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Description = description;
            this.PriceL = priceL;
            this.PriceM = priceM;
            this.PriceS = priceS;

        }

        public override string ToString()
        {
            return "Shake Information:\nId: " + this.Id + "\nName: " + this.Name + "\nDescription: " + this.Description + "\nPriceL: " + this.PriceL + "\nPriceM: " + this.PriceM + "\nPriceS: " + this.PriceS + "\n";
        }


    }



}
