using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

            
        }
    }
}
