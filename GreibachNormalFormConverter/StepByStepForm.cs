using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreibachNormalFormConverter
{
    public partial class StepByStepForm : Form
    {
        public GNFConverter GNFConverter { get; set; }
        public List<string> Variables { get; set; }
        public List<string> Terminals { get; set; }
        public List<string> InitProductions { get; set; }
        public List<string> StartVariable { get; set; }
        public Grammar Grammar { get; set; }
        public List<Production> NewProductions { get; set; }
        public Production FinalProduction { get; set; }

        public StepByStepForm(
            GNFConverter gnfConverter, 
            List<string> initVariables, 
            List<string> initTerminals, 
            List<string> initProductions, 
            List<string> startVariable)
        {
            InitializeComponent();

            GNFConverter = gnfConverter;

            Variables = initVariables;
            Terminals = initTerminals;
            InitProductions = initProductions;
            StartVariable = startVariable;

            Creation_btn.Enabled = false;
            Clean_btn.Enabled = false;
            Substitute_btn.Enabled = false;
            Finish_btn.Enabled = false;
        }

        private void Validation_btn_Click(object sender, EventArgs e)
        {
            if (GNFConverter.ValidateSymbols(this.StartVariable, this.Terminals, this.StartVariable))
            {
                var productionsAreValid = GNFConverter.ValidateProductions(InitProductions, Variables, Terminals);

                if (productionsAreValid.Item2)
                {
                    var initProduction = new Production(productionsAreValid.Item1);
                    Grammar = new Grammar(Variables, Terminals, initProduction, StartVariable);

                    Transformation_Log.BeginInvoke((Action)delegate ()
                    {
                        Transformation_Log.Text = "The given grammar is valid. You may continue.";
                    });
                }
            }

            Validation_btn.Enabled = false;
            Creation_btn.Enabled = true;
        }

        private void Creation_btn_Click(object sender, EventArgs e)
        {
            NewProductions = GNFConverter.CreateNewProductions(Grammar);

            Creation_btn.Enabled = false;
            Clean_btn.Enabled = true;
        }

        private void Clean_btn_Click(object sender, EventArgs e)
        {
            GNFConverter.CleanNewProductions(NewProductions, Grammar);

            Clean_btn.Enabled = false;
            Substitute_btn.Enabled = true;
        }

        private void Substitute_btn_Click(object sender, EventArgs e)
        {
            FinalProduction = GNFConverter.SubstituteDerivations(NewProductions, Grammar);

            Substitute_btn.Enabled = false;
            Finish_btn.Enabled = true;
        }

        private void Help_btn_Click(object sender, EventArgs e)
        {

        }

        private void Finish_btn_Click(object sender, EventArgs e)
        {
            Grammar.Production = FinalProduction;
            GNFConverter.DisplayResult(Grammar);

            GNFConverter.Transformation_Log.AppendText("The transformation was complete! The given grammar was successfully transformed into a GNF grammar, that produces the same language!"
            + Environment.NewLine
            + "You can see the complete grammar in the textboxes on the left!");

            GNFConverter.CleanInput_btn.Enabled = true;

            this.Close();
        }

        private void Abort_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
