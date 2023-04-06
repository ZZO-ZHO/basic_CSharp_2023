using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf03_property
{
    public partial class FrmMain : Form
    {
        Random rnd = new Random();
        public FrmMain()
        {
            InitializeComponent();
            // 생성자에는 되도록 설정 넣지 말기
            // Form_Laod() 이벤트 핸들러에 작성
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            GbxMain.Text = "컨트롤 학습";
            var fonts = FontFamily.Families.ToList();
            foreach (var font in fonts)
            {
                CboFontFamily.Items.Add(font.Name);
            }

           
            NudFontSize.Minimum = 5;
            NudFontSize.Maximum = 40;

            TxtResult.Text = "Hello, WinForms";
        }
        // 글자 크기 스타일을 변경하는 메서드
        private void ChangeFontStyle()
        {
            if (CboFontFamily.SelectedIndex < 0)
            {
                CboFontFamily.SelectedIndex = 257;
            }
            FontStyle style = FontStyle.Regular;
            if (ChkBold.Checked == true)
            {
                style |= FontStyle.Bold;    //비트연산 or

            }
            if (ChkItelic.Checked == true)
            {
                style |= FontStyle.Italic;
            }

            decimal fontSize = NudFontSize.Value;

            TxtResult.Font = new Font((string)CboFontFamily.SelectedItem, (float)fontSize, style);

        }

        private void Changeindent()
        {
            if (RdoNormal.Checked)  // 라디오버튼 추가 이벤트
            {
                TxtResult.Text = TxtResult.Text.Trim();
            }
            else if (RdoIndent.Checked)
            {
                TxtResult.Text = "     " + TxtResult.Text;
            }
        }
        private void CboFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();

        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }


        private void ChkItelic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void NudFontSize_ValueChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PgbDummy.Value = TrbDummy.Value;
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { 
                Text = "Modal Form",
                Width = 300,
                Height = 200,
                Left = 10,
                Top = 20,
                BackColor = Color.Crimson,
            };
            frm.ShowDialog();   // 모달방식 자식창 새로 띄우기

        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Modaless Form",
                Width = 300,
                Height = 200,
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.GreenYellow
            };
            frm.Show();   // 모달리스 방식으로 자식창 새로 띄우기
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(TxtResult.Text);                        // 메세지박스는 기본이 모달
            //MessageBox.Show(TxtResult.Text, caption: "메시지창");    // 캡션
            //MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.AbortRetryIgnore);       // 버튼 추가
            //MessageBox.Show(TxtResult.Text, "메시지창",
            //                MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);  // 아이콘 추가.

            //MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
            //                , MessageBoxDefaultButton.Button2);                       // 기본 포커스 설정

            //MessageBox.Show(TxtResult.Text,"메시지창",MessageBoxButtons.YesNo, MessageBoxIcon.Warning
            //                ,MessageBoxDefaultButton.Button2,MessageBoxOptions.RightAlign); // 오른쪽 정렬

            //MessageBox.Show(text: TxtResult.Text, caption: "커스텀", icon:MessageBoxIcon.Asterisk,
            //                options:MessageBoxOptions.DefaultDesktopOnly);

        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rnd.Next(50).ToString());
            TreeToList();
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if(TrvDummy.SelectedNode != null)
            {
                TrvDummy.SelectedNode.Nodes.Add(rnd.Next(50, 100).ToString());
                TrvDummy.SelectedNode.Expand();     // 트리노드 하위
                TreeToList();
            }
        }

        void TreeToList()
        {
            LsvDummy.Items.Clear();
            foreach (TreeNode item in TrvDummy.Nodes)
            {
                TreeToList(item);
            }
        }

        private void TreeToList(TreeNode item)
        {
            LsvDummy.Items.Add(
                new ListViewItem(new[] { item.Text, item.FullPath.ToString() }));

            foreach (TreeNode node in item.Nodes)
            {
                TreeToList(node);
            }
        }

        private void RdoIndent_CheckedChanged(object sender, EventArgs e)
        {
            Changeindent();
        }

        private void RdoNormal_CheckedChanged(object sender, EventArgs e)
        {
            Changeindent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            PcbDummy.Image = Bitmap.FromFile("cat.png");
            
        }

        private void PcbDummy_Click(object sender, EventArgs e)
        {
            if (PcbDummy.SizeMode == PictureBoxSizeMode.Zoom)
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
