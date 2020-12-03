using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskAssistant;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskAssistant.Tests
{
    [TestClass()]
    public class PriorityColorTests
    {
        [TestMethod()]
        public void Convert_1_FD699Areturns()
        {
            int x = 1;
            string exepted = "#FD699A";

            PriorityColor priorityColor = new PriorityColor();
            string actual = priorityColor.Convert((object)x, typeof(string), new object(), new System.Globalization.CultureInfo(1)).ToString();

            Assert.AreEqual(exepted, actual);
        }

        [TestMethod()]
        public void Convert_2_9677FFreturns()
        {
            int x = 2;
            string exepted = "#9677FF";

            PriorityColor priorityColor = new PriorityColor();
            string actual = priorityColor.Convert((object)x, typeof(string), new object(), new System.Globalization.CultureInfo(1)).ToString();

            Assert.AreEqual(exepted, actual);
        }

        [TestMethod()]
        public void Convert_3_5BB1FFreturns()
        {
            int x = 3;
            string exepted = "#5BB1FF";

            PriorityColor priorityColor = new PriorityColor();
            string actual = priorityColor.Convert((object)x, typeof(string), new object(), new System.Globalization.CultureInfo(1)).ToString();

            Assert.AreEqual(exepted, actual);
        }

        [TestMethod()]
        public void Convert_4_5BB1FFreturns()
        {
            int x = 4;
            string exepted = "#5BB1FF";

            PriorityColor priorityColor = new PriorityColor();
            string actual = priorityColor.Convert((object)x, typeof(string), new object(), new System.Globalization.CultureInfo(1)).ToString();

            Assert.AreEqual(exepted, actual);
        }


        [TestMethod()]
        public void Convert_n1_5BB1FFreturns()
        {
            int x = -1;
            string exepted = "#5BB1FF";

            PriorityColor priorityColor = new PriorityColor();
            string actual = priorityColor.Convert((object)x, typeof(string), new object(), new System.Globalization.CultureInfo(1)).ToString();

            Assert.AreEqual(exepted, actual);
        }
    }
}