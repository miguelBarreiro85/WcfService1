using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ServiceGetAllHolidays.Holiday> Holidays = new List<ServiceGetAllHolidays.Holiday>();
            ServiceGetAllHolidays.HolidaySoapClient HolidayClient = new ServiceGetAllHolidays.HolidaySoapClient();
            Holidays = HolidayClient.GetAllHolidays((int)numericUpDown1.Value).ToList();
            foreach (ServiceGetAllHolidays.Holiday item in Holidays)
                 listBox1.Items.Add(item.Date);
        }
    }
}
