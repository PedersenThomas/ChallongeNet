using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using ChallongeNet.OptionalParameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallongeNet.TestProject.Pychallonge.Test
{
    [TestClass]
    public class PaticipantsTestCase
    {
        private ChallongeV1 target;
        private string tournamentName;
        private string particiant1Name;
        private Participant particiant1;
        private string particiant2Name;
        private Participant particiant2;
        private Tournament tournamentUnderTest;

        [TestInitialize]
        public void Initialize()
        {
            var username = Properties.Settings.Default.username;
            var apiKey = Properties.Settings.Default.apiKey;

            this.tournamentName = "TommeAPITest" + Utilities.RandomName();
            Debug.WriteLine(string.Format("Initializing with name {0}", this.tournamentName));
            this.target = new ChallongeV1(username, apiKey);
            this.tournamentUnderTest = this.target.TournamentCreate(this.tournamentName, TournamentType.SingleElimination, this.tournamentName);

            this.particiant1Name = "TommeAPITest" + Utilities.RandomName();
            this.particiant2Name = "TommeAPITest" + Utilities.RandomName();

            this.particiant1 = this.target.ParticipantCreate(this.tournamentUnderTest, new ParticipantCreateParameters { Name = this.particiant1Name });
            this.particiant2 = this.target.ParticipantCreate(this.tournamentUnderTest, new ParticipantCreateParameters { Name = this.particiant2Name });
         }

        [TestCleanup]
        public void Cleanup()
        {
            Debug.WriteLine("Cleaning up");
            this.target.TournamentDestroy(this.tournamentUnderTest);
        }

        [TestMethod]
        [TestCategory("Paticipant"), TestCategory("pychallongeTest")]
        public void PaticipantIndex()
        {
            var ps = this.target.ParticipantIndex(this.tournamentUnderTest).ToList();
            Assert.AreEqual(2, ps.Count);

            Assert.IsNotNull(ps.SingleOrDefault(p => p.Id == this.particiant1.Id));
            Assert.IsNotNull(ps.SingleOrDefault(p => p.Id == this.particiant2.Id));
        }

        [TestMethod]
        [TestCategory("Paticipant"), TestCategory("pychallongeTest")]
        public void PaticipantShow()
        {
            var p = this.target.ParticipantShow(this.tournamentUnderTest, this.particiant1.Id);
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Id, this.particiant1.Id);
        }

        [TestMethod]
        [TestCategory("Paticipant"), TestCategory("pychallongeTest")]
        public void PaticipantUpdate()
        {
            const string Expected = "Test!";
            var parameters = new ParticipantUpdateParameters { Misc = Expected };
            Thread.Sleep(1500);
            var updatedParticipant = this.target.ParticipantUpdate(this.tournamentUnderTest, this.particiant1, parameters);

            Assert.AreEqual(Expected, updatedParticipant.Misc);
            Assert.IsNotNull(updatedParticipant.UpdatedAt);
            Assert.IsNotNull(this.particiant1.UpdatedAt);
            Utilities.AssertDateTimeWithin(updatedParticipant.UpdatedAt.Value, this.particiant1.UpdatedAt.Value, new TimeSpan(hours: 0, minutes: 1, seconds: 0));
        }

        [TestMethod]
        [TestCategory("Paticipant"), TestCategory("pychallongeTest")]
        public void PaticipantRandomize()
        {
            /*
             * randomize has a 50% chance of actually being different than
             * current seeds, so we're just verifying that the method runs at all
             */

            var participants = this.target.ParticipantRandomize(this.tournamentUnderTest);
            Assert.AreEqual(2, participants.Count());
        }
    }
}
