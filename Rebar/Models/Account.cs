namespace Rebar.Models
{
    public class Account
    {
        public List<Order> Orders { get; set; }

        public int SumOrders { get; set; }

        public Account(List<Order> orders)
        {
            this.Orders = orders;

            foreach (var order in orders)
            {
                this.SumOrders += order.Sum;
            }

        }

        public override string ToString()
        {
            string ordersInfo = null!;
            foreach (var order in Orders)
            {
                ordersInfo += order.ToString() + "\n";
            }

            return "Account Information:\n" + ordersInfo + "Sum orders: " + this.SumOrders + "\n";
        }
    }
}
