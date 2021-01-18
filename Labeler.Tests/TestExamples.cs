using Labeler.Core.Extentions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Labeler.Tests
{
    [TestClass]
    public class TestExamples
    {
        private string[] SentViaOsLabels;

        public TestExamples()
        {
            SentViaOsLabels = new string[] { "Sent via iOS 12", "Sent via iOS 13", "Sent via iOS 14" };
        }

        [TestMethod]
        public void TryGetMultipleLabels_MultipleLabelsExist_ReturnLabelsAsEnumerable()
        {
            var labels = SentViaOS.SentViaIOS.GetLabels();
            Assert.IsTrue(labels.Intersect(SentViaOsLabels).Count() == 3);
        }

        [TestMethod]
        public void TryGetLabel_MultipleLabelsExist_ReturnFirstLabel()
        {
            Assert.AreEqual(SentViaOS.SentViaAndroid.GetLabel(), "Sent via Android 9");
        }

        [TestMethod]
        public void TryGetLabel_LabelNotExists_ReturnsFieldAsStr()
        {
            Assert.AreEqual(SentViaOS.SentViaUbuntu.GetLabel(), "SentViaUbuntu");
        }

        [TestMethod]
        public void TryGetMultipleLabels_LabelsNotExist_ReturnsFieldAsStr()
        {
            var labels = SentViaOS.SentViaUbuntu.GetLabels();
            
            Assert.IsTrue(labels.Count() == 1);
            Assert.AreEqual(labels.First(), "SentViaUbuntu");
        }
    }
}
