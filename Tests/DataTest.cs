using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    
    [TestClass]
    public class DataTest {

        [TestMethod]
        public void DataAbstractAPItest()
        {
            DataAbstractAPI api;
            api = DataAbstractAPI.CreateAPI();

            Assert.IsInstanceOfType(api, typeof(DataAbstractAPI));
        }



    }
    
}

