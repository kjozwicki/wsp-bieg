using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    
    [TestClass]
    public class DataTest {

        [TestMethod]
        public void DataAbstractAPItest() {
            DataAbstractAPI api = DataAbstractAPI.createAPI();

            Assert.IsInstanceOfType(api, typeof(DataAbstractAPI));
        }



    }
    
}

