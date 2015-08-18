using System;
using System.Diagnostics;
using System.Linq;
using ChallongeNet.OptionalParameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallongeNet.TestProject
{
    [TestClass]
    public class ParticipantTest
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
                this.target.TournamentDestroy(this.tournament);
            }
        }

        [TestMethod]
        [TestCategory("Paticipant")]
        public void CreateOptionalParameters()
        {
            var tournamentName = Utilities.RandomName();
            this.tournament = this.target.TournamentCreate(tournamentName, TournamentType.SingleElimination, tournamentName);

            var participant1Parameters = new ParticipantCreateParameters { Seed = 1, Name = Utilities.RandomName() };
            var participant1 = this.target.ParticipantCreate(this.tournament, participant1Parameters);

            var participant2Parameters = new ParticipantCreateParameters { Seed = 2, Name = Utilities.RandomName() };
            var participant2 = this.target.ParticipantCreate(this.tournament, participant2Parameters);

            var participant3Parameters = new ParticipantCreateParameters { Seed = 2, Name = Utilities.RandomName() };
            var participant3 = this.target.ParticipantCreate(this.tournament, participant3Parameters);

            var tourParameters = new TournamentShowParameters { IncludeParticipants = true };
            this.tournament = this.target.TournamentShow(this.tournament.Id, tourParameters);

            Assert.AreEqual(1, this.tournament.Participants.Find(p => p.Participant.Id == participant1.Id).Participant.Seed);
            Assert.AreEqual(2, this.tournament.Participants.Find(p => p.Participant.Id == participant3.Id).Participant.Seed);
            Assert.AreEqual(3, this.tournament.Participants.Find(p => p.Participant.Id == participant2.Id).Participant.Seed);
        }

        [TestMethod]
        [TestCategory("Paticipant")]
        public void ShowOptionalParameters()
        {
            var tournamentName = Utilities.RandomName();
            this.tournament = this.target.TournamentCreate(tournamentName, TournamentType.SingleElimination, tournamentName);

            var participant1 = this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters { Name = Utilities.RandomName() });
            this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters { Name = Utilities.RandomName() });

            this.target.TournamentStart(this.tournament);

            var parameters = new ParticipantShowParameters { IncludeMatches = true };
            var participant1Show = this.target.ParticipantShow(this.tournament, participant1.Id, parameters);

            Assert.IsNotNull(participant1Show.Matches);
            Assert.AreEqual(1, participant1Show.Matches.Count);
            Assert.IsNotNull(participant1Show.Matches.Find(p => p.Match.Player1Id == participant1.Id));
        }

        [TestMethod]
        [TestCategory("Paticipant")]
        public void UpdateParticipant()
        {
            var tournamentName = Utilities.RandomName();
            this.tournament = this.target.TournamentCreate(tournamentName, TournamentType.SingleElimination, tournamentName);

            var participant = this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters { ChallongeUsername = this.target.Username });
            Assert.IsTrue(participant.Active);
            Assert.IsNull(participant.CheckedInAt);
            Assert.IsFalse(participant.CheckedIn);
            Assert.IsTrue(participant.CreatedAt.HasValue);
            Utilities.AssertDateTimeWithin(DateTime.Now, participant.CreatedAt.Value, new TimeSpan(hours: 0, minutes: 1, seconds: 0));
            Assert.IsNull(participant.FinalRank);
            Assert.IsNull(participant.GroupId);
            Assert.IsNull(participant.Icon);
            Assert.IsTrue(participant.Id > 0);
            Assert.IsTrue(participant.InvitationId > 0);
            Assert.IsNull(participant.InviteEmail);
            Assert.IsNull(participant.Misc);
            Assert.IsNull(participant.Name);
            Assert.IsFalse(participant.OnWaitingList);
            Assert.AreEqual(1, participant.Seed);
            Assert.AreEqual(this.tournament.Id, participant.TournamentId);
            Assert.IsTrue(participant.UpdatedAt.HasValue);
            Utilities.AssertDateTimeWithin(DateTime.Now, participant.UpdatedAt.Value, new TimeSpan(hours: 0, minutes: 1, seconds: 0));
            Assert.AreEqual(this.target.Username, participant.ChallongeUsername);
            Assert.IsNotNull(participant.ChallongeEmailAddressVerified);
            Assert.IsTrue(participant.ChallongeEmailAddressVerified == true);
            Assert.IsTrue(participant.Removable);
            Assert.IsTrue(participant.ParticipatableOrInvitationAttached);
            Assert.IsTrue(participant.ConfirmRemove);
            Assert.IsFalse(participant.InvitationPending);
            Assert.AreEqual(this.target.Username, participant.DisplayNameWithInvitationEmailAddress);
            Assert.IsNotNull(participant.EmailHash);
            Assert.AreEqual(this.target.Username, participant.Username);
            Assert.IsNull(participant.AttachedUserPortraitUrl);
            Assert.IsFalse(participant.CanCheckIn);
            Assert.IsFalse(participant.Reactivatable);

            const string NewMisc = "Foobar";
            var updateParameter = new ParticipantUpdateParameters { Misc = NewMisc };

            var updatedParticipant = this.target.ParticipantUpdate(this.tournament, participant, updateParameter);
            Assert.IsTrue(updatedParticipant.Active);
            Assert.IsNull(updatedParticipant.CheckedInAt);
            Assert.IsFalse(updatedParticipant.CheckedIn);
            Assert.IsTrue(updatedParticipant.CreatedAt.HasValue);
            Utilities.AssertDateTimeWithin(DateTime.Now, updatedParticipant.CreatedAt.Value, new TimeSpan(hours: 0, minutes: 1, seconds: 0));
            Assert.IsNull(updatedParticipant.FinalRank);
            Assert.IsNull(updatedParticipant.GroupId);
            Assert.IsNull(updatedParticipant.Icon);
            Assert.IsTrue(updatedParticipant.Id > 0);
            Assert.IsTrue(updatedParticipant.InvitationId > 0);
            Assert.IsNull(updatedParticipant.InviteEmail);
            Assert.AreEqual(NewMisc, updatedParticipant.Misc);
            Assert.IsNull(updatedParticipant.Name);
            Assert.IsFalse(updatedParticipant.OnWaitingList);
            Assert.AreEqual(1, updatedParticipant.Seed);
            Assert.AreEqual(this.tournament.Id, updatedParticipant.TournamentId);
            Assert.IsTrue(updatedParticipant.UpdatedAt.HasValue);
            Utilities.AssertDateTimeWithin(DateTime.Now, updatedParticipant.UpdatedAt.Value, new TimeSpan(hours: 0, minutes: 1, seconds: 0));
            Assert.AreEqual(this.target.Username, updatedParticipant.ChallongeUsername);
            Assert.IsNotNull(participant.ChallongeEmailAddressVerified);
            Assert.IsTrue(participant.ChallongeEmailAddressVerified.Value);
            Assert.IsTrue(updatedParticipant.Removable);
            Assert.IsTrue(updatedParticipant.ParticipatableOrInvitationAttached);
            Assert.IsTrue(updatedParticipant.ConfirmRemove);
            Assert.IsFalse(updatedParticipant.InvitationPending);
            Assert.AreEqual(this.target.Username, participant.DisplayNameWithInvitationEmailAddress);
            Assert.IsNotNull(updatedParticipant.EmailHash);
            Assert.AreEqual(this.target.Username, participant.Username);
            Assert.IsNull(updatedParticipant.AttachedUserPortraitUrl);
            Assert.IsFalse(updatedParticipant.CanCheckIn);
            Assert.IsFalse(updatedParticipant.Reactivatable);
        }

        [TestMethod]
        [TestCategory("Paticipant")]
        public void BulkAddParticipants()
        {
            var tournamentName = Utilities.RandomName();
            this.tournament = this.target.TournamentCreate(tournamentName, TournamentType.SingleElimination, tournamentName);

            var param = new ParticipantBulkAddParameters();
            string name1 = Utilities.RandomName();
            string name2 = Utilities.RandomName();
            param.Add(new BulkParticipant { Name = name1 });
            param.Add(new BulkParticipant { Name = name2 });

            var result = this.target.ParticipantBulkAdd(this.tournament, param);
            Assert.IsTrue(result.Any(p => p.Name == name1));
            Assert.IsTrue(result.Any(p => p.Name == name1));
        }
    }
}
