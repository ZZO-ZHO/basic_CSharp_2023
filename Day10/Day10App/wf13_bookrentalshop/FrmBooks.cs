using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using wf13_bookrentalshop.Helpers;

namespace wf13_bookrentalshop
{
    public partial class FrmBooks : Form
    {
        bool isNew = false;     // false(UPDATE) / true(INSERT)

        #region < 생성자 >
        public FrmBooks()
        {
            InitializeComponent();
        }
        #endregion


        #region < 이벤트 핸들러 >

        private void FrmBooks_Load(object sender, EventArgs e)
        {
            isNew = true;
            RefreshData();
            LoadCboData();

            DtpReleaseDate.Format = DateTimePickerFormat.Custom;
            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
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
            // FK제약조건으로 지울수없는 데이터인지 먼저 확인
            using (MySqlConnection conn = new MySqlConnection(Commons.ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string strChkQuery = "DELETE FROM bookstbl WHERE BookIdx = @BookIdx";

                MySqlCommand chkCmd = new MySqlCommand(strChkQuery,conn);
                MySqlParameter prmBookIdx = new MySqlParameter("@BookIdx", TxtBookIdx.Text);
                chkCmd.Parameters.Add(prmBookIdx);

                var result = chkCmd.ExecuteScalar();

                if (result.ToString() != "0")
                {
                    MessageBox.Show("이미 대여중인 책입니다.", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
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
                    MySqlParameter prmDivision = new MySqlParameter("@Division", TxtBookIdx.Text);
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
                TxtBookIdx.Text = selData.Cells[0].Value.ToString();
                TxtAuthor.Text = selData.Cells[1].Value.ToString();
                CboDivision.SelectedValue = selData.Cells[2].Value;
                TxtName.Text = selData.Cells[4].Value.ToString();
                DtpReleaseDate.Value = (DateTime)selData.Cells[5].Value;
                TxtISBN.Text = selData.Cells[6].Value.ToString();
                NudPrice.Text = selData.Cells[7].Value.ToString();

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

                    var selQuery = @"SELECT b.bookIdx,
	                                       b.Author,
	                                       b.Division,
                                           b.Names AS DivNames,
	                                       b.Names,
	                                       b.ReleaseDate,
	                                       b.ISBN,
	                                       b.Price
                                      FROM bookstbl AS b
                                     INNER JOIN divtbl AS d
	                                    ON b.Division = d.Division
                                  ORDER BY b.bookIdx ASC;";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(selQuery, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "divtbl");     // divtbl으로 dataset 접근가능

                    DgvResult.DataSource = ds.Tables[0];
                    // 컬럼 헤더 제목
                    DgvResult.Columns[0].HeaderText = "번호";
                    DgvResult.Columns[1].HeaderText = "저자명";
                    DgvResult.Columns[2].HeaderText = "책장르";
                    DgvResult.Columns[3].HeaderText = "책장르";
                    DgvResult.Columns[4].HeaderText = "책제목";
                    DgvResult.Columns[5].HeaderText = "출판일자";
                    DgvResult.Columns[6].HeaderText = "ISBN";
                    DgvResult.Columns[7].HeaderText = "책가격";
                    // 컬럼 넓이 또는 보이기
                    DgvResult.Columns[0].Width = 50;
                    DgvResult.Columns[2].Visible = false;
                    DgvResult.Columns[5].Width = 78;
                    DgvResult.Columns[7].Width = 80;
                    // 컬럼정렬
                    DgvResult.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    DgvResult.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DgvResult.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"RefreshData() 비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCboData()
        {
            try
            {
                using(MySqlConnection conn = new MySqlConnection(Commons.ConnString))
                {
                    if(conn.State == ConnectionState.Closed) { conn.Open(); }
                    var query = "SELECT Division, Names FROM divtbl";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>();
                    while (reader.Read())
                    {
                        temp.Add(reader[0].ToString(), reader[1].ToString());   // (key) B001, (values) 공포/스릴러
                    }
                    
                    //콤보박스에 할당
                    CboDivision.DataSource = new BindingSource(temp, null);
                    CboDivision.DisplayMember = "Value";
                    CboDivision.ValueMember = "Key";
                    CboDivision.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"LoadCboData() 비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            TxtBookIdx.Text = TxtAuthor.Text = string.Empty;
            TxtName.Text = TxtName.Text = string.Empty;   // 신규일 땐 입력가능
            CboDivision.SelectedIndex = -1;
            DtpReleaseDate.Value = DateTime.Now;
            NudPrice.Value = 0;
            TxtBookIdx.Focus();
            isNew = true;   // 신규
        }

        // 입력검증
        private bool CheckValidation()
        {
            var result = true;
            var errorMsg = string.Empty;

            if (string.IsNullOrEmpty(TxtAuthor.Text))
            {
                result = false;
                errorMsg = "● 저자명를 입력하세요.\r\n";
            }

            if (CboDivision.SelectedIndex < 0)
            {
                result = false;
                errorMsg += "● 장르를 선택하세요.\r\n";
            }

            if (string.IsNullOrEmpty(TxtName.Text))
            {
                result = false;
                errorMsg = "● 책제목을 입력하세요.\r\n";
            }

            if (DtpReleaseDate.Value == null)
            {
                result = false;
                errorMsg = "● 출판일자를 선택하세요.\r\n";
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
                        query = @"INSERT INTO bookstbl
                                            (Author,
                                             Division,
                                             Names,
                                             ReleaseDate,
                                             ISBN,
                                             Price)
                                            VALUES
                                            (@Author,
                                            @Division,
                                            @Names,
                                            @ReleaseDate,
                                            @ISBN,
                                            @Price);";
                    }

                    else
                    {
                        query = @"UPDATE bookstbl
                                       SET Author = @Author,
	                                       Division = @Division,
	                                       Names = @Names,
	                                       ReleaseDate = @ReleaseDate,
                                           ISBN = @ISBN,
	                                       Price = @Price
                                     WHERE bookIdx = @bookIdx;";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmAuthor = new MySqlParameter("@Author", TxtAuthor.Text);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", CboDivision.SelectedValue.ToString());
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtName.Text);
                    MySqlParameter prmReleaseDate = new MySqlParameter("@ReleaseDate", DtpReleaseDate.Value);
                    MySqlParameter prmISBN = new MySqlParameter("@ISBN", TxtISBN.Text);
                    MySqlParameter prmPrice = new MySqlParameter("@Price", NudPrice.Value);

                    cmd.Parameters.Add(prmAuthor);
                    cmd.Parameters.Add(prmDivision);
                    cmd.Parameters.Add(prmNames);
                    cmd.Parameters.Add(prmReleaseDate);
                    cmd.Parameters.Add(prmISBN);
                    cmd.Parameters.Add(prmPrice);

                    if(isNew == false)
                    {
                        MySqlParameter prmBookIdx = new MySqlParameter("@bookIdx",TxtBookIdx.Text);
                        cmd.Parameters.Add(prmBookIdx);

                    }
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
