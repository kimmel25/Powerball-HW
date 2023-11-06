using Powerball_Homework;

namespace PowerballFinal
{
    public partial class Form1 : Form
    {
        //Dov Kimmel, ID: T00505770
        //Yair Kimmel, ID: T00443600
        private PowerballModel model;
        List<int> userNumbers = new List<int>();

        public Form1()
        {
            InitializeComponent();
            model = new PowerballModel();
            List<int> winningNumbers = model.GetWinningNumbers();
            string winningNumbersString = string.Join(", ", winningNumbers);
            label2.Text = "Winning Numbers: " + winningNumbersString;
        }


        private bool TryParseTextBox(TextBox textBox, out int number)
        {
            if (int.TryParse(textBox.Text, out number) && number >= 1 && number <= 100)
            {
                return true;
            }
            return false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (TryParseTextBox(textBox1, out int num1) &&
               TryParseTextBox(textBox2, out int num2) &&
               TryParseTextBox(textBox3, out int num3) &&
               TryParseTextBox(textBox4, out int num4) &&
               TryParseTextBox(textBox5, out int num5))
            {
                userNumbers.AddRange(new[] { num1, num2, num3, num4, num5 });


            }

            bool isWinner = model.CheckPowerballNumbers(userNumbers);

            if (isWinner)
            {
                label1.Text = "Congrats! You won the Powerball!";
            }
            else
            {
                label1.Text = "Sorry, you lost the powerball!!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            model.ResetFields();
            List<int> winningNumbers = model.GetWinningNumbers();
            string winningNumbersString = string.Join(", ", winningNumbers);
            label2.Text = "Winning Numbers: " + winningNumbersString;
            label1.Text = "Please enter valid numbers from 1 - 99.";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label2.Text = " ";
            }
            if (!checkBox1.Checked)
            {
                List<int> winningNumbers = model.GetWinningNumbers();
                string winningNumbersString = string.Join(", ", winningNumbers);
                label2.Text = "Winning Numbers: " + winningNumbersString;
            }
        }
    }
}



