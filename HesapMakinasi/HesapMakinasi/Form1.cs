using System.Windows.Forms;

namespace HesapMakinasi
{
    public partial class Form1 : Form
    {
        float s1, s2, result, m;// Variables to store first number, second number, result, and memory value
        int operation = 0;// Variable to store the type of operation
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // Allows the form to capture keyboard events
            //First of all before capturing KeyPress you have to set the KeyPreview
            //  property of the Win Form to true.
            //Unless you set it to true KeyPress will not be captured.

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);// Binds the All KeyDown event to Form1_KeyDown method
            // textBox1.KeyDown += new KeyEventHandler(Form1_KeyDown); // Binds the KeyDown event to Form1_KeyDown method
            // This, when any key is pressed on the form, the Form1_KeyDown method is executed.
            textBox1.ReadOnly = true;
            label1.Text = "Calculator\nMuhammed Süleyman Güney";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            operation = 1;// Indicates division operation
            s1 = float.Parse(textBox1.Text);
            textBox1.Clear(); //Ýlk kýsmý al ve TextBox ý temizler
        }
        private void button12_Click(object sender, EventArgs e)
        {
            operation = 2;// Indicates multiplication operation
            s1 = float.Parse(textBox1.Text);// Parses the text to a float and assigns to s1
            textBox1.Clear(); // Clears the textbox
        }

        private void button11_Click(object sender, EventArgs e)
        {
            operation = 3;// Indicates addition operation
            s1 = float.Parse(textBox1.Text);
            textBox1.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            operation = 4;// Indicates subtraction operation
            s1 = float.Parse(textBox1.Text);
            textBox1.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            operation = 5;// Indicates percentage operation
            s1 = float.Parse(textBox1.Text);
            textBox1.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            s2 = float.Parse(textBox1.Text);

            switch (operation)
            {
                case 1: result = s1 / s2; break; // Division
                case 2: result = s1 * s2; break; // Multiplication
                case 3: result = s1 + s2; break; // Addition
                case 4: result = s1 - s2; break; // Subtraction
                case 5: result = (s1 * s2) / 100; break; // Percentage
            }
            textBox1.Clear();
            textBox1.Text = result.ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            s1 = s2 = result = operation = 0;
        }

        private void button18_Click(object sender, EventArgs e)//Memorise
        {
            
            // Remember the value in valueToRemember
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                label1.Text = "Invalid input. Please try again.";
                
            }
            else
            {
                m = float.Parse((string)textBox1.Text);
                textBox1.Clear();
                label1.Text = "Calculator\nMuhammed Süleyman Güney";
                
                // Remember the valueToRemember
            }
            
        }

        private void button19_Click(object sender, EventArgs e)//ac
        {
            textBox1.Text = m.ToString();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) // Handles 0-9 keys above the "qwer" only numeric
            {
                textBox1.Text += (e.KeyCode - Keys.D0).ToString();
            }
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                textBox1.Text += (e.KeyCode - Keys.NumPad0).ToString();
                textBox1.SelectionStart = textBox1.Text.Length;

            }
            // ----------------

            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                button11_Click(null, null); // Calls the addition button click event
                textBox1.SelectionStart = textBox1.Text.Length;


            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                button14_Click(null, null);// Calls the subtraction button click event

            }
            else if (e.KeyCode == Keys.Multiply)
            {
                button12_Click(null, null);// Calls the multiplication button click event

            }
            else if (e.KeyCode == Keys.Divide)
            {
                button13_Click(null, null);// Calls the division button click event

            }
            else if (e.KeyCode == Keys.Enter)
            {
                button17_Click(null, null);// Calls the equals button click event
            }
            else if (e.KeyCode == Keys.Escape)
            {
                button20_Click(null, null);//Clear button
            }
            else if (e.KeyCode == Keys.Back) // Backspace button
            {
                if(textBox1.TextLength - 1 >=0)
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1);// Removes last character
                    textBox1.SelectionStart = textBox1.Text.Length; // Moves the cursor to the end of the text

                }
            }

            else if (e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.Decimal) // Handles numeric keypad comma key
            {
                button15_Click(null, null);
            }
            else
            {
                e.SuppressKeyPress = true;// Suppresses invalid key presses
            }

        }
    }
}
