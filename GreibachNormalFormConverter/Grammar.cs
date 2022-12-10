using System;
using System.Collections.Generic;
using System.Linq;

namespace GreibachNormalFormConverter
{
    public class Grammar
    {
        public List<string> Variables { get; set; }
        public List<string> Terminals { get; set; }
        public Production Production { get; set; }
        public List<string> Startvariable { get; set; }
        public GNFConverter GNFConverter { get; set; }

        public Grammar(List<string> variables, List<string> terminals, Production production, List<string> startvariable, GNFConverter gNFConverter)
        {
            Variables = variables;
            Terminals = terminals;
            Production = production;
            Startvariable = startvariable;
            GNFConverter = gNFConverter;
        }



        /// <summary>
        /// Creates new Productions after the following rules:
        ///     1. Every rule A -> BC creates new rule B_X -> CA_X.
        ///     2. Every rule X -> BC also creates new rule B_X -> C.
        ///     3. Every rule A -> a creates new rule X -> aA_X.
        ///     4. Every rule X -> a is added to the new set of productions.
        /// </summary>
        /// <returns>A list of new Productions P_X.</returns>
        public List<Production> CreateNewProductions()
        {
            // Group existing rules after left side.
            ILookup<string, Tuple<string, string>> groupedRules = this.Production.Derivations.ToLookup(r => r.Item1);
            var newRuleList = new List<List<string>>();
            var newVariables = new List<string>();

            // Iterate through each grouping to create new rules for each variable.
            foreach (var grouping in groupedRules)
            {
                var key = grouping.Key.ToString();
                var newRules = new List<string>();

                // Create new rules from each existing rule.
                foreach (var rule in this.Production.Derivations)
                {
                    // Every rule A -> BC creates new rule B_X -> CA_X.
                    if (rule.Item2.Length == 2 && rule.Item2.All(x => this.Variables.Contains(x.ToString())))
                    {
                        var newLeftSide = rule.Item2.First() + "_" + key;
                        var newRightSide = rule.Item2.Last() + rule.Item1 + "_" + key;

                        if (!newVariables.Contains(newLeftSide))
                        {
                            newVariables.Add(newLeftSide);
                        }

                        if (!newVariables.Contains(newRightSide.Substring(1)))
                        {
                            newVariables.Add(newRightSide.Substring(1));
                        }

                        var newRule = newLeftSide + "->" + newRightSide;
                        newRules.Add(newRule);
                    }

                    // Every rule X -> BC also creates new rule B_X -> C.
                    if (rule.Item1 == key && rule.Item2.Length == 2 && rule.Item2.All(x => this.Variables.Contains(x.ToString())))
                    {
                        var newLeftSide = rule.Item2.First() + "_" + key;
                        var newRightSide = rule.Item2.Last();

                        if (!newVariables.Contains(newLeftSide))
                        {
                            newVariables.Add(newLeftSide);
                        }

                        var newRule = newLeftSide + "->" + newRightSide;
                        newRules.Add(newRule);
                    }

                    // Every rule A -> a creates new rule X -> aA_X.
                    if (rule.Item2.Length == 1 && rule.Item2.All(x => this.Terminals.Contains(x.ToString())))
                    {
                        var newLeftSide = key;
                        var newRightSide = rule.Item2 + rule.Item1 + "_" + key;

                        if (!newVariables.Contains(newRightSide.Substring(1)))
                        {
                            newVariables.Add(newRightSide.Substring(1));
                        }

                        var newRule = newLeftSide + "->" + newRightSide;
                        newRules.Add(newRule);
                    }

                    // Every rule X -> a is added to the new set of productions.
                    if (rule.Item1 == key && rule.Item2.Length == 1 && rule.Item2.All(x => this.Terminals.Contains(x.ToString())))
                    {
                        var newRule = rule.Item1 + "->" + rule.Item2;
                        newRules.Add(newRule);
                    }
                }

                newRuleList.Add(newRules);
            }

            // Add new variables to original ones.
            this.Variables.AddRange(newVariables);

            var newProductionsList = new List<Production>();

            // Create new List of Productions P_X from the new Rules.
            foreach (var newRules in newRuleList)
            {
                var tupleList = new List<Tuple<string, string>>();
                foreach (var rule in newRules)
                {
                    var splitItem = rule.Split(new string[] { "->" }, StringSplitOptions.None);
                    var tuple = new Tuple<string, string>(splitItem[0], splitItem[1]);
                    tupleList.Add(tuple);
                }

                var newProduction = new Production(tupleList);
                newProductionsList.Add(newProduction);
            }

            // Logging the changes.
            GNFConverter.LogChanges(newVariables.OrderBy(x => x).ToList(), "variables", "created");

            var loggedProductions = new List<string>();

            // format newProductions to string list for logging.
            foreach (var newProduction in newProductionsList.Select(x => x.Derivations))
            {
                var derivations = newProduction;

                foreach (var derivation in derivations)
                {
                    loggedProductions.Add(derivation.Item1 + " -> " + derivation.Item2);
                }
            }

            GNFConverter.LogChanges(loggedProductions.OrderBy(x => x).ToList(), "new derivations", "newly created");

            return newProductionsList;
        }
    }
}
