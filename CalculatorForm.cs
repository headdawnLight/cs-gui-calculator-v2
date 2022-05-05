﻿using System;
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

        // Runs the number and comma buttons
        private void Number_Click(object sender, EventArgs e)
        {
            if ((numBox.Text == "0") || (isOperationPerformed))
                numBox.Clear();

            isOperationPerformed = false;

            Button numbers = (Button)sender;
            numBox.Text += numbers.Text;
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
            }
            else
            {
                operationPerformed = operators.Text;
                resultValue = Double.Parse(numBox.Text);
                operationLabel.Text = resultValue + operationPerformed;
                isOperationPerformed = true;
            }
        }

        // Runs the clear button
        private void ClearButton_Click(object sender, EventArgs e)
        {
            operationLabel.Text = "0";
            numBox.Text = "0";
            resultValue = 0;
        }

        // Runs the clear entry button
        private void ClearEntryButton_Click(object sender, EventArgs e)
        {
            numBox.Text = "0";
        }

        // Runs the backspace button
        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            if (numBox.Text.Length > 1)
            {
                numBox.Text = numBox.Text.Substring(0, (numBox.Text.Length - 1));
            }
            else
            {
                numBox.Text = "0";
            }
        }

        // Runs the comma button
        private void Comma_Click(object sender, EventArgs e)
        {
            if (CommaButton.Text == ",")
            {
                if (!numBox.Text.Contains(","))
                    numBox.Text += CommaButton.Text;
            }
            else
            {
                numBox.Text += CommaButton.Text;
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
            }
            else if (sign == -1)
            {
                numBox.Text = (textNum * (-1)).ToString();
            }
            else if (sign == 0)
            {
                numBox.Text = "0";
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
            resultValue = Double.Parse(numBox.Text);
            operationLabel.Text = resultValue + operationPerformed;
            isOperationPerformed = true;
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
            resultValue = Double.Parse(numBox.Text);
            operationLabel.Text = resultValue.ToString();
            isOperationPerformed = true;
        }        
    }
}