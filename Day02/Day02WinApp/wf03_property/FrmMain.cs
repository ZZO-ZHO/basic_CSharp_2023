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
            if (CboFontFamily.SelectedIndex < 0) return;

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
    }
}
