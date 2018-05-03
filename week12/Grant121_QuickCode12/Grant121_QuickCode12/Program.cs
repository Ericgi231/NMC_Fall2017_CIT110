using FinchAPI;

namespace Grant121_QuickCode12
{
    class Program
    {
        static void Main(string[] args)
        {
            //eric grant
            //quick code
            //11/15/17
            //

            Finch tim = new Finch();
            tim.connect();

            while (true)
            {
                if (tim.getObstacleSensors()[0])
                {
                    tim.setLED(255, 0, 0);
                } else
                {
                    tim.setLED(0, 0, 0);
                }   
            }
        }
    }
}
