namespace Rebar.Models
{
    public class Account
    {
        private List<Order> _orders = null!;
        private int _sumOrders ;

        public List<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public int SumOrders
        {
            get { return _sumOrders; }
            set { _sumOrders = value; }
        }

        public Account()
        {
            Orders = new List<Order> { };
            SumOrders = 0;
        }
    }
}
