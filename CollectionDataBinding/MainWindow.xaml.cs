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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollectionDataBinding
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users;
        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
        }
        private void LoadUsers()
        {
            users = new List<User>(); 
            users.Add(new User() { Name = "Peter Parker" }); 
            users.Add(new User() { Name = "Tony Stark" }); 
            users.Add(new User() { Name = "Natasha Romanoff" }); 
            userslistbox.ItemsSource = users;
        }

        private void adduserbutton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(usertextbox.Text)) 
            {
                User user = new User() { Name = usertextbox.Text }; 
                users.Add(user); userslistbox.SelectedItem = user; UpdateView(); 
            }
        }      
        private void changeuserbutton_Click(object sender, RoutedEventArgs e)
        {
            if (userslistbox.SelectedItem != null)
            { User user = userslistbox.SelectedItem as User; 
                user.Name = usertextbox.Text; 
                userslistbox.SelectedItem = user; UpdateView(); }
        }

        private void delateuserbutton_Click(object sender, RoutedEventArgs e)
        {
            if (userslistbox.SelectedItem != null) 
            { users.Remove(userslistbox.SelectedItem as User); 
                usertextbox.Text = ""; UpdateView(); }
        }
        private void UpdateView()
        {
            userslistbox.Items.Refresh();
            if (users.Count > 0) { delateuserbutton.IsEnabled = true; changeuserbutton.IsEnabled = true; } 
            else { userslistbox.SelectedIndex = -1; delateuserbutton.IsEnabled = false; changeuserbutton.IsEnabled = false; }
        }

        private void userslistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userslistbox.SelectedItem != null) 
            { usertextbox.Text = (userslistbox.SelectedItem as User).Name; }
        }
    }
}
