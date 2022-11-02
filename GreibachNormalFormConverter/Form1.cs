using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
        }

        private void Convert_btn_Click(object sender, EventArgs e)
        {
            List<string> initVariables = V_txt.Text.Replace(" ", "").Split(',').ToList();
            List<string> initTerminals = Sig_txt.Text.Replace(" ", "").Split(',').ToList();
            List<string> initProductions = P_txt.Text.Replace(" ", "").Split(';').ToList();
            List<string> initStartVariable = new List<string>() { S_txt.Text.Replace(" ", "") };

            ValidateSymbols(initVariables, initTerminals, initStartVariable);
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
                    if (!regex.IsMatch(symbol))
                    {
                        throw new ArgumentException("The used symbols are not valid charactes, please only use upper and lowercase characters of the roman alphabet!");
                    }

                    if (symbol.Length != 1)
                    {
                        throw new ArgumentException("Every symbol should only contain a single character!");
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

                // Validate if each symbol only occurs once in the terminals.
                if (terminals.Count != terminals.Distinct().Count())
                {
                    throw new ArgumentException("Every terminal may only be used once!");
                }

                // Check if variables and terminals are disjoint.
                if (variables.SequenceEqual(terminals))
                {
                    throw new ArgumentException("The sets variables and terminals MUST be disjoint!");
                }

                // Check if variables contain startVariable.
                if (variables.Contains(startVariable.First()))
                {
                    throw new ArgumentException("The set of variables MUST contain the startVariable!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ValidateProductions(List<string> productions)
        {

        }
    }
}
