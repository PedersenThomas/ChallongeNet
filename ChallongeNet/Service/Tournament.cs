using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using ChallongeNet.OptionalParameters;

namespace ChallongeNet
{
    public partial class ChallongeV1
    {
        /// <summary>
        /// Retrieve a set of tournaments created with your account.
        /// </summary>
        /// <returns></returns>
        public IList<Tournament> TournamentIndex(TournamentIndexParameters parameters = null)
        {
            string url = string.Format("tournaments");
            var param = new Dictionary<string, dynamic>();
            if (parameters != null)
            {
                param = parameters.ToDictionary();
            }

            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Get, param);
            return Deserializer.ListOfTournaments(json);
        }

        /// <summary>
        /// Create a new tournament.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="url"> </param>
        /// <param name="parameters"> </param>
        /// <returns></returns>
        public Tournament TournamentCreate(string name, TournamentType type, string url, TournamentCreateParameters parameters = null)
        {
            string apiUrl = string.Format("tournaments");

            var param = new Dictionary<string, dynamic>();
            if (parameters != null)
            {
                param = parameters.ToDictionary();
            }

            if (!param.ContainsKey("tournament") || param["tournament"] == null)
            {
                param["tournament"] = new Dictionary<string, dynamic>();
            }

            param["tournament"]["name"] = name;
            param["tournament"]["tournament_type"] = type.ToChallongeString();
            param["tournament"]["url"] = url;

            var json = this.MakeJsonRequest(apiUrl, WebRequestMethods.Http.Post, param);
            return Deserializer.Tournament(json);
        }

        /// <summary>
        /// Retrieve a single tournament record created with your account.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Tournament TournamentShow(int id, TournamentShowParameters parameters = null)
        {
            string url = string.Format("tournaments/{0}", id);

            var param = new Dictionary<string, dynamic>();
            if (parameters != null)
            {
                param = parameters.ToDictionary();
            }

            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Get, param);
            return Deserializer.Tournament(json);
        }

        /// <summary>
        /// Retrieve a single tournament record created with your account.
        /// </summary>
        /// <param name="subdomain"></param>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Tournament TournamentShow(string subdomain, string url, TournamentShowParameters parameters = null)
        {
            string interfaceUrl = string.Format("tournaments/{0}-{1}", subdomain, url);

            var param = new Dictionary<string, dynamic>();
            if (parameters != null)
            {
                param = parameters.ToDictionary();
            }

            var json = this.MakeJsonRequest(interfaceUrl, WebRequestMethods.Http.Get, param);
            return Deserializer.Tournament(json);
        }

        /// <summary>
        /// Update a tournament's attributes.
        /// </summary>
        /// <returns></returns>
        public Tournament TournamentUpdate(Tournament tournament, TournamentUpdateParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            Dictionary<string, dynamic> param = parameters.ToDictionary();

            if (param.Count == 0)
            {
                throw new ArgumentException("You need to change some parameters in order to call update.", "parameters");
            }

            string url = string.Format("tournaments/{0}", this.TournamentIdentifier(tournament));
            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Put, param);
            return Deserializer.Tournament(json);
        }

        /// <summary>
        /// Deletes a tournament along with all its associated records. There is no undo, so use with care!
        /// </summary>
        /// <returns></returns>
        public Tournament TournamentDestroy(Tournament tournament)
        {
            string url = string.Format("tournaments/{0}", this.TournamentIdentifier(tournament));
            var json = this.MakeJsonRequest(url, "DELETE");
            return Deserializer.Tournament(json);
        }

        /// <summary>
        /// Start a tournament, opening up first round matches for score reporting (matches/update) 
        /// The tournament must have at least 2 participants.
        /// </summary>
        /// <param name="tournament"></param>
        /// <param name="parameters"> </param>
        public Tournament TournamentStart(Tournament tournament, TournamentStartParameters parameters = null)
        {
            string url = string.Format("tournaments/{0}/start", this.TournamentIdentifier(tournament));
            var param = new Dictionary<string, dynamic>();
            if (parameters != null)
            {
                param = parameters.ToDictionary();
            }

            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Post, param);

            return Deserializer.Tournament(json);
        }

        /// <summary>
        /// Finalize a tournament, rendering its results permanent.
        /// </summary>
        /// <returns></returns>
        public Tournament TournamentFinalize(Tournament tournament)
        {
            string url = string.Format("tournaments/{0}/finalize", this.TournamentIdentifier(tournament));
            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Post);
            return Deserializer.Tournament(json);
        }

        /// <summary>
        /// Reset a tournament, clearing all of its scores and attachments. 
        /// You can then add/remove/edit participants before starting the tournament again (tournaments/start).
        /// 
        /// Discovery:
        ///     It does not clear for participants.
        /// </summary>
        /// <returns></returns>
        public Tournament TournamentReset(Tournament tournament, TournamentResetParameters parameters = null)
        {
            string url = string.Format("tournaments/{0}/reset", this.TournamentIdentifier(tournament));
            var param = new Dictionary<string, dynamic>();
            if (parameters != null)
            {
                param = parameters.ToDictionary();
            }

            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Post, param);

            return Deserializer.Tournament(json);
        }

        /// <summary>
        /// Extract the identifier from a Tournament.
        /// </summary>
        /// <param name="tournament"></param>
        /// <returns></returns>
        private string TournamentIdentifier(Tournament tournament)
        {
            return string.IsNullOrWhiteSpace(tournament.Subdomain)
                ? tournament.Id.ToString(CultureInfo.InvariantCulture)
                : string.Format("{0}-{1}", tournament.Subdomain, tournament.Url);
        }
    }
}
