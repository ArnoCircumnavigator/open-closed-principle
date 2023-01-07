using ButtonForOpenClose.Level_4;

namespace ButtonForOpenClose_Test
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Phone phone = new Phone();
            phone.digitButtons[9].Press();
            phone.digitButtons[1].Press();
            phone.digitButtons[1].Press();
            phone.sendButton.Press();

            Assert.Pass();
        }
    }
}