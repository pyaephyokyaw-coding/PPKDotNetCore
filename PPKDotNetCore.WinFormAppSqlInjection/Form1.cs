using PPKDotNetCore.Shared;

namespace PPKDotNetCore.WinFormAppSqlInjection
{
    public partial class Form1 : Form
    {
        private readonly DapperService _dapperService;
        public Form1()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //string query =
            //    $"Select * From [dbo].[Tbl_User] Where email = '{txtEmail.Text.Trim()}' and password = '{txtPassword.Text.Trim()}'";
            string query = $"Select * From [dbo].[Tbl_User] Where email = @Email and password = @Password";

            var model = _dapperService.QueryFirstOrDefault<UserModel>(query, new UserModel
            {
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim()
            });

            if (model is null)
            {
                MessageBox.Show("User doesn't Exit");
                return;
            }
            MessageBox.Show("Is Admin " + model.Email);
        }
    }
}

public class UserModel
{
    public string Email { get; set; }
    public bool IsAdmin { get; set; }
    public string Password { get; set; }
}
