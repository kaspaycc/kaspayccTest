using Kaspadontnet.Clients;
using Kaspawalletd;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class frmMain : Form
    {
        protected Thread m_thread=null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Connect()
        {
            ThreadStart myThreadStart = new ThreadStart(KaspaWalletConnect);
            m_thread = new Thread(myThreadStart);
            m_thread.Start();
        }

        public async void KaspaWalletConnect()
        {
            var kaspawalletClient = new KaspawalletdClient();
            var getBalanceRequest = new GetBalanceRequest { };
            var getBalanceResponse = await kaspawalletClient.Client.GetBalanceAsync(getBalanceRequest);

            Trace.WriteLine("Balance:");
            Trace.WriteLine(getBalanceResponse.Available);

            var newAddressRequest = new NewAddressRequest();
            //var newAddressResponse = kaspawalletClient.Client.NewAddressAsync(newAddressRequest);
            var newAddressResponse = await kaspawalletClient.Client.NewAddressAsync(newAddressRequest);

            Trace.WriteLine("New Address:");
            Trace.WriteLine(newAddressResponse.Address);
        }

        private void llBalance_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Connect();
        }
    }
}