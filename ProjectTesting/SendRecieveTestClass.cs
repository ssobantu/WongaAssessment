using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectTesting
{
    [TestClass]
    public class SendRecieveTestClass
    {
        [TestMethod]
        public void SendTest()
        {
            try
            {
                SendMessageHelper.SendHelper.MessageSend();

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void RecieveTest()
        {
            try
            {
                RecieveMessageHelper.RecieveHelper.MessageRecieve();

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
  
}
