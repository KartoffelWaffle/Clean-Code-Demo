using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DesktopClient
{

    delegate void DisplayBroadcastMessage(List<string> msg);
    delegate void DisplayView(List<string> text);
    delegate string GetMessageToBroadcast();
    delegate void ShowMessage(string msg);
    delegate string GetAddItemString();
    delegate string GetAddQuantString();

    public partial class MainWindow : Window
    {
        private WPFClient client;
        private Task clientTask;
        private string ServerMessage;
        private int command;

        public MainWindow()
        {
            InitializeComponent();
            client = new WPFClient(AppendBroadcastMessage, getBroadcastMessage, ShowMessage);
            clientTask = Task.Run(client.Run);
        }

        private void AppendBroadcastMessage(List<string> msg)
        {
            Dispatcher.Invoke(() => ApplicationOutput.Text = "");
            msg.ForEach(s => Dispatcher.Invoke(() => ApplicationOutput.Text += s + "\n"));
            Dispatcher.Invoke(() => ApplicationOutput.ScrollToEnd());
        }

        private string getBroadcastMessage()
        {
            return this.ServerMessage;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        private void Add_New_Item_Click(object sender, RoutedEventArgs e)
        {
            TitleTextBox("Add Item To Stock");
            ToggleVisibility();
            ToggleRequestButton();

            SendRequestButton.Click += delegate { AddItem(); SendRequest(); };

            Dispatcher.Invoke(() =>
            {
                SendRequestButton.Visibility = Visibility.Visible;

                empName_lbl.Visibility = Visibility.Visible;
                EmployeeName_TextBox.Visibility = Visibility.Visible;

                itemId_lbl.Visibility = Visibility.Visible;
                ItemID_TextBox.Visibility = Visibility.Visible;

                item_name_lb.Visibility = Visibility.Visible;
                ItemName_TextBox.Visibility = Visibility.Visible;

                item_quant_lb.Visibility = Visibility.Visible;
                Quantity_TextBox.Visibility = Visibility.Visible;

                item_price_lb.Visibility = Visibility.Visible;
                Price_TextBox.Visibility = Visibility.Visible;
            });

            this.command = 1;

            if (this.ServerMessage != "::::")
            {
                ToggleRequestButton();
            }
            else
            {
                MessageBox.Show("please check you have entered all the values correctly");
            }
        }

        private void Add_Quantity_To_Stock_Click(object sender, RoutedEventArgs e)
        {
            TitleTextBox("Add Quantity To Item");
            ToggleVisibility();
            ToggleRequestButton();

            SendRequestButton.Click += delegate { AddQuantity(); SendRequest(); };

            Dispatcher.Invoke(() =>
            {
                SendRequestButton.Visibility = Visibility.Visible;

                empName_lbl.Visibility = Visibility.Visible;
                EmployeeName_TextBox.Visibility = Visibility.Visible;

                itemId_lbl.Visibility = Visibility.Visible;
                ItemID_TextBox.Visibility = Visibility.Visible;

                item_name_lb.Visibility = Visibility.Visible;
                ItemName_TextBox.Visibility = Visibility.Visible;

                item_quant_lb.Visibility = Visibility.Visible;
                Quantity_TextBox.Visibility = Visibility.Visible;
            });

            this.command = 2;
            this.ServerMessage =
                ItemID_TextBox.Text + ":" +
                ItemName_TextBox.Text + ":" +
                Quantity_TextBox.Text + ":" +
                EmployeeName_TextBox.Text;

            if (this.ServerMessage != ":::")
            {
                ToggleRequestButton();
            }
            else
            {
                MessageBox.Show("please check you have entered all the values correctly");
            }

        }

        private void Take_Quantity_From_Stock_Click(object sender, RoutedEventArgs e)
        {
            TitleTextBox("Take Quantity From Stock");
            ToggleVisibility();
            ToggleRequestButton();

            SendRequestButton.Click += delegate { TakeQuantity(); SendRequest(); };

            Dispatcher.Invoke(() =>
            {
                SendRequestButton.Visibility = Visibility.Visible;

                empName_lbl.Visibility = Visibility.Visible;
                EmployeeName_TextBox.Visibility = Visibility.Visible;

                itemId_lbl.Visibility = Visibility.Visible;
                ItemID_TextBox.Visibility = Visibility.Visible;

                item_name_lb.Visibility = Visibility.Visible;
                ItemName_TextBox.Visibility = Visibility.Visible;

                item_quant_lb.Visibility = Visibility.Visible;
                Quantity_TextBox.Visibility = Visibility.Visible;
            });

            this.ServerMessage =
                ItemID_TextBox.Text + ":" +
                ItemName_TextBox.Text + ":" +
                Quantity_TextBox.Text + ":" +
                EmployeeName_TextBox.Text;

            this.command = 3;

            if (this.ServerMessage != ":::")
            {
                ToggleRequestButton();
            }
            else
            {
                MessageBox.Show("please check you have entered all the values correctly");
            }

        }

        private void view_inventory_btn_Click(object sender, RoutedEventArgs e)
        {
            TitleTextBox("View Inventory");
            ToggleVisibility();

            this.ServerMessage = "";
            this.command = 4;

            SendRequest();
        }

        private void view_financial_reports_btn_Click(object sender, RoutedEventArgs e)
        {
            TitleTextBox("View Finacial Reports");
            ToggleVisibility();

            this.ServerMessage = "";
            this.command = 5;

            SendRequest();
        }

        private void view_transaction_logs_Click(object sender, RoutedEventArgs e)
        {
            TitleTextBox("View Transaction Logs");
            ToggleVisibility();

            this.command = 6;
            this.ServerMessage = "";

            SendRequest();
        }

        private void Get_Personal_Usage_Report_Click(object sender, RoutedEventArgs e)
        {
            TitleTextBox("View Personal Usage Report");
            ToggleVisibility();
            ToggleRequestButton();

            SendRequestButton.Click += delegate { ViewPersonalUsageReport(); SendRequest(); };

            Dispatcher.Invoke(() =>
            {
                SendRequestButton.Visibility = Visibility.Visible;

                empName_lbl.Visibility = Visibility.Visible;
                EmployeeName_TextBox.Visibility = Visibility.Visible;
            });

            this.command = 7;
            this.ServerMessage = EmployeeName_TextBox.Text;

            if (this.ServerMessage != "")
            {
                ToggleRequestButton();
            }
            else
            {
                MessageBox.Show("please enter a value for Employee Name");
            }

        }

        private void ToggleVisibility()
        {
            Dispatcher.Invoke(() => { ApplicationOutput.Text = "";

                SendRequestButton.Visibility = Visibility.Hidden;

                empName_lbl.Visibility = Visibility.Hidden;
                EmployeeName_TextBox.Visibility = Visibility.Hidden;

                itemId_lbl.Visibility = Visibility.Hidden;
                ItemID_TextBox.Visibility = Visibility.Hidden;

                item_name_lb.Visibility = Visibility.Hidden;
                ItemName_TextBox.Visibility = Visibility.Hidden;

                item_quant_lb.Visibility = Visibility.Hidden;
                Quantity_TextBox.Visibility = Visibility.Hidden;

                item_price_lb.Visibility = Visibility.Hidden;
                Price_TextBox.Visibility = Visibility.Hidden;

                SendRequestButton.Visibility = Visibility.Hidden;

            });
        }

        private void TitleTextBox(string name)
        {
            MenuTitleBlock.Text = name;
        }

        private void ToggleRequestButton()
        {
            Dispatcher.Invoke(() => SendRequestButton.IsEnabled = !SendRequestButton.IsEnabled);
        }

        private void AddItem()
        {
            this.ServerMessage =
                ItemID_TextBox.Text + ":" +
                ItemName_TextBox.Text + ":" +
                Price_TextBox.Text + ":" +
                Quantity_TextBox.Text + ":" +
                EmployeeName_TextBox.Text;
        }

        private void AddQuantity()
        {
            this.ServerMessage =
                ItemID_TextBox.Text + ":" +
                ItemName_TextBox.Text + ":" +
                Quantity_TextBox.Text + ":" +
                EmployeeName_TextBox.Text;
        }

        private void TakeQuantity()
        {
            this.ServerMessage =
                ItemID_TextBox.Text + ":" +
                ItemName_TextBox.Text + ":" +
                Quantity_TextBox.Text + ":" +
                EmployeeName_TextBox.Text;
        }

        private void ViewFinancialReport()
        {
            this.ServerMessage = "";
        }

        private void ViewInventoryReport()
        {
            this.ServerMessage = "";
        }

        private void ViewPersonalUsageReport()
        {
            this.ServerMessage = EmployeeName_TextBox.Text;
        }

        private void ViewTransactionLog()
        {
            this.ServerMessage = "";
        }

        private void SendRequest()
        {
            client.AddCommand(this.command);
        }

        private void RapidRequestsButtonClick(object sender, RoutedEventArgs e)
        {
            Task.Run(client.RapidRequests);
        }
    }
}
