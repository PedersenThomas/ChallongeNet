using System;
using System.Collections.Generic;

namespace ChallongeNet.OptionalParameters
{
    public enum IndexState
    {
        all,
        pending,
        in_progress,
        ended
    }

    public class TournamentIndexParameters
    {
        private IndexState state;
        private bool stateIsSet;

        private TournamentType type;
        private bool typeIsSet;

        private DateTime createdAfter;
        private bool createdAfterIsSet;

        private DateTime createdBefore;
        private bool createdBeforeIsSet;

        private string subdomain;
        private bool subdomainIsSet;

        public IndexState State
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

        public DateTime CreatedAfter
        {
            get
            {
                return this.createdAfter;
            }

            set
            {
                this.createdAfter = value;
                this.createdAfterIsSet = true;
            }
        }

        public DateTime CreatedBefore
        {
            get
            {
                return this.createdBefore;
            }

            set
            {
                this.createdBefore = value;
                this.createdBeforeIsSet = true;
            }
        }

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

        internal Dictionary<string, dynamic> ToDictionary()
        {
            var dictionary = new Dictionary<string, dynamic>();
            if (this.stateIsSet)
            {
                dictionary["state"] = this.state.ToString();
            }

            if (this.typeIsSet)
            {
                dictionary["type"] = this.type.ToString();
            }

            if (this.createdAfterIsSet)
            {
                dictionary["created_after"] = this.CreatedAfter.ToString("o");
            }

            if (this.createdBeforeIsSet)
            {
                dictionary["created_before"] = this.CreatedBefore.ToString("o");
            }

            if (this.subdomainIsSet)
            {
                dictionary["subdomain"] = this.Subdomain;
            }

            return dictionary;
        }
    }
}