using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDA_AUTO_COMPILE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }


        public void button1_Click(object sender, EventArgs e)
        {
            string[] names = new string[] {
                "#export CC=/usr/bin/gcc\n",
                "#在编译之前要确定的东西，首先要制定好customer，logo，IR\n",
                "#其次，要make mconfig 并选好要编译的第一个屏参，比如本文件为CLAA170EA10_1280x1024\n",
                "#最后本脚本一共有七处需要手动修改，有些可以不改，加了*的是必改\n",
                "#在编译之前要先生成存放软件的目录，请先看‘需要改一’\n",
                "\n",
                "#需要改一 \n",
                "#OUT_BIN_PATH：这个是生成在根目录的文件夹，里面存放软件，可以不改\n",
                "OUT_BIN_PATH=./YDG_SOFTWARE\n",
                "\n",
                "#需要改二 *\n",
                "#OUT_BIN_NAME：这个是生成软件的文件名\n",
                "#WORK_PATH：是你代码的根目录\n",
                "OUT_BIN_NAME=",textBox2.Text,"\n",
                "WORK_PATH=",textBox1.Text,"\n",
                "\n",
                "#需要改三 *\n",
                "#以下四个是customize.h 中你建立好的customer，用于切换customize.h中的4:3,16:9\n",
                "C4_3COSTOMER_OPEN=\"#define ",textBox3.Text,"\"\n",
                "C4_3COSTOMER_CLOSE=\"//#define ",textBox3.Text,"\"\n",
                "C16_9COSTOMER_OPEN=\"#define ",textBox4.Text,"\"\n",
                "C16_9COSTOMER_CLOSE=\"//#define ",textBox4.Text,"\"\n",
                "\n",
                "#需要改四 *\n",
                "#iConfigNumber：是最大屏参数，若当前最大为14，则填15\n",
                "iConfigNumber=",Get_Total_Panel_Number(),
                "\n\n",
                "#需要改五 *\n",
                "\n",
                "#i4_3Index：是16:9的第一个屏参的编号，用于切换customize.h中的4:3,16:9\n",
                "i4_3Index=",Get_4_3_Panel_Number(),
                "\n\n########################\n",
                "#\n",
                "# Generate Panel data\n",
                "#\n",
                "########################\n",
                "#############################################   4:3   #########################################\n",
                "\n",
                "#注意panel_name中的x按照屏参名来写\n",
                "#注意panel_n_UP中的x一律大写\n",
                "#注意resolution中的x一律小写\n",
                "\n",
            };
            string[] names1 = new string[] {
                "#############################################   16:9   #########################################\n\n",
            };

            string[] names2 = new string[] {
                "#=======================================================\n",
                "echo \"====================================================\"\n",
                "echo \"Start build YDG SOFTWARE \"\n",
                "\n",
                "function error_exit {\n",
                "  echo \"$1\" 1>&2\n",
                "  exit 1\n",
                "}\n",
                "#===================================================\n",
                "\n",
                "iBuildIndex=0\n",
                "iBuildIndex1=0\n",
                "iBuildIndex2=0\n",
                "\n",
                "#首先查找屏参分辨率中有无1440X900，有的话提醒放在最后一个编译，没有就不管\n",
                "\n",
                "while [ \"$iBuildIndex1\" != \"$iConfigNumber\" ]\n",
                "do	\n",
                "        Res=${resolution[$iBuildIndex1]}\n",
                "        icc=$(($iConfigNumber-1))\n",
                "        if [ \"$Res\"x = \"1440x900\"x ]\n",
                "        then\n",
                "        if [ \"$iBuildIndex1\" != \"$icc\" ]\n",
                "                then\n",
                "                error_exit \"1440x900应该放在最后一个编译 \"\n",
                "                fi\n",
                "        fi\n",
                "        iBuildIndex1=$(($iBuildIndex1+1))\n",
                "done\n",
                "\n",
                "echo \"====================================================\"\n",
                "echo \"Start build YDG SOFTWARE \"\n",
                "#需要改六 *\n",
                "#需要改的地方是里面的JEDIA,MIRROR_JEDIA,MIRROR_VESA,VESA\n",
                "#比如正常文件夹名为CSTM_KL_ENG_T_R5L_03C_05_GENERAL_1440x900_IRCVT00BF_KPD_LUCKY_JEDIA_20190417\n",
                "#则要改成	JEDIA=\"CSTM_KL_ENG_T_R5L_03C_\"$Panel_name\"_IRCVT00BF_KPD_LUCKY_JEDIA_20190417\"，其余三个类似\n",
                "\n",
                "#第一步建立生成目录\n",
                "\n",
                "rm -v -rf ${OUT_BIN_PATH}\n",
                "mkdir -v ${OUT_BIN_PATH}\n",
                "while [ \"$iBuildIndex2\" != \"$iConfigNumber\" ]\n",
                "do\n",
                "       Panel_name=${panel_name[$iBuildIndex2]}\n",
                "       OutBinPath=${OUT_BIN_PATH}/$Panel_name\n",
                "       JEDIA=\"",textBox7.Text,"\"$Panel_name\"",textBox8.Text,"\"\n",
                "       MIRROR_JEDIA=\"",textBox7.Text,"\"$Panel_name\"",textBox9.Text,"\"\n",
                "       MIRROR_VESA=\"",textBox7.Text,"\"$Panel_name\"",textBox10.Text,"\"\n",
                "       VESA=\"",textBox7.Text,"\"$Panel_name\"",textBox11.Text,"\"\n",
                "\n",
                "   mkdir -v $OutBinPath\n",
                "   mkdir -v $OutBinPath/$JEDIA\n",
                "   mkdir -v $OutBinPath/$MIRROR_JEDIA\n",
                "   mkdir -v $OutBinPath/$MIRROR_VESA\n",
                "   mkdir -v $OutBinPath/$VESA\n",
                "   iBuildIndex2=$(($iBuildIndex2+1))\n",
                "done\n\n",
                "chmod -R 777 ${OUT_BIN_PATH}\n",
                "\n",
                "while [ \"$iBuildIndex\" != \"$iConfigNumber\" ]\n",
                "do\n",
                "    echo \"-----------------------------------------\"\n",
                "    echo \"[iBuildIndex=$iBuildIndex]\"\n",
                "\n",
                "    #第二步，查看customer是4:3还是16:9,\n",
                "    # -lt:<      -gt:>       -ge:>=      -le:<=     -eq :==\n",
                "    cd ~/$WORK_PATH/aps/customer/s2tek/sub_customer/s2tek/s2tek\n",
                "    pwd\n",
                "\n",
                "    if [ $iBuildIndex -eq $i4_3Index ]\n",
                "    then\n",
                "        sed -i \"s!$C4_3COSTOMER_OPEN!$C4_3COSTOMER_CLOSE!g\" customize.h\n",
                "        sed -i \"s!$C16_9COSTOMER_CLOSE!$C16_9COSTOMER_OPEN!g\" customize.h\n",
                "     fi\n",
                "    #第三步修改mconfig.config	\n",
                "    Panel_name=${panel_name[$iBuildIndex]}\n",
                "    Panel_name_1=${panel_name[$iBuildIndex-1]}\n",
                "    Panel_n_UP=${panel_n_UP[$iBuildIndex]}\n",
                "    Panel_n_UP_1=${panel_n_UP[$iBuildIndex-1]}\n",                      
                "    Resolution=${resolution[$iBuildIndex]}\n",
                "    Resolution_1=${resolution[$iBuildIndex-1]}\n",
                "    OutBinPath=${OUT_BIN_PATH}/$Panel_name\n",
                "    cd ~/$WORK_PATH/\n",
                "    pwd\n",
                "\n",
               "        if [ $iBuildIndex -gt 0 ]\n",
               "        then\n",
               "                echo \"修改mconfig.config\"\n",
               "                #echo \"[Panel_name=$Panel_name]\"\n",
               "                #echo \"[Panel_name_1=$Panel_name_1]\"\n",
               "                sed -i \"s/$Panel_name_1/$Panel_name/g\" mconfig.config\n",
               "                sed -i \"s/$Panel_n_UP_1/$Panel_n_UP/g\" mconfig.config\n",               
               "                sed -i \"s/$Resolution_1/$Resolution/g\" mconfig.config\n",
               "        fi\n",
               "        #第四步确定屏参,按照如下顺序编写正屏_JEIDA,倒屏_JEDIA,倒屏_VESA,正屏_VESA\n",
               "        #并且要把编好的软件放到对应的文件夹\n",
               "        # Get panel name\n",
               "\n",
               "    echo \"Panel_name=$Panel_name\"\n",
               "    iIndex=0\n",
               "    PANEL_INVERT_0=\"#define	PANEL_INVERT	0\"\n",
               "    PANEL_INVERT_1=\"#define	PANEL_INVERT	1\"\n",
               "    PANEL_LVDS_TYPE_0=\"#define	PANEL_LVDS_TYPE	 0\"\n",
               "    PANEL_LVDS_TYPE_2=\"#define	PANEL_LVDS_TYPE	 2\"\n",
               "#需要改七*\n",
               "#可以直接复制‘需要改六’的JEIDA...   此处的作用的把编好的软件放到对应文件夹\n",
               "    JEDIA=\"",textBox7.Text,"\"$Panel_name\"",textBox8.Text,"\"\n",
               "    MIRROR_JEDIA=\"",textBox7.Text,"\"$Panel_name\"",textBox9.Text,"\"\n",
               "    MIRROR_VESA=\"",textBox7.Text,"\"$Panel_name\"",textBox10.Text,"\"\n",
               "    VESA=\"",textBox7.Text,"\"$Panel_name\"",textBox11.Text,"\"\n",
               "    while [ $iIndex -le 4 ]\n",
               "    do\n",
               "                cd ~/$WORK_PATH/aps/customer/s2tek/public/panel/${Panel_name}\n",
               "                pwd\n",
               "\n",
               "    case ${iIndex} in\n",
               "        0)\n",
               "           echo 'This is 正屏_JEDIA'\n",
               "           sed -i \"/PANEL_INVERT/c$PANEL_INVERT_0\"  panel_setting.h\n",
               "           sed -i \"/PANEL_LVDS_TYPE/c$PANEL_LVDS_TYPE_0\"  panel_setting.h\n",
               "           cd ~/$WORK_PATH\n",
               "           make clean ; make -j\n",
               "           cp -v  ./mergedir/$OUT_BIN_NAME  $OutBinPath/$JEDIA/  ||  error_exit \"cannot copy *.bin file to directory\"\n",
               "       ;;\n",
               "       1)\n",
               "            echo 'This is 倒屏_JEDIA'\n",
               "            sed -i \"/PANEL_INVERT/c$PANEL_INVERT_1\" panel_setting.h\n",
               "            sed -i \"/PANEL_LVDS_TYPE/c$PANEL_LVDS_TYPE_0\" panel_setting.h\n",
               "            cd ~/$WORK_PATH\n",
               "            make -j\n",
               "            cp -v  ./mergedir/$OUT_BIN_NAME  $OutBinPath/$MIRROR_JEDIA/ || error_exit \"cannot copy *.bin file to directory\"\n",
               "        ;;\n",
               "        2)\n",
               "            echo 'This is 倒屏_VESA'\n",
               "            sed -i \"/PANEL_INVERT/c$PANEL_INVERT_1\" panel_setting.h\n",
               "            sed -i \"/PANEL_LVDS_TYPE/c$PANEL_LVDS_TYPE_2\" panel_setting.h\n",
               "            cd ~/$WORK_PATH\n",
               "            make -j\n",
               "            cp -v  ./mergedir/$OUT_BIN_NAME  $OutBinPath/$MIRROR_VESA/ || error_exit \"cannot copy *.bin file to directory\"\n",
               "        ;;\n",
               "        3)\n",
               "            echo 'This is 正屏_VESA'\n",
               "            sed -i \"/PANEL_INVERT/c$PANEL_INVERT_0\" panel_setting.h\n",
               "            sed -i \"/PANEL_LVDS_TYPE/c$PANEL_LVDS_TYPE_2\" panel_setting.h\n",
               "            cd ~/$WORK_PATH\n",
               "            make -j\n",
               "            cp -v  ./mergedir/$OUT_BIN_NAME  $OutBinPath/$VESA/ || error_exit \"cannot copy *.bin file to directory\"\n",
               "        ;;\n",
               "        *)\n",
               "            echo '编译完成'\n",
               "        ;;\n",
               "    esac\n",
               "    iIndex=$(($iIndex+1))\n",
               "    done\n",
               "\n",
               "    iBuildIndex=$(($iBuildIndex+1))\n",
               "done\n",
               "\n",
               "#cd configs/melody",
            };
            using (StreamWriter sw = new StreamWriter("ydg_make_all_bin.sh"))
            {
                List<String> list = new List<String>();
                int a = 0;
                foreach (string s in names)
                {
                    list.Add(s);

                }
                richTextBox1.Text = richTextBox1.Text.TrimEnd((char[])"\r\n".ToCharArray());
                //richTextBox1.Text = Regex.Replace(richTextBox1.Text, @"\n...", "\n");
                
                foreach (String s in richTextBox1.Lines)
                {
                    list.Add("# " + s + "\n");
                    list.Add("panel_name[" + a + "]=" + s + "\n");
                    list.Add("panel_n_UP[" + a + "]=" + s.ToUpper() + "\n");
                    //查找本行的字符串中有没有_，没有就跳过
                    int x = s.IndexOf("_");
                    if (x == -1) continue;
                    //将本行字符串分隔成2个，以_分隔
                    //判断字符串中是否含有_有的话就分隔，直到没有为止
                    string[] sArray = new string[100];
                    if (s.IndexOf("_") > -1)
                    {
                        sArray = s.Split(new char[] { '_' }, 2);
                    }

                    //int y = sArray[1].ToString().IndexOf("_");
                    //if (y == -1) continue;

                    while (sArray[1].ToString().IndexOf("_") > -1)
                    {
                        sArray = sArray[1].ToString().Split(new char[] { '_' }, 2);
                    }
                    if (s != "\0")
                        list.Add("resolution[" + a + "]=" + sArray[1].ToLower().ToString() + "\n\n");
                    a++;
                }

                label17.Text = a.ToString();

                foreach (string s in names1)
                {
                    list.Add(s);

                }
                richTextBox2.Text = richTextBox2.Text.TrimEnd((char[])"\r\n".ToCharArray());
                //richTextBox2.Text = Regex.Replace(richTextBox2.Text, @"\n...", "\n");

                foreach (String s in richTextBox2.Lines)
                {
                    if (s == "\n") continue;
                    list.Add("# " + s + "\n");
                    list.Add("panel_name[" + a + "]=" + s + "\n");
                    list.Add("panel_n_UP[" + a + "]=" + s.ToUpper() + "\n");

                    //查找本行的字符串中有没有_，没有就跳过
                    int x = s.IndexOf("_");
                    if (x == -1) continue;
                    //将本行字符串分隔成2个，以_分隔
                    //判断字符串中是否含有 '_' , 有的话就分隔，直到没有为止
                    string[] sArray = new string[100];

                    if (s.IndexOf("_") > -1)
                    {
                        sArray = s.Split(new char[] { '_' }, 2);
                    }

                    //int y = sArray[1].ToString().IndexOf("_");
                    //if (y == -1) continue;

                    while (sArray[1].ToString().IndexOf("_") > -1)
                    {
                        sArray = sArray[1].ToString().Split(new char[] { '_' }, 2);
                    }
                    if (s != "\0")
                        list.Add("resolution[" + a + "]=" + sArray[1].ToLower().ToString() + "\n\n");
                    a++;
                }

                label18.Text = a.ToString();

                foreach (string s in names2)
                {
                    list.Add(s);
                }
                foreach (string s in list)
                {
                    sw.Write(s);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //HelpProvider HP = new HelpProvider();
            //HP.HelpNamespace = ("help.txt");
            //HP.SetShowHelp(this, true);
            //Help.ShowHelp(this, HP.HelpNamespace);
            //textBox1.Text = ConfigurationManager.AppSettings["WORK PATH"];
            //textBox2.Text = ConfigurationManager.AppSettings["OUT BIN NAME"];
            //textBox3.Text = ConfigurationManager.AppSettings["CUSTOMER 4 3"];
            //textBox4.Text = ConfigurationManager.AppSettings["CUSTOMER 16 9"];
            //richTextBox1.Text = ConfigurationManager.AppSettings["PANEL 4 3"];
            //richTextBox2.Text = ConfigurationManager.AppSettings["PANEL 16 9"];
            //textBox7.Text = ConfigurationManager.AppSettings["CUSTOMER HEAD"];
            //textBox8.Text = ConfigurationManager.AppSettings["JEDIA"];
            //textBox9.Text = ConfigurationManager.AppSettings["MIRROR JEDIA"];
            //textBox10.Text = ConfigurationManager.AppSettings["MIRROR VESA"];
            //textBox11.Text = ConfigurationManager.AppSettings["VESA"];
        }

        public String Get_Total_Panel_Number()
        {
            int a = 0;
            foreach (String s in richTextBox1.Lines)
            {
                a++;
            }
            foreach (String s in richTextBox2.Lines)
            {
                a++;
            }
            label18.Text = a.ToString();
            return label18.Text;
        }
        public String Get_4_3_Panel_Number()
        {
            int a = 0;
            foreach (String s in richTextBox1.Lines)
            {
                a++;
            }
            label17.Text = a.ToString();
            return label17.Text;
        }

        private void label19_Click(object sender, EventArgs e)
        {
                MessageBox.Show(@"
                        该工具的作用仅仅是为了生成脚本文件，
                        并不能直接编译软件，请知悉
                        在利用工具生成脚本之后，按照下面的步骤设置好，
                        然后将脚本文件放到代码的根目录下
                        ./ydg_make_all_bin.sh    运行即可

                        在编译之前要确定的东西
                        首先要制定好customer，logo，IR
                        其次，要make mconfig 并选好要编译的第一个屏参，
                        比如本文件为AA150XC01_1024X768

                        OUT_BIN_NAME：这个是生成软件的文件名
                        WORK_PATH：是你代码的根目录
                        CUSTOMER_4_3: 要编译的4_3的customer
                        CUSTOMER_16_9: 要编译的4_3的customer
                        PANEL_4_3: 要编译的4_3的屏参
                        PANEL_16_9: 要编译的16_9的屏参
                        当前默认打开的屏参的是通用加15扣板的（我自用的），
                        使用之前请自行更改。
                        全部填好后，点击GENERATE生成
                    ");

            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //cfa.AppSettings.Settings["WORK PATH"].Value = textBox1.Text;
            //cfa.AppSettings.Settings["OUT BIN NAME"].Value = textBox2.Text;
            //cfa.AppSettings.Settings["CUSTOMER 4 3"].Value = textBox3.Text;
            //cfa.AppSettings.Settings["CUSTOMER 16 9"].Value = textBox4.Text;
            //cfa.AppSettings.Settings["PANEL 4 3"].Value = richTextBox1.Text;
            //cfa.AppSettings.Settings["PANEL 16 9"].Value = richTextBox2.Text;
            //cfa.AppSettings.Settings["CUSTOMER HEAD"].Value = textBox7.Text;
            //cfa.AppSettings.Settings["JEDIA"].Value = textBox8.Text;
            //cfa.AppSettings.Settings["MIRROR JEDIA"].Value = textBox9.Text;
            //cfa.AppSettings.Settings["MIRROR VESA"].Value = textBox10.Text;
            //cfa.AppSettings.Settings["VESA"].Value = textBox11.Text;

            //cfa.Save();
        }

        //private void label20_Click(object sender, EventArgs e)
        //{
        //    Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    cfa.AppSettings.Settings["WORK PATH"].Value = textBox1.Text;
        //    cfa.AppSettings.Settings["OUT BIN NAME"].Value = textBox2.Text;
        //    cfa.AppSettings.Settings["CUSTOMER 4 3"].Value = textBox3.Text;
        //    cfa.AppSettings.Settings["CUSTOMER 16 9"].Value = textBox4.Text;
        //    cfa.AppSettings.Settings["PANEL 4 3"].Value = richTextBox1.Text;
        //    cfa.AppSettings.Settings["PANEL 16 9"].Value = richTextBox2.Text;
        //    cfa.AppSettings.Settings["CUSTOMER HEAD"].Value = textBox7.Text;
        //    cfa.AppSettings.Settings["JEDIA"].Value = textBox8.Text;
        //    cfa.AppSettings.Settings["MIRROR JEDIA"].Value = textBox9.Text;
        //    cfa.AppSettings.Settings["MIRROR VESA"].Value = textBox10.Text;
        //    cfa.AppSettings.Settings["VESA"].Value = textBox11.Text;

        //    cfa.Save();
        //    MessageBox.Show("保存成功");
        //}
    }
}
