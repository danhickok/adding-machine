using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingMachine
{
    public class Accumulator
    {
        private string currentDisplay;
        public string CurrentDisplay {
            get
            {
                return currentDisplay;
            }
            private set
            {
                currentDisplay = value;
                currentValue = decimal.Parse(currentDisplay);
            }
        }

        private decimal currentValue;
        public decimal CurrentValue
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

        private int numberOfDecimalPlaces;
        public int NumberOfDecimalPlaces
        {
            get
            {
                return numberOfDecimalPlaces;
            }
            set
            {
                numberOfDecimalPlaces = value;

            }
        }

        private readonly int maxDigits;
        private int numberOfDigitsEntered;
        private bool decimalEntered;
        private decimal operand;

        public Accumulator(int maxDigits)
        {
            currentDisplay = string.Empty;
            this.maxDigits = maxDigits;
            numberOfDigitsEntered = 0;
            decimalEntered = false;
        }

        private void Reformat()
        {
            currentDisplay = currentValue.ToString();
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
                    if (numberOfDigitsEntered < maxDigits)
                    {
                        CurrentDisplay += key;
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
                        CurrentDisplay += key;
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
