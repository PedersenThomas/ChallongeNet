using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using ChallongeNet.OptionalParameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallongeNet.TestProject.Pychallonge.Test
{
    [TestClass]
    public class TournamentsTest
    {
        private ChallongeV1 target;
        private string randomName;
        private Tournament tournamentUnderTest;

        [TestInitialize]
        public void Initialize()
        {
            var username = Properties.Settings.Default.username;
            var apiKey = Properties.Settings.Default.apiKey;
            this.randomName = "TommeAPITest" + Utilities.RandomName();
            Debug.WriteLine(string.Format("Initializing with name {0}", this.randomName));

            this.target = new ChallongeV1(username, apiKey);
            this.tournamentUnderTest = this.target.TournamentCreate(this.randomName, TournamentType.SingleElimination, this.randomName);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Debug.WriteLine("Cleaning up");
            this.target.TournamentDestroy(this.tournamentUnderTest);
        }

        [TestMethod]
        [TestCategory("Tournament"), TestCategory("pychallongeTest")]
        public void TournamentIndex()
        {
            var tournaments = this.target.TournamentIndex();

            Assert.AreEqual(1, tournaments.Count(t => t.Name == this.randomName));
        }

        [TestMethod]
        [TestCategory("Tournament"), TestCategory("pychallongeTest")]
        public void TournamentShow()
        {
            var tournament = this.target.TournamentShow(this.tournamentUnderTest.Id);

            Assert.IsNotNull(tournament);
            Assert.AreEqual(this.tournamentUnderTest.Id, tournament.Id);
            Assert.AreEqual(this.tournamentUnderTest.AnonymousVoting, tournament.AnonymousVoting);
            Assert.AreEqual(this.tournamentUnderTest.PtsForGameWin, tournament.PtsForGameWin);
            Assert.AreEqual(this.tournamentUnderTest.CreatedByApi, tournament.CreatedByApi);
            Assert.AreEqual(this.tournamentUnderTest.CreatedAt, tournament.CreatedAt);
        }

        [TestMethod]
        [TestCategory("Tournament"), TestCategory("pychallongeTest")]
        public void IndexFilterByState()
        {
            var param = new TournamentIndexParameters { State = IndexState.pending };
            var tournaments = this.target.TournamentIndex(param);
            var tournament = tournaments.SingleOrDefault(t => t.Name == this.randomName);

            Assert.IsNotNull(tournament, "The newly inserted tournament, is not to be found.");

            param = new TournamentIndexParameters { State = IndexState.in_progress };
            tournaments = this.target.TournamentIndex(param);
            tournament = tournaments.SingleOrDefault(t => t.Name == this.randomName);

            Assert.IsNull(tournament, "Tryed another state: " + param.State + " to search by, and found the tournament again.");

            param = new TournamentIndexParameters { State = IndexState.ended };
            tournaments = this.target.TournamentIndex(param);
            tournament = tournaments.SingleOrDefault(t => t.Name == this.randomName);

            Assert.IsNull(tournament, "Tryed another state: " + param.State + " to search by, and found the tournament again.");
        }

        [TestMethod]
        [TestCategory("Tournament"), TestCategory("pychallongeTest")]
        public void TournamentIndexFilterByCreated()
        {
            var parameters = new TournamentIndexParameters { CreatedAfter = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)) };
            var result = this.target.TournamentIndex(parameters);
            var tournament = result.SingleOrDefault(t => t.Id == this.tournamentUnderTest.Id);
            Assert.IsNotNull(tournament);
        }

        [TestMethod]
        [TestCategory("Tournament"), TestCategory("pychallongeTest")]
        public void TournamentUpdateName()
        {
            var newName = "TommeTest!" + Utilities.RandomName();
            var parameters = new TournamentUpdateParameters { Name = newName };

            Thread.Sleep(1500); // Letting time pase, so the updated_at is sure to be different.

            var updatedTournament = this.target.TournamentUpdate(this.tournamentUnderTest, parameters);

            Assert.AreEqual(newName, updatedTournament.Name);
            Assert.IsTrue(updatedTournament.UpdatedAt > this.tournamentUnderTest.UpdatedAt);
        }

        [TestMethod]
        [TestCategory("Tournament"), TestCategory("pychallongeTest")]
        public void TournamentUpdatePrivate()
        {
            var parameters = new TournamentUpdateParameters { Private = true };

            var updatedTournament = this.target.TournamentUpdate(this.tournamentUnderTest, parameters);

            Assert.IsTrue(updatedTournament.IsPrivate);
        }

        [TestMethod]
        [TestCategory("Tournament"), TestCategory("pychallongeTest")]
        public void TournamentUpdateType()
        {
            var parameters = new TournamentUpdateParameters { Type = TournamentType.RoundRobin };
            var updatedTournament = this.target.TournamentUpdate(this.tournamentUnderTest, parameters);
            Assert.AreEqual(updatedTournament.TournamentType, TournamentType.RoundRobin);
        }

        [TestMethod]
        [TestCategory("Tournament"), TestCategory("pychallongeTest")]
        public void TournamentStart()
        {
            Debug.WriteLine("Initial state: {0}", this.tournamentUnderTest.Tournamentstate);
            try
            {
                this.target.TournamentStart(this.tournamentUnderTest);
                Assert.Fail("You should not be able to start a tournament without paticipants.");
            }
            catch (ChallongeException)
            {
                Debug.WriteLine("A tournament first need some paticipants.");
            }

            Assert.IsNull(this.tournamentUnderTest.StartedAt);

            // we have have some paticipants first
            this.target.ParticipantCreate(this.tournamentUnderTest, new ParticipantCreateParameters { Name = "#1" });
            this.target.ParticipantCreate(this.tournamentUnderTest, new ParticipantCreateParameters { Name = "#2" });

            this.tournamentUnderTest = this.target.TournamentShow(this.tournamentUnderTest.Id);

            Debug.WriteLine("After added some paticipants. State: {0}", this.tournamentUnderTest.Tournamentstate);
            var startedTournament = this.target.TournamentStart(this.tournamentUnderTest);

            Debug.WriteLine("The end State: {0}", startedTournament.Tournamentstate);
            Assert.IsNotNull(startedTournament.StartedAt);
        }

        [TestMethod]
        [TestCategory("Tournament"), TestCategory("pychallongeTest")]
        public void TournamentReset()
        {
            this.target.ParticipantCreate(this.tournamentUnderTest, new ParticipantCreateParameters { Name = "#1" });
            this.target.ParticipantCreate(this.tournamentUnderTest, new ParticipantCreateParameters { Name = "#2" });

            this.target.TournamentStart(this.tournamentUnderTest);

            // we can't add participants to a started tournament...
            try
            {
                this.target.ParticipantCreate(this.tournamentUnderTest, new ParticipantCreateParameters { Name = "#3" });
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ChallongeException e)
            {
                Debug.WriteLine("Caught the planned exception: {0} - {1}", e.GetType(), e.Message);
            }

            this.target.TournamentReset(this.tournamentUnderTest);

            // but we can add participants to a reset tournament
            var p3 = this.target.ParticipantCreate(this.tournamentUnderTest, new ParticipantCreateParameters { Name = "#3" });

            this.target.ParticipantDestroy(this.tournamentUnderTest, p3);
        }
    }
}
