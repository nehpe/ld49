using System;
using Ccc.Game;

namespace Ccc
{
    class Program
    {
        static void Main(string[] args)
        {
          using (var g = new CccGame()) 
          {
            g.Run();
          }
        }
    }
}
