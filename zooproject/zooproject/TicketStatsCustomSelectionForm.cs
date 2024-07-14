using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zooproject
{
    public partial class TicketStatsCustomSelectionForm : Form
    {
        private TicketStatistics ticketStatistics;
        public TicketStatsCustomSelectionForm(TicketStatistics ticketstatistics)
        {
            InitializeComponent();
            this.ticketStatistics = ticketstatistics;
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            ticketStatistics.UpdateChart(dateTimePicker1.Value);
            this.Close();
        }

        private void TicketStatsCustomSelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ticketStatistics.ticketStatsCustomSelectionForm = null;
        }
    }
}
