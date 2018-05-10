using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slot_Machine_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        decimal winTotal = 0m;      // Total winning accumulator
        decimal moneyTotal = 0m;    // Total money spent accumulator

        private void spinButton_Click(object sender, EventArgs e)
        {
            // Variables
            decimal money;
            decimal winning;
            

            // Create Random objects
            Random rand = new Random();

            // Get random indexes
            int index1 = rand.Next(imageList1.Images.Count);

            // Display image1
            pictureBox1.Image = imageList1.Images[index1];

            // Get another random number
            int index2 = rand.Next(imageList2.Images.Count);

            // Display image2
            pictureBox2.Image = imageList2.Images[index2];

            // Get another random number
            int index3 = rand.Next(imageList3.Images.Count);

            // Display image3
            pictureBox3.Image = imageList3.Images[index3];
            
            if (decimal.TryParse(moneyTextBox.Text, out money))
            {
                // Add the money to the total
                moneyTotal += money;

                if (index1 == index2 && index1 == index3 && index2 == index3)
                {
                    // Calculate winning
                    winning = money * 3;

                    // Add the winnings to the total
                    winTotal += winning;

                    // Display winnings
                    MessageBox.Show("You won " + winning.ToString("c"));
                }

                else if (index1 == index2 || index1 == index3 || index2 == index3)
                {
                    // Calculate winning
                    winning = money * 2;

                    // Add the winnings to the total
                    winTotal += winning;

                    // Display winnings
                    MessageBox.Show("You won " + winning.ToString("c"));
                }

                else if (index1 != index2 && index1 != index3 && index2 != index3)
                {
                    winning = 0;

                    // Display winnings
                    MessageBox.Show("You won " + winning.ToString("c"));
                }

                // Clear text box
                moneyTextBox.Clear();
                moneyTextBox.Focus();

            }
            else
            {
                MessageBox.Show("Invalid entry.");
                moneyTextBox.Focus();
            } // end else
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Display totals
            MessageBox.Show("You entered " + moneyTotal.ToString("c") + ". You won " + winTotal.ToString("c"));

            // Close the form
            this.Close();

        }
    }
}
