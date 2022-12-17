using System.Globalization;
using System.Text.RegularExpressions;

namespace AddingMachine.Core
{
    public class Accumulator
    {
        public const string ErrorDisplay = "-E-";
        public static char DecimalChar { get; } =
            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

        public event EventHandler<DisplayChangedEventArgs>? DisplayChanged;
        public event EventHandler<NewTapeEntryPublishedEventArgs>? NewTapeEntryPublished;

        protected virtual void OnDisplayChanged(DisplayChangedEventArgs e) => DisplayChanged?.Invoke(this, e);
        protected virtual void OnNewTapeEntryPublished(NewTapeEntryPublishedEventArgs e) => NewTapeEntryPublished?.Invoke(this, e);

        private string _display = "";
        public string Display
        {
            get
            {
                return _display;
            }
            private set
            {
                _display = value;
                _ = decimal.TryParse(_display, out _value);
                OnDisplayChanged(new DisplayChangedEventArgs(_display));
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
                OnDisplayChanged(new DisplayChangedEventArgs(_display));
                return;
            }

            string formatString;
            switch (DecimalOption)
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
                    formatString = "N" + MaxDigits;
                    break;
            }

            _display = Value.ToString(formatString);

            // add decimal to end if no decimal in result
            if (!_display.Contains(DecimalChar))
                _display += DecimalChar;

            // floating point only
            if (DecimalOption == DecimalOptions.Float)
            {
                // remove trailing zeros
                _display = Regex.Replace(_display, "0+$", "");

                // position of decimal counts only digits, minus sign, and decimal
                var pattern = "^[-0-9" + DecimalChar + "]";
                var positionOfDecimal = Regex.Replace(_display, pattern, "").IndexOf(DecimalChar);

                // number of digits counts only digits and minus sign
                pattern = "[-0-9]";
                var numberOfDigits = Regex.Matches(_display, pattern).Count;

                if (positionOfDecimal > MaxDigits)
                {
                    // too many digits before the decimal
                    Value = 0M;
                    hasError = true;
                    _display = ErrorDisplay;
                }
                else if (numberOfDigits > MaxDigits)
                {
                    // round to necessary number of decimal places to stay within max digits
                    formatString = "N" + (MaxDigits - positionOfDecimal);
                    _display = Value.ToString(formatString);
                }
            }

            OnDisplayChanged(new DisplayChangedEventArgs(_display));
        }

        public void AddKey(char key)
        {
            if (hasError && key != 'C')
                return;

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

                    clearWasPreviousKey = false;
                    totalWasPreviousKey = false;
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

                    clearWasPreviousKey = false;
                    totalWasPreviousKey = false;
                    break;

                case '*':
                    if (multiplicationInitiated)
                    {
                        try
                        {
                            var previousDisplay = Display;
                            var previousValue = Value;

                            Value = operand * Value;
                            CheckForOverflow();

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = previousDisplay,
                                    Value = previousValue,
                                }));
                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    Operation = "="
                                }));
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    IsError = true
                                }));
                        }
                    }
                    else
                    {
                        Reformat();

                        OnNewTapeEntryPublished(
                            new NewTapeEntryPublishedEventArgs(new TapeEntry
                            {
                                Display = Display,
                                Value = Value,
                                Operation = "*"
                            }));
                    }

                    numberOfDigitsEntered = 0;
                    decimalEntered = false;

                    operand = Value;
                    multiplicationInitiated = true;
                    clearWasPreviousKey = false;
                    totalWasPreviousKey = false;
                    break;

                case '/':
                    if (divisionInitiated)
                    {
                        try
                        {
                            var previousDisplay = Display;
                            var previousValue = Value;

                            Value = operand / Value;
                            CheckForOverflow();

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = previousDisplay,
                                    Value = previousValue,
                                }));
                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    Operation = "="
                                }));
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    IsError = true
                                }));
                        }
                    }
                    else
                    {
                        Reformat();

                        OnNewTapeEntryPublished(
                            new NewTapeEntryPublishedEventArgs(new TapeEntry
                            {
                                Display = Display,
                                Value = Value,
                                Operation = "/"
                            }));
                    }

                    numberOfDigitsEntered = 0;
                    decimalEntered = false;

                    operand = Value;
                    divisionInitiated = true;
                    clearWasPreviousKey = false;
                    totalWasPreviousKey = false;
                    break;

                case '-':
                    if (multiplicationInitiated)
                    {
                        try
                        {
                            var previousDisplay = Display;
                            var previousValue = Value;

                            Value = operand * Value;
                            multiplicationInitiated = false;
                            CheckForOverflow();

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = previousDisplay,
                                    Value = previousValue,
                                }));
                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    Operation = "="
                                }));
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    IsError = true
                                }));
                        }
                    }
                    else if (divisionInitiated)
                    {
                        try
                        {
                            var previousDisplay = Display;
                            var previousValue = Value;

                            Value = operand / Value;
                            divisionInitiated = false;
                            CheckForOverflow();

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = previousDisplay,
                                    Value = previousValue,
                                }));
                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    Operation = "="
                                }));
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    IsError = true
                                }));
                        }
                    }
                    else
                    {
                        total -= Value;
                        grandTotal -= Value;
                        Reformat();

                        OnNewTapeEntryPublished(
                            new NewTapeEntryPublishedEventArgs(new TapeEntry
                            {
                                Display = Display,
                                Value = Value,
                                Operation = "-"
                            }));
                    }

                    numberOfDigitsEntered = 0;
                    decimalEntered = false;

                    clearWasPreviousKey = false;
                    totalWasPreviousKey = false;
                    break;

                case '+':
                    if (multiplicationInitiated)
                    {
                        try
                        {
                            var previousDisplay = Display;
                            var previousValue = Value;

                            Value = operand * Value;
                            multiplicationInitiated = false;
                            CheckForOverflow();

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = previousDisplay,
                                    Value = previousValue,
                                }));
                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    Operation = "="
                                }));
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    IsError = true
                                }));
                        }
                    }
                    else if (divisionInitiated)
                    {
                        try
                        {
                            var previousDisplay = Display;
                            var previousValue = Value;

                            Value = operand / Value;
                            divisionInitiated = false;
                            CheckForOverflow();

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = previousDisplay,
                                    Value = previousValue,
                                }));
                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    Operation = "="
                                }));
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    IsError = true
                                }));
                        }
                    }
                    else
                    {
                        total += Value;
                        grandTotal += Value;
                        Reformat();

                        OnNewTapeEntryPublished(
                            new NewTapeEntryPublishedEventArgs(new TapeEntry
                            {
                                Display = Display,
                                Value = Value,
                                Operation = "+"
                            }));
                    }

                    numberOfDigitsEntered = 0;
                    decimalEntered = false;

                    clearWasPreviousKey = false;
                    totalWasPreviousKey = false;
                    break;

                case 'C':
                    if (hasError || clearWasPreviousKey)
                    {
                        if (hasError)
                        {
                            total = 0M;
                            grandTotal = 0M;
                        }

                        hasError = false;
                        multiplicationInitiated = false;
                        divisionInitiated = false;
                        operand = 0M;
                    }

                    Value = 0M;

                    OnNewTapeEntryPublished(
                        new NewTapeEntryPublishedEventArgs(new TapeEntry
                        {
                            Display = Display,
                            Value = Value,
                            Operation = "C"
                        }));
                    OnNewTapeEntryPublished(
                        new NewTapeEntryPublishedEventArgs(new TapeEntry
                        {
                            Display = "",
                            Value = 0,
                            Operation = ""
                        }));

                    numberOfDigitsEntered = 0;
                    decimalEntered = false;

                    clearWasPreviousKey = true;
                    totalWasPreviousKey = false;
                    break;

                case 'T':
                    if (totalWasPreviousKey)
                    {
                        try
                        {
                            Value = grandTotal;
                            CheckForOverflow();

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    Operation = "GT"
                                }));
                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = "",
                                    Value = 0,
                                    Operation = ""
                                }));
                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = "",
                                    Value = 0,
                                    Operation = ""
                                }));
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    IsError = true
                                }));
                        }

                        grandTotal = 0M;
                    }
                    else
                    {
                        try
                        {
                            Value = total;
                            CheckForOverflow();

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    Operation = "T"
                                }));
                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = "",
                                    Value = 0,
                                    Operation = ""
                                }));
                        }
                        catch
                        {
                            hasError = true;
                            Value = 0M;

                            OnNewTapeEntryPublished(
                                new NewTapeEntryPublishedEventArgs(new TapeEntry
                                {
                                    Display = Display,
                                    Value = Value,
                                    IsError = true
                                }));
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
