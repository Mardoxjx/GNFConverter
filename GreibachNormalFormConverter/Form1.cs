﻿using System;
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

                // Check if variables contain startVariable.
                if (!variables.Contains(startVariable.First()))
                {
                    throw new ArgumentException("The set of variables MUST contain the startVariable!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Validates the productions of the grammar.
        /// The productions are to be of the form A -> x; A -> y; B -> z.
        /// </summary>
        /// <param name="productions"></param>
        /// <returns>A valid production.</returns>
        private Production ValidateProductions(List<string> productions, List<string> variables, List<string> terminals)
        {
            var leftSideList = new List<string>();
            var rightSideList = new List<string>();

            //split production rules into left and right sides.
            foreach (var rule in productions)
            {
                var splitRule = rule.Split(new string[] {"->"}, StringSplitOptions.None);
                leftSideList.Add(splitRule[0]);
                rightSideList.Add(splitRule[1]);
            }

            //check if each left side symbol is in fact a variable.
            foreach (var leftSideSymbol in leftSideList)
            {
                if (!variables.Contains(leftSideSymbol))
                {
                    throw new ArgumentException("The left side of each production MUST be a variable. The given grammar is not context-free!");
                }
            }

            //check if each rightSideSymbol is contained in the variable and/or terminal set.
            foreach (var rightSide in rightSideList)
            {
                foreach (var symbol in rightSide)
                {
                    if (!(variables.Contains(rightSide) || terminals.Contains(rightSide)))
                    {
                        throw new ArgumentException("The right side of each production MUST only contain variables and/or terminals");
                    }
                }
            }

            return new Production(productions);
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
