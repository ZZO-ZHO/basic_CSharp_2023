﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace wf13_bookrentalshop
{
    public partial class FrmGenre : Form
    {
        bool isNew = false;     // false(UPDATE) / true(INSERT)

        #region < 생성자 >
        public FrmGenre()
        {
            InitializeComponent();
        }
        #endregion


        #region < 이벤트 핸들러 >

        private void FrmGenre_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidation() != true) return;
            SaveData();     // 데이터 저장 / 수정
            RefreshData();  // 데이터 재조회
            ClearInputs();  // 입력창 클리어
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if ( isNew ==true)
            {
                MessageBox.Show("삭제할 데이터를 선택하세요.","오류",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show(this, "삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = "";

                    query = @"DELETE FROM divtbl 
                                    WHERE Division = @Division";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", TxtDivision.Text);
                    cmd.Parameters.Add(prmDivision);

                    var result = cmd.ExecuteNonQuery();     // INSERT, UPDATE, DELETE

                    if (result != 0)
                    {
                            // 저장성공
                        MessageBox.Show("삭제성공!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                            // 저장실패
                        MessageBox.Show("삭제실패!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
                catch (Exception)
                {
                    MessageBox.Show($"비정상적인 오류");
                    throw;
                }

            RefreshData();
            ClearInputs();
        }

        // 그리드뷰 클릭하면 발생이벤트
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)        // 아무것도 선택안하면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex];
                // MessageBox.Show(selData.ToString());
                // Debug.WriteLine(selData.ToString());
                Debug.WriteLine(selData.Cells[0].Value);
                Debug.WriteLine(selData.Cells[1].Value);
                TxtDivision.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();
                TxtDivision.ReadOnly = true;        // PK는 수정하면 안됨

                isNew = false;      // 수정
            }
        }

        #endregion


        #region < 커스텀 메서드 >

        private void RefreshData()
        {
            // DB divtbl 데이터 조회 DgvResult 뿌림
            try
            {
                // string connectionString = "Server=localhost;Port=3306;Database=bookrentalshop;Uid=root;Pwd=12345";
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var selQuery = @"SELECT Division, Names FROM divtbl";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(selQuery, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "divtbl");     // divtbl으로 dataset 접근가능

                    DgvResult.DataSource = ds.Tables[0];
                    // DgvResult.DataSource = ds;
                    // DgvResult.DataMember = "divtbl";

                    DgvResult.Columns[0].HeaderText = "장르코드";
                    DgvResult.Columns[1].HeaderText = "장르명";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ClearInputs()
        {
            TxtDivision.Text = TxtNames.Text = string.Empty;
            TxtDivision.ReadOnly = false;   // 신규일 땐 입력가능
            TxtDivision.Focus();
            isNew = true;   // 신규
        }

        // 입력검증
        private bool CheckValidation()
        {
            var result = true;
            var errorMsg = string.Empty;

            if (string.IsNullOrEmpty(TxtDivision.Text))
            {
                result = false;
                errorMsg = "● 장르코드를 입력하세요.\r\n";
            }

            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                result = false;
                errorMsg += "● 장르명을 입력하세요.\r\n";
            }

            if (result == false)
            {
                MessageBox.Show(errorMsg, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
            else
            {
                return result;
            }
        }

        private void SaveData()
        {
            // INSERT 부터 시작
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = "";

                    if (isNew)
                    {
                        query = @"INSERT INTO divtbl VALUES (@Division, @Names)";
                    }

                    else
                    {
                        query = @"UPDATE divtbl 
                                    SET Names = @Names
                                    WHERE Division = @Division";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", TxtDivision.Text);
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtNames.Text);
                    cmd.Parameters.Add(prmDivision);
                    cmd.Parameters.Add(prmNames);

                    var result = cmd.ExecuteNonQuery();     // INSERT, UPDATE, DELETE

                    if (result != 0)
                    {
                        // 저장성공
                        MessageBox.Show("저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // 저장실패
                        MessageBox.Show("저장실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"비정상적인 오류");
                throw;
            }

            RefreshData();
            ClearInputs();
        }

        #endregion

    }
}
