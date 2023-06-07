using Algorithms.Codewars.API.DataManager.Interfaces;

namespace Algorithms.Codewars.API.DataManager
{
    public class NoviceLevel : INoviceLevel
    {
        public bool IsValidIP(string ipAddres)
        {
            /* Examples of valid inputs: 4 octet, [0,255]
                1.2.3.4
                123.45.67.89
             */

            if (string.IsNullOrEmpty(ipAddres)) return false;

            var octets = ipAddres.Split('.');

            if (octets.Contains("")) return false;// not equals to null string -> For EX: "." -> split -> "","" | "123.342.23." -> "123","342","23",""

            var isValidCharacters = octets.SelectMany(x => x.Select(y => y)).All(char.IsDigit);// is all digit and 

            if (!isValidCharacters || octets.Length != 4) return false;

            // value range -> [0,255] and not contains EX: 078, 00, 000 ...
            var isValidRange = !octets.Select(x => x).Any(x => Convert.ToInt32(x) > 255 || Convert.ToInt32(x) < 0 
                                                            || (x.Length > 1 && x.StartsWith("0")));
            
            if (!isValidRange) return false;

            return true;
        }
    }
}
