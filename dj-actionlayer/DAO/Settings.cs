using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.DAO
{
    public class Settings
    {
        public static string SecretKey()
        {
            return "npqhdyzryqtirqiqazozklrfxdogjbdy";
        }
        public static string DBConnect()
        {
            return "Data Source=localhost;Initial Catalog=dj_coding;Integrated Security=True;encrypt=true;trustservercertificate=true;MultipleActiveResultSets=True;";
        }
        public static string DBConnectHosting()
        {
            return "Server=localhost;Integrated Security=false;Initial Catalog=djxuyen1_coding;MultipleActiveResultSets=True;User ID= djxuyen1_djxuyen1;Password =Mamama99@";
        }
    }
}
