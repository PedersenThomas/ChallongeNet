using System;
using System.Collections.Generic;

namespace ChallongeNet.OptionalParameters
{
    public class TournamentUpdateParameters
    {
        private string name;
        private bool nameIsSet;

        private TournamentType type;
        private bool typeIsSet;

        private string url;
        private bool urlIsSet;

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
        private bool isPrivateIsSet;

        private bool notifyUsersWhenMatchesOpen;
        private bool notifyUsersWhenMatchesOpenIsSet;

        private bool notifyUsersWhenTheTournamentEnds;
        private bool notifyUsersWhenTheTournamentEndsIsSet;

        private bool sequentialPairings;
        private bool sequentialPairingsIsSet;

        private int signupCap;
        private bool signupCapIsSet;

        private DateTime? startAt;
        private bool startAtIsSet;

        private int? checkInDuration;
        private bool checkInDurationIsSet;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.nameIsSet = true;
            }
        }

        public TournamentType Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
                this.typeIsSet = true;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.urlIsSet = true;
            }
        }

        public string Domain
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

        public bool @Private
        {
            get
            {
                return this.isPrivate;
            }

            set
            {
                this.isPrivate = value;
                this.isPrivateIsSet = true;
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

        public DateTime? StartAt
        {
            get
            {
                return this.startAt;
            }

            set
            {
                this.startAt = value;
                this.startAtIsSet = true;
            }
        }

        public int? CheckInDuration
        {
            get
            {
                return this.checkInDuration;
            }

            set
            {
                this.checkInDuration = value;
                this.checkInDurationIsSet = true;
            }
        }

        internal Dictionary<string, dynamic> ToDictionary()
        {
            var tour = new Dictionary<string, dynamic>();

            if (this.nameIsSet)
            {
                tour["name"] = this.name;
            }

            if (this.typeIsSet)
            {
                tour["tournament_type"] = this.type.ToChallongeString();
            }

            if (this.urlIsSet)
            {
                tour["url"] = this.url;
            }

            if (this.subdomainIsSet)
            {
                tour["subdomain"] = this.subdomain;
            }

            if (this.descriptionIsSet)
            {
                tour["description"] = this.description;
            }

            if (this.openSignupIsSet)
            {
                tour["open_signup"] = this.openSignup.ToString().ToLower();
            }

            if (this.holdThirdPlaceMatchIsSet)
            {
                tour["hold_third_place_match"] = this.holdThirdPlaceMatch.ToString().ToLower();
            }

            if (this.ptsForMatchWinIsSet)
            {
                tour["pts_for_match_win"] = this.ptsForMatchWin;
            }

            if (this.ptsForMatchTieIsSet)
            {
                tour["pts_for_match_tie"] = this.ptsForMatchTie;
            }

            if (this.ptsForGameWinIsSet)
            {
                tour["pts_for_game_win"] = this.ptsForGameWin;
            }

            if (this.ptsForGameTieIsSet)
            {
                tour["pts_for_game_tie"] = this.ptsForGameTie;
            }

            if (this.ptsForByeIsSet)
            {
                tour["pts_for_bye"] = this.ptsForBye;
            }

            if (this.swissRoundsIsSet)
            {
                tour["swiss_rounds"] = this.swissRounds;
            }

            if (this.rankedByIsSet)
            {
                tour["ranked_by"] = this.rankedBy.ToChallongeString();
            }

            if (this.rrPtsForMatchWinIsSet)
            {
                tour["rr_pts_for_match_win"] = this.rrPtsForMatchWin;
            }

            if (this.rrPtsForMatchTieIsSet)
            {
                tour["rr_pts_for_match_tie"] = this.rrPtsForMatchTie;
            }

            if (this.rrPtsForGameWinIsSet)
            {
                tour["rr_pts_for_game_win"] = this.rrPtsForGameWin;
            }

            if (this.rrPtsForGameTieIsSet)
            {
                tour["rr_pts_for_game_tie"] = this.rrPtsForGameTie;
            }

            if (this.acceptAttachmentsIsSet)
            {
                tour["accept_attachments"] = this.acceptAttachments.ToString().ToLower();
            }

            if (this.hideForumIsSet)
            {
                tour["hide_forum"] = this.hideForum.ToString().ToLower();
            }

            if (this.showRoundsIsSet)
            {
                tour["show_rounds"] = this.showRounds.ToString().ToLower();
            }

            if (this.isPrivateIsSet)
            {
                tour["private"] = this.isPrivate.ToString().ToLower();
            }

            if (this.notifyUsersWhenMatchesOpenIsSet)
            {
                tour["notify_users_when_matches_open"] = this.notifyUsersWhenMatchesOpen.ToString().ToLower();
            }

            if (this.notifyUsersWhenTheTournamentEndsIsSet)
            {
                tour["notify_users_when_the_tournament_ends"] = this.notifyUsersWhenTheTournamentEnds.ToString().ToLower();
            }

            if (this.sequentialPairingsIsSet)
            {
                tour["sequential_pairings"] = this.sequentialPairings.ToString().ToLower();
            }

            if (this.signupCapIsSet)
            {
                tour["signup_cap"] = this.signupCap;
            }

            if (this.startAtIsSet)
            {
                tour["start_at"] = this.startAt.HasValue ? this.startAt.Value.ToString("o") : null;
            }

            if (this.checkInDurationIsSet)
            {
                tour["check_in_duration"] = this.checkInDuration.HasValue ? this.checkInDuration.Value.ToString() : null;
            }

            var dictionary = new Dictionary<string, dynamic>();
            dictionary["tournament"] = tour;
            return dictionary;
        }
    }
}
