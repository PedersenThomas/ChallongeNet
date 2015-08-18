using System.Collections.Generic;

namespace ChallongeNet.OptionalParameters
{
    public class TournamentShowParameters
    {
        private bool includeParticipants;
        private bool includeParticipantsIsSet;

        private bool includeMatches;
        private bool includeMatchesIsSet;

        public bool IncludeParticipants
        {
            get
            {
                return this.includeParticipants;
            }

            set
            {
                this.includeParticipants = value;
                this.includeParticipantsIsSet = true;
            }
        }

        public bool IncludeMatches
        {
            get
            {
                return this.includeMatches;
            }

            set
            {
                this.includeMatches = value;
                this.includeMatchesIsSet = true;
            }
        }

        internal Dictionary<string, dynamic> ToDictionary()
        {
            var dict = new Dictionary<string, dynamic>();
            if (this.includeParticipantsIsSet)
            {
                dict["include_participants"] = this.includeParticipants ? "1" : "0";
            }

            if (this.includeMatchesIsSet)
            {
                dict["include_matches"] = this.includeMatches ? "1" : "0";
            }

            return dict;
        }
    }
}