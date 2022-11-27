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

        private string _display = "";
        public string Display {
            get
            {
                return _display;
            }
            private set
            {
                _display = value;
                _ = decimal.TryParse(_display, out _value);
            }
        }

        private decimal _value;
        public decimal Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                numberOfDigitsEntered = 0;
                decimalEntered = false;
                Reformat();
            }
        }

        private DecimalOptions _decimalOption;
        public DecimalOptions DecimalOption
        {
            get
            {
                return _decimalOption;
            }
            set
            {
                _decimalOption = value;
                Value += 0;
                Reformat();
            }
        }

        private readonly int MaxDigits;
        
        private int numberOfDigitsEntered;
        private bool decimalEntered;
        private decimal total;
        private decimal grandTotal;
        private decimal operand;
        private bool multiplicationInitiated;
        private bool divisionInitiated;

        public Accumulator(int maxDigits, DecimalOptions decimalOption)
        {
            MaxDigits = maxDigits;
            DecimalOption = decimalOption;
            total = 0M;
            grandTotal = 0M;
            operand = 0M;
            multiplicationInitiated= false;
            divisionInitiated = false;
        }

        private void Reformat()
        {
            string formatString;
            switch (_decimalOption)
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

            _display = Value.ToString(formatString);
            if ((_decimalOption == DecimalOptions.Zero || _decimalOption == DecimalOptions.Float)
                    && !_display.Contains(DecimalChar))
                _display += DecimalChar;
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
                        _display = string.Empty;
                    }
                    if (numberOfDigitsEntered < MaxDigits)
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
                    if (multiplicationInitiated)
                    {
                        Value = operand * Value;
                    }

                    operand = Value;
                    multiplicationInitiated = true;
                    break;

                case '/':
                    if (divisionInitiated)
                    {
                        Value = operand / Value;
                    }
                    
                    operand= Value;
                    divisionInitiated = true;
                    break;

                case '-':
                    if (multiplicationInitiated)
                    {
                        Value = operand * Value;
                        multiplicationInitiated = false;
                    }
                    else if (divisionInitiated)
                    {
                        Value = operand / Value;
                        divisionInitiated = false;
                    }
                    else
                    {
                        total -= Value;
                        grandTotal -= Value;
                    }
                    break;

                case '+':
                    if (multiplicationInitiated)
                    {
                        Value = operand * Value;
                        multiplicationInitiated = false;
                    }
                    else if (divisionInitiated)
                    {
                        Value = operand / Value;
                        divisionInitiated = false;
                    }
                    else
                    {
                        total += Value;
                        grandTotal += Value;
                    }
                    break;

                case 'C':
                    Value = 0M;
                    break;

                case 'T':
                    Value = total;
                    total = 0M;
                    break;
            }
        }
    }
}
