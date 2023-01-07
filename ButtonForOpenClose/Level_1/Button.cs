namespace ButtonForOpenClose.Level_1
{
    /*
     * 如下代码，如果说需要多一个按钮，就“*”号
     * 那么一定是要修改Press中的代码
     * 这违反开闭原则
     * 
     * 还有，按钮类中，强耦合了一个Dialer类，在这种情况下
     * 如果按钮是要操作另一个东西，不再是Dialer，那么这个Button对象
     * 是无法复用的。
     * 
     * 某个阿里的架构师说过一句
     * “粗暴一点说，当我们在代码中看到 else 或者 switch/case 关键字的时候
     *  ，基本可以判断违反开闭原则了”
     */
    public class Button
    {
        public const int SEND_BUTTON = -99;

        private Dialer dialer;
        private int token;

        public Button(int token, Dialer dialer)
        {
            this.token = token;
            this.dialer = dialer;
        }

        public void Press()
        {
            switch (token)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case SEND_BUTTON:
                    break;
                default:
                    throw new System.NotSupportedException("unknown button pressed!");
            }
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