using System.Collections.Generic;

namespace ChallongeNet.OptionalParameters
{
    public class MatchUpdateParameters
    {
        private string scoresCsv;
        private bool scoresCsvIsSet;

        private int winnerId;
        private bool winnerIdIsSet;

        private string player1Votes;
        private bool player1VotesIsSet;

        private string player2Votes;
        private bool player2VotesIsSet;

        public string ScoresCsv
        {
            get
            {
                return this.scoresCsv;
            }

            set
            {
                this.scoresCsv = value;
                this.scoresCsvIsSet = true;
            }
        }

        public int WinnerId
        {
            get
            {
                return this.winnerId;
            }

            set
            {
                this.winnerId = value;
                this.winnerIdIsSet = true;
            }
        }

        public string Player1Votes
        {
            get
            {
                return this.player1Votes;
            }

            set
            {
                this.player1Votes = value;
                this.player1VotesIsSet = true;
            }
        }

        public string Player2Votes
        {
            get
            {
                return this.player2Votes;
            }

            set
            {
                this.player2Votes = value;
                this.player2VotesIsSet = true;
            }
        }

        internal Dictionary<string, dynamic> ToDictionary()
        {
            var match = new Dictionary<string, dynamic>();

            if (this.scoresCsvIsSet)
            {
                match["scores_csv"] = this.scoresCsv;
            }

            if (this.winnerIdIsSet)
            {
                match["winner_id"] = this.winnerId;
            }

            if (this.player1VotesIsSet)
            {
                match["player1_votes"] = this.player1Votes;
            }

            if (this.player2VotesIsSet)
            {
                match["player2_votes"] = this.player2Votes;
            }

            var dictionary = new Dictionary<string, dynamic>();
            dictionary["match"] = match;
            return dictionary;
        }
    }
}
