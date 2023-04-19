using System;

namespace MyApp
{
    public class Singleton
    {

        private Singleton _instance;

        public Singleton()
        {
            //code
        }

        public Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }
    }
}
