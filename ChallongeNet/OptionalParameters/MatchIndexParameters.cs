using System.Collections.Generic;

namespace ChallongeNet.OptionalParameters
{
    public class MatchIndexParameters
    {
        private MatchIndexState state;
        private bool stateIsSet;

        private int participantId;
        private bool participantIdIsSet;

        public enum MatchIndexState
        {
            all,
            pending,
            open,
            complete
        }

        public MatchIndexState State
        {
            get
            {
                return this.state;
            }

            set
            {
                this.state = value;
                this.stateIsSet = true;
            }
        }

        public int ParticipantId
        {
            get
            {
                return this.participantId;
            }

            set
            {
                this.participantId = value;
                this.participantIdIsSet = true;
            }
        }

        internal Dictionary<string, dynamic> ToDictionary()
        {
            var match = new Dictionary<string, dynamic>();

            if (this.stateIsSet)
            {
                match["state"] = this.state.ToString();
            }

            if (this.participantIdIsSet)
            {
                match["participant_id"] = this.participantId;
            }

            return match;
        }
    }
}
