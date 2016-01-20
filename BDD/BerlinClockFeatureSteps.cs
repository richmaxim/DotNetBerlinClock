using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private ITimeConverter berlinClock;
        private String theTime;

        public TheBerlinClockSteps()
        {
            var timeParser = new Time24hParser();
            var clockRenderer = new TextClockRenderer("\n");
            berlinClock = new TimeConverter(timeParser, clockRenderer);
        }
        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            var theTestBerlinClockOutput = berlinClock.convertTime(theTime);
            Assert.AreEqual(theExpectedBerlinClockOutput, theTestBerlinClockOutput);
        }

        [When(@"the time is null")]
        public void WhenTheTimeIsNull()
        {
            WhenTheTimeIsInvalidLike(null);
        }

        [Then(@"the ArgumentNullException is thrown")]
        public void ThenTheArgumentNullExceptionIsThrown()
        {
            try
            {
                var theTestBerlinClockOutput = berlinClock.convertTime(theTime);
            }
            catch (ArgumentNullException)
            {
                return;
            }
            Assert.Inconclusive();
        }

        [When(@"the time is invalid like ""(.*)""")]
        public void WhenTheTimeIsInvalidLike(string invalidTime)
        {
            WhenTheTimeIs(invalidTime);
        }

        [Then(@"the FormatException is thrown")]
        public void ThenTheFormatExceptionIsThrown()
        {
            try
            {
                var theTestBerlinClockOutput = berlinClock.convertTime(theTime);
            }
            catch (FormatException)
            {
                return;
            }
            Assert.Inconclusive();
        }

        [Then(@"the OverflowException is thrown")]
        public void ThenTheOverflowExceptionIsThrown()
        {
            try
            {
                var theTestBerlinClockOutput = berlinClock.convertTime(theTime);
            }
            catch (OverflowException)
            {
                return;
            }
            Assert.Inconclusive();
        }
    }
}
