using System.Windows;
using System.Windows.Controls;
using vk1;


namespace vk1
{
    public partial class LoginWindow : Window
    {
        private readonly AuthService _authService;
        private readonly DataContext _context;

        public LoginWindow()
        {
            InitializeComponent();
            _context = new DataContext(); // Создание нового экземпляра контекста базы данных
            _authService = new AuthService(_context); // Передача контекста в сервис аутентификации
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (_authService.Authenticate(username, password))
            {
                User user = _context.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    UserWindow userWindow = new UserWindow(user);
                    userWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User not found");
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    


    private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close(); 
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Создаем сервис аутентификации
            AuthService authService = new AuthService(new DataContext());

            // Вызываем метод Authenticate с обоими аргументами
            bool isAuthenticated = authService.Authenticate(username, password);

            return isAuthenticated;
        }
    }
}