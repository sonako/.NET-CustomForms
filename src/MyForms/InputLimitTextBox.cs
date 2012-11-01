using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyForms
{
    public class InputLimitTextBox : TextBox
    {
        /// <summary>
        /// 入力を許可する文字を表す正規表現
        /// </summary>
        protected Regex _acceptRegex = null;

        /// <summary>
        /// 入力許可する文字を判断する正規表現を設定する
        /// </summary>
        public Regex AcceptRegex
        {
            get
            {
                return _acceptRegex;
            }
            set
            {
                this._acceptRegex = value;
            }
        }


        protected override void WndProc(ref Message m)
        {
            const int WM_PASTE = 0x302; // ペースト時に送られるメッセージ

            if (m.Msg == WM_PASTE)
            {
                // ペーストの時は何もしない
                return;
            }

            base.WndProc(ref m);
        }


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (this._acceptRegex != null)
            {
                if (this._acceptRegex.IsMatch(e.KeyChar.ToString()) == false)
                {
                    // 入力許可の文字ではない場合、何もしない
                    return;
                }
            }

            base.OnKeyPress(e);
        }
    }
}
