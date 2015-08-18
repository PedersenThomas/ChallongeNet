using System.Diagnostics;
using System.Linq;
using ChallongeNet.OptionalParameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallongeNet.TestProject
{
    [TestClass]
    public class AttachmentTest
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

        // [TestMethod]
        // [TestCategory("Attachment")]
        public void CreateAttachment()
        {
            var name = "TournamentTest" + Utilities.RandomName();

            var tournamentParameter = new TournamentCreateParameters { AcceptAttachments = true };
            this.tournament = this.target.TournamentCreate(name, TournamentType.DoubleElimination, name, tournamentParameter);
            Assert.IsTrue(this.tournament.AcceptAttachments);
            Debug.WriteLine("Created: ({0}){1} Url:{2} subdomain:{3}", this.tournament.Id, this.tournament.Name, this.tournament.Url, this.tournament.Subdomain);

            var participant1 = this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters
                {
                    Name = Utilities.RandomName()
                });
            var participant2 = this.target.ParticipantCreate(this.tournament, new ParticipantCreateParameters
                {
                    Name = Utilities.RandomName()
                });
            this.tournament = this.target.TournamentStart(this.tournament);

            var matches = this.target.MatchIndex(this.tournament);

            var match1 = matches.First();
            var parameters = new AttachmentCreateParameters
                {
                    Description = "This is just another description",
                    Asset = "The quick brown fox jumps over the lazy dog."
                };
            Debug.WriteLine("Attachment Create request");
            var attachment = this.target.AttachmentCreate(this.tournament, match1.Id, parameters);
            Assert.IsNotNull(attachment);
        }
    }
}
