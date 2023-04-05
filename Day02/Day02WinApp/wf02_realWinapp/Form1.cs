using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf02_realWinapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 버튼 클릭 이벤트에 대한 처리메서드
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("버튼클릭", "클릭",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            return;
        }
    }
}
