using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace wf13_bookrentalshop
{
    public partial class FrmLogin : Form
    {
        private bool isLogined = false;     // 로그인이 성공했는지 변수

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            isLogined = LoginProcess();

            if(isLogined) this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Environment.Exit(0);
        }

        // 이게 없으면 X버튼이나 alt+F4 했을때 메인폼이 나타남
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isLogined == true)
            {
                Environment.Exit(0);
            }
        }
        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                BtnLogin_Click(sender,e);
            }
        }
        // DB userTbl정보확인 로그인처리
        private bool LoginProcess()
        {
            // Validation cheak(입력검증)
            if (string.IsNullOrEmpty(TxtUserId.Text))
            {
                MessageBox.Show("유저아이디를 입력하세요.","오류",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                MessageBox.Show("패스워드를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string strUserId = TxtUserId.Text;
            string strPassword = TxtPassword.Text;
            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=bookrentalshop;Uid=root;Pwd=12345";
                // DB처리 
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    #region << DB쿼리를 위한 구성 >>

                    string selQuery = @"SELECT userId
	                                         , password
                                          FROM usertbl
                                         WHERE userID = @userID
                                           AND password = @password;";
                    MySqlCommand selCmd = new MySqlCommand(selQuery, conn);

                    MySqlParameter prmUserID = new MySqlParameter("@userID", TxtUserId.Text);
                    MySqlParameter prmPassword = new MySqlParameter("@password", TxtPassword.Text);
                    selCmd.Parameters.Add(prmUserID);
                    selCmd.Parameters.Add(prmPassword);

                    #endregion

                    MySqlDataReader reader = selCmd.ExecuteReader();    //실행해서 userId, password
                    reader.Read();

                    strUserId = reader["userId"] != null ? reader["userId"].ToString() : "-";
                    strPassword = reader["password"] != null ? reader["password"].ToString(): "--";
                }
                //conn.Close();
                MessageBox.Show($"{strUserId} / {strPassword}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"로그인 정보가 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return false;
        }

        private void TxtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TxtPassword.Focus();
            }
        }

        private void TxtPassword_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoginProcess();
            }
        }
    }
}
