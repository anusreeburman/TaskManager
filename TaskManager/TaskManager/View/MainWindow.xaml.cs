using System;
using System.Windows;
using System.Windows.Controls;


namespace TaskManager
{
    public static class Global
    {
        public static bool updatedTaskID = false;
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            tmDatePicker.Text= DateTime.Today.ToString("MM/dd/yyyy");
            id_TextBox.Text = string.Empty;

        }

        /// <summary>
        /// Method: id_TextBox_TextChanged
        /// Parameters: object, TextChangedEventArgs
        /// Description: Checks if the Create and Update button should be enabled/disabled. In this scenario, it will update a global variable that will update TaskID to 0
        /// and disable the buttons accordingly
        /// </summary>
        private void id_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (id_TextBox.Text.ToString() == string.Empty)
                Global.updatedTaskID = true;
            else
            {
                Global.updatedTaskID = false;
            }
        }
    }
}
