using System.Collections.Generic;

namespace ChallongeNet.OptionalParameters
{
    public class ParticipantShowParameters
    {
        private bool includeMatches;
        private bool includeMatchesIsSet;

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

            if (this.includeMatchesIsSet)
            {
                dict["include_matches"] = this.includeMatches ? "1" : "0";
            }

            return dict;
        }
    }
}
