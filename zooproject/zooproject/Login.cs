using Domain.Domain.Exceptions;
using zooproject.Domain.Domain.Exceptions;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Logic.Services.User;
using zooproject.Domain.Domain.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace zooproject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();
            PasswordTxtBx.PasswordChar = '*';
            PasswordTxtBx.MaxLength = 14;
            SetBackGroundImage("NotCat");
            TestLoginAnimals.Visible = true;
        }
        private void SetBackGroundImage(string ImageName)
        {
            Object rm = Properties.Resources.ResourceManager.GetObject(ImageName);
            Bitmap bitMap = (Bitmap)rm;
            Image image = bitMap;
            pictureBox_Login_CatNotCat.Image = image;
        }
        EmployeeManager employeeManager = new EmployeeManager(new DBEmployees());

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string hashed = employeeManager.GetHashByUserName(UsernameTxtBx.Text);
                string newhashed = Hash.HashPassword(PasswordTxtBx.Text);
                bool ree = Hash.VerifyHashedPassword(hashed, PasswordTxtBx.Text);
                if (employeeManager.CheckUsername(UsernameTxtBx.Text) == true && Hash.VerifyHashedPassword(hashed, PasswordTxtBx.Text) == true)
                {
                    Home HomeForm = new Home(employeeManager);
                    HomeForm.StartPosition = FormStartPosition.Manual;
                    HomeForm.Location = new Point(this.Location.X + -300, this.Location.Y);
                    this.Hide(); HomeForm.Show();
                }
            }
            catch (DomainException Ex)
            {
                MessageBox.Show(Ex.Message);
                Console.WriteLine(Ex);
            }
            catch (LoginException Ex)
            {
                MessageBox.Show(Ex.Message);
                Console.WriteLine(Ex);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                Console.WriteLine(Ex);
            }
        }

        private void TestLoginAnimals_Click(object sender, EventArgs e)
        {
            Home HomeForm = new Home(employeeManager);
            HomeForm.StartPosition = FormStartPosition.Manual;
            HomeForm.Location = new Point(this.Location.X + -300, this.Location.Y);
            this.Hide(); HomeForm.Show();
        }

        private void button_Login_SecretButton_Click(object sender, EventArgs e)
        {
            int CatCounter = Counter.GetCatCounter();
            if (CatCounter == 0) { SetBackGroundImage("Cat"); }
            if (CatCounter == 1) { SetBackGroundImage("NotCat"); }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                switch (MessageBox.Show(this, "Close Application?", "Closing",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes: Application.Exit(); break;
                    case DialogResult.No: e.Cancel = true; break;
                }
            }
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void PasswordTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginBtn.PerformClick();
            }
        }
    }
}