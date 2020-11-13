using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Customer.Controllers;

namespace Customer.Model
{
    public static class CustomerRepository
    {
        private static readonly Dictionary<int, Customer> s_Customers = new Dictionary<int, Model.Customer>();
        //private static readonly Dictionary<int, List<Move>> s_Moves = new Dictionary<int, List<Move>>();
        static CustomerRepository()
        {
            s_Customers.Add(1, new Customer
            {
                Id = 1,
                Name = "Andrew Perez",
                Street = "Annamark",
                City = "Zhendong",
                ZipCode = null,
                Country = "CN",
            });
            s_Customers.Add(2, new Customer
            {
                Id = 2,
                Name = "Donald Davis",
                Street = "Kingsford",
                City = "Garland",
                ZipCode = "75044",
                Country = "US"
            });
            s_Customers.Add(3, new Customer
            {
                Id = 3,
                Name = "Chelsea Elizabeth Manning",
                Street = "Elrod Avenue",
                City = "Quantico",
                ZipCode = "VA22134",
                Country = "USA",
                ImageFile = "Manning.jpg"
            });
            s_Customers.Add(4, new Customer
            {
                Id = 4,
                Name = "Billy Alvarez",
                Street = "Ronald Regan",
                City = "Harderwijk",
                ZipCode = "3844",
                Country = "NL",
            });

        }
        public static List<Customer> GetAll()
        {
            lock (s_Customers)
            {
                return new List<Customer>(s_Customers.Values);
            }
        }
        public static List<Customer> GetAllFavorites()
        {
            lock (s_Customers)
            {
                return s_Customers.Values.Where(c => c.IsFavorite).ToList();
            }
        }
        public static Customer Get(int id)
        {
            lock (s_Customers)
            {
                return s_Customers[id];
            }
        }
        public static bool TryGet(int id, out Customer customer)
        {
            lock (s_Customers)
            {
                if (s_Customers.ContainsKey(id))
                {
                    customer = Get(id);
                    return true;
                }
            }
            customer = null;
            return false;
        }
        public static int Add(Customer customer)
        {
            lock (s_Customers)
            {
                customer.Id = s_Customers.Count + 1;
                s_Customers.Add(customer.Id, customer);
                return customer.Id;
            }
        }
        public static void Update(Customer customer)
        {
            lock (s_Customers)
            {
                s_Customers[customer.Id] = customer;
            }
        }
        public static void Delete(int id)
        {
            lock (s_Customers)
            {
                s_Customers.Remove(id);
            }
        }
       //public static List<Move> GetAllMoves(int customerId)
       //{
       //    lock (s_Moves)
       //    {
       //        if (s_Moves.TryGetValue(customerId, out List<Move> moves))
       //        {
       //            return moves;
       //        }
       //
       //        return new List<Move>();
       //    }
       //}
       //
       //public static int AddMove(in int customerId, Move move)
       //{
       //    lock (s_Moves)
       //    {
       //        move.Id = s_Moves.Count + 1;
       //        List<Move> moves;
       //        if (!s_Moves.TryGetValue(customerId, out moves))
       //        {
       //            moves = new List<Move>();
       //            s_Moves.Add(customerId, moves);
       //        }
       //        moves.Add(move);
       //        return customerId;
       //    }
       //}
    }
}