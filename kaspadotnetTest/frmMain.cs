using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
//using Kaspadontnet.Clients;
//using Kaspawalletd;

namespace kaspadotnetTest
{
    public partial class frmMain : Form
    {
        protected Thread m_thread;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void Connect()
        {
            ThreadStart myThreadStart = new ThreadStart(KaspaWalletConnect);
            m_thread = new Thread(myThreadStart);
            m_thread.Start();
        }

        public void KaspaWalletConnect()
        {
            //var kaspawalletClient = new KaspawalletdClient();
            //var getBalanceRequest = new GetBalanceRequest { };
            //var getBalanceResponse = await kaspawalletClient.Client.GetBalanceAsync(getBalanceRequest);

            Console.WriteLine("Balance:");
            //Console.WriteLine(getBalanceResponse);
        }
    }
}
