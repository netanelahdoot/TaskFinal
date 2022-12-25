using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class OrderBook
    {
        private static OrderBook instance = null;

        private List<Order> book;
        private HashSet<Product> products;


        public List<Order> Book { get => book; set => book = value; }

        private OrderBook()
        {
            this.book = new List<Order>();
            this.products = new HashSet<Product>();
        }
        public static OrderBook getInstance()
        {
            if(instance == null)
            {
                instance = new OrderBook();
            }
            return instance;
        }

        public void addProductNow(Product product, int quantity, DateTime expdate)
        {
            products.Add(product);
            book.Add(new Order(product, Status.HERE, quantity, expdate));
        }
        public void orderProduct(Product product, int quantity)
        {
            products.Add(product);
            book.Add(new Order(product, Status.PROCESSING, quantity));
        }
        public void orderProduct(String name, int quantity)
        {
            orderProduct(products.Where(p => p.Name == name).FirstOrDefault(), quantity);
        }
        public Order getOrder(string id)
        {
            return book.Where(o => o.Id.Equals(id)).FirstOrDefault();
        }
        public List<Order> avaliableOrders(Product p)
        {
            List<Order> orders = new List<Order>();
            book.ForEach(o =>
            {
                if (o.expired())
                    this.book.Remove(o);
                if (!o.expired()&& o.Product.Equals(p) && o.Status == Status.HERE)
                    orders.Add(o);
            });
                
                return orders;
        }
        public bool isAvaliable(Product p)
        {
            return getAvaliable(p) > 0;
        }
        public Order getOrderHere(Product product)
        {
            return book.Where(o => o.Product == product && o.Status==Status.HERE).FirstOrDefault();
        }
        public List<Order> allOrders(Product p)
        {
            return book.Where(o => o.Product.Equals(p)).ToList();
        }

        public List<Order> expiredOrders(Product p)
        {
            return book.Where(o => o.expired() && o.Product.Equals(p)).ToList();
        }

        public int getAvaliable(Product p)
        {
            return avaliableOrders(p).Select(o => o.avaliableCount()).Sum();
        } 

        public bool sellOneProduct(Product p)
        {
            foreach( Order o in avaliableOrders(p))
            {
                if(o.sellOne())
                {
                        if (o.Quantity == o.Sold)
                            book.Remove(o);
                    return true;
                }
            }
            return false;
        }

        public bool sellManyProducts(Product p, int q)
        {
            foreach (Order o in avaliableOrders(p))
            {
                if (o.sellMany(q))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isInTrouble(Product p)
        {
            int avaliable = getAvaliable(p);
            return avaliable < 20 || avaliableOrders(p).Where(o => o.willExpire()).Select(o=> o.avaliableCount()).Sum() / avaliable >= 0.5 ;
        }

        public List<Product> areInTrouble()
        {
            return products.Where(p => isInTrouble(p)).ToList();
        }

        public void printProductsHere()
        {
            foreach (Product p in products)
            {
                
                Console.WriteLine("Product " + p.Name + " x" + getAvaliable(p));
            }
        }
        public void printProducts(List<Product> products)
        {
            products.ForEach(p =>
            {
                if(this.isInTrouble(p))
                Console.WriteLine(p.ToString());

            }

            );
        }
        public void printProductThatAreInTrouble()
        {
            List<Product> products = areInTrouble();
            foreach(Product p in products)
            {
                Console.WriteLine(p.ToString());
                if(hasOrder(p))
                {
                    Console.WriteLine("Though We Have An Order For This Product"+ "\n");
                }
            }

        }
        public bool hasOrder(Product product1)
        {
            List<Order> orders = book;
            foreach(Order order in orders)
            {
                if (order.Status == Status.PROCESSING)
                    if (order.Product == product1)
                        return true;
            }
            return false;
        }
        public bool productExists(String name)
        {
            return products.Contains(new Product(0, name));
        }
        public Product findProductName(string name)
        {
             return products.Where(p => p.Name.Equals(name)).FirstOrDefault();
        }
        public void printOrdersId()
        {
            foreach (Product p in products) 
            {
                
                allOrders(p).ForEach(o =>
                {
                    if(o.Status==Status.HERE)
                    {
                        Console.WriteLine(p.Name + " x" + o.Quantity + " => Order: " + o.Id + " - " + o.Status.ToString());
                    }
                });
            };
        }
        public void printAllOrdersByStatus()
        {
            List<Order> ordersProcessing = new List<Order>();
            foreach(Order o in book)
            {
                if(o.Status==Status.HERE)
                    Console.WriteLine(o.Product.Name + " x" + o.Quantity + " => Order: " + o.Id + " - " + "In The Store");
                if (o.Status == Status.PROCESSING)
                    ordersProcessing.Add(o);
            }
            foreach (Order o in ordersProcessing)
            {
                    Console.WriteLine(o.Product.Name + " x" + o.Quantity + " => Order: " + o.Id + " - " + "In Shipping");
            }
        }
    }
}
