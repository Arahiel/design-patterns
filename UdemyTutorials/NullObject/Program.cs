using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var acc = new Account(new NullLog());

            acc.SomeOperation();

            ReadKey();
        }


    }
}
