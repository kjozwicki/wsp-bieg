using System;

namespace Data
{
    public abstract class DataAbstractAPI
    {

        public static DataAbstractAPI createAPI()
        {
            return new DataAPI();
        }

        private class DataAPI : DataAbstractAPI
        {
            public DataAPI() { }
        }
    }
}