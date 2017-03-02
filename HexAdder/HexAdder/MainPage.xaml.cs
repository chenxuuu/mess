using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace HexAdder
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Adder_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = "";
            log.Text = "";

            string TextIn = TextRead.Text;
            int SumAll = 0;

            TextIn = TextIn.Replace("\r","").Replace("\n", "").Replace(" ","");

            if (TextIn.IndexOf(",") >= 1)
            {
                string[] str2;
                str2 = TextIn.Split(',');
                foreach (string i in str2)
                {
                    if(i.ToString()=="")
                    {
                        break;
                    }
                    string temp = i.ToString().Replace("0x", "").Replace("0X", "").ToUpper();
                    string TempSum = "";
                    for(int j=0;j<temp.Length;j++)
                    {
                        switch(temp[j])
                        {
                            case '0':
                                TempSum += "0000";
                                break;
                            case '1':
                                TempSum += "0001";
                                break;
                            case '2':
                                TempSum += "0010";
                                break;
                            case '3':
                                TempSum += "0011";
                                break;
                            case '4':
                                TempSum += "0100";
                                break;
                            case '5':
                                TempSum += "0101";
                                break;
                            case '6':
                                TempSum += "0110";
                                break;
                            case '7':
                                TempSum += "0111";
                                break;
                            case '8':
                                TempSum += "1000";
                                break;
                            case '9':
                                TempSum += "1001";
                                break;
                            case 'A':
                                TempSum += "1010";
                                break;
                            case 'B':
                                TempSum += "1011";
                                break;
                            case 'C':
                                TempSum += "1100";
                                break;
                            case 'D':
                                TempSum += "1101";
                                break;
                            case 'E':
                                TempSum += "1110";
                                break;
                            case 'F':
                                TempSum += "1111";
                                break;
                            default:
                                break;
                        }
                    }
                    SumAll += Convert.ToInt32(TempSum, 2);
                    log.Text += Convert.ToInt32(TempSum, 2).ToString() + ",";
                }
            }
            else
            {
                Result.Text = "error!";
            }
            Result.Text += "Dec:" + SumAll.ToString();
            Result.Text += ",Hex:0x" + Convert.ToString(SumAll, 16);
            Result.Text += ",Bin:" + Convert.ToString(SumAll, 2);


        }
    }
}
