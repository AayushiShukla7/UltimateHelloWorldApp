using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldLibrary.Models
{
    public class CustomText
    {
        // C# naming standard - Pascal Case 
        // JSON naming standard - Camel Case
        public string Language { get; set; }
        public Dictionary<string,string> Translation { get; set; }
    }
}
