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

        /// <summary>
        /// Cleans the production by removing useless rules. Variables that are useless after the removal of said rules will also be removed from the set of variables in the initial grammar.
        /// </summary>
        /// <param name="newProductions">The newly created productions to be cleaned.</param>
        public void CleanNewProductions(List<Production> newProductions)
        {
            var firstRightSymbols = new List<string>();
            var secondRightSymbols = new List<string>();
            var leftSymbols = new List<string>();

            var removedVariableList = new List<string>();
            var removedDerivationList = new List<string>();

            // Split each derivation in each production into left side and the first and second part of the right side.
            foreach (var production in newProductions)
            {
                foreach (var derivation in production.Derivations)
                {
                    firstRightSymbols.Add(derivation.Item2.Substring(0, 1));
                    secondRightSymbols.Add(derivation.Item2.Substring(1));
                    leftSymbols.Add(derivation.Item1);
                }
            }

            firstRightSymbols = firstRightSymbols.Distinct().ToList();
            secondRightSymbols = secondRightSymbols.Distinct().ToList();
            leftSymbols = leftSymbols.Distinct().ToList();

            // Exclude startVariable as it never occurs on the right. This behavior is intended and the derivations of the startVariable must not be removed.
            leftSymbols.Remove(this.Startvariable.First());

            // Remove derivations where the left side never occurs on any right side, thus being useless.
            foreach (var symbol in leftSymbols)
            {
                if (firstRightSymbols.All(x => x != symbol) && secondRightSymbols.All(y => y != symbol))
                {
                    foreach (var production in newProductions.Select(x => x.Derivations))
                    {
                        removedVariableList.Add(symbol);
                        var removedDerivations = production.Where(x => x.Item1 == symbol);
                        foreach (var derivation in removedDerivations)
                        {
                            removedDerivationList.Add(derivation.Item1 + " -> " + derivation.Item2);
                        }

                        production.RemoveAll(x => x.Item1 == symbol);
                    }

                    this.Variables.Remove(symbol);
                }
            }

            // Remove derivations where the right side never occurs on any left side, thus being useless.
            // The variables in question are the newly created startVariables S_X.
            foreach (var production in newProductions.Select(x => x.Derivations))
            {
                var removedStartDerivations = production.Where(x => x.Item2.Contains(this.Startvariable.First() + "_"));
                foreach (var derivation in removedStartDerivations)
                {
                    removedDerivationList.Add(derivation.Item1 + " -> " + derivation.Item2);
                }

                production.RemoveAll(x => x.Item2.Contains(this.Startvariable.First() + "_"));
            }

            removedVariableList.Add(String.Join(Environment.NewLine, this.Variables.Where(x => x.Contains(this.Startvariable.First() + "_"))));
            this.Variables.RemoveAll(x => x.Contains(this.Startvariable.First() + "_"));

            // Logging the changes
            GNFConverter.LogChanges(removedVariableList.Distinct().ToList(), "obsolete variables", "removed from the newly created variables");
            GNFConverter.LogChanges(removedDerivationList.OrderBy(x => x).ToList(), "obsolete derivations", "removed from the newly created derivations");
        }
    }
}
