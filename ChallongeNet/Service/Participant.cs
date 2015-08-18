using System;
using System.Collections.Generic;
using System.Net;
using ChallongeNet.OptionalParameters;

namespace ChallongeNet
{
    public partial class ChallongeV1
    {
        /// <summary>
        /// Receive a list of all the participants of a tournament.
        /// </summary>
        /// <param name="tournament"></param>
        /// <returns></returns>
        public IList<Participant> ParticipantIndex(Tournament tournament)
        {
            string url = string.Format("tournaments/{0}/participants", this.TournamentIdentifier(tournament));
            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Get);

            return Deserializer.ListOfParticipants(json);
        }

        /// <summary>
        /// Add a participant to a tournament.
        /// </summary>
        /// <param name="tournament"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Participant ParticipantCreate(Tournament tournament, ParticipantCreateParameters parameters = null)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            string url = string.Format("tournaments/{0}/participants", this.TournamentIdentifier(tournament));

            Dictionary<string, dynamic> param = parameters.ToDictionary();
            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Post, param);

            return Deserializer.Participant(json);
        }

        public IList<Participant> ParticipantBulkAdd(Tournament tournament, ParticipantBulkAddParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            string url = string.Format("tournaments/{0}/participants/bulk_add", this.TournamentIdentifier(tournament));
            Dictionary<string, dynamic> dictionary = parameters.ToDictionary();

            var response = this.MakeJsonRequest(url, WebRequestMethods.Http.Post, dictionary);
            return Deserializer.ListOfParticipants(response);
        }

        /// <summary>
        /// Fetch a specific participant.
        /// </summary>
        /// <param name="tournament"></param>
        /// <param name="participantId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Participant ParticipantShow(Tournament tournament, int participantId, ParticipantShowParameters parameters = null)
        {
            string url = string.Format("tournaments/{0}/participants/{1}", this.TournamentIdentifier(tournament), participantId);
            var param = new Dictionary<string, dynamic>();
            if (parameters != null)
            {
                param = parameters.ToDictionary();
            }

            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Get, param);
            return Deserializer.Participant(json);
        }

        /// <summary>
        /// Change some information about a participant.
        /// </summary>
        /// <param name="tournament"></param>
        /// <param name="participant"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Participant ParticipantUpdate(Tournament tournament, Participant participant, ParticipantUpdateParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            var param = parameters.ToDictionary();

            string url = string.Format("tournaments/{0}/participants/{1}", this.TournamentIdentifier(tournament), participant.Id);
            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Put, param);

            return Deserializer.Participant(json);
        }

        /// <summary>
        /// Remove a participant from a tournament.
        /// </summary>
        /// <param name="tournament"></param>
        /// <param name="participant"></param>
        /// <returns></returns>
        public Participant ParticipantDestroy(Tournament tournament, Participant participant)
        {
            string url = string.Format("tournaments/{0}/participants/{1}", this.TournamentIdentifier(tournament), participant.Id);
            var json = this.MakeJsonRequest(url, "DELETE");

            return Deserializer.Participant(json);
        }

        /// <summary>
        /// Randomize seeds among participants.
        /// </summary>
        /// <param name="tournament"></param>
        /// <returns></returns>
        public IEnumerable<Participant> ParticipantRandomize(Tournament tournament)
        {
            string url = string.Format("tournaments/{0}/participants/randomize", this.TournamentIdentifier(tournament));
            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Post);

            return Deserializer.ListOfParticipants(json);
        }
    }
}
