using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class test : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }


    public class test2
    {

        public void m1()
        {

            using (test obj=new test())
            {
                
            };
        }
    }
}
