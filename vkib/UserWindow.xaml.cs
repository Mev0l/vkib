using System;
using System.Windows;

namespace vk1
{
    public partial class UserWindow : Window
    {
        private readonly User _user;

        public UserWindow(User user)
        {
            InitializeComponent();
            _user = user;

           
            lblUsername.Text = _user.Username;
            lblFirstName.Text = _user.FirstName;
            lblLastName.Text = _user.LastName;
            lblDateOfBirth.Text = _user.Birthday.ToString("yyyy-MM-dd");
            lblMaritalStatus.Text = _user.MaritalStatus;
        }
    }
}