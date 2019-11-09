using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// 
    /// Kieran Burns - 40272382
    /// 
    /// Interaction Logic for the page emulates a potential version of the Enabling Portal Connection,
    /// a nondescript finance portal from the design specification of this project. Logic for connecting and
    /// disconnecting was added as well as a live chat support box to demonstrate the live communication between
    /// the client and portal.
    /// 
    /// </summary>
    public partial class FinanceApproval : Window
    {

        private EnablingPortal currentConnection;
        private bool portalConnected = false;

        //Public Id variable for portal to identify connected client.
        public int userId;

        public FinanceApproval(int thisUserId)
        {
            InitializeComponent();

            userId = thisUserId;

            //Default portal log message.
            ConnectionLogListBox.Items.Add("Portal Connection: Awaiting Portal Connection...");
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //Check in case a connection is open to an instance of Enbaling portal,
            //if so, close it.
            for (int i = App.Current.Windows.Count - 1; i >= 1; i--)
            {
                App.Current.Windows[i].Close();
            }

            //Return to the previous page, closing this one.
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            //Any existing support messages between the portal and user.
            LiveSupportListBox.Items.Clear();

            if (!portalConnected)
            {
                //Clear log box for new message.
                ConnectionLogListBox.Items.Clear();

                //Confirm connection is in progress.
                ConnectionLogListBox.Items.Add("Attempting to connect to Enabling Portal...");

                //Mock connection for this prototype, would be a normal server connection in the real system.
                currentConnection = new EnablingPortal(this);
                currentConnection.Show();
            }
            else
            {
                MessageBox.Show("Already Connected!");
            }
        }

        private void disconnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (portalConnected)
            {
                //Clear log box for new message.
                ConnectionLogListBox.Items.Clear();

                //Confirm Connection is closing.
                ConnectionLogListBox.Items.Add("Disconnecting from Portal...");
                
                //Close connection to the portal.
                currentConnection.Close();

                //Clear the support messages between the portal and user.
                LiveSupportListBox.Items.Clear();

                //Set local variable with connection status to false (portal closed).
                portalConnected = false;

                //Confirm Connection is closing.
                ConnectionLogListBox.Items.Add("Portal Connection Closed!");
            }
            else
            {
                MessageBox.Show("No Current Portal Connection");
            }
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            if (portalConnected)
            {
                //Aquire message from input box.
                string messageToSend = ChatInput.Text;

                //Add message to local message box.
                LiveSupportListBox.Items.Add("Me: " + messageToSend);

                //Send message to connected portal.
                currentConnection.supportMessagefromClient(messageToSend);
            }
            else
            {
                MessageBox.Show("Connection required for Live Support");
            }

            //Clear the box that sent the message.
            ChatInput.Clear();
        }

        public void confirmConntection(string message)
        {
            //Display the returned message from Enabling.
            ConnectionLogListBox.Items.Add(message);

            //Set local variable with connection status to true (portal open).
            portalConnected = true;
        }

        public void supportMessagefromServer(string message)
        {
            //Add support's message to the box.
            LiveSupportListBox.Items.Add("Support: " + message);
        }

        public void connectionClosedByPortal()
        {
            //Clear log box for new message.
            ConnectionLogListBox.Items.Clear();

            //Display that connection has been closed.
            ConnectionLogListBox.Items.Add("Connection closed by portal");

            //Display that support has disconnected.
            LiveSupportListBox.Items.Add("");
            LiveSupportListBox.Items.Add("Support Disconnected!");

            //Set local variable with connection status to false (portal closed).
            portalConnected = false;
        }
    }
}
