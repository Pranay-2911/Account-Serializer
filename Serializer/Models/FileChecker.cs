using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Serializer.Models
{
    internal class FileChecker
    {

        
        public static bool ToCheckFile( ref Account[] account)
        {
            var filePath = ConfigurationManager.AppSettings["MyPath"].ToString();

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                account = JsonSerializer.Deserialize<Account[]>(jsonData);
                return true;
            }
            return false;
        }

        public static bool ToSerialize(Account[] account, int exit)
        {
            var filePath = ConfigurationManager.AppSettings["MyPath"].ToString();
            if (exit == 0)
            {

                string jsonData = JsonSerializer.Serialize(account);
                File.WriteAllText(filePath, jsonData);
               
                return false;
            }


            return true;
        }


        
    }
}
