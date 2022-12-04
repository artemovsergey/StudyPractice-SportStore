namespace SF2022UserLib.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            TimeSpan[] startTimes = new TimeSpan[5];

            startTimes[0] = new TimeSpan(10, 0, 0);
            startTimes[1] = new TimeSpan(11, 0, 0);
            startTimes[2] = new TimeSpan(15, 0, 0);
            startTimes[3] = new TimeSpan(15, 30, 0);
            startTimes[4] = new TimeSpan(16, 50, 0);

            int[] durations = new int[5];
            durations[0] = 60;
            durations[1] = 30;
            durations[2] = 10;
            durations[3] = 10;
            durations[4] = 40;

            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;



            Calculations c = new Calculations();

            string[] output = c.AvailablePeriods(
                               startTimes,
                               durations,
                               beginWorkingTime,
                               endWorkingTime,
                               consultationTime);

            string[] expected = {

                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:40-16:10",
                "16:10-16:40",
                "17:30-18:00"

            };

            Assert.AreEqual(expected, output);
        }
    }
}