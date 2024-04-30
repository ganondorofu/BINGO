using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BINGO
{

    public partial class Form1 : Form
    {
        private List<int> list; //listをクラスのメンバー変数に変更
        private List<int> result;
        private int rand;
        string Text = ""; // 初期化する
        private int num = 0;

        
        public Form1()
        {
            InitializeComponent();
            list = new List<int>(); //コンストラクター内で初期化
            result = new List<int>();
            
            for (int i = 1; i <= 75; i++) //リストに1-75まで追加する。そこから一つずつ消していき被らないようにする。
            {
                list.Add(i);
            }
            System.Random r = new System.Random();
            rand = r.Next(0, list.Count); // 乱数の範囲を修正
            num = list[rand];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Random r = new System.Random();
            if (list.Count > 0) // リストが空でないことを確認
            {
                if (1 <= num && num <= 15) { Text = "B"; } // アルファベットの振り分け
                else if (15 < num && num <= 30) { Text = "I"; } // else if を使用し、条件の重複を回避
                else if (30 < num && num <= 45) { Text = "N"; }
                else if (45 < num && num <= 60) { Text = "G"; }
                else if (60 < num && num <= 75) { Text = "O"; }
                list.Remove(num); // 最初のリストから削除
                result.Add(num); // あとから見返せるように出た数字を記録するリスト
                result.Sort();
                listBox1.Items.Clear(); // リストを数字順にするため一度リストを初期化する
                foreach (int item in result) // リストに一括追加
                {
                    listBox1.Items.Add(item);
                }
                label3.Text = num.ToString();
                label2.Text = Text;
                rand = r.Next(0, list.Count); // 乱数の範囲を修正
                num = list[rand];
                //label6.Text = num.ToString();
                Console.WriteLine(string.Join(", ", list));
                if (list.Count == 0) // 最初のリストが空になった時
                {
                    label5.Text = ("End"); // ビンゴが終わったことを表示する
                    label3.Text = ("");
                    label2.Text = ("");
                }
            }
        }
    }
}