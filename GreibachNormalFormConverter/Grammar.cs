using System.Collections.Generic;

namespace GreibachNormalFormConverter
{
    public class Grammar
    {
        public List<string> Vocabulary { get; set; }
        public List<string> Terminals { get; set; }
        public Production Production { get; set; }
        public List<string> Startvariable { get; set; }

        public Grammar(List<string> vocabulary, List<string> terminals, Production production, List<string> startvariable)
        {
            Vocabulary = vocabulary;
            Terminals = terminals;
            Production = production;
            Startvariable = startvariable;
        }
    }
}
