using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonForOpenClose.Level_4
{
    /*
     * 如果一个按钮需要同时控制多个设备（按下按钮时需要蜂鸣器发出不同声音）
     * 按照第三版的设计，就需要修改适配器，所以适配器不符合开闭原则
     * 
     * 为了应对这种变化，我们开始重构
     * 用观察者进行重构
     */
    public class Button
    {
        List<IButtonListenser> listensers;
        public Button()
        {
            this.listensers = new List<IButtonListenser>();
        }
        public void AddListener(IButtonListenser listenser)
        {
            this.listensers.Add(listenser);
        }
        public void Press()
        {
            foreach (IButtonListenser listenser in listensers)
            {
                listenser.ButtonPressed();
            }
        }
    }

    public class Phone
    {
        private Dialer dialer;
        /// <summary>
        /// 数字键
        /// </summary>
        public Button[] digitButtons;
        /// <summary>
        /// 拨号键
        /// </summary>
        public Button sendButton;

        public Phone()
        {
            //拨号器
            dialer = new Dialer();
            //10个数字键
            digitButtons = new Button[10];
            for (int i = 0; i < digitButtons.Length; i++)
            {
                digitButtons[i] = new Button();
                digitButtons[i].AddListener(new DigitButtonDialerAdepter(dialer, i));
            }

            sendButton = new Button();
            sendButton.AddListener(new SendButtonDialerAdepter(dialer));
        }
    }

    public class DigitButtonDialerAdepter : IButtonListenser
    {
        readonly Dialer dialer;
        readonly int token;
        public DigitButtonDialerAdepter(Dialer dialer, int token)
        {
            this.dialer = dialer;
            this.token = token;
        }
        public void ButtonPressed()
        {
            dialer.EnterDigit(token);
        }
    }
    public class SendButtonDialerAdepter : IButtonListenser
    {
        readonly Dialer dialer;
        public SendButtonDialerAdepter(Dialer dialer)
        {
            this.dialer = dialer;
        }
        public void ButtonPressed()
        {
            dialer.Dial();
        }
    }
    public interface IButtonListenser
    {
        public void ButtonPressed();
    }
    public class Dialer
    {
        public void EnterDigit(int digit)
        {
            //拨号器按下digit
            Console.WriteLine($"enter digit: {digit}");
        }
        public void Dial()
        {
            //拨号器拨号
            Console.WriteLine("dialing");
        }
    }
}
