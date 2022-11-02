using System;
using System.Collections.Generic;

namespace GreibachNormalFormConverter
{
    public class Production
    {
        public List<Tuple<string, string>> Derivations { get; set; }

        public Production(List<string> derivations)
        {
            foreach (var item in derivations)
            {
                var splitItem = item.Split(new string[] { "->" }, StringSplitOptions.None);
                var tuple = new Tuple<string, string>(splitItem[0], splitItem[1]);
                Derivations.Add(tuple);
            }
        }
    }
}
