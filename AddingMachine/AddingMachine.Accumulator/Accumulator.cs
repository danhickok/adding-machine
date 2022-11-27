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
        public const string ErrorDisplay = "-E-";
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
        private bool clearWasPreviousKey;
        private bool totalWasPreviousKey;
        private bool hasError;

        public Accumulator(int maxDigits, DecimalOptions decimalOption)
        {
            MaxDigits = maxDigits;
            DecimalOption = decimalOption;
            
            total = 0M;
            grandTotal = 0M;
            operand = 0M;
            multiplicationInitiated = false;
            divisionInitiated = false;
            clearWasPreviousKey = false;
            totalWasPreviousKey = false;
            hasError = false;
        }

        private void Reformat()
        {
            if (hasError)
            {
                _display = ErrorDisplay;
                return;
            }

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
                    if (hasError)
                        return;

                    if (numberOfDigitsEntered == 0)
                    {
                        _display = string.Empty;
                    }
                    if (numberOfDigitsEntered < MaxDigits)
                    {
                        Display += key;
                        numberOfDigitsEntered++;
                    }

                    clearWasPreviousKey = false; 
                    totalWasPreviousKey = false;
                    break;

                case '.':
                    if (hasError)
                        return;

                    if (!decimalEntered)
                    {
                        if (numberOfDigitsEntered == 0)
                        {
                            AddKey('0');
                        }
                        Display += key;
                        decimalEntered = true;
                    }

                    clearWasPreviousKey = false; 
                    totalWasPreviousKey = false;
                    break;

                case '*':
                    if (hasError)
                        return;

                    if (multiplicationInitiated)
                    {
                        try
                        {
                            Value = operand * Value;
                            CheckForOverflow();
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;
                        }
                    }

                    numberOfDigitsEntered = 0;
                    decimalEntered = false;

                    operand = Value;
                    multiplicationInitiated = true;
                    clearWasPreviousKey = false; 
                    totalWasPreviousKey = false;
                    break;

                case '/':
                    if (hasError)
                        return;

                    if (divisionInitiated)
                    {
                        try
                        {
                            Value = operand / Value;
                            CheckForOverflow();
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;
                        }
                    }

                    numberOfDigitsEntered = 0;
                    decimalEntered = false;

                    operand = Value;
                    divisionInitiated = true;
                    clearWasPreviousKey = false; 
                    totalWasPreviousKey = false;
                    break;

                case '-':
                    if (hasError)
                        return;

                    if (multiplicationInitiated)
                    {
                        try
                        {
                            Value = operand * Value;
                            multiplicationInitiated = false;
                            CheckForOverflow();
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;
                        }
                    }
                    else if (divisionInitiated)
                    {
                        try
                        {
                            Value = operand / Value;
                            divisionInitiated = false;
                            CheckForOverflow();
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;
                        }
                    }
                    else
                    {
                        total -= Value;
                        grandTotal -= Value;
                    }

                    numberOfDigitsEntered = 0;
                    decimalEntered = false;

                    clearWasPreviousKey = false;
                    totalWasPreviousKey = false;
                    break;

                case '+':
                    if (hasError)
                        return;

                    if (multiplicationInitiated)
                    {
                        try
                        {
                            Value = operand * Value;
                            multiplicationInitiated = false;
                            CheckForOverflow();
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;
                        }
                    }
                    else if (divisionInitiated)
                    {
                        try
                        {
                            Value = operand / Value;
                            divisionInitiated = false;
                            CheckForOverflow();
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;
                        }
                    }
                    else
                    {
                        total += Value;
                        grandTotal += Value;
                    }

                    numberOfDigitsEntered = 0;
                    decimalEntered = false;

                    clearWasPreviousKey = false;
                    totalWasPreviousKey = false;
                    break;

                case 'C':
                    if (hasError)
                        hasError = false;

                    if (clearWasPreviousKey)
                    {
                        multiplicationInitiated = false;
                        divisionInitiated = false;
                        operand = 0M;
                    }

                    Value = 0M;

                    numberOfDigitsEntered = 0;
                    decimalEntered = false;

                    clearWasPreviousKey = true;
                    totalWasPreviousKey = false;
                    break;

                case 'T':
                    if (hasError)
                        return;

                    if (totalWasPreviousKey)
                    {
                        try
                        {
                            Value = grandTotal;
                            CheckForOverflow();
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;
                        }
                        grandTotal = 0M;
                    }
                    else
                    {
                        try
                        {
                            Value = total;
                            CheckForOverflow();
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;
                        }
                        total = 0M;
                        totalWasPreviousKey = true;
                    }

                    numberOfDigitsEntered = 0;
                    decimalEntered = false;

                    clearWasPreviousKey = false;
                    break;
            }
        }

        private void CheckForOverflow()
        {
            if ((double)Value >= Math.Pow(10, MaxDigits) || (double)Value <= -Math.Pow(10, MaxDigits))
                throw new Exception("SizeOverflow");
        }
    }
}
