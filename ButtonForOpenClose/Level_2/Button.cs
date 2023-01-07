using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonForOpenClose.Level_2
{
    /*
     * 这样的实际Button是可以复用的
     * 当不需要Dialer，而需要开密码锁时，
     * 不需要修改Button，而不需要修改Dialer，只需要新建一个密码锁，实现IButtonServer即可
     * 
     * 当前使用策略模式
     * 策略模式是一种行为模式，多个策略实现同一个策略接口，
     * 编程的时候 client 程序依赖策略接口，运行期根据不同上下文向 client 程序传入不同的策略实现
     * 
     * 思考：
     *  当前的Dialer是否复合开闭原则
     */
    public class Button
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

    public class Dialer : IButtonServer
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

        void IButtonServer.ButtonPressed(int token)
        {
            if (token == 9)
                EnterDigit(token);
            else if (token == -99)
                Dial();

        }
    }
}
