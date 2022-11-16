using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GreibachNormalFormConverter
{
    public partial class GNFConverter : Form
    {
        public GNFConverter()
        {
            InitializeComponent();
            P_tooltip.ShowAlways = true;
            P_tooltip.SetToolTip(this.P_txt, "Please seperate Productions with ';'!");
            P_txt.Text = "Please note productions like the following: A -> x; A -> y; B -> z";
        }

        private void Convert_btn_Click(object sender, EventArgs e)
        {
            List<string> initVariables = V_txt.Text.Replace(" ", "").Split(',').ToList();
            List<string> initTerminals = Sig_txt.Text.Replace(" ", "").Split(',').ToList();
            List<string> initProductions = P_txt.Text.Replace(" ", "").Split(';').ToList();
            List<string> initStartVariable = new List<string>() { S_txt.Text.Replace(" ", "") };

            ValidateSymbols(initVariables, initTerminals, initStartVariable);
            Production initProduction = ValidateProductions(initProductions, initVariables, initTerminals);
            Grammar initGrammar = new Grammar(initVariables, initTerminals, initProduction, initStartVariable);

            var newProductions = CreateNewProductions(initGrammar);
            CleanNewProductions(newProductions);

            // TODO: Clean Prodcutions.
            // TODO: Logging of changes.
            // TODO: Create new grammar in GNF.
            MessageBox.Show("hi");
        }

        /// <summary>
        /// Validates whether the symbols used in the set of variables, terminals and the startVariable are made of lower-/uppercase roman letters.
        /// Also checks if each symbol is contains only one letter i.e. A,B,c,d instead of Aa,Bx,Cy
        /// </summary>
        /// <param name="variables">The variables to be validated.</param>
        /// <param name="terminals">The terminals to be validated</param>
        /// <param name="startVariable">The startVariable to be validated.</param>
        private void ValidateSymbols(List<string> variables, List<string> terminals, List<string> startVariable)
        {
            // Regex only allowing roman lower-/uppercase letters.
            var regex = new Regex(@"^[a-zA-Z]+$");

            try
            {
                // Check if variables/terminals/startvariable are empty.
                if (!(variables.Any() && terminals.Any() && startVariable.Any()))
                {
                    throw new ArgumentException("The Variables/Terminals/Startvariable MUST not be empty!");
                }

                // Check if each symbol in variables, terminals and startVariable matches the regex and contains only one letter.
                foreach (var symbol in variables.Concat(terminals).Concat(startVariable))
                {
                    if (symbol.Length != 1)
                    {
                        throw new ArgumentException("Every symbol should only contain a single character!");
                    }

                    if (!regex.IsMatch(symbol))
                    {
                        throw new ArgumentException("The used symbols are not valid charactes, please only use upper and lowercase characters of the roman alphabet!");
                    }
                }

                // Check if there is only a single startVariable.
                if (startVariable.Count != 1)
                {
                    throw new ArgumentException("You may only specify a single startVariable!");
                }

                // Check if variables contain startVariable.
                if (!variables.Contains(startVariable.First()))
                {
                    throw new ArgumentException("The set of variables MUST contain the startVariable!");
                }

                // Validate if each symbol only occurs once in the variables.
                if (variables.Count != variables.Distinct().Count())
                {
                    throw new ArgumentException("Every variable may only be used once!");
                }

                // Check if variables and terminals are disjoint.
                if (variables.SequenceEqual(terminals))
                {
                    throw new ArgumentException("The sets variables and terminals MUST be disjoint!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Validates the productions of the grammar.
        /// The productions are to be of the form A -> x;A -> y;B -> z.
        /// </summary>
        /// <param name="productions">The productions to be validated.</param>
        /// <param name="variables">The set of variables which is used for validation of the productions.</param>
        /// <param name="terminals">The set of terminals which is used for validation of the productions.</param>
        /// <returns>A valid production.</returns>
        private Production ValidateProductions(List<string> productions, List<string> variables, List<string> terminals)
        {
            var leftSideList = new List<string>();
            var rightSideList = new List<string>();

            // TODO: check if all symbols of production are in variables U terminals.

            try
            {
                // Check if productions are empty.
                if (!productions.Any())
                {
                    throw new ArgumentException("The productions MUST not be empty!");
                }

                // Split production rules into left and right sides.
                foreach (var rule in productions)
                {
                    var splitRule = rule.Split(new string[] { "->" }, StringSplitOptions.None);
                    leftSideList.Add(splitRule[0]);
                    rightSideList.Add(splitRule[1]);
                }

                // Check if each left side symbol is in fact a variable.
                foreach (var leftSideSymbol in leftSideList)
                {
                    if (!variables.Contains(leftSideSymbol))
                    {
                        throw new ArgumentException("The left side of each production MUST be a variable. The given grammar is not context-free!");
                    }
                }

                // Check if each rightSideSymbol is contained in the variable and/or terminal set.
                foreach (var rightSide in rightSideList)
                {
                    foreach (var symbol in rightSide)
                    {
                        if (!(rightSide.All(x => variables.Contains(x.ToString())) || rightSide.All(x => terminals.Contains(x.ToString()))))
                        {
                            throw new ArgumentException("The right side of each production MUST only contain variables and/or terminals");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new Production(productions);
        }

        /// <summary>
        /// Creates new Productions after the following rules:
        ///     1. Every rule A -> BC creates new rule B_X -> CA_X.
        ///     2. Every rule X -> BC also creates new rule B_X -> C.
        ///     3. Every rule A -> a creates new rule X -> aA_X.
        ///     4. Every rule X -> a is added to the new set of productions.
        /// </summary>
        /// <param name="initGrammar">The initial grammar which new productions are going to be created for.</param>
        /// <returns>A list of new Productions P_X.</returns>
        private List<Production> CreateNewProductions(Grammar initGrammar)
        {
            // Group existing rules after left side.
            ILookup<string, Tuple<string, string>> groupedRules = initGrammar.Production.Derivations.ToLookup(r => r.Item1);
            var newRuleList = new List<List<string>>();
            var newVariables = new List<string>();

            // Iterate through each grouping to create new rules for each variable.
            foreach (var grouping in groupedRules)
            {
                var key = grouping.Key.ToString();
                var newRules = new List<string>();

                // Create new rules from each existing rule.
                foreach (var rule in initGrammar.Production.Derivations)
                {
                    // Every rule A -> BC creates new rule B_X -> CA_X.
                    if (rule.Item2.Length == 2 && rule.Item2.All(x => initGrammar.Variables.Contains(x.ToString())))
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
                    if (rule.Item1 == key && rule.Item2.Length == 2 && rule.Item2.All(x => initGrammar.Variables.Contains(x.ToString())))
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
                    if (rule.Item2.Length == 1 && rule.Item2.All(x => initGrammar.Terminals.Contains(x.ToString())))
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
                    if (rule.Item1 == key && rule.Item2.Length == 1 && rule.Item2.All(x => initGrammar.Terminals.Contains(x.ToString())))
                    {
                        var newRule = rule.Item1 + "->" + rule.Item2;
                        newRules.Add(newRule);
                    }
                }

                newRuleList.Add(newRules);
            }

            // Add new variables to original ones.
            initGrammar.Variables.AddRange(newVariables);

            var newProductionsList = new List<Production>();

            // Create new List of Productions P_X from the new Rules.
            foreach (var newRules in newRuleList)
            {
                var newProduction = new Production(newRules);
                newProductionsList.Add(newProduction);
            }

            return newProductionsList;
        }

        private void CleanNewProductions(List<Production> newProductions)
        {
            var firstRightSymbols = new List<string>();
            var secondRightSymbols = new List<string>();
            var leftSymbols = new List<string>();

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
            leftSymbols.Remove("S");

            // Remove derivations where the left side never occurs on any right side, thus being useless.
            foreach (var symbol in leftSymbols)
            {
                if (!(firstRightSymbols.Any(x => x == symbol) || secondRightSymbols.Any(y => y == symbol)))
                {
                    foreach (var production in newProductions)
                    {
                        production.Derivations.RemoveAll(x => x.Item1.StartsWith(symbol));
                    }
                }
            }

            MessageBox.Show("HI");
        }

        // Add placeholder in productions.
        private void P_txt_Enter(object sender, EventArgs e)
        {
            if (P_txt.Text == "Please note productions like the following: A -> x; A -> y; B -> z")
            {
                P_txt.Text = "";
            }
        }

        // Remove placeholder in productions.
        private void P_txt_Leave(object sender, EventArgs e)
        {
            if (P_txt.Text.Trim() == "")
            {
                P_txt.Text = "Please note productions like the following: A -> x; A -> y; B -> z";
            }
        }
    }
}
