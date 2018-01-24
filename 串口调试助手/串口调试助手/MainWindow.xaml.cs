using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.Threading;

namespace 串口调试助手
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += F;
            ComNumber.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                ComNumber.Items.Add(s);
                ComNumber.SelectedItem = s;
            }
        }

        private void F(object o, System.ComponentModel.CancelEventArgs e)
        {
            serialPort1.Close();
        }

        private void ClearSendTextBox_Click(object sender, RoutedEventArgs e)
        {
            SendTextBox.Text = "";
        }

        private void ClearReceiveTextBox_Click(object sender, RoutedEventArgs e)
        {
            ReceiveTextBox.Text = "";
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            about About = new about();
            About.ShowDialog();
        }

        private void RefreshCom_Click(object sender, RoutedEventArgs e)
        {
            ComNumber.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                ComNumber.Items.Add(s);
                ComNumber.SelectedItem = s;
            }
        }

        private void FontView_Click(object sender, RoutedEventArgs e)
        {
            if (FontView.Content.ToString() == "置顶显示")
            {
                MainPage.Topmost = true;
                FontView.Content = "取消置顶";
            }
            else if (FontView.Content.ToString() == "取消置顶")
            {
                MainPage.Topmost = false;
                FontView.Content = "置顶显示";
            }
            
        }

        private static SerialPort serialPort1 = new SerialPort();
        delegate void HandleInterfaceUpdateDelagate(string text);// 委托；此为重点
        private static HandleInterfaceUpdateDelagate interfaceUpdateHandle;

        private void OpenCom_Click(object sender, RoutedEventArgs e)
        {
            if (OpenCom.Content.ToString() == "打开串口")
            {
                try
                {
                    serialPort1.PortName = ComNumber.SelectedItem.ToString();
                }
                catch
                {
                    ComNumber.Items.Clear();
                    foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
                    {
                        ComNumber.Items.Add(s);
                        ComNumber.SelectedItem = s;
                    }
                    try
                    {
                        serialPort1.PortName = ComNumber.SelectedItem.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("未检测到可连接的串口！");
                        return;
                    }
                }
                

                serialPort1.BaudRate = int.Parse(((ComboBoxItem)Wave.SelectedItem).Content.ToString());

                if (Check.SelectedItem.ToString() == "无")
                    serialPort1.Parity = Parity.None;
                else if (Check.SelectedItem.ToString() == "奇校检")
                    serialPort1.Parity = Parity.Odd;
                else if (Check.SelectedItem.ToString() == "偶校检")
                    serialPort1.Parity = Parity.Even;

                if (Stop.SelectedItem.ToString() == "1")
                    serialPort1.StopBits = StopBits.One;
                else if (Stop.SelectedItem.ToString() == "2")
                    serialPort1.StopBits = StopBits.Two;

                serialPort1.DataBits = int.Parse(((ComboBoxItem)Bit.SelectedItem).Content.ToString());

                try
                {
                    serialPort1.Open();
                    

                    OpenCom.Content = "关闭串口";
                    ReceiveData(serialPort1);// 开启接收数据线程
                }
                catch
                {
                    MessageBox.Show("打开失败！前检查串口设备是否已连接！");
                    ComNumber.Items.Clear();
                    foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
                    {
                        ComNumber.Items.Add(s);
                        ComNumber.SelectedItem = s;
                    }
                    return;
                }
                
                
            }
            else if (OpenCom.Content.ToString() == "关闭串口")
            {
                serialPort1.Close();
                OpenCom.Content = "打开串口";
            }

        }


        private void ReceiveData(SerialPort serialPort)
        {
            // 也可用异步接收数据线程
            Thread threadReceiveSub = new Thread(new ParameterizedThreadStart(AsyReceiveData));
            threadReceiveSub.Start(serialPort);

        }

        // 发送二进制数据
        private void SendBytesData(SerialPort serialPort)
        {
            if(!(bool)SendAsHex.IsChecked)
            {
                byte[] bytesSend = System.Text.Encoding.Default.GetBytes(SendTextBox.Text);
                serialPort.Write(bytesSend, 0, bytesSend.Length);
            }
            else
            {
                byte[] bytesSend = hexStringToByte(SendTextBox.Text.ToUpper());
                serialPort.Write(bytesSend, 0, bytesSend.Length);
            }
        }

        private void UpdateTextBox(string text)
        {
            if (text != "")
            {
                ReceiveTextBox.Text += text;
                ReceiveTextBox.ScrollToEnd();
                if((bool)AutoReplay.IsChecked)
                {
                    byte[] bytesSend = hexStringToByte(ReplayTextBox.Text.ToUpper());
                    serialPort1.Write(bytesSend, 0, bytesSend.Length);
                }
            }
        }

        // 异步读取
        private void AsyReceiveData(object serialPortobj)
        {
            SerialPort serialPort = (SerialPort)serialPortobj;
            bool IsShowAsHex = false;
            System.Threading.Thread.Sleep(500);
            while (true)
            {
                try
                {
                    System.Threading.Thread.Sleep(10);
                    int n = serialPort.BytesToRead;// 先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致  
                    byte[] buf = new byte[n];// 声明一个临时数组存储当前来的串口数据  
                                             //received_count += n;// 增加接收计数  
                    serialPort.Read(buf, 0, n);// 读取缓冲数据
                                               // 因为要访问 ui 资源，所以需要使用 invoke 方式同步 ui。
                    interfaceUpdateHandle = new HandleInterfaceUpdateDelagate(UpdateTextBox);// 实例化委托对象

                    this.Dispatcher.Invoke(new Action(delegate {
                        if ((bool)ShowAsHex.IsChecked)
                        {
                            IsShowAsHex = true;
                        }
                        else
                        {
                            IsShowAsHex = false;
                        }
                    }));
                    if(!IsShowAsHex)
                    {
                        Dispatcher.Invoke(interfaceUpdateHandle, new string[] { Encoding.Default.GetString(buf) });
                    }
                    else
                    {
                        Dispatcher.Invoke(interfaceUpdateHandle, new string[] { ByteToString(buf, n) });
                    }
                }
                catch
                {
                    //MessageBox.Show(e.Message);
                    try
                    {
                        this.Dispatcher.Invoke(new Action(delegate {
                            OpenCom.Content = "打开串口";
                        }));
                        serialPort1.Close();
                    }
                    catch { }
                    // 处理错误
                    break;
                }
            }
        }

        /**
          * 把 16 进制字符串转换成字节数组
          * @param hexString
          * @return byte[]
          */
        private static bool ShowWarning = true;
        private static byte[] hexStringToByte(String hex)
        {
            int len = (hex.Length / 2);
            byte[] result = new byte[len];
            char[] achar = hex.ToCharArray();
            for (int i = 0; i < len; i++)
            {
                int pos = i * 2;
                result[i] = (byte)(toByte(achar[pos]) << 4 | toByte(achar[pos + 1]));
            }
            ShowWarning = true;
            return result;
        }

        private static int toByte(char c)
        {
            byte b = (byte)"0123456789ABCDEF".IndexOf(c);
            if (b == (byte)"0".IndexOf('c') && ShowWarning)
            {
                MessageBox.Show("16进制仅限1234567890abcdef这些字符！（大小写均可）");
                ShowWarning = false;
            }
            return b;
        }


        /// <summary>
        /// 字节数组转 16 进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteToString(byte[] InBytes)
        {
            string StringOut = "";
            foreach (byte InByte in InBytes)
            {
                StringOut = StringOut + String.Format("{0:X2}", InByte);
            }
            return StringOut;
        }
        public string ByteToString(byte[] InBytes, int len)
        {
            string StringOut = "";
            for (int i = 0; i < len; i++)
            {
                StringOut = StringOut + String.Format("{0:X2}", InBytes[i]);
            }
            return StringOut;
        }

        private void SendText_Click(object sender, RoutedEventArgs e)
        {
            if(OpenCom.Content.ToString() == "关闭串口")
            {
                SendBytesData(serialPort1);// 用字节的形式发送数据
            }
            else
            {
                MessageBox.Show("串口未打开！");
            }
        }
    }
}
