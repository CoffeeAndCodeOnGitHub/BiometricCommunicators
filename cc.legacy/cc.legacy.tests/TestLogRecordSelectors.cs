using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cc.legacy.Functions;

namespace cc.legacy.tests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void MoveToNextRecord() {
            Int32 RecordSelector = 32;
            Assert.IsTrue(RecordSelector.MoveToNextRecord() == 64,"Move To Next Record did not cover 32 characters.");
        }
    }
}
