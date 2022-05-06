using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs_gui_calculator_v2
{
    public partial class CalculatorForm : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        // the result fits the num box
        private void LimitTheNumBox()
        {
            if (numBox.Text.Length > 13)
            {
                numBox.Text = numBox.Text.Substring(0, 12);
            }
        }

        // the number box stays in focus
        private void FocusOnTheNumBox()
        {
            // Set focus to control
            numBox.Focus();
            // Set text-selection to end
            numBox.SelectionStart = numBox.Text.Length == 0 ? 0 : numBox.Text.Length;
            // Set text-selection length (in your case 0 = no blue text)
            numBox.SelectionLength = 0;
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            FocusOnTheNumBox();
        }

        // Runs the number and comma buttons
        private void Number_Click(object sender, EventArgs e)
        {
            if ((numBox.Text == "0") || (isOperationPerformed))
                numBox.Clear();

            isOperationPerformed = false;

            Button numbers = (Button)sender;
            numBox.Text += numbers.Text;
            FocusOnTheNumBox();
        }

        // Runs the addition, subtraction, multiplication and divide operators
        private void Operator_Click(object sender, EventArgs e)
        {
            Button operators = (Button)sender;

            if (resultValue != 0)
            {
                operationPerformed = operators.Text;
                operationLabel.Text = resultValue + operationPerformed;
                isOperationPerformed = true;
                FocusOnTheNumBox();
            }
            else
            {
                operationPerformed = operators.Text;
                resultValue = Double.Parse(numBox.Text);
                operationLabel.Text = resultValue + operationPerformed;
                isOperationPerformed = true;
                FocusOnTheNumBox();
            }
        }

        // Runs the clear button
        private void ClearButton_Click(object sender, EventArgs e)
        {
            operationLabel.Text = "0";
            numBox.Text = "0";
            resultValue = 0;
            FocusOnTheNumBox();
        }

        // Runs the clear entry button
        private void ClearEntryButton_Click(object sender, EventArgs e)
        {
            numBox.Text = "0";
            FocusOnTheNumBox();
        }

        // Runs the backspace button
        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            if (numBox.Text.Length > 1)
            {
                numBox.Text = numBox.Text.Substring(0, (numBox.Text.Length - 1));
                FocusOnTheNumBox();
            }
            else
            {
                numBox.Text = "0";
                FocusOnTheNumBox();
            }
        }

        // Runs the comma button
        private void Comma_Click(object sender, EventArgs e)
        {
            if (CommaButton.Text == ",")
            {
                if (!numBox.Text.Contains(","))
                    numBox.Text += CommaButton.Text;
                    FocusOnTheNumBox();
            }
            else
            {
                numBox.Text += CommaButton.Text;
                FocusOnTheNumBox();
            }
        }

        // Runs the sign button
        private void SignButton_Click(object sender, EventArgs e)
        {
            double textNum = Double.Parse(numBox.Text);

            int sign = Math.Sign(textNum);

            if (sign == 1)
            {
                numBox.Text = (textNum * (-1)).ToString();
                FocusOnTheNumBox();
            }
            else if (sign == -1)
            {
                numBox.Text = (textNum * (-1)).ToString();
                FocusOnTheNumBox();
            }
            else if (sign == 0)
            {
                numBox.Text = "0";
                FocusOnTheNumBox();
            }
        }

        // Runs the equal button
        private void EqualButton_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    numBox.Text = (resultValue + Double.Parse(numBox.Text)).ToString();
                    break;
                case "-":
                    numBox.Text = (resultValue - Double.Parse(numBox.Text)).ToString();
                    break;
                case "*":
                    numBox.Text = (resultValue * Double.Parse(numBox.Text)).ToString();
                    break;
                case "/":
                    numBox.Text = (resultValue / Double.Parse(numBox.Text)).ToString();
                    break;
            }

            LimitTheNumBox();
            resultValue = Double.Parse(numBox.Text);
            operationLabel.Text = resultValue + operationPerformed;
            isOperationPerformed = true;
            FocusOnTheNumBox();
        }

        // Runs the factor, the square root, the square and the log buttons
        private void MathButtons_Click(object sender, EventArgs e)
        {
            double num = Double.Parse(numBox.Text);

            Button mathButtons = (Button)sender;

            switch (mathButtons.Text)
            {
                case "X!":
                    int recursiveFactorialCalculation(int factorial)
                    {
                        if (factorial == 0 || factorial == 1 || factorial < 0)
                        {
                            return 1;
                        }
                        return factorial * recursiveFactorialCalculation(factorial - 1);
                    }
                    int factNum = int.Parse(numBox.Text);
                    int result1 = recursiveFactorialCalculation(factNum);
                    numBox.Text = result1.ToString();
                    break;
                case "√x":
                    double result2 = Math.Sqrt(num);
                    numBox.Text = result2.ToString();
                    break;
                case "x²":
                    double result3 = Math.Pow(2,num);
                    numBox.Text = result3.ToString();
                    break;
                case "Log10":
                    double result4 = Math.Log10(num);
                    numBox.Text = result4.ToString();
                    break;
            }

            LimitTheNumBox();
            resultValue = Double.Parse(numBox.Text);
            operationLabel.Text = resultValue.ToString();
            isOperationPerformed = true;
            FocusOnTheNumBox();
        }

        // this method is used to take input from keyboard 
        private void CalculatorForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case ".":
                case ",":
                    CommaButton.PerformClick();
                    break;
                case "0":
                    NumBtn0.PerformClick();
                    break;
                case "1":
                    NumBtn1.PerformClick();
                    break;
                case "2":
                    NumBtn2.PerformClick();
                    break;
                case "3":
                    NumBtn3.PerformClick();
                    break;
                case "4":
                    NumBtn4.PerformClick();
                    break;
                case "5":
                    NumBtn5.PerformClick();
                    break;
                case "6":
                    NumBtn6.PerformClick();
                    break;
                case "7":
                    NumBtn7.PerformClick();
                    break;
                case "8":
                    NumBtn8.PerformClick();
                    break;
                case "9":
                    NumBtn9.PerformClick();
                    break;                
                case "/":
                    DivButton.PerformClick();
                    break;
                case "*":
                    MultiplyButton.PerformClick();
                    break;
                case "-":
                    SubButton.PerformClick();
                    break;
                case "+":
                    AddButton.PerformClick();
                    break;                                              
                case "=":
                    EqualButton.PerformClick();
                    break;
                default:
                    FocusOnTheNumBox();
                    break;

            } //end switch 

            if (e.KeyChar == (char)Keys.Enter)
                EqualButton.PerformClick();
            if (e.KeyChar == (char)Keys.Back)
                BackspaceButton.PerformClick();
        }

        // gets fired when the focus is inside of the numBox.
        private void numBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CalculatorForm_KeyPress(sender, e);
            e.Handled = true;
        }
    }
}