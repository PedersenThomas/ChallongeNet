using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ChallongeNet.OptionalParameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallongeNet.TestProject
{
    [TestClass]
    public class MatchTest
    {
        private ChallongeV1 target;

        [TestInitialize]
        public void Initialize()
        {
            var username = Properties.Settings.Default.username;
            var apiKey = Properties.Settings.Default.apiKey;

            this.target = new ChallongeV1(username, apiKey);
        }

        [TestMethod]
        [TestCategory("Match")]
        public void MatchIndex()
        {
            string tournamentName = "ChallongeNet" + Utilities.RandomName();
            Debug.WriteLine(string.Format("Initializing with name {0}", tournamentName));

            var tournamentUnderTest = this.target.TournamentCreate(tournamentName, TournamentType.SingleElimination, tournamentName);

            var participantNames = new HashSet<string>();
            const int NumberOfParticipants = 8;
            while (participantNames.Count < NumberOfParticipants)
            {
                string name = "ChallongeNet" + Utilities.RandomName();
                participantNames.Add(name);
            }

            var participants = participantNames.Select(name => this.target.ParticipantCreate(tournamentUnderTest, new ParticipantCreateParameters { Name = name })).ToList();

            tournamentUnderTest = this.target.TournamentStart(tournamentUnderTest);

            var participant = participants.First();
            var parameters = new MatchIndexParameters { ParticipantId = participant.Id };
            var matches = this.target.MatchIndex(tournamentUnderTest, parameters);
            var m = matches.Where(match => match.Player1Id == participant.Id || match.Player2Id == participant.Id);
            Assert.AreEqual(1, m.Count());

            parameters = new MatchIndexParameters { State = MatchIndexParameters.MatchIndexState.complete };
            matches = this.target.MatchIndex(tournamentUnderTest, parameters);
            Assert.AreEqual(0, matches.Count);

            this.target.TournamentDestroy(tournamentUnderTest);
        }
    }
}
