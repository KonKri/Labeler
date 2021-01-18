using Labeler.Core.Extentions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;

namespace Labeler.Tests
{
    [TestClass]
    public class TestExamples
    {
        private string[] SentViaOsLabels;

        public TestExamples()
        {
            SentViaOsLabels = new string[] { "Sent via IPhone 12", "Sent via iOS 13", "Sent via iOS 14" };
        }

        [TestMethod]
        public void TryGetMultipleLabels_MultipleLabelsExist_ReturnLabelsAsEnumerable()
        {
            var labels = SentViaOS.SentViaIOS.GetLabels();
            Assert.IsTrue(labels.Intersect(SentViaOsLabels).Count() == 3, $"TestMethod: {MethodBase.GetCurrentMethod().Name} Failed.");
        }

        [TestMethod]
        public void TryGetLabel_MultipleLabelsExist_ReturnFirstLabel()
        {
            Assert.AreEqual(SentViaOS.SentViaAndroid.GetLabel(), "Sent via Android 9", $"TestMethod: {MethodBase.GetCurrentMethod().Name} Failed.");
        }

        [TestMethod]
        public void TryGetLabel_LabelNotExists_ReturnsFieldAsStr()
        {
            Assert.AreEqual(SentViaOS.SentViaUbuntu.GetLabel(), "SentViaUbuntu", $"TestMethod: {MethodBase.GetCurrentMethod().Name} Failed.");
        }

        [TestMethod]
        public void TryGetMultipleLabels_LabelsNotExist_ReturnsFieldAsStr()
        {
            var labels = SentViaOS.SentViaUbuntu.GetLabels();

            Assert.IsTrue(labels.Count() == 1, $"TestMethod: {MethodBase.GetCurrentMethod().Name} Failed, \nlabels count was {labels.Count()} when it should be 1.");
            Assert.AreEqual(labels.First(), "SentViaUbuntu", $"TestMethod: {MethodBase.GetCurrentMethod().Name} Failed, \nfirst label was not the correct one.");
        }
    }
}
