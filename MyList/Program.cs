using System.Threading;

namespace MyList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        }
    }
}
