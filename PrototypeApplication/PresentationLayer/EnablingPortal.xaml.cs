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
    /// Interaction Logic for the page emulates a potential version of the Enabling Portal.
    /// The portal is nondescript within the design specification so connection and disconnection
    /// logic was added, as well as a live chat support box to demonstrate the live connection between
    /// the portal and the connected client.
    /// 
    /// </summary>
    public partial class EnablingPortal : Window
    {
        private FinanceApproval connectedClient;

        public EnablingPortal(FinanceApproval client)
        {
            InitializeComponent();

            connectedClient = client;

            connectedClient.confirmConntection("Connection Successful!");
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            //Aquire message from input box.
            string messageToSend = ChatInput.Text;

            //Add message to local message box.
            LiveSupportListBox.Items.Add("Me: " + messageToSend);

            //Send message to connected client.
            connectedClient.supportMessagefromServer(messageToSend);

            //Clear the box that sent the message.
            ChatInput.Clear();
        }

        public void supportMessagefromClient(string message)
        {
            //Add support's message to the box.
            LiveSupportListBox.Items.Add("DE-System(" + connectedClient.userId + "): " + message);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connectedClient.connectionClosedByPortal();
        }
    }
}
