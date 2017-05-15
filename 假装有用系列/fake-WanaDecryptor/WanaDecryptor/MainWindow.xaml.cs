using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Windows.Threading;

namespace WanaDecryptor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            texts.Text = @"我的电脑出了什么问题？
您的一些重要文件被我加密保存了。
照片、图片、文档、压缩包、音频、视频文件、exe文件等，几乎所有类型的文件都被加密了，因此不能正常打开。
这和一般文件损坏有本质上的区别。您大可在网上找找恢复文件的方法，我敢保证，没有我们的解密服务，就算老天爷来了也不能恢复这些文档。

有没有恢复这些文档的方法？
当然有可恢复的方法。只能通过我们的解密服务才能恢复。我以人格担保，能够提供安全有效的恢复服务。
但这是收费的，也不能无限期的推迟。
请点击 <Decrypt> 按钮，就可以免费恢复一些文档。请您放心，我是绝不会骗你的。
但想要恢复全部文档，需要付款点费用。
是否随时都可以固定金额付款，就会恢复的吗，当然不是，推迟付款时间越长对你不利。
最好3天之内付款费用，过了三天费用就会翻倍。
还有，一个礼拜之内未付款，将会永远恢复不了。
对了，忘了告诉你，对半年以上没钱付款的穷人，会有活动免费恢复，能否轮到你，就要看您的运气怎么样了。

付款方法
我们只会接受比特币。不懂比特币是什么，请点击查看详情 <About bitcoin>。
不会购买比特币，请点击查看购买方法，<How to buy bitcoins>。
要注意：付款金额不能低于在窗口上显示的金额。
付款后，请点击 <Check Payment> 按钮，因为比特币的到账，所需要的时间有点长，付款后请耐心等待。
最好的确认时间为周一到周五，从上午9点到11点
到账成功后，可立刻开始恢复工作。

联系方式
如果需要我们的帮组，请点击 <Contact Us>，发给我们消息吧。

我强烈建议，为了避免不必要的麻烦，恢复工作结束之前，请不要关闭或者删除该软件，并且暂停杀毒软件。 不管由于什么原因，万一该软件被删除了，很可能会导致付款后也不能恢复信息的情况。
by chenxublog.com（滑稽";
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;//每秒触发这个事件，以刷新时间
            timer.Start();  //开始计时器

            RasedTime.Text = System.DateTime.Now.AddDays(2).ToString();
            LostTime.Text = System.DateTime.Now.AddDays(30).ToString();
        }

        DispatcherTimer timer;//定义定时器
        long rl= 172800, ll = 172800 * 15;

        private void Timer_Tick(object sender, object e)
        {
            rl -= 1;
            RasedTimeLeft.Text = $"{(rl / 60 / 60 / 24).ToString().PadLeft(2,'0')} :{(rl / 60 / 60 % 24).ToString().PadLeft(2, '0')} :{(rl / 60 % 60).ToString().PadLeft(2, '0')} :{(rl % 60).ToString().PadLeft(2, '0')}";
            ll -= 1;
            LostTimeLeft.Text = $"{(ll / 60 / 60 / 24).ToString().PadLeft(2, '0')} :{(ll / 60 / 60 % 24).ToString().PadLeft(2, '0')} :{(ll / 60 % 60).ToString().PadLeft(2, '0')} :{(ll % 60).ToString().PadLeft(2, '0')}";

        }
    }
}
