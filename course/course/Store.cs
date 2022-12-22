using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class Store
    {
        private List<CashRegister> registers;
        private List<Worker> allWorkers;
        private List<Costumer> costumers;

        public List<Worker> AllWorkers { get => allWorkers; set => allWorkers = value; }
        public List<Costumer> Costumers { get => costumers; set => costumers = value; }

        public bool addWorker(Worker worker)
        {
            int length = allWorkers.Count();
            allWorkers.Add(worker);
            return (allWorkers.Count() > length);
        }
        public bool existRegister(string index)
        {
            foreach(CashRegister r in registers)
            {
                if (r.Index.Equals(index))
                    return true;

            }
            return false;

        }
        public Store(List<CashRegister> registers, List<Worker> allWorkers)
        {
            this.registers = registers;
            this.allWorkers = allWorkers;
            this.costumers = new List<Costumer>();
        }
        public Store(List<CashRegister> registers)
        {
            this.registers = registers;
            this.allWorkers = new List<Worker>();
            this.costumers = new List<Costumer>();
        }
        public void addCostumer(Costumer costumer)
        {
            costumers.Add(costumer);
        }
        public List<Costumer> getAllIsolatedClients()
        {
            return registers.Select(r => r.getIsolatedClients()).SelectMany(c => c).ToHashSet().ToList();
        }
        public List<Worker> getAllIsolatedWorkers()
        {
            return registers.Select(r => r.getIsolatedWorkers()).SelectMany(c => c).ToHashSet().ToList();
        }
        public Worker findWorkerByID(string id)
        {
            return (Worker)allWorkers.Where(w => w.Id.Equals(id));
        }
        public Costumer findCostumerByID(string id)
        {
            return (Costumer)allWorkers.Where(c => c.Id.Equals(id));
        }

        public CashRegister findCashRegistersByID(string id)
        {
            return (CashRegister)registers.Where(r => r.Index.Equals(id));
        }
        public void printIsolatedClients()
        {
            this.getAllIsolatedClients().ForEach(c =>
            {
                Console.WriteLine(c.ToString() + "\n");
            });
        }

        public void printIsolatedWorkers()
        {
            this.getAllIsolatedWorkers().ForEach(w =>
            {
                Console.WriteLine(w.ToString() + "\n");
            });
        }
        public void update()
        {
            registers.ForEach(r => registers[registers.IndexOf(r)].Active = true);
            registers.Where(r => !r.Shifts.Last().Worker.canwork()).ToList().ForEach(r => registers[registers.IndexOf(r)].Active = false);
        }

        public CashRegister fastest()
        {
            return registers[registers.IndexOf(registers.Where(r => r.Active &&r.Shifts.Last().CostumersLine.Count() == registers.Select(x => x.Shifts.Last().CostumersLine.Count).Min()).First())];
        }
        public void addClientToTheFastestCash(Costumer costumer)
        {
            List<WorkShift> shifts = fastest().Shifts;
            shifts.Last().addCustomer(costumer);
        }
        public void printallShiftsOfWorkers()
        {
            Console.WriteLine("Theses are all the shifts of all the workers of every cash register: " + "\n");
            registers.ForEach(r =>
            {
                Console.WriteLine("This are all the shifts of all the worker on cash register number " + r.Index + "\n");
                r.printShiftsOfWorkers();
            }
            );
        }
        public void printallClients()
        {
            Console.WriteLine("Theses are all the costumers of all the cash registers: " + "\n");
            registers.ForEach(r =>
            {
                Console.WriteLine("These are all the costumers of register number " + r.Index + "\n");
                r.printAllClients();

            }
            
            );
        }
        public void changeCostumerToSick(string id)
        {
            registers.ForEach(r => r.Shifts.ForEach(s =>s.Costumers.ForEach(c=> 
             {
                 if (c.Id.Equals(id))
                 {
                     c.Sick = true;
                     return;
                 }
             }
            )));
        }
        public void printallProducts()
        {
            Console.WriteLine("These are all the products bought from all the cash registers: " + "\n");
            registers.ForEach(r =>
            {
                Console.WriteLine("Thess are all the products of register number " + r.Index + "\n");
                r.printAllClients();
            });
        }
    }
}
