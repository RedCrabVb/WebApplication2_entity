using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2_entity.Service
{
    public interface IClass1Service {
        int Add5(int x);
    }

    public class Class1Service : IClass1Service
    {
        public Class1Service() {
        
        }

        public int Add5(int x)
        {
            return x + 5;
        }
    }
}