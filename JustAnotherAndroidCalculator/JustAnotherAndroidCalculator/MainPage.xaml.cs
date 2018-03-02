using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JustAnotherAndroidCalculator
{
    public partial class MainPage : ContentPage
    {
        private Func<double, double, double> _operationToPerform;

        private double? _firstNumber;
        private double? _secondNumber;
        private string _operatorText;

        private string _currentNumberAsString;
        private string CurrentNumberAsString
        {
            get { return _currentNumberAsString; }
            set
            {
                _currentNumberAsString = value;

                if (value.Length > 10)
                {
                    CurrentNumber.FontSize = 30;
                }
                else if (value.Length > 5)
                {
                   CurrentNumber.FontSize = 40;
                }

                CurrentNumber.Text = value;
            }
        }

        public MainPage()
        {
            InitializeComponent();
            _firstNumber = 0;
            CurrentNumberAsString = "0";
        }

        private void NumberClicked(object sender, EventArgs e)
        {
            var buttonText = (sender as Button).Text;
            CurrentEquationOverview.Text = CurrentEquationOverview.Text.TrimEnd(' ').TrimEnd('0').TrimEnd(CurrentNumberAsString.ToCharArray());

            CurrentNumberAsString = CurrentNumberAsString.ToLowerInvariant().Replace("infinity", "") + buttonText;

            var value = Double.Parse(CurrentNumberAsString);
            CurrentNumberAsString = value.ToString();

            if (_operationToPerform == null)
            {
                _firstNumber = value;
            }
            else
            {
                _secondNumber = value;
            }

            CurrentEquationOverview.Text = GetSummaryText();
        }

        private void OperatorClicked(object sender, EventArgs e)
        {
            var buttonText = (sender as Button).Text;
            if (_operationToPerform != null)
            {
                var result = CalculateEquation(_firstNumber, _secondNumber);
                _firstNumber = result;
            }
            else
            {
                _firstNumber = Double.Parse(CurrentNumberAsString);
            }

            switch (buttonText)
            {
                case "+":
                    _operationToPerform = CalculatorOperations.Addition;
                    break;
                case "-":
                    _operationToPerform = CalculatorOperations.Subtraction;
                    break;
                case "*":
                    _operationToPerform = CalculatorOperations.Multiplication;
                    break;
                case "/":
                    _operationToPerform = CalculatorOperations.Division;
                    break;
            }
            
            _operatorText = buttonText;
            CurrentNumberAsString = "0";
            _secondNumber = 0;
            CurrentEquationOverview.Text = GetSummaryText();
        }

        private double CalculateEquation(double? firstNumber, double? secondNumber)
        {
            if (_operationToPerform == null)
            {
                throw new InvalidOperationException("Operation was not set");
            }

            if (firstNumber == null || secondNumber == null)
            {
                throw new InvalidOperationException("Operands were not set");
            }

            return Math.Round(_operationToPerform.Invoke(firstNumber.Value, secondNumber.Value), 2);
        }

        private void EqualsClicked(object sender, EventArgs e)
        {
            if (_operationToPerform == null)
            {
                return;
            }

            _secondNumber = double.Parse(_currentNumberAsString);
            CurrentEquationOverview.Text = GetSummaryText();

            var result = CalculateEquation(_firstNumber, _secondNumber);
            CurrentNumberAsString = result.ToString();

            _firstNumber = result;
            _secondNumber = 0;
            _operationToPerform = null;
        }

        private void ClearClicked(object sender, EventArgs e)
        {
            _firstNumber = 0;
            _secondNumber = null;
            _operationToPerform = null;
            CurrentEquationOverview.Text = "0";
            CurrentNumberAsString = "0";
        }

        private string GetSummaryText()
        {
            if (_secondNumber != null)
            {
                return $"{_firstNumber} {_operatorText} {_secondNumber}";
            }
            else
            {
                return $"{_firstNumber} {_operatorText}";
            }
        }
    }
}
