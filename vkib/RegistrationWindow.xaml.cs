using System;
using System.Windows;
using vk1;

namespace vk1
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            DateTime dateOfBirth;
            if (!DateTime.TryParse(txtDateOfBirth.Text, out dateOfBirth))
            {
                lblErrorMessage.Visibility = Visibility.Visible;
                lblErrorMessage.Text = "Invalid date format. Please use YYYY-MM-DD.";
                return;
            }
            string maritalStatus = cmbMaritalStatus.SelectedItem.ToString();

            using (var context = new DataContext())
            {

                if (context.Users.Any(u => u.Username == username))
                {
                    lblErrorMessage.Visibility = Visibility.Visible;
                    lblErrorMessage.Text = "Username is already taken. Please choose another one.";
                    return;
                }


                var newUser = new User
                {

                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Birthday = dateOfBirth,
                    MaritalStatus = maritalStatus
                };


                context.Users.Add(newUser);
                context.SaveChanges();
            }

            MessageBox.Show("Registration successful!");
            this.Close();
        }
    }
}

