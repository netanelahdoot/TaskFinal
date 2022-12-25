using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class Program
    {
        static Line line;
        static OrderBook book;
        static Store store;
        static void Main(string[] args)
        {

            List<CashRegister> registers = new List<CashRegister>()
            {
                new CashRegister("1"),new CashRegister("2"), new CashRegister("3")
            };
            store = new Store(registers);
            //store= new Store(c)\



            line = new Line();
            book = OrderBook.getInstance();
           
            
/*
 *  Order order = new Order();
            Product coke = new Product(2.5, "Coca Cola");
            Product pepsi = new Product(2, "Pepsi");
            Product icecream = new Product(10, "ice cream");
            Product chips = new Product(5, "chips");
            Product beef = new Product(50, "beef");
            Product chicken = new Product(25, "chicken");

            Costumer Netanel = new Costumer("214294944", "Netanel");
            Netanel.addProduct(coke);
            Netanel.addProduct(chips);
            Netanel.addProduct(icecream);
            Netanel.addProduct(chicken);

            Costumer ori = new Costumer("020384759", "ori");
            ori.addProduct(coke);
            ori.addProduct(chips);

            Costumer habibi = new Costumer("553453659", "habibi");
            habibi.addProduct(pepsi);

            Costumer nayef = new Costumer("999999999", "nayef", false);
            nayef.addProduct(beef);
            nayef.addProduct(chicken);

            Costumer messi = new Costumer("123535699", "messi", false);
            messi.addProduct(beef);
            messi.addProduct(icecream);
            messi.addProduct(chicken);

            Costumer ronaldo = new Costumer("467535799", "ronaldo", false);
            ronaldo.addProduct(pepsi);

            Costumer christiano = new Costumer("988899999", "christiano");
            christiano.addProduct(coke);

            Worker daniel = new Worker("Daniel", "989898999", false, false);
            Worker mohamed = new Worker("Mohamed", "138964596", false, false);

            List<Costumer> Line1 = new List<Costumer>();
            Line1.Add(ori);
            Line1.Add(habibi);
            List<Costumer> Line2 = new List<Costumer>();
            Line2.Add(nayef);
            Line2.Add(ori);
            Line2.Add(Netanel);
            List<Costumer> Line3 = new List<Costumer>();
            Line3.Add(habibi);
            Line3.Add(messi);
            List<Costumer> Line4 = new List<Costumer>();
            Line4.Add(ronaldo);
            Line4.Add(christiano);
            WorkShift shiftD2 = new WorkShift(new DateTime(2022, 12, 17, 8, 0, 0), new DateTime(2022, 12, 17, 16, 0, 0), daniel, Line1, "1");
            WorkShift shiftM2 = new WorkShift(new DateTime(2022, 12, 17, 8, 0, 0), new DateTime(2022, 12, 17, 16, 0, 0), mohamed, Line3, "2");
            
            WorkShift shiftD1 = new WorkShift(new DateTime(2022, 12, 13, 8, 0, 0), new DateTime(2022, 12, 13, 22, 0, 0), daniel, Line4, "1");
            WorkShift shiftM1 = new WorkShift(new DateTime(2022, 12, 14, 8, 0, 0), new DateTime(2022, 12, 14, 22, 0, 0), mohamed, Line2, "2");
            List<WorkShift> workShifts1 = new List<WorkShift>();
            workShifts1.Add(shiftD1);
            workShifts1.Add(shiftD2);
            List<WorkShift> workShifts2 = new List<WorkShift>();
            workShifts2.Add(shiftM1);
            workShifts2.Add(shiftM2);
            CashRegister cashRegister = new CashRegister("1", workShifts1);
            CashRegister cashRegister2 = new CashRegister("2", workShifts2);
            List<CashRegister> registers2 = new List<CashRegister>();
            registers2.Add(cashRegister);
            registers2.Add(cashRegister2);
            List<Worker> workers = new List<Worker>();
            workers.Add(daniel);
            workers.Add(mohamed);
            store = new Store(registers2,workers);

            */
            Mainloop();
            //Test.TestMain();
        }
        static void Mainloop()
        {
            showHelp();
            int x = 0;
            while(x != 9 && (x = int.Parse(Console.ReadLine()))!= 9)
            {
                x = parseX(x);
                if(x ==8)
                {
                    showHelp();
                }
            }
            Console.Clear();
        }
        static int parseX(int x)
        {
                switch (x)
                {
                    case 1: { x = manageCustomers(x); } break;
                    case 2: { x = manageCashRegisters(x); } break;
                    case 3: { x = manageWorkers(x); } break;
                    //case 4: { x = manageCorona(x); } break;
                    case 4: { x = manageProducts(x);  } break;
                    case 5: { x = addProducts(x);  } break;

                    case 8: {
                        showHelp();
                        } break;
                    default: break;
                }
            return x;
        }
        static void showHelp()
        {
            Console.Clear();
            Console.WriteLine("Press 1 For Customer Management");
            Console.WriteLine("Press 2 For Cash Register Management");
            Console.WriteLine("Press 3 For Worker Management (First Thing To Do For Starting A WorkingShift)");
            //Console.WriteLine("Press 4 For Corona Insights");
            Console.WriteLine("Press 4 For Product/Order Management");
            Console.WriteLine("For Costumer: Press 5 To Add Products And Enter A Line Of A Cash Register");
            Console.WriteLine("Press 8 For going back to the main menu");
            Console.WriteLine("Press 9 To Exit the program");
        }
        static int manageCustomers(int x)
        {
            
            
            Console.Clear();
            Console.WriteLine("Press 1 To Add A New Customer");
            Console.WriteLine("Press 2 To Add x Customers To The Store");
            Console.WriteLine("Press 3 To Show The Line");
            Console.WriteLine("Press 4 to Remove A Person From The Line");
            Console.WriteLine("Press 8 To Return To The Main Menu ");

            while ((x = int.Parse(Console.ReadLine())) != 8 && x != 9) {
                Console.Clear();
                if (x == 1)
                {
                    Console.WriteLine("if the costumer isn't supposed to be isolated please press 1 else press 0");
                    int result = int.Parse(Console.ReadLine());
                    Console.Clear();
                    if (result == 0)
                    {
                        Console.WriteLine("sorry but he cannot join the line, please press enter");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("what's his temperature");
                        result = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (result > 38)
                        {
                            Console.WriteLine("sorry but he cannot join the line, please press enter");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("does he have mask on him, if yes press 1 if no press 0");
                            result = int.Parse(Console.ReadLine());
                            Console.Clear();
                            if (result == 0)
                            {
                                Console.WriteLine("sorry but he cannot join the line, please press enter");
                                Console.ReadLine();
                            }
                            else
                            {

                                Console.WriteLine("please enter the costumer's First Name and then press enter");
                                string firstName = Console.ReadLine();
                                Console.WriteLine("please enter the costumer's Last Name and then press enter");
                                string lastName = Console.ReadLine();
                                Console.WriteLine("please enter the costumer's ID and then press enter");
                                string id = Console.ReadLine();
                                Console.WriteLine("do you want him to be sick if yes press 1 else press 0");
                                int sick = int.Parse(Console.ReadLine());
                                if (sick == 1)
                                    line.Add(new Costumer(id, firstName + " " + lastName, true));
                                else
                                    line.Add(new Costumer(id, firstName + " " + lastName, false));


                                Console.WriteLine("costumer has been added to the line");
                            }
                        }

                    }
                }
                if (x == 2)
                {
                    Console.Clear();
                    Console.WriteLine("how many costumer do you want to add to the store");
                    int numberofCostumers = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Queue<Costumer> costumers = line.CostumersLine;
                    for (int i = 0; i < numberofCostumers; i++)
                    {
                        costumers.Peek().Inside = true;
                        store.addCostumer(costumers.Dequeue());
                        
                    }
                }
                if (x == 3)
                {
                    if (line.CostumersLine.Count == 0)
                        Console.WriteLine("there are no costumers");
                    else
                    {
                        Console.WriteLine(line);

                    }
                }
                if (x == 4)
                {
                    if (line.CostumersLine.Count == 0)
                        Console.WriteLine("There Are No Costumers");
                    else
                    {
                        Console.WriteLine("Please Enter the Id Of The Person You Want To Remove");
                        string id = Console.ReadLine();
                        bool success = line.RemoveCostumer(id);
                        if (success)
                            Console.WriteLine("Costumer Has Been Removed Succesfully");
                        else
                            Console.WriteLine("There Is No Costumer With This Id");
                    }
                    
                }
                    Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Press 1 To Add A new Costumer");
                Console.WriteLine("press 2 to add costumers to the store");
                Console.WriteLine("press 3 to show the line");
                Console.WriteLine("press 8 to return to the main menu ");
            
            }
            return x;
        }

        static int manageWorkers(int x)
        {
            Console.Clear();
            Console.WriteLine("For Manager: Please Press 1 To Add A New Worker");
            Console.WriteLine("For Manager: Please Press 2 To Check The Worker If He Can Work So He Can Start Working");
            Console.WriteLine("For Worker: Press 3 To End Your Working Shift");
            Console.WriteLine("Press 8 To Return To The Main Menu");

            while((x = int.Parse(Console.ReadLine())) != 8 && x != 9)
            {
                Console.Clear();
                if (x == 1)
                {
                    Console.WriteLine("Please Enter His Id" + "\n");
                    string id = Console.ReadLine();
                    Console.WriteLine("Please Enter His Name" + "\n");
                    string name = Console.ReadLine();
                    Console.WriteLine("If He Is Sick Please Press 1, Else Please Press 0" + "\n");
                    bool sick = false;
                    if (Console.ReadLine().Equals("1"))
                        sick = true;
                    Console.WriteLine("If He Is Isolated Please Press 1, Else Please Press 0" + "\n");
                    bool isolated = false;
                    if (Console.ReadLine().Equals("1"))
                        isolated = true;

                    bool success = store.addWorker(new Worker(name, id, sick, isolated));
                    if (success)
                        Console.WriteLine("The Worker Has Been Successfully Added To Your Workers Crew");
                    else
                        Console.Write("Costumer Has not Been Added");



                }
                if (x == 2)
                {
                    Console.WriteLine("Please Enter The Worker's Id");
                    string id = Console.ReadLine();
                    Worker worker = store.findWorkerByID(id);
                    Console.WriteLine("If The Worker Doesn't Have A Mask, Please Press 1, Else Please Press 0");
                    if (Console.ReadLine().Equals("1"))
                    {
                        worker.Mask = false;
                        worker.makeFine();

                    }
                    else
                    {
                        worker.Mask = true;
                        Console.WriteLine("If The Worker Is Supposed To Be Isolated, Please Press 1, Else Please Press 0");
                        if (Console.ReadLine().Equals("1"))
                        {
                            worker.Isolated = true;
                            worker.makeFine();
                        }
                        else
                        {

                            Console.WriteLine("Please Enter the Worker's Temperature");
                            if ((worker.Tempereaure = int.Parse(Console.ReadLine())) > 38)
                            {
                                worker.makeFine();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Great, The Worker can start Working");
                                Console.WriteLine("Please Enter The Index Of The Cash Register The Worker Will Be Working With");
                                string index = "";
                                if (!store.existRegister(index = Console.ReadLine()))
                                    Console.WriteLine("Sorry, But we Don't Have A Register With This Index");
                                else
                                {
                                    WorkShift workShift = new WorkShift(DateTime.Now, worker, index);
                                    CashRegister cash = store.findCashRegistersByID(index);
                                    cash.addShift(workShift);
                                }
                                

                            }

                        }

                    }
                }
                    if(x==3)
                    {
                        Console.Clear();
                        Console.WriteLine("Please Enter Your The Index Of The Cash Register You've Been Working With");
                        string id1 = Console.ReadLine();
                        CashRegister cashRegister1 = store.findCashRegistersByID(id1);
                        Console.WriteLine("Please Enter Your Id");
                        string id2 = Console.ReadLine();
                        Worker worker1 = store.findWorkerByID(id2);
                        WorkShift test = cashRegister1.Shifts.Last();
                        if (test.Worker.Id.Equals(id2))
                        {
                             test.End = DateTime.Now;
                             if (!(worker1.Isolated || worker1.Tempereaure > 38 || !worker1.Mask))
                                worker1.payFine(test.findHours());
                        }
                            
                        
                    }
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("For Manager: Please Press 1 To Add A New Worker");
                    Console.WriteLine("For Manager: Please Press 2 To Check The Worker If He Can Work");
                    Console.WriteLine("For Worker: Press 3 To End Your Working Shift");
                    Console.WriteLine("Press 8 To Return To The Main Menu");


                
            }
            
            

            
            return x;
        }
        static int manageProducts(int x)
        {
            Console.Clear();

            Console.WriteLine("press 1 To Order A Product");
            Console.WriteLine("press 2 To List All Products");
            Console.WriteLine("press 3 To List All Orders Id");
            Console.WriteLine("press 4 To Track A Product Order");

            Console.WriteLine("press 5 To Confirm That The Supply Has Arrived To The Store");

            Console.WriteLine("press 6 to list all Orders By Status");

            Console.WriteLine("press 7 to Get An Alert Of What Product You Need To Buy");
            Console.WriteLine("press 8 to return to the main menu ");

            while ((x = int.Parse(Console.ReadLine())) != 8 && x != 9)
            {
                switch(x)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Product Name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Quantity:");
                            int q = int.Parse(Console.ReadLine());
                            if (book.productExists(name))
                            {
                                book.orderProduct(name, q);
                                Console.WriteLine("Order Created Sucessfuly");
                            }
                            else
                            {
                                Console.WriteLine("Price:");
                                double price = double.Parse(Console.ReadLine());
                                book.orderProduct(new Product(price, name), q);
                                Console.WriteLine("Order and Product Created Sucessfuly");
                            }
                            Console.WriteLine("The Number Of This Order Is: " + book.Book.Last().Id);
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        {
                            Console.Clear();
                            book.printProductsHere();
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            book.printOrdersId();
                            Console.WriteLine("<Press Enter to Continue>");
                            Console.ReadLine();
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Order ID :");
                            String id = Console.ReadLine();
                            Order o = book.getOrder(id);
                            if (!id.StartsWith("#")){
                                o = book.getOrder("#" + id);
                            }
                            if (o == null)
                            {
                                Console.WriteLine("Order doesn't exist!");
                            }
                            else {
                                Console.WriteLine(o.ToString());
                            }
                            Console.WriteLine("<Press Enter to Continue>");
                            Console.ReadLine();
                        }
                        break;
                    case 5:
                        {
                            
                            Console.Clear();
                            Console.WriteLine("Please Enter The Id Of The Order And To Stop Please Press 0");
                            string id = "";
                            while (!(id = Console.ReadLine()).Equals("0"))
                            {
                                Order o = book.getOrder(id);
                                if (!id.StartsWith("#"))
                                {
                                    o = book.getOrder("#" + id);
                                }
                                if (o == null)
                                {
                                    Console.WriteLine("Order doesn't exist!");
                                }
                                else
                                {
                                    if(book.productExists(o.Product.Name)&&o.Status==Status.PROCESSING)
                                    {
                                        o.Status = Status.HERE;
                                    Console.WriteLine("Order Found:" + "\n");
                                    Console.WriteLine(o.ToString());
                                    }
                                        

                                }
                                Console.WriteLine("Enter The Id Of The Order And To Stop Please Press 0");
                            }
                               
                        }
                        break;
                    case 6:
                        {
                            Console.Clear();
                            book.printAllOrdersByStatus();
                            Console.WriteLine("<Press Enter to Continue>");
                            Console.ReadLine();
                        }
                        break;
                    case 7:
                        {
                            Console.Clear();
                            book.printProductThatAreInTrouble();
                            Console.WriteLine("<Press Enter to Continue>");
                            Console.ReadLine();
                            //book.printProducts(book.areInTrouble());
                        }
                        break;
                }
                Console.Clear();
                Console.WriteLine("press 1 To Order A Product");
                Console.WriteLine("press 2 To List All Products");
                Console.WriteLine("press 3 To List All Orders Id");
                Console.WriteLine("press 4 To Track A Product Order");

                Console.WriteLine("press 5 To Confirm That The Supply Has Arrived To The Store");

                Console.WriteLine("press 6 to list all Orders By Status");
                Console.WriteLine("press 8 to return to the main menu ");

                
            }
            return x;
        }
        static void ManageOneCashRegister(string index)
        {
            Console.Clear();
            Console.WriteLine("Press 1 To Perform A Buy From A Costumer");
            Console.WriteLine("Press 2 To See All The Costumer And All The Product From The Cash Registers");
            Console.WriteLine("Press 3 To See All The Working Shifts Of The Cash Register");
            Console.WriteLine("Press 7 To Return");
            CashRegister cash = store.findCashRegistersByID(index);
            WorkShift shift = cash.Shifts.Last();
            int x;
            while ((x = int.Parse(Console.ReadLine())) != 7)
            {
                switch(x)
                {
                    case 1:
                        {

                            shift.Costumers.Add(shift.CostumersLine.Dequeue());
                        }
                        break;
                    case 2:
                        {
                            cash.printAllClients();
                            cash.printAllProducts();
                        }
                        break;
                    case 3:
                        {
                            cash.printShiftsOfWorkers();
                        }
                        break;
                    default: break;


                }
                Console.WriteLine("Please Press Enter");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Press 1 To Perform A Buy From A Costumer");
                Console.WriteLine("Press 2 To See All The Costumer And All The Product From The Cash Registers");
                Console.WriteLine("Press 3 To See All The Working Shifts Of The Cash Register");
                Console.WriteLine("Press 7 To Return");
            }

        }
        static void indexOfCashRegister()
        {
            Console.Clear();
            Console.WriteLine("Please Enter The Index Of The Cash Register");
            string index = Console.ReadLine();
            ManageOneCashRegister(index);
        }
        static int manageCashRegisters(int x)
        {
            Console.Clear();
            Console.WriteLine("Press 1 To See All The Costumer And All The Product From All The Cash Registers");
            Console.WriteLine("Press 2 Is To See All The Working Shifts All The Cash Registers");
            Console.WriteLine("Press 3 to report a sick costumer");
            Console.WriteLine("Press 4 to see all the isolated costumers and workers");
            Console.WriteLine("Press 5 To Manage One Cash Register (To see Costumers, Products, Perform a buy etc)");
            Console.WriteLine("press 8 to return to the main menu ");

            while ((x = int.Parse(Console.ReadLine())) != 8 && x != 9)
            {
                Console.Clear();
                switch(x)
                {
                    case 1:
                        {
                            
                            store.printallClients();
                            
                            store.printallProducts();
                        }
                        break;
                    case 2:
                        {
                            store.printallShiftsOfWorkers();
                        }
                        break;
                    case 3:
                        {
                            costumertoSick();
                        }
                        break;
                    case 4:
                        {

                            Console.WriteLine("these are all the isolated workers:" + "\n");
                            store.printIsolatedWorkers();
                            Console.WriteLine("these are all the isolated costumers:" + "\n");
                            store.printIsolatedClients();
                            
                        }
                        break;
                    case 5:
                        {
                            indexOfCashRegister();
                        }
                        break;
                    default:
                        {

                        }
                        break;

                }
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Press 1 To See All The Costumer And All The Product From All The Cash Registers");
                Console.WriteLine("Press 2 Is To See All The Working Shifts All The Cash Registers Live");
                Console.WriteLine("Press 3 to report a sick costumer");
                Console.WriteLine("Press 4 to see all the isolated costumers and workers");
                Console.WriteLine("Press 5 To Manage One Cash Register (To see Costumers, Products, Perform a buy etc)");
                Console.WriteLine("press 8 to return to the main menu ");


            }
                return x;
        }
        static int addProducts(int x)
        {
            Console.Clear();
            string value = "";
            string id = "";
            Console.WriteLine("Please Enter Your Id");
            Costumer costumer = store.findCostumerByID(id=Console.ReadLine());


            Console.WriteLine("Please Enter All The Names Of The Products You Want To Buy, Please Press 1 To Buy"+ "\n");
            Console.WriteLine("These Are All The Products In The Store"+ "\n");
            book.printProductsHere();
            while (!((value = (Console.ReadLine())).Equals("1")) && !value.Equals("9"))
            {
                
                if (book.productExists(value) && book.sellOneProduct(book.findProductName(value)))
                {
                    costumer.addProduct(book.findProductName(value));
                    Console.WriteLine("Product Has Been Added To Your Cart Successfully");
                }
                else
                {
                    Console.WriteLine("Product Does Not Exist In The Store Or is Out of Inventory, Please Press Enter To Continue");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Please Enter Name Of The Product You Want To Buy, And At The End Please Press 1 To Stop Adding Products And Start Buying");
                }
            }
            Console.Clear();
            CashRegister cash = store.fastest();
            store.addClientToTheFastestCash(costumer);
            Console.WriteLine("Please Go to cash Register number " + cash.Index + "Press Enter To continue");
            Console.ReadLine();
            Console.Clear();

            return x;
           
        }
        static void costumertoSick()
        {
            Console.Clear();
            Console.WriteLine("Please Enter The Id Of The Sick Costumer, And Press 7 To Return");
            string id = "";
            while (!(id = Console.ReadLine()).Equals("7"))
            {
                if (id.Length != 9)
                    Console.WriteLine("sorry but the id is not valid please enter again");
                else
                    store.changeCostumerToSick(id);
            }
            
        }
        /*static int manageCorona(int x)
        {
            Console.Clear();

            while ((x = int.Parse(Console.ReadLine())) != 8 && x != 9)
            {
                Console.Clear();
            }
            return x;
        }*/
    }
}
