using System;
using System.Diagnostics;
using System.Linq;
using ChallongeNet.OptionalParameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallongeNet.TestProject
{
    [TestClass]
    public class TournamentTest
    {
        private string username;
        private string apikey;
        private string subdomain;
        private ChallongeV1 target;
        private Tournament tournament;

        [TestInitialize]
        public void Initialize()
        {
            this.username = Properties.Settings.Default.username;
            this.apikey = Properties.Settings.Default.apiKey;
            this.subdomain = Properties.Settings.Default.organization;

            this.target = new ChallongeV1(this.username, this.apikey);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (this.tournament != null)
            {
                Debug.WriteLine("Deleting Tournament. id:{0} name:{1}", this.tournament.Id, this.tournament.Name);
                Debug.WriteLine("Deleting Tournament. id:{0} name:{1}", this.tournament.Id, this.tournament.Name);
                this.target.TournamentDestroy(this.tournament);
            }
        }

        [TestMethod]
        [TestCategory("Tournament")]
        public void CreateInOrganization()
        {
            var name = "TournamentTest" + Utilities.RandomName();

            var parameter = new TournamentCreateParameters { Subdomain = this.subdomain };
            this.tournament = this.target.TournamentCreate(name, TournamentType.DoubleElimination, name, parameter);
            Debug.WriteLine("Created: ({0}){1} Url:{2} subdomain:{3}", this.tournament.Id, this.tournament.Name, this.tournament.Url, this.tournament.Subdomain);

            var indexParam = new TournamentIndexParameters { Subdomain = this.subdomain };
            var tournaments = this.target.TournamentIndex(indexParam);
            foreach (var t in tournaments)
            {
                Debug.WriteLine("({0}){1} Url:{2} subdomain:{3}", t.Id, t.Name, t.Url, t.Subdomain);
            }

            Assert.IsTrue(tournaments.Any(t => t.Id == this.tournament.Id));

            var showTour = this.target.TournamentShow(this.subdomain, name);
            Assert.AreEqual(this.tournament.Id, showTour.Id);

            showTour = this.target.TournamentShow(this.tournament.Id);
            Assert.AreEqual(this.tournament.Id, showTour.Id);
        }

        [TestMethod]
        [TestCategory("Tournament")]
        public void ResetOganizationOptionalParameters()
        {
            var name = "TournamentTest" + Utilities.RandomName();

            var parameter = new TournamentCreateParameters { Subdomain = this.subdomain };
            this.tournament = this.target.TournamentCreate(name, TournamentType.DoubleElimination, name, parameter);

            var participant1 = this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters { Name = Utilities.RandomName() });
            var participant2 = this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters { Name = Utilities.RandomName() });

            this.target.TournamentStart(this.tournament);

            var resetParameters = new TournamentResetParameters { IncludeParticipants = true };
            var tourReset = this.target.TournamentReset(this.tournament, resetParameters);

            Assert.IsNotNull(tourReset.Participants);
            Assert.AreEqual(2, tourReset.Participants.Count);
        }

        [TestMethod]
        [TestCategory("Tournament")]
        public void StartOganizationOptionalParameters()
        {
            var name = "TournamentTest" + Utilities.RandomName();

            var parameter = new TournamentCreateParameters { Subdomain = this.subdomain };
            this.tournament = this.target.TournamentCreate(name, TournamentType.DoubleElimination, name, parameter);

            var participant1 = this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters { Name = Utilities.RandomName() });
            var participant2 = this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters { Name = Utilities.RandomName() });

            var startParameters = new TournamentStartParameters { IncludeParticipants = true, IncludeMatches = true };
            var tour = this.target.TournamentStart(this.tournament, startParameters);

            Assert.IsNotNull(tour.Participants);
            Assert.AreEqual(2, tour.Participants.Count);
            Assert.IsNotNull(tour.Matches);
            Assert.AreEqual(3, tour.Matches.Count);
        }

        [TestMethod]
        [TestCategory("Tournament")]
        public void UpdateEveryPropertyInATournament()
        {
            var name = "TournamentTest" + Utilities.RandomName();
            this.tournament = this.target.TournamentCreate(name, TournamentType.Swiss, name);

            Assert.AreEqual(String.Empty, this.tournament.Description);
            Assert.IsFalse(this.tournament.OpenSignup, "Default of open_signup is true");
            Assert.IsFalse(this.tournament.AcceptAttachments, "Default of accept_attachments is true");
            Assert.IsFalse(this.tournament.HideForum, "Default of hide_forum is true");
            Assert.IsFalse(this.tournament.ShowRounds, "Default of show_rounds is true");
            Assert.IsFalse(this.tournament.IsPrivate, "Default of isPrivate is true");
            Assert.IsTrue(this.tournament.NotifyUsersWhenMatchesOpen, "Default of notify_users_when_matches_open is true");
            Assert.IsTrue(this.tournament.NotifyUsersWhenTheTournamentEnds, "Default of notify_users_when_the_tournament_ends is true");
            Assert.IsFalse(this.tournament.SequentialPairings, "Default of sequential_pairings is true");
            Assert.IsNull(this.tournament.SignupCap, "Default of signup_cap is not null");
            Assert.IsFalse(this.tournament.HoldThirdPlaceMatch, "Default of hold_third_place_match is not false");
            Assert.AreEqual(1.0, this.tournament.PtsForMatchWin);
            Assert.AreEqual(0.5, this.tournament.PtsForMatchTie);
            Assert.AreEqual(0.0, this.tournament.PtsForGameWin);
            Assert.AreEqual(0.0, this.tournament.PtsForGameTie);
            Assert.AreEqual(1.0, this.tournament.PtsForBye);
            Assert.AreEqual(0, this.tournament.SwissRounds);
            Assert.IsNull(this.tournament.RankedBy);
            Assert.AreEqual(1.0, this.tournament.RrPtsForMatchWin);
            Assert.AreEqual(0.5, this.tournament.RrPtsForMatchTie);
            Assert.AreEqual(0.0, this.tournament.RrPtsForGameWin);
            Assert.AreEqual(0.0, this.tournament.RrPtsForGameTie);
            Assert.IsNull(this.tournament.StartAt, "Default of started_at is not null");
            Assert.IsTrue(this.tournament.CreatedAt.HasValue);
            Utilities.AssertDateTimeWithin(DateTime.Now, this.tournament.CreatedAt.Value, new TimeSpan(0, 1, 0));
            Assert.IsNull(this.tournament.CheckInDuration);

            // Properties unchanged but still checked.
            Assert.IsTrue(this.tournament.CreatedByApi);
            Assert.IsTrue(this.tournament.AllowParticipantMatchReporting);
            Assert.IsNull(this.tournament.Category);
            Assert.IsNull(this.tournament.CompletedAt);
            Assert.IsFalse(this.tournament.CreditCapped);
            Assert.IsNull(this.tournament.GameId);
            Assert.IsFalse(this.tournament.EnableGroupStage);
            Assert.IsFalse(this.tournament.HideSeeds);
            Assert.AreEqual(1, this.tournament.MaxPredictionsPerUser);
            Assert.AreEqual(0, this.tournament.ParticipantsCount);
            Assert.AreEqual(0, this.tournament.PredictionMethod);
            Assert.IsNull(this.tournament.PredictionsOpenedAt);
            Assert.AreEqual(0, this.tournament.ProgressMeter);
            Assert.IsFalse(this.tournament.QuickAdvance);
            Assert.IsFalse(this.tournament.RequireScoreAgreement);
            Assert.IsNull(this.tournament.StartedCheckingInAt);
            Assert.AreEqual(String.Empty, this.tournament.DescriptionSource);
            Assert.IsNull(this.tournament.Subdomain);
            Assert.AreEqual("http://challonge.com/" + name, this.tournament.FullChallongeUrl);
            Assert.AreEqual("http://images.challonge.com/" + name + ".png", this.tournament.LiveImageUrl);
            Assert.IsNull(this.tournament.SignUpUrl);
            Assert.IsTrue(this.tournament.ReviewBeforeFinalizing);
            Assert.IsFalse(this.tournament.AcceptingPredictions);
            Assert.IsFalse(this.tournament.ParticipantsLocked);
            Assert.IsNull(this.tournament.GameName);
            Assert.IsTrue(this.tournament.ParticipantsSwappable);
            Assert.IsFalse(this.tournament.TeamConvertable);
            Assert.IsFalse(this.tournament.GroupStagesWereStarted);

            // In order to test swiss_rounds we need some participants in the tournament.
            this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters { Name = Utilities.RandomName() });
            this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters { Name = Utilities.RandomName() });
            this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters { Name = Utilities.RandomName() });
            this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters { Name = Utilities.RandomName() });

            const string NewDescription = "My awesome Description";
            const int NewSignupCap = 16;
            int? newCheckInDuration = 10;
            DateTime newStartAt = DateTime.Now.AddHours(1.0);
            const double NewPtsForMatchWin = 2.0;
            const double NewPtsForMatchTie = 3.0;
            const double NewPtsForGameWin = 4.0;
            const double NewPtsForGameTie = 5.0;
            const double NewPtsForBye = 6.0;
            const int NewSwissRounds = 2;
            const double NewRrPtsForMatchWin = 7.0;
            const double NewRrPtsForMatchTie = 8.0;
            const double NewRrPtsForGameWin = 9.0;
            const double NewRrPtsForGameTie = 10.0;

            var updateParameters = new TournamentUpdateParameters
            {
                Description = NewDescription,
                OpenSignup = true,
                AcceptAttachments = true,
                HideForum = true,
                ShowRounds = true,
                Private = true,
                NotifyUsersWhenMatchesOpen = false,
                NotifyUsersWhenTheTournamentEnds = false,
                SequentialPairings = true,
                SignupCap = NewSignupCap,
                StartAt = newStartAt,
                CheckInDuration = newCheckInDuration,
                PtsForMatchWin = NewPtsForMatchWin,
                PtsForMatchTie = NewPtsForMatchTie,
                PtsForGameWin = NewPtsForGameWin,
                PtsForGameTie = NewPtsForGameTie,
                PtsForBye = NewPtsForBye,
                SwissRounds = NewSwissRounds,
                RrPtsForMatchWin = NewRrPtsForMatchWin,
                RrPtsForMatchTie = NewRrPtsForMatchTie,
                RrPtsForGameWin = NewRrPtsForGameWin,
                RrPtsForGameTie = NewRrPtsForGameTie,
                RankedBy = TournamentRankedBy.GameWins
            };

            var updatedTournament = this.target.TournamentUpdate(this.tournament, updateParameters);
            Assert.AreEqual(NewDescription, updatedTournament.Description);
            Assert.IsTrue(updatedTournament.OpenSignup);
            Assert.IsTrue(updatedTournament.AcceptAttachments);
            Assert.IsTrue(updatedTournament.HideForum);
            Assert.IsTrue(updatedTournament.ShowRounds);
            Assert.IsTrue(updatedTournament.IsPrivate);
            Assert.IsFalse(updatedTournament.NotifyUsersWhenMatchesOpen);
            Assert.IsFalse(updatedTournament.NotifyUsersWhenTheTournamentEnds);
            Assert.IsTrue(updatedTournament.SequentialPairings);
            Assert.AreEqual(NewSignupCap, updatedTournament.SignupCap);
            Assert.IsTrue(updatedTournament.StartAt.HasValue);
            Utilities.AssertDateTimeWithin(newStartAt, updatedTournament.StartAt.Value, new TimeSpan(hours: 0, minutes: 1, seconds: 0));
            Assert.AreEqual(newCheckInDuration, updatedTournament.CheckInDuration);

            Assert.AreEqual(NewPtsForMatchWin, updatedTournament.PtsForMatchWin);
            Assert.AreEqual(NewPtsForMatchTie, updatedTournament.PtsForMatchTie);
            Assert.AreEqual(NewPtsForGameWin, updatedTournament.PtsForGameWin);
            Assert.AreEqual(NewPtsForGameTie, updatedTournament.PtsForGameTie);
            Assert.AreEqual(NewPtsForBye, updatedTournament.PtsForBye);
            Assert.AreEqual(NewSwissRounds, updatedTournament.SwissRounds);
            Assert.AreEqual(TournamentRankedBy.GameWins, updatedTournament.RankedBy);
            Assert.AreEqual(NewRrPtsForMatchWin, updatedTournament.RrPtsForMatchWin);
            Assert.AreEqual(NewRrPtsForMatchTie, updatedTournament.RrPtsForMatchTie);
            Assert.AreEqual(NewRrPtsForGameWin, updatedTournament.RrPtsForGameWin);
            Assert.AreEqual(NewRrPtsForGameTie, updatedTournament.RrPtsForGameTie);
        }

        [TestMethod]
        [TestCategory("Tournament")]
        public void TournamentOperationsInSubdomainControlledByTournamentId()
        {
            var name = "TournamentTest" + Utilities.RandomName();

            var parameter = new TournamentCreateParameters { Subdomain = this.subdomain };
            this.tournament = this.target.TournamentCreate(name, TournamentType.DoubleElimination, name, parameter);

            const string NewDescription = "Just another description";
            var updateParameters = new TournamentUpdateParameters
            {
                Description = NewDescription
            };
            var updatedTournament = this.target.TournamentUpdate(new Tournament { Id = this.tournament.Id }, updateParameters);
            Assert.AreEqual(NewDescription, updatedTournament.Description);

            // In order to start a tournament do we need some participants.
            this.target.ParticipantCreate(new Tournament { Id = this.tournament.Id }, new ParticipantCreateParameters { Name = Utilities.RandomName() });
            this.target.ParticipantCreate(new Tournament { Id = this.tournament.Id }, new ParticipantCreateParameters { Name = Utilities.RandomName() });

            var startedTournament = this.target.TournamentStart(new Tournament { Id = this.tournament.Id });
            Assert.AreEqual(TournamentState.underway, startedTournament.Tournamentstate);
        }

        [TestMethod]
        [TestCategory("Tournament")]
        public void FinalizaTournament()
        {
            var name = "TournamentTest" + Utilities.RandomName();

            this.tournament = this.target.TournamentCreate(name, TournamentType.SingleElimination, name);

            var participant1 = this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters { Name = Utilities.RandomName() });
            var participant2 = this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters { Name = Utilities.RandomName() });

            this.target.TournamentStart(this.tournament);
            var matches = this.target.MatchIndex(this.tournament, new MatchIndexParameters { State = MatchIndexParameters.MatchIndexState.open });

            var match = matches[0];
            this.target.MatchUpdate(this.tournament, match.Id, new MatchUpdateParameters { ScoresCsv = "1-0", WinnerId = participant1.Id });

            var finalTournament = this.target.TournamentFinalize(this.tournament);
            Assert.AreEqual(TournamentState.complete, finalTournament.Tournamentstate);
            Assert.IsNotNull(finalTournament.CompletedAt);
            Utilities.AssertDateTimeWithin(DateTime.Now, finalTournament.CompletedAt.Value, new TimeSpan(hours: 0, minutes: 1, seconds: 0));
        }
    }
}
