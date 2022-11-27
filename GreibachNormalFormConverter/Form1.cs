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
            Transformation_Log.Text = "Transformation-Log:" + Environment.NewLine + Environment.NewLine;
            P_tooltip.SetToolTip(this.P_txt, "Please seperate Productions with ';'!");

            ComboBox.Items.Add("Grammar 1");
            ComboBox.Items.Add("Grammar 2");
            ComboBox.Items.Add("Grammar 3");
            ComboBox.Items.Add("Grammar 4");
            ComboBox.Items.Add("");
            // TODO: Add remaining example grammar to combobox.
            // TODO: add check for cnf, currently A -> BCD is valid.
            // P_txt.Text = "Please note productions like the following: A -> x; A -> BC; B -> z";
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBox.SelectedIndex)
            {
                case 0:
                    V_txt.Text = "S, B, C, D, E";
                    Sig_txt.Text = "a, b";
                    P_txt.Text = "S -> BC; S -> b; B -> CD; B -> ED; B -> a; C -> BC; C -> DE; D -> a; E -> b";
                    S_txt.Text = "S";
                    break;

                case 1:
                    V_txt.Text = "S, T, A, Z";
                    Sig_txt.Text = "a";
                    P_txt.Text = "S -> TA; S -> AA; S -> ZA; S -> a; T -> AA; A -> ZA; A -> a; Z -> a";
                    S_txt.Text = "S";
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    Transformation_Log.Text = "Transformation-Log:" + Environment.NewLine + Environment.NewLine;
                    V_txt.Text = "";
                    Sig_txt.Text = "";
                    P_txt.Text = "";
                    S_txt.Text = "";
                    break;
            }
        }

        /// <summary>
        /// This method is called when the convert button is clicked.
        /// Within this method the UI will be cleaned, the input will be read, and the methods that execute the different steps of the algorithm will be called.
        /// </summary>
        private void Convert_btn_Click(object sender, EventArgs e)
        {
            // Clean UI.
            Transformation_Log.Text = "Transformation-Log:" + Environment.NewLine + Environment.NewLine;
            Result_V_txt.Text = "";
            Result_Sig_txt.Text = "";
            Result_P_txt.Text = "";
            Result_S_txt.Text = "";

            // Read input.
            List<string> initVariables = V_txt.Text.Replace(" ", "").TrimEnd(',').Split(',').ToList();
            List<string> initTerminals = Sig_txt.Text.Replace(" ", "").TrimEnd(',').Split(',').ToList();
            List<string> initProductions = P_txt.Text.Replace(" ", "").TrimEnd(';').Split(';').ToList();
            List<string> initStartVariable = new List<string>() { S_txt.Text.Replace(" ", "") };

            // Validate input and create grammar if input is valid.
            if (ValidateSymbols(initVariables, initTerminals, initStartVariable))
            {
                // Returns valid production derivations and bool stating if they are valid.
                var productionsAreValid = ValidateProductions(initProductions, initVariables, initTerminals);
                if (productionsAreValid.Item2)
                {
                    var initProduction = new Production(productionsAreValid.Item1);
                    Grammar initGrammar = new Grammar(initVariables, initTerminals, initProduction, initStartVariable);

                    Transformation_Log.AppendText("The given grammar is valid. The transformation will now commence." + Environment.NewLine + Environment.NewLine);

                    // Create new productions and clean them.
                    var newProductions = CreateNewProductions(initGrammar);
                    CleanNewProductions(newProductions, initGrammar);

                    // Substitute new productions to bring them into GNF.
                    var completeProduction = SubstituteDerivations(newProductions, initGrammar);

                    Transformation_Log.AppendText("The transformation was complete! The given grammar was successfully transformed into a GNF grammar, that produces the same language!"
                        + Environment.NewLine
                        + "You can see the complete grammar in the textboxes on the left!");

                    // Create new grammar in GNF with completed productions.
                    var gnfGrammar = new Grammar(initVariables, initTerminals, completeProduction, initStartVariable);

                    // Display GNF grammar in the form.
                    DisplayResult(gnfGrammar);
                }
            }

        }

        /// <summary>
        /// Validates whether the symbols used in the set of variables, terminals and the startVariable are made of lower-/uppercase roman letters.
        /// Also checks if each symbol is contains only one letter i.e. A,B,c,d instead of Aa,Bx,Cy
        /// </summary>
        /// <param name="variables">The variables to be validated.</param>
        /// <param name="terminals">The terminals to be validated</param>
        /// <param name="startVariable">The startVariable to be validated.</param>
        /// <returns>True if the sets are valid, otherwise false.</returns>
        private bool ValidateSymbols(List<string> variables, List<string> terminals, List<string> startVariable)
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
                if (variables.Any(x => terminals.Contains(x)))
                {
                    throw new ArgumentException("The sets variables and terminals MUST be disjoint!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Transformation_Log.AppendText("The given grammar is not valid! There seems to be an error in the set of variables/terminals.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the productions of the grammar.
        /// The productions are to be of the form A -> x;A -> y;B -> z.
        /// </summary>
        /// <param name="productions">The productions to be validated.</param>
        /// <param name="variables">The set of variables which is used for validation of the productions.</param>
        /// <param name="terminals">The set of terminals which is used for validation of the productions.</param>
        /// <returns>
        /// A Tuple containing a list of derivation tuples to create the production and a bool containing the information of the initial production's validity.
        /// The list of tuples is empty and the bool false if the inital productions are invalid. Otherwise the list of tuples is filled correctly and the bool is true.
        /// </returns>
        private Tuple<List<Tuple<string, string>>, bool> ValidateProductions(List<string> productions, List<string> variables, List<string> terminals)
        {
            var leftSideList = new List<string>();
            var rightSideList = new List<string>();
            var tupleList = new List<Tuple<string, string>>();

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
                    tupleList.Add(new Tuple<string, string>(splitRule[0], splitRule[1]));
                }

                // Check if each left side symbol is in fact a variable.
                foreach (var leftSideSymbol in leftSideList)
                {
                    if (!variables.Contains(leftSideSymbol))
                    {
                        throw new ArgumentException("The left side of each production MUST be a variable. The given grammar is not context-free!");
                    }
                }

                // Check if right side is empty or null.
                if (rightSideList.Any(x => String.IsNullOrEmpty(x)))
                {
                    throw new ArgumentException("The right side of each production MUST not be empty!");
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
                Transformation_Log.AppendText("The given grammar is not valid! There seems to be an error in the set of productions.");
                return Tuple.Create(new List<Tuple<string, string>>(), false);
            }

            return Tuple.Create(tupleList, true);
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
            LogChanges(newVariables.OrderBy(x => x).ToList(), "variables", "created");

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

            LogChanges(loggedProductions.OrderBy(x => x).ToList(), "new derivations", "newly created");

            return newProductionsList;
        }

        /// <summary>
        /// Cleans the production by removing useless rules. Variables that are useless after the removal of said rules will also be removed from the set of variables in the initial grammar.
        /// </summary>
        /// <param name="newProductions">The newly created productions to be cleaned.</param>
        /// <param name="initGrammar">The inital grammar whose variables may be altered.</param>
        private void CleanNewProductions(List<Production> newProductions, Grammar initGrammar)
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
            leftSymbols.Remove(initGrammar.Startvariable.First());

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

                    initGrammar.Variables.Remove(symbol);
                }
            }

            // Remove derivations where the right side never occurs on any left side, thus being useless.
            // The variables in question are the newly created startVariables S_X.
            foreach (var production in newProductions.Select(x => x.Derivations))
            {
                var removedStartDerivations = production.Where(x => x.Item2.Contains(initGrammar.Startvariable.First() + "_"));
                foreach (var derivation in removedStartDerivations)
                {
                    removedDerivationList.Add(derivation.Item1 + " -> " + derivation.Item2);
                }

                production.RemoveAll(x => x.Item2.Contains(initGrammar.Startvariable.First() + "_"));
            }

            removedVariableList.Add(String.Join(Environment.NewLine, initGrammar.Variables.Where(x => x.Contains(initGrammar.Startvariable.First() + "_"))));
            initGrammar.Variables.RemoveAll(x => x.Contains(initGrammar.Startvariable.First() + "_"));

            // Logging the changes
            LogChanges(removedVariableList.Distinct().ToList(), "obsolete variables", "removed from the newly created variables");
            LogChanges(removedDerivationList.OrderBy(x => x).ToList(), "obsolete derivations", "removed from the newly created derivations");
        }

        /// <summary>
        /// Substitutes every B in derivations of the form A -> BC with all possible derivations of B itself.
        /// Since all derivations of B are already in GNF the remaining derivations that are not in GNF will be after this substitution.
        /// </summary>
        /// <param name="newProductions">The newly created and cleaned productions whose derivations are to be substituted.</param>
        /// <param name="initGrammar">The initial grammar with now modified variables.</param>
        /// <returns>The final set of production rules in the form of a production. All derivations of this production are now in GNF.</returns>
        private Production SubstituteDerivations(List<Production> newProductions, Grammar initGrammar)
        {
            // Select the newly created Variables whose derivations are still of the form A -> BC.
            var newVariables = initGrammar.Variables.Where(x => x.Contains("_")).ToList();
            var productionsToSubstitute = new List<Tuple<string, string>>();
            var substitutedProductions = new List<Tuple<string, string>>();

            // Select the derivations of said variables.
            foreach (var production in newProductions)
            {
                var derivationsToSubstitute = production.Derivations.Where(x => newVariables.Contains(x.Item1));
                productionsToSubstitute.AddRange(derivationsToSubstitute);
            }

            // Substitude the first symbol of each derivation to be substituted with every possible derivation of the symbols own derivations.
            foreach (var productionToSubstitute in productionsToSubstitute)
            {
                var symbolToSubstitute = productionToSubstitute.Item2.Substring(0, 1);
                var productionsForSymbol = new List<Tuple<string, string>>();

                foreach (var production in newProductions)
                {
                    var foundProductions = production.Derivations.Where(x => x.Item1 == symbolToSubstitute);
                    productionsForSymbol.AddRange(foundProductions);
                }

                foreach (var productionForSymbol in productionsForSymbol)
                {
                    var substitutedDerivation = new Tuple<string, string>
                        (
                            productionToSubstitute.Item1,
                            productionForSymbol.Item2 + productionToSubstitute.Item2.Substring(1)
                        );

                    substitutedProductions.Add(substitutedDerivation);
                }
            }

            var productionsToLog = substitutedProductions;

            // Remove the now old verions of the now substituted derivations and create a new Porduction with all the newly created and freshly substituted derivations.
            foreach (var production in newProductions.Select(x => x.Derivations))
            {
                production.RemoveAll(x => x.Item1.Contains("_"));
                substitutedProductions.AddRange(production);
            }

            // Remove derivations with old variables on the left, as they are obsolete after the substitution.
            // Also remove the old variables and "cache" them to log later.
            substitutedProductions.RemoveAll(x => x.Item1.Length == 1 && x.Item1 != initGrammar.Startvariable.First());
            var variablesToLog = initGrammar.Variables.Where(x => x.Length == 1 && x != initGrammar.Startvariable.First()).ToList();
            initGrammar.Variables.RemoveAll(x => x.Length == 1 && x != initGrammar.Startvariable.First());

            // Logging the changes.
            var variableList = new List<string>
            {
                String.Join(Environment.NewLine, newVariables)
            };

            var productionList = new List<string>();

            foreach (var production in productionsToLog.Where(x => x.Item1.Length != 1))
            {
                productionList.Add(String.Join(Environment.NewLine, production.Item1 + " -> " + production.Item2));
            }

            LogChanges(variableList, "variables' derivations", "not yet brought into GNF");
            LogChanges(productionList, "derivations", "substituted and brought into GNF");
            Transformation_Log.AppendText("The following initial variables were also removed, as they and their derivations are obsolete after the subsitution: "
                + Environment.NewLine
                + string.Join(Environment.NewLine, variablesToLog)
                + Environment.NewLine
                + Environment.NewLine);

            return new Production(substitutedProductions);
        }

        /// <summary>
        /// Formats the variable, terminal, production and startvariable sets into strings and displays them in the dedicated textboxes on the UI.
        /// </summary>
        /// <param name="gnfGrammar">The finished grammar in GNF.</param>
        private void DisplayResult(Grammar gnfGrammar)
        {
            var splitVariables = new List<string>();
            var splitTerminals = new List<string>();
            var splitDerivations = new List<string>();

            // Split all variables into strings appended with a comma unless it is the last variable.
            for (int i = 0; i < gnfGrammar.Variables.Count; i++)
            {
                var variable = gnfGrammar.Variables[i];
                if (i == gnfGrammar.Variables.Count - 1)

                {
                    splitVariables.Add(variable);
                }
                else
                {
                    splitVariables.Add(variable + ", ");
                }
            }

            // Split all terminals into strings appended with a comma unless it is the last terminal.
            for (int i = 0; i < gnfGrammar.Terminals.Count; i++)
            {
                var terminal = gnfGrammar.Terminals[i];
                if (i == gnfGrammar.Terminals.Count - 1)

                {
                    splitTerminals.Add(terminal);
                }
                else
                {
                    splitTerminals.Add(terminal + ", ");
                }
            }

            // Split all derivations into strings joined by "->", and appended with a comma unless it is the last derivation.
            for (int i = 0; i < gnfGrammar.Production.Derivations.Count; i++)
            {
                var derivation = gnfGrammar.Production.Derivations[i];

                if (i == gnfGrammar.Production.Derivations.Count - 1)
                {
                    splitDerivations.Add(derivation.Item1 + " -> " + derivation.Item2);
                }
                else
                {
                    splitDerivations.Add(derivation.Item1 + " -> " + derivation.Item2 + ", ");
                }
            }

            // Display the variables, terminals, derivations and the startvariable in the dedicated textboxes.
            Result_V_txt.Text = String.Join(Environment.NewLine, splitVariables);
            Result_Sig_txt.Text = String.Join(Environment.NewLine, splitTerminals);
            Result_P_txt.Text = String.Join(Environment.NewLine, splitDerivations);
            Result_S_txt.Text = String.Join(Environment.NewLine, gnfGrammar.Startvariable);
        }

        /// <summary>
        /// A somewhat generic method to log changes to the transformation log.
        /// </summary>
        /// <param name="changes">The changes that happend in the form of a string List.</param>
        /// <param name="nameOfChange">The name of what was changed e.g. variables/terminals/derivations.</param>
        /// <param name="kindOfChange">What the change was e.g. removed/created/substituted.</param>
        private void LogChanges(List<string> changes, string nameOfChange, string kindOfChange)
        {
            Transformation_Log.AppendText($"The following {nameOfChange} were {kindOfChange} during the transformation: "
            + Environment.NewLine
            + string.Join(Environment.NewLine, changes)
            + Environment.NewLine
            + Environment.NewLine);
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