using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int []size_all = { 16, 20, 24, 32, 40, 48, 64, 96, 128, 256 };
        string file_path = "";//文件路径
        int size=0;//输出尺寸,如果是-1代表全部输出
        string save_path = "";//存储路径
        string file_name = "";//真正使用的文件名
        string rel_file_name = "";//不会改变的文件名
        string file_name_aft = "_副本";//保存的文件名后缀
        int num_file = 1;//记录存取了几个文件
        int nums_size = 10;//一共有几个尺寸
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(56, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(252, 61);
            this.button2.TabIndex = 0;
            this.button2.Text = "开始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(202, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(217, 60);
            this.button3.TabIndex = 1;
            this.button3.Text = "选择文件";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "2.请选择要保存的大小:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "16x16",
            "20x20",
            "24x24",
            "32x32",
            "40x40",
            "48x48",
            "64x64",
            "96x96",
            "128x128",
            "256x256",
            "我全都要"});
            this.comboBox1.Location = new System.Drawing.Point(202, 132);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(190, 26);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "1.选择要转换的文件:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(543, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "当前未选取图片";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(727, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(22, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "3.请选择要保存的位置:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(202, 192);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(217, 60);
            this.button4.TabIndex = 8;
            this.button4.Text = "选择保存位置";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(467, 193);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(430, 40);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "默认保存后的名称为原名称+_副本\n如许修改名称请勾选此框并在下方文本框输入名称";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(493, 239);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 28);
            this.textBox1.TabIndex = 11;
            this.textBox1.Visible = false;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(782, 237);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 25);
            this.button5.TabIndex = 12;
            this.button5.Text = "确认";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(723, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "By.小僵大队长";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(56, 386);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(252, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(909, 464);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Png转Ico";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)//此按钮用来指定png文件
        {
           
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//不允许多选
            dialog.Title = "请选择文件";
            dialog.InitialDirectory = "C:/";//初始文件夹为c盘
            dialog.Filter = ".png类型|*.png";//文件筛选
            dialog.ShowHelp = false;
            
            if(dialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)//如果点了ok
            {
                file_path=dialog.FileName;//文件地址取值
                //if (size != 0 && save_path != "") button2.Enabled = true;//选择文件后可以开始
                
                file_name=dialog.SafeFileName;//获取文件名包含拓展名
                file_name = file_name.Replace(".png", "");//将后缀名去掉
                rel_file_name = file_name;//将文件名保存起来

                label3.Text = "你当前选取的图片为:";//选择图片后改变标签的内容
                label3.ForeColor = Color.Black;

                pictureBox1.Visible = true;//令图片可见
                pictureBox1.Load(file_path);//设置图片位置
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            if (size==-1)//如果选择全都保存则执行这个
            for(int i=0;i<nums_size;i++)
            {
                if(file_name_aft!="")//如果没起名则加编号在后面
                {
                    ConvertImageToIcon(file_path, save_path + "\\" + file_name + file_name_aft+num_file.ToString() + ".ico", new Size(size_all[i], size_all[i]));//执行转换
                    num_file++;
                }
                else ConvertImageToIcon(file_path, save_path+"\\"+file_name+file_name_aft+".ico", new Size(size_all[i], size_all[i]));
            }//执行转换
            else
            {
                
                    if (file_name_aft != "")//如果没起名则加编号在后面
                    {
                        ConvertImageToIcon(file_path, save_path + "\\" + file_name + file_name_aft + num_file.ToString() + ".ico", new Size(size, size));//执行转换
                        num_file++;
                    }
                    else ConvertImageToIcon(file_path, save_path + "\\" + file_name + file_name_aft + ".ico", new Size(size, size));
                //执行转换
            }
            progressBar1.Value = 100;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)//根据当前选项改变size的值
            {
                case 0:size = 16;break;
                case 1:size = 20; break;
                case 2:size = 24; break;
                case 3:size = 32; break;
                case 4:size = 40; break;
                case 5:size = 48; break;
                case 6:size = 64; break;
                case 7:size = 96; break;
                case 8:size =128; break;
                case 9:size =256; break;
                case 10:size = -1; break;
            }
            //if(file_path!=""&&save_path!="")button2.Enabled = true;//如果这时文件已经选好了则可以开始
        }

        private void button4_Click(object sender, EventArgs e)//选取保存路径
        {
            FolderBrowserDialog dialog= new FolderBrowserDialog();//分配一个选择文件夹实例
            dialog.ShowNewFolderButton = true;//用户可以创建新文件夹
            dialog.Description="请选择一个文件夹用来保存";//修改提示语句

            if(dialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                save_path=dialog.SelectedPath;//获取保存路径
                //textBox1.Text = save_path;
                //if (&&size != 0 && file_path != "") button2.Enabled = true;//选择文件后可以开始
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)//如果打够了则下面俩可见
            {
                textBox1.Visible = true;
                button5.Visible = true;
            }
            else//如果不打勾则不可见
            {
                textBox1.Visible = false;
                button5.Visible = false;
                file_name = rel_file_name;
                file_name_aft = "_副本";
            }
        }

        private void button5_Click(object sender, EventArgs e)//点击确定名称
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("名称不允许为空");
            }
            else//如果制定名称了则取指定名称并没有后缀
            {
                //if(file_path!=""&&size!=0&&save_path!="")button2.Enabled = true;
                file_name= textBox1.Text;
                file_name_aft = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                if (file_path != "" && save_path != "" && size != 0&&file_name_aft=="")
                    button2.Enabled = true;
                else if(textBox1.Text=="") 
                    button2.Enabled = false;
            }
            else
            {
                if (file_path != "" && save_path != "" && size != 0 )
                    button2.Enabled = true;
            }
            
        }
    }
}
