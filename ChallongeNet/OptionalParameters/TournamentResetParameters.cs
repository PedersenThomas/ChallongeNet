using System.Collections.Generic;

namespace ChallongeNet.OptionalParameters
{
    public class TournamentResetParameters
    {
        private bool includeParticipants;
        private bool includeParticipantsIsSet;

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

        internal Dictionary<string, dynamic> ToDictionary()
        {
            var dict = new Dictionary<string, dynamic>();
            if (this.includeParticipantsIsSet)
            {
                dict["include_participants"] = this.includeParticipants ? "1" : "0";
            }

            return dict;
        }
    }
}
