using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingMachine.Accumulator
{
    public class Accumulator
    {
        public static char DecimalChar { get; } =
            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

        private string currentDisplay = "";
        public string Display {
            get
            {
                return currentDisplay;
            }
            private set
            {
                currentDisplay = value;
                _ = decimal.TryParse(currentDisplay, out currentValue);
            }
        }

        private decimal currentValue;
        public decimal Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                numberOfDigitsEntered = 0;
                decimalEntered = false;
                Reformat();
            }
        }

        private DecimalOptions decimalOption;
        public DecimalOptions DecimalOption
        {
            get
            {
                return decimalOption;
            }
            set
            {
                decimalOption = value;
                Value += 0;
                Reformat();
            }
        }

        private readonly int maxDigits;
        private int numberOfDigitsEntered;
        private bool decimalEntered;
        private decimal operand;

        public Accumulator(int maxDigits, DecimalOptions decimalOption)
        {
            this.maxDigits = maxDigits;
            this.decimalOption = decimalOption;
            Value = 0;
            operand = 0;
        }

        private void Reformat()
        {
            string formatString;
            switch (decimalOption)
            {
                case DecimalOptions.Zero:
                    formatString = "N0";
                    break;

                case DecimalOptions.Two:
                    formatString = "N2";
                    break;

                case DecimalOptions.Four:
                    formatString = "N4";
                    break;

                case DecimalOptions.Six:
                    formatString = "N6";
                    break;

                default:
                    formatString = "G";
                    break;
            }

            currentDisplay = Value.ToString(formatString);
            if ((decimalOption == DecimalOptions.Zero || decimalOption == DecimalOptions.Float)
                    && !currentDisplay.Contains(DecimalChar))
                currentDisplay += DecimalChar;
        }

        public void AddKey(char key)
        {
            switch (key)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    if (numberOfDigitsEntered == 0)
                    {
                        currentDisplay = string.Empty;
                    }
                    if (numberOfDigitsEntered < maxDigits)
                    {
                        Display += key;
                        numberOfDigitsEntered++;
                    }
                    break;

                case '.':
                    if (!decimalEntered)
                    {
                        if (numberOfDigitsEntered == 0)
                        {
                            AddKey('0');
                        }
                        Display += key;
                        decimalEntered = true;
                    }
                    break;

                case '*':
                    //TODO: multiply
                    break;

                case '/':
                    //TODO: divide
                    break;

                case '-':
                    //TODO: subtract
                    break;

                case '+':
                    //TODO: add
                    break;

                case 'C':
                    //TODO: clear entry/clear
                    break;

                case 'T':
                    //TODO: total/grand total
                    break;
            }
        }
    }
}
