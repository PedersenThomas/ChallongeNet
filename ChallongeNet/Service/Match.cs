using System;
using System.Collections.Generic;
using System.Net;
using ChallongeNet.OptionalParameters;

namespace ChallongeNet
{
    public partial class ChallongeV1
    {
        /// <summary>
        /// List all matches in a tournament.
        /// </summary>
        /// <param name="tournament"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IList<Match> MatchIndex(Tournament tournament, MatchIndexParameters parameters = null)
        {
            string url = string.Format("tournaments/{0}/matches", this.TournamentIdentifier(tournament));
            var param = new Dictionary<string, dynamic>();
            if (parameters != null)
            {
                param = parameters.ToDictionary();
            }

            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Get, param);

            return Deserializer.ListOfMatches(json);
        }

        /// <summary>
        /// Fetch a specific match.
        /// </summary>
        /// <param name="tournament"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public Match MatchShow(Tournament tournament, int matchId)
        {
            string url = string.Format("tournaments/{0}/matches/{1}", this.TournamentIdentifier(tournament), matchId);
            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Get);

            return Deserializer.Match(json);
        }

        /// <summary>
        /// Change some information about the match.
        /// </summary>
        /// <param name="tournament"></param>
        /// <param name="matchId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Match MatchUpdate(Tournament tournament, int matchId, MatchUpdateParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            var param = parameters.ToDictionary();

            string url = string.Format("tournaments/{0}/matches/{1}", this.TournamentIdentifier(tournament), matchId);
            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Put, param);

            return Deserializer.Match(json);
        }
    }
}
