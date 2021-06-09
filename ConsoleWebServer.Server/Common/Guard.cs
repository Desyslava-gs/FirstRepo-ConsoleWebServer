using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWebServer.Server.Common
{
   public static class Guard
   {
       public static void AgainstNull(object value, string name = null)
       {
           if (value==null)
           {
               name ??= "Value"; //ako name nqma stoinost vzemi tazi
               throw new ArgumentException($"{name} cannot be null!");
           }
       }
   }
}
