using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    class ShellViewModel : Screen
    {
        public ShellViewModel()
        {
            Display = "0";
        }

        private string display;
        private string currentNumber = "";
        private string expression = "";

        public string Display
        {
            get { return display; }
            set
            {
                display = value;
                NotifyOfPropertyChange(() => Display);
            }
        }

        public void Button0() { PressButton('0'); }
        public void Button1() { PressButton('1'); }
        public void Button2() { PressButton('2'); }
        public void Button3() { PressButton('3'); }
        public void Button4() { PressButton('4'); }
        public void Button5() { PressButton('5'); }
        public void Button6() { PressButton('6'); }
        public void Button7() { PressButton('7'); }
        public void Button8() { PressButton('8'); }
        public void Button9() { PressButton('9'); }
        public void ButtonAdd() { PressButton('+'); }
        public void ButtonSubtract() { PressButton('-'); }
        public void ButtonMultiply() { PressButton('*'); }
        public void ButtonDivide() { PressButton('/'); }
        public void ButtonDecimal() { PressButton('.'); }

        public void ButtonClear()
        {
            currentNumber = "";
            expression = "";
            Display = "0";
        }

        public void ButtonEquals()
        {
            EvaluateExpression();
        }

        private void EvaluateExpression()
        {
            if (string.IsNullOrEmpty(expression)) return;

            double result;
            if (expression.Last() < '0')
            {
                string clipped = expression.Remove(expression.Length - 1);
                result = Convert.ToDouble(new DataTable().Compute(clipped, null));
            } 
            else
            {
                result = Convert.ToDouble(new DataTable().Compute(expression, null));
            }
            Display = result.ToString();
        }

        private void PressButton(char button)
        {
            switch (button) {
                case char c when (c >= '0' && c <= '9' || c == '.'): // numbers and decimal point

                    if (currentNumber == "0" || currentNumber == "")
                        if (button == '0')
                            return;

                    expression += button;
                    currentNumber += button;
                    Display = currentNumber;
                    break;
                case char c when (c < '0' && c != '.'): // operators
                    expression += button;
                    currentNumber = "";
                    EvaluateExpression();
                    break;
            }
        }



    }
}
