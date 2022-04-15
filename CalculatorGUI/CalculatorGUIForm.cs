using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CalculatorGUI
{
   public partial class CalculatorGUIForm : Form
   {
      public CalculatorGUIForm()
      {
         InitializeComponent();
      }

        /// <summary>
        /// Replaces any spaces with inputs in textbox1 and textbox2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(" ", "");
            textBox2.Text = textBox2.Text.Replace(" ", "");
        }

        /// <summary>
        /// Reverses text in textbox1 and textbox2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            char[] charArray = textBox1.Text.ToCharArray();
            Array.Reverse(charArray);
            textBox1.Text = String.Concat(charArray);

            charArray = textBox2.Text.ToCharArray();
            Array.Reverse(charArray);
            textBox2.Text = String.Concat(charArray);
        }

        /// <summary>
        /// divides the number in textbox1 by the number in textbox2
        /// and puts the result in textbox2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int numerator = int.Parse(textBox1.Text);
            int denominator = int.Parse(textBox2.Text);
            textBox2.Text = String.Concat("Remainder: ",numerator % denominator);
            textBox1.Text = String.Concat(numerator / denominator);
        }

        /// <summary>
        /// Performs Log Base 10 with the number in textbox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Concat(Math.Log10(double.Parse(textBox1.Text)));
        }

        /// <summary>
        /// Performs Log Base any using the number in textbox1 as input
        /// and the number in textbox2 as the base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Concat(Math.Log(double.Parse(textBox1.Text), double.Parse(textBox2.Text)));
        }

        /// <summary>
        /// Finds the minimum number between textbox1 and textbox2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            double temp1 = double.Parse(textBox1.Text);
            double temp2 = double.Parse(textBox2.Text);
            if(temp1 < temp2)
            {
                textBox2.Text = String.Concat("Minimum: ", temp1);
            }
            else if(temp2 < temp1)
            {
                textBox2.Text = String.Concat("Minimum: ", temp2);
            }
        }

        /// <summary>
        /// Finds the maximum number between textbox1 and textbox2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            double temp1 = double.Parse(textBox1.Text);
            double temp2 = double.Parse(textBox2.Text);
            if (temp1 > temp2)
            {
                textBox2.Text = String.Concat("Maximum: ", temp1);
            }
            else if (temp2 > temp1)
            {
                textBox2.Text = String.Concat("Maximum: ", temp2);
            }
        }

        /// <summary>
        /// Finds the power of the number in textbox1 using the
        /// number in textbox2 as the power
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            double temp1 = double.Parse(textBox1.Text);
            double temp2 = double.Parse(textBox2.Text);
            textBox2.Text = String.Concat("Answer: ", Math.Pow(temp1, temp2));
        }

        /// <summary>
        /// This Will find each non connected number three times
        /// from whats inputted into textbox1 and does the quadratic
        /// equation, putting the answer into textbox2.
        /// 
        /// Example:
        /// 12 12 12 will be A = 12, B = 12, C = 12
        /// 14ad 345sfdas43 will be A = 14, B = 345, C = 43
        /// 12x+18x+6 will be A = 12, B = 18, C = 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            string start = textBox1.Text;

            string temp = Regex.Match(start, @"\d+").Value;
            double A = double.Parse(temp);
            var regex = new Regex(Regex.Escape(temp));
            start = regex.Replace(start, string.Empty, 1);

            temp = Regex.Match(start, @"\d+").Value;
            double B = double.Parse(temp);
            regex = new Regex(Regex.Escape(temp));
            start = regex.Replace(start, string.Empty, 1);

            temp = Regex.Match(start, @"\d+").Value;
            double C = double.Parse(temp);
            
            string x1 = String.Concat("x1: ", Math.Round(((-B + Math.Sqrt(Math.Pow(B, 2) - 4 * A * C)) / (2 * A)), 2));
            string x2 = String.Concat(" x2: ", Math.Round(((-B - Math.Sqrt(Math.Pow(B, 2) - 4 * A * C)) / (2 * A)), 2));
            textBox2.Text = String.Concat(x1, x2);
        }

        /// <summary>
        /// Square roots the number in textbox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Concat(Math.Sqrt(double.Parse(textBox1.Text)));
        }

        /// <summary>
        /// Exits the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

/**************************************************************************
 * (C) Copyright 1992-2017 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/