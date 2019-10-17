using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RefrigeratorAppPractice3
{
    public partial class RefrigeratorUi : Form
    {
        public bool flag4=false;
        public Refrigerator refrigerator;
        public RefrigeratorUi()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                flag4 = true;
                refrigerator = new Refrigerator(Convert.ToDouble(maxWeightTakeTextBox.Text));
                maxWeightTakeTextBox.Clear();
            }
            catch (Exception m)
            {
                MessageBox.Show("Please input a double number only.");
            }
            

        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (flag4 == true)
            {
                bool flag1 = Regex.IsMatch(itemTextBox.Text, "[0-9]{1,}$");
                bool flag2 = Regex.IsMatch(weightTextBox.Text, "[0-9.]{1,}$");

                if (flag1 != true && flag2 != true)
                {
                    MessageBox.Show("Please input valid value for item and weight.");
                }
                else if (flag1 != true)
                {
                    MessageBox.Show("Please input valid Item");
                }
                else if (flag2 != true)
                {
                    MessageBox.Show("Please input valid Weight");
                }
                if (flag1 == true && flag2 == true)
                {
                    double item = Convert.ToDouble(itemTextBox.Text);
                    double weight = Convert.ToDouble(weightTextBox.Text);
                    if (item <= 0)
                    {
                        MessageBox.Show("Please input valid Item");
                    }
                    if (weight <= 0)
                    {
                        MessageBox.Show("Please input valid weight");
                    }
                    if (item > 0 && weight > 0)
                    {
                        bool flag3 = refrigerator.store(item, weight);
                        if (flag3 == true)
                        {
                            currentWeightTextBox.Text = Convert.ToString(refrigerator.getCurrentUsedCapacity());
                            remainingWeightTextBox.Text = Convert.ToString(refrigerator.getRemainingCapacity());
                            richTextBox.Text = refrigerator.GetData();
                        }
                        else
                        {
                            MessageBox.Show("Your given amount can't be stored because it will be over flown");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter maximum capacity first.");
                return;
            }

        }

    }
}
