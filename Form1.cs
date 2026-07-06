using System.Diagnostics;
using System.IO;
using System.Management;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;

namespace 一键修改账户名密码
{
    public partial class Form1 : Form
    {
        private static readonly string ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "password.dat");

        public Form1()
        {
            InitializeComponent();
            // 显示当前登录用户名
            textBox3.Text = Environment.UserName;
            // 读取上次保存的密码
            LoadSavedPassword();
            MessageBox.Show("每修改一次账户名重启一次");
        }

        // 从配置文件读取已保存的密码
        private void LoadSavedPassword()
        {
            try
            {
                if (File.Exists(ConfigPath))
                {
                    textBox4.Text = File.ReadAllText(ConfigPath);
                }
            }
            catch { }
        }

        // 保存密码到配置文件
        private void SavePassword(string password)
        {
            try
            {
                File.WriteAllText(ConfigPath, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"密码记录保存失败：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 修改密码
        private async void button2_Click(object sender, EventArgs e)
        {
            string newPassword = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(newPassword))
            {
                ShowErrorMessage("请输入新密码！");
                return;
            }
            try
            {
                await Task.Run(() => ChangePassword(newPassword));
                textBox4.Text = newPassword;
                SavePassword(newPassword);
                MessageBox.Show("密码修改成功！");
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"密码修改失败：{ex.Message}");
            }
        }

        // 修改密码的方法
        private void ChangePassword(string newPassword)
        {
            using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(context, Environment.UserName);
                if (user == null)
                {
                    throw new Exception("找不到当前用户！");
                }
                user.SetPassword(newPassword);
                user.Save();
            }
        }

        // 重命名账户的方法
        private void RenameUserAccount(string oldName, string newName)
        {
            var mo = new ManagementObject($"Win32_UserAccount.Name='{oldName}',Domain='{Environment.UserDomainName}'");
            var inParams = mo.GetMethodParameters("Rename");
            inParams["Name"] = newName;
            var outParams = mo.InvokeMethod("Rename", inParams, null);

            if ((uint)outParams["ReturnValue"] != 0)
            {
                throw new Exception("用户名修改失败！");
            }
        }

        // 重启电脑的方法
        private void RestartComputer()
        {
            DialogResult dialogResult = MessageBox.Show("是否立即重启电脑？", "重启确认", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Process.Start("shutdown.exe", "-r -t 0");
            }
        }

        // 显示错误信息的方法
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                string oldName = Environment.UserName;
                string newName = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(newName))
                {
                    ShowErrorMessage("请输入新的用户名！");
                    return;
                }
                try
                {
                    RenameUserAccount(oldName, newName);
                    textBox3.Text = newName;
                    RestartComputer();
                }
                catch (Exception ex)
                {
                    ShowErrorMessage($"用户名修改失败：{ex.Message}");
                }
        }
    }
}
