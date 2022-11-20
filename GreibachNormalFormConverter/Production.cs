﻿using System;
using System.Collections.Generic;

namespace GreibachNormalFormConverter
{
    public class Production
    {
        public List<Tuple<string, string>> Derivations { get; set; }

        public Production(List<Tuple<string, string>> derivations)
        {
            var derivationList = new List<Tuple<string, string>>();

            foreach (var item in derivations)
            {
                derivationList.Add(item);
            }

            this.Derivations = derivationList;
        }
    }
}
