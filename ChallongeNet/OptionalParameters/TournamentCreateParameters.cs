using System.Collections.Generic;

namespace ChallongeNet.OptionalParameters
{
    public class TournamentCreateParameters
    {
        private string subdomain;
        private bool subdomainIsSet;

        private string description;
        private bool descriptionIsSet;

        private bool openSignup;
        private bool openSignupIsSet;

        private bool holdThirdPlaceMatch;
        private bool holdThirdPlaceMatchIsSet;

        private double ptsForMatchWin;
        private bool ptsForMatchWinIsSet;

        private double ptsForMatchTie;
        private bool ptsForMatchTieIsSet;

        private double ptsForGameWin;
        private bool ptsForGameWinIsSet;

        private double ptsForGameTie;
        private bool ptsForGameTieIsSet;

        private double ptsForBye;
        private bool ptsForByeIsSet;

        private int swissRounds;
        private bool swissRoundsIsSet;

        private TournamentRankedBy rankedBy;
        private bool rankedByIsSet;

        private double rrPtsForMatchWin;
        private bool rrPtsForMatchWinIsSet;

        private double rrPtsForMatchTie;
        private bool rrPtsForMatchTieIsSet;

        private double rrPtsForGameWin;
        private bool rrPtsForGameWinIsSet;

        private double rrPtsForGameTie;
        private bool rrPtsForGameTieIsSet;

        private bool acceptAttachments;
        private bool acceptAttachmentsIsSet;

        private bool hideForum;
        private bool hideForumIsSet;

        private bool showRounds;
        private bool showRoundsIsSet;

        private bool isPrivate;
        private bool isPprivateIsSet;

        private bool notifyUsersWhenMatchesOpen;
        private bool notifyUsersWhenMatchesOpenIsSet;

        private bool notifyUsersWhenTheTournamentEnds;
        private bool notifyUsersWhenTheTournamentEndsIsSet;

        private bool sequentialPairings;
        private bool sequentialPairingsIsSet;

        private int signupCap;
        private bool signupCapIsSet;

        public string Subdomain
        {
            get
            {
                return this.subdomain;
            }

            set
            {
                this.subdomain = value;
                this.subdomainIsSet = true;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
                this.descriptionIsSet = true;
            }
        }

        public bool OpenSignup
        {
            get
            {
                return this.openSignup;
            }

            set
            {
                this.openSignup = value;
                this.openSignupIsSet = true;
            }
        }

        public bool HoldThirdPlaceMatch
        {
            get
            {
                return this.holdThirdPlaceMatch;
            }

            set
            {
                this.holdThirdPlaceMatch = value;
                this.holdThirdPlaceMatchIsSet = true;
            }
        }

        public double PtsForMatchWin
        {
            get
            {
                return this.ptsForMatchWin;
            }

            set
            {
                this.ptsForMatchWin = value;
                this.ptsForMatchWinIsSet = true;
            }
        }

        public double PtsForMatchTie
        {
            get
            {
                return this.ptsForMatchTie;
            }

            set
            {
                this.ptsForMatchTie = value;
                this.ptsForMatchTieIsSet = true;
            }
        }

        public double PtsForGameWin
        {
            get
            {
                return this.ptsForGameWin;
            }

            set
            {
                this.ptsForGameWin = value;
                this.ptsForGameWinIsSet = true;
            }
        }

        public double PtsForGameTie
        {
            get
            {
                return this.ptsForGameTie;
            }

            set
            {
                this.ptsForGameTie = value;
                this.ptsForGameTieIsSet = true;
            }
        }

        public double PtsForBye
        {
            get
            {
                return this.ptsForBye;
            }

            set
            {
                this.ptsForBye = value;
                this.ptsForByeIsSet = true;
            }
        }

        public int SwissRounds
        {
            get
            {
                return this.swissRounds;
            }

            set
            {
                this.swissRounds = value;
                this.swissRoundsIsSet = true;
            }
        }

        public TournamentRankedBy RankedBy
        {
            get
            {
                return this.rankedBy;
            }

            set
            {
                this.rankedBy = value;
                this.rankedByIsSet = true;
            }
        }

        public double RrPtsForMatchWin
        {
            get
            {
                return this.rrPtsForMatchWin;
            }

            set
            {
                this.rrPtsForMatchWin = value;
                this.rrPtsForMatchWinIsSet = true;
            }
        }

        public double RrPtsForMatchTie
        {
            get
            {
                return this.rrPtsForMatchTie;
            }

            set
            {
                this.rrPtsForMatchTie = value;
                this.rrPtsForMatchTieIsSet = true;
            }
        }

        public double RrPtsForGameWin
        {
            get
            {
                return this.rrPtsForGameWin;
            }

            set
            {
                this.rrPtsForGameWin = value;
                this.rrPtsForGameWinIsSet = true;
            }
        }

        public double RrPtsForGameTie
        {
            get
            {
                return this.rrPtsForGameTie;
            }

            set
            {
                this.rrPtsForGameTie = value;
                this.rrPtsForGameTieIsSet = true;
            }
        }

        public bool AcceptAttachments
        {
            get
            {
                return this.acceptAttachments;
            }

            set
            {
                this.acceptAttachments = value;
                this.acceptAttachmentsIsSet = true;
            }
        }

        public bool HideForum
        {
            get
            {
                return this.hideForum;
            }

            set
            {
                this.hideForum = value;
                this.hideForumIsSet = true;
            }
        }

        public bool ShowRounds
        {
            get
            {
                return this.showRounds;
            }

            set
            {
                this.showRounds = value;
                this.showRoundsIsSet = true;
            }
        }

        public bool Private
        {
            get
            {
                return this.isPrivate;
            }

            set
            {
                this.isPrivate = value;
                this.isPprivateIsSet = true;
            }
        }

        public bool NotifyUsersWhenMatchesOpen
        {
            get
            {
                return this.notifyUsersWhenMatchesOpen;
            }

            set
            {
                this.notifyUsersWhenMatchesOpen = value;
                this.notifyUsersWhenMatchesOpenIsSet = true;
            }
        }

        public bool NotifyUsersWhenTheTournamentEnds
        {
            get
            {
                return this.notifyUsersWhenTheTournamentEnds;
            }

            set
            {
                this.notifyUsersWhenTheTournamentEnds = value;
                this.notifyUsersWhenTheTournamentEndsIsSet = true;
            }
        }

        public bool SequentialPairings
        {
            get
            {
                return this.sequentialPairings;
            }

            set
            {
                this.sequentialPairings = value;
                this.sequentialPairingsIsSet = true;
            }
        }

        public int SignupCap
        {
            get
            {
                return this.signupCap;
            }

            set
            {
                this.signupCap = value;
                this.signupCapIsSet = true;
            }
        }

        internal Dictionary<string, dynamic> ToDictionary()
        {
            var tournament = new Dictionary<string, dynamic>();
            if (this.subdomainIsSet)
            {
                tournament["subdomain"] = this.subdomain;
            }

            if (this.descriptionIsSet)
            {
                tournament["description"] = this.description;
            }

            if (this.openSignupIsSet)
            {
                tournament["open_signup"] = this.openSignup;
            }

            if (this.holdThirdPlaceMatchIsSet)
            {
                tournament["hold_third_place_match"] = this.holdThirdPlaceMatch;
            }

            if (this.ptsForMatchWinIsSet)
            {
                tournament["pts_for_match_win"] = this.ptsForMatchWin;
            }

            if (this.ptsForMatchTieIsSet)
            {
                tournament["pts_for_match_tie"] = this.ptsForMatchTie;
            }

            if (this.ptsForGameWinIsSet)
            {
                tournament["pts_for_game_win"] = this.ptsForGameWin;
            }

            if (this.ptsForGameTieIsSet)
            {
                tournament["pts_for_game_tie"] = this.ptsForGameTie;
            }

            if (this.ptsForByeIsSet)
            {
                tournament["pts_for_bye"] = this.ptsForBye;
            }

            if (this.swissRoundsIsSet)
            {
                tournament["swiss_rounds"] = this.swissRounds;
            }

            if (this.rankedByIsSet)
            {
                tournament["ranked_by"] = this.rankedBy.ToChallongeString();
            }

            if (this.rrPtsForMatchWinIsSet)
            {
                tournament["rr_pts_for_match_win"] = this.rrPtsForMatchWin;
            }

            if (this.rrPtsForMatchTieIsSet)
            {
                tournament["rr_pts_for_match_tie"] = this.rrPtsForMatchTie;
            }

            if (this.rrPtsForGameWinIsSet)
            {
                tournament["rr_pts_for_game_win"] = this.rrPtsForGameWin;
            }

            if (this.rrPtsForGameTieIsSet)
            {
                tournament["rr_pts_for_game_tie"] = this.rrPtsForGameTie;
            }

            if (this.acceptAttachmentsIsSet)
            {
                tournament["accept_attachments"] = this.acceptAttachments;
            }

            if (this.hideForumIsSet)
            {
                tournament["hide_forum"] = this.hideForum;
            }

            if (this.showRoundsIsSet)
            {
                tournament["show_rounds"] = this.showRounds;
            }

            if (this.isPprivateIsSet)
            {
                tournament["private"] = this.isPrivate;
            }

            if (this.notifyUsersWhenMatchesOpenIsSet)
            {
                tournament["notify_users_when_matches_open"] = this.notifyUsersWhenMatchesOpen;
            }

            if (this.notifyUsersWhenTheTournamentEndsIsSet)
            {
                tournament["notify_users_when_the_tournament_ends"] = this.notifyUsersWhenTheTournamentEnds;
            }

            if (this.sequentialPairingsIsSet)
            {
                tournament["sequential_pairings"] = this.sequentialPairings;
            }

            if (this.signupCapIsSet)
            {
                tournament["signup_cap"] = this.signupCap;
            }

            var dictionary = new Dictionary<string, dynamic>();
            dictionary["tournament"] = tournament;
            return dictionary;
        }
    }
}
