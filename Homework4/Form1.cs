using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise1
{
    public partial class Form1 : Form
    {
        //设置变量
        int flag = 0;//如果为零关闭闹铃，为1则打开
        int ihour; //小时
        int iminute; //分钟

        public Form1()
        {
            InitializeComponent();
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = 1; //开启闹铃flag变为1

            //获取用户输入的时间，并转化为整型
            try
            {
                string time = maskedTextBox.Text;
                string[] time_array = time.Split('时', '分');
                ihour = Int32.Parse(time_array[0]);
                iminute = Int32.Parse(time_array[1]);
            }
            catch (FormatException)
            {
                MessageBox.Show("您输入的时间有误,请重新输入 ");//重新输入闹铃时间
            }
            finally
            {
                //flag = 0;//闹铃关闭
            }
            //判断用户输入是否有误
            if ((ihour > 24 && ihour < 0) || (iminute > 60 && iminute < 0))
            {
                MessageBox.Show("您输入的时间有误,请重新输入 ");//重新输入闹铃时间
                flag = 0;//闹铃关闭
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = 0; //关闭闹铃，flag变为0
            MessageBox.Show("您已关闭闹铃 ");
        }

        int now_hour, now_minute;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                //获取用户输入的时间，并转化为整型
                string now_time = DateTime.Now.ToString("hh:mm:ss");
                string[] now_time_array = now_time.Split(':');
                now_hour = Int32.Parse(now_time_array[0]);
                now_minute = Int32.Parse(now_time_array[1]);

                //现在时间与用户输入时间进行对比
                if (now_hour == ihour && now_minute == iminute)
                {
                    MessageBox.Show("时间到了 ");
                    flag = 0;
                }
            }
        }
    }
}