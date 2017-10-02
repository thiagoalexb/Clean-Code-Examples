using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    public class OutputParameters
    {
        #region Wrong
        public void DisplayCustomersWrong()
        {
            int totalCount = 0;
            var customers = GetCustomersWrong(1, out totalCount);

            Console.WriteLine("Total customers: " + totalCount);
            foreach (var c in customers)
                Console.WriteLine(c);
        }

        public IEnumerable<Customer> GetCustomersWrong(int pageIndex, out int totalCount)
        {
            totalCount = 100;
            return new List<Customer>();
        }
        #endregion

        #region Right
        public void DisplayCustomers()
        {
            var result = GetCustomers(pageIndex: 1);

            Console.WriteLine("Total customers: " + result.TotalCount);
            foreach (var c in result.Customers)
                Console.WriteLine(c);
        }

        public GetCustomersResult GetCustomers(int pageIndex)
        {
            return new GetCustomersResult() { Customers = new List<Customer>(), TotalCount = 100};
        }

        public class GetCustomersResult
        {
            public IEnumerable<Customer> Customers { get; set; }
            public int TotalCount { get; set; }      
        }
        #endregion
    }
}
