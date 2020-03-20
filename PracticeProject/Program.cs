using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeProject
{
    class Program
    {
        static void Main(string[] args)
        {

            
            //List<QuestionAndAnswers> qas = new List<QuestionAndAnswers>();

            QuestionAndAnswers qaDict = new QuestionAndAnswers()
            {
                QuestionandAnswer = new Dictionary<string, string>() { { "Hi", "Hi Saitej how are you" }, { "What is your name", "My name is chatbot" } }

            };


        


            Category obj = new Category()
            {
                CategoryID = 1,
                CategoryName = "Policies",
                QA = qaDict

            };

            var jsonString = JsonConvert.SerializeObject(obj);

            


            var apple = new Product { Name = "Apple" };
            var orange = new Product { Name = "Orange" };
            var bread = new Product { Name = "Bread" };
            var customers = new[] {
            new Customer { Name = "Alexey", Orders = new[] { new Order { Product = apple, Quantity = 10 },
                                                             new Order { Product = orange, Quantity = 5 } }.ToList() },
            new Customer { Name = "Andrey", Orders = new[] { new Order { Product = bread, Quantity = 5 },
                                                             new Order { Product = orange, Quantity = 2 } }.ToList() },
            new Customer { Name = "Alexandr", Orders = new[] { new Order { Product = apple, Quantity = 10 } }.ToList() }
            }.ToList();



            //var query = (from cust in customers
            //             let products = from product in cust.Orders select product.Product

            //             select new
            //             {
            //                 name = cust.Name,

            //                 productsNames = products.Select(s=>s.Name)
            //             }).ToList();

            //Console.WriteLine(query);



            List<Employee> employees = new List<Employee>(){
            new Employee(){Skills = new Dictionary<string,int>(){ { "c#", 2}, {"SQL", 4}, {"java", 5}} ,Name="test1"},
            new Employee(){Skills = new Dictionary<string,int>(){ { "SQL",1}, {"java", 2}},Name="test2" },
            new Employee(){Skills = new Dictionary<string,int>(){ { "c#", 5}, {"SQL", 1}, {"java", 2}},Name="test3" },
            new Employee(){Skills = new Dictionary<string,int>(){ { "c#", 3}, {"SQL", 3}},Name="test4" },
            new Employee(){Skills = new Dictionary<string,int>(){ { "c#", 5}, {"SQL", 4}},Name="test5" },

        };

           


            var QueryTwo = (from x in employees


                            where x.Skills.Keys.Contains("java")
                            where x.Skills.Values.Contains(2)
                            select x).ToList();


            var test = employees.Where(s => (s.Skills.Keys.Contains("java")) && (s.Skills.Values.Contains(2))).Select(s => new
            {
                skills = s.Skills
            }).ToList();




            string nameValue = string.Empty;
            var result = employees
                .Select(s => 

                   new { sk = s.Skills, name = s.Name }
                
                )
                .SelectMany(sm => sm.sk)
              

                .Where(w => (w.Key == "java") && (w.Value == 2)).ToList().Select(sf=>new { 
                
                name=nameValue,
                skill=sf.Key
                }).ToList();








            // let skill = x.Skills.Keys.Contains("java")
            //let years = x.Skills.Values.Contains(2)

            Console.WriteLine(QueryTwo);

            Console.ReadKey();
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public Dictionary<string, int> Skills
        { get; set; }
    }
    public class Customer
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
    public class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
    public class Product
    {
        public string Name { get; set; }
    }
}
