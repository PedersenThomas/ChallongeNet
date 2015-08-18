using System.Diagnostics;
using System.Linq;
using ChallongeNet.OptionalParameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallongeNet.TestProject.Pychallonge.Test
{
    [TestClass]
    public class MatchTestCase
    {
        private ChallongeV1 target;
        private string tournamentName;
        private Tournament tournamentUnderTest;
        private string particiant1Name;
        private string particiant2Name;
        private Participant participant1;
        private Participant participant2;

        [TestInitialize]
        public void Initialize()
        {
            var username = Properties.Settings.Default.username;
            var apiKey = Properties.Settings.Default.apiKey;

            this.tournamentName = Utilities.RandomName();
            Debug.WriteLine(string.Format("Initializing with name {0}", this.tournamentName));
            this.target = new ChallongeV1(username, apiKey);

            this.tournamentUnderTest = this.target.TournamentCreate(this.tournamentName, TournamentType.SingleElimination, this.tournamentName);

            this.particiant1Name = "TommeAPITest" + Utilities.RandomName();
            this.participant1 = this.target.ParticipantCreate(this.tournamentUnderTest, new ParticipantCreateParameters { Name = this.particiant1Name });
            this.particiant2Name = "TommeAPITest" + Utilities.RandomName();
            this.participant2 = this.target.ParticipantCreate(this.tournamentUnderTest, new ParticipantCreateParameters { Name = this.particiant2Name });

            this.tournamentUnderTest = this.target.TournamentStart(this.tournamentUnderTest);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Debug.WriteLine("Cleaning up");
            this.target.TournamentDestroy(this.tournamentUnderTest);
        }

        [TestMethod]
        [TestCategory("Match"), TestCategory("pychallongeTest")]
        public void MatchIndex()
        {
            var ms = this.target.MatchIndex(this.tournamentUnderTest);
            Assert.AreEqual(1, ms.Count());

            var match = ms.First();
            Assert.AreEqual(MatchState.open, match.State);
        }

        [TestMethod]
        [TestCategory("Match"), TestCategory("pychallongeTest")]
        public void MatchShow()
        {
            var ms = this.target.MatchIndex(this.tournamentUnderTest);
            foreach (var match in ms)
            {
                var matchShow = this.target.MatchShow(this.tournamentUnderTest, match.Id);
                Assert.AreEqual(match.Id, matchShow.Id);
            }
        }

        [TestMethod]
        [TestCategory("Match"), TestCategory("pychallongeTest")]
        public void MatchUpdateScores()
        {
            var ms = this.target.MatchIndex(this.tournamentUnderTest);
            Assert.AreEqual(1, ms.Count());

            var match = ms.First();
            Assert.AreEqual(MatchState.open, match.State);

            const string Score = "3-2,4-1,2-2";
            var parameters = new MatchUpdateParameters { ScoresCsv = Score, WinnerId = this.participant1.Id };

            match = this.target.MatchUpdate(this.tournamentUnderTest, match.Id, parameters);
            Assert.AreEqual(MatchState.complete, match.State);
            Assert.AreEqual(this.participant1.Id, match.WinnerId);
            Assert.AreEqual(this.participant2.Id, match.LoserId);
            Assert.AreEqual(Score, match.ScoresCsv);
        }
    }
}
