using System;
using System.Collections.Generic;
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
        public string CurrentStep { get; set; }

        public bool Finished = false;

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
            Help_btn.Enabled = false;
        }

        /// <summary>
        /// Executes only the validation part of the algorithm.
        /// The popup closes if the validation fails.
        /// If the validation is successfull the creation button is activated.
        /// </summary>
        private void Validation_btn_Click(object sender, EventArgs e)
        {
            Help_btn.Enabled = true;
            CurrentStep = "Validate";

            if (GNFConverter.ValidateSymbols(this.Variables, this.Terminals, this.StartVariable))
            {
                var productionsAreValid = GNFConverter.ValidateProductions(InitProductions, Variables, Terminals);

                if (productionsAreValid.Item2)
                {
                    var initProduction = new Production(productionsAreValid.Item1);
                    Grammar = new Grammar(Variables, Terminals, initProduction, StartVariable);

                    Transformation_Log.Text = "The given grammar is valid. You may continue. For more detailed Information use the button below or check the transformation_log box after you are done.";
                }
                else
                {
                    this.Close();
                }

                Validation_btn.Enabled = false;
                Creation_btn.Enabled = true;
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Executes only the creation part of the algorithm.
        /// After executing, the clean button is activated.
        /// </summary>
        private void Creation_btn_Click(object sender, EventArgs e)
        {
            CurrentStep = "Create";

            NewProductions = GNFConverter.CreateNewProductions(Grammar);

            Transformation_Log.Text = "New Productions were created. For more detailed Information use the button below or check the transformation_log box after you are done.";

            Creation_btn.Enabled = false;
            Clean_btn.Enabled = true;
        }

        /// <summary>
        /// Executes only the clean part of the algorithm.
        /// After executing, the substitute button is activated.
        /// </summary>
        private void Clean_btn_Click(object sender, EventArgs e)
        {
            CurrentStep = "Clean";

            GNFConverter.CleanNewProductions(NewProductions, Grammar);

            Transformation_Log.Text = "The newly created Productions were cleaned properly. For more detailed Information use the button below or check the transformation_log box after you are done.";

            Clean_btn.Enabled = false;
            Substitute_btn.Enabled = true;
        }

        /// <summary>
        /// Executes only the substitute part of the algorithm.
        /// After executing, the finish button is activated.
        /// </summary>
        private void Substitute_btn_Click(object sender, EventArgs e)
        {
            CurrentStep = "Substitute";

            Transformation_Log.Text = "Derivations that were not yet in GNF were substituted." + Environment.NewLine +
                "For more detailed Information use the button below or check the transformation_log box after you are done.";

            FinalProduction = GNFConverter.SubstituteDerivations(NewProductions, Grammar);

            Substitute_btn.Enabled = false;
            Finish_btn.Enabled = true;
        }

        /// <summary>
        /// Provides additional info the the current step if clicked.
        /// </summary>
        private void Help_btn_Click(object sender, EventArgs e)
        {
            switch (CurrentStep)
            {
                case "Validate":
                    MessageBox.Show("During this step the input grammar will be fully validated. This means that the tool will check if all symbols used are valid. It will also check if the grammar is in CNF and " +
                        "if the derivations of the productions are valid and logically correct.", "Validate");
                    break;
                case "Create":
                    MessageBox.Show("This step will create new Derivations by applying the following rules for each variable \"X\" of the grammar:" + Environment.NewLine + Environment.NewLine +
                        "1. Every rule A -> BC creates a new rule B_X -> CA_X." + Environment.NewLine +
                        "2. Every rule X -> BC also creates a new rule B_X -> C." + Environment.NewLine +
                        "3. Every rule A -> a creates a new rule X -> aA_X." + Environment.NewLine +
                        "4. If A=X for A -> a, no new rule is created and X -> a is added to the new set of productions.", "Create");
                    break;
                case "Clean":
                    MessageBox.Show("During this step the tool will remove all unnecessary derivations from the newly created derivations in the prior step." + Environment.NewLine +
                        "This concerns all derivations that contain symbols that only ever occur on either the left or the right side. They will be removed as they will never be able to produce anything.", "Clean");
                    break;
                case "Substitute":
                    MessageBox.Show("As of right now, there are still derivations that are not in GNF." + Environment.NewLine +
                        "The derivations in question are all newly created and cleaned derivations of the newly created variables." +
                        "The derivations of these new derivations start with old variables." +
                        " Meanwhile all the derivations of the original variables are in GNF." +
                        "By substituting the derivations that are not yet in GNF with all derivations of the original variable at the beginning on the left side of said variable, " +
                        "it is possible to bring all derivations into GNF.", "Substitute");
                    break;
            }
        }

        /// <summary>
        /// Finishes the execution of the algorithm and closes the popup.
        /// </summary>
        private void Finish_btn_Click(object sender, EventArgs e)
        {
            Grammar.Production = FinalProduction;
            GNFConverter.DisplayResult(Grammar);

            GNFConverter.Transformation_Log.AppendText("The transformation was complete! The given grammar was successfully transformed into a GNF grammar, that produces the same language!"
            + Environment.NewLine
            + "You can see the complete grammar in the textboxes on the left!");

            GNFConverter.CleanInput_btn.Enabled = true;
            Finished = true;

            this.Close();
        }

        /// <summary>
        /// Stops the step by step execution and closes the popup.
        /// </summary>
        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StepByStepForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Finished)
            {
                GNFConverter.Transformation_Log.Text = "The step by step execution was canceled!";

                GNFConverter.Result_V_txt.Text = "";
                GNFConverter.Result_Sig_txt.Text = "";
                GNFConverter.Result_P_txt.Text = "";
                GNFConverter.Result_S_txt.Text = ""; 
            }
        }
    }
}
