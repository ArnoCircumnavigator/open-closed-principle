using ButtonForOpenClose.Level_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonForOpenClose.Level_3
{
    /*
     * 上一版中Dialer的ButtonPressed方法中，依旧存在else
     * 同样是不符合开闭原则的
     * 
     * 这一版设计，使得Dialer类复合开闭原则，
     * 不论Dialer加几个功能，都只需要加适配器即可。不需要修改Dialer
     * 
     *
     */
    internal class Button
    {
        readonly IButtonServer buttonServer;

        public Button(IButtonServer buttonServer)
        {
            this.buttonServer = buttonServer;
        }
        public void Press(int token)
        {
            buttonServer.ButtonPressed(token);
        }
    }
    public interface IButtonServer
    {
        public void ButtonPressed(int token);
    }

    public class DigitButtonDialerAdepter : IButtonServer
    {
        readonly Dialer dialer;
        public DigitButtonDialerAdepter(Dialer dialer)
        {
            this.dialer = dialer;
        }
        public void ButtonPressed(int token)
        {
            dialer.EnterDigit(token);
        }
    }
    public class SendButtonDialerAdepter : IButtonServer
    {
        readonly Dialer dialer;
        public SendButtonDialerAdepter(Dialer dialer)
        {
            this.dialer = dialer;
        }
        public void ButtonPressed(int token)
        {
            dialer.Dial();
        }
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
