using System.Collections.Generic;

namespace GreibachNormalFormConverter
{
    public class Grammar
    {
        public List<string> Variables { get; set; }
        public List<string> Terminals { get; set; }
        public Production Production { get; set; }
        public List<string> Startvariable { get; set; }

        public Grammar(List<string> variables, List<string> terminals, Production production, List<string> startvariable)
        {
            Variables = variables;
            Terminals = terminals;
            Production = production;
            Startvariable = startvariable;
        }
    }
}
