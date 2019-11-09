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
using BusinessLayer;

namespace PresentationLayer
{
    /// <summary>
    /// 
    /// Kieran Burns - 40272382
    /// 
    /// Interaction Logic for the Manager Mobile Message Box page, a page used to simulate the concept of
    /// a message inbox (such as email, text, etc) belonging to the store manager where all low/no stock
    /// alerts are to be sent.
    /// 
    /// </summary>
    public partial class ManagerMobileMessageBox : Window
    {
        public ManagerMobileMessageBox()
        {
            InitializeComponent();

            //Call the method that populates the ListBox used to represent the manager's message inbox.
            getMessages();
        }

        private void getMessages()
        {
            StockMessageFormulation messages = new StockMessageFormulation();

            //0 is input as the 2nd parameter as it refers to the store Id, which is not required when requesting 
            //manager messages from this class, only when requesting messages to send to central.
            ListBox recievedMessages = messages.getAllMessages(0,0);

            //Display all recieved formulated messages.
            //Spacings were added between each item for the sake of readability.
            foreach (var item in recievedMessages.Items)
            {
                MessageListBox.Items.Add(item);
                MessageListBox.Items.Add("");
            }
        }
    }
}
