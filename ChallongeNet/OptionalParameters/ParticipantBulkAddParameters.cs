using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallongeNet.OptionalParameters
{
    public class ParticipantBulkAddParameters
    {
        private List<BulkParticipant> participants = new List<BulkParticipant>();

        public void Add(BulkParticipant participant)
        {
            this.participants.Add(participant);
        }

        internal Dictionary<string, dynamic> ToDictionary()
        {
            var json = new Dictionary<string, dynamic>();
            json["participants"] = this.participants.Select(p => p.ToDictionary()).ToList();

            return json;
        }
    }

    public class BulkParticipant
    {
        private bool nameIsSet;
        private string name;

        private string inviteNameOrEmail;
        private bool inviteNameOrEmailIsSet;

        private int seed;
        private bool seedIsSet;

        private string misc;
        private bool miscIsSet;

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

        public string InviteNameOrEmail
        {
            get
            {
                return this.inviteNameOrEmail;
            }

            set
            {
                this.inviteNameOrEmail = value;
                this.inviteNameOrEmailIsSet = true;
            }
        }

        public int Seed
        {
            get
            {
                return this.seed;
            }

            set
            {
                this.seed = value;
                this.seedIsSet = true;
            }
        }

        public string Misc
        {
            get
            {
                return this.misc;
            }

            set
            {
                if (value.Length > 255)
                {
                    throw new ArgumentException("Misc can not be more than 255 characters.");
                }

                this.misc = value;
                this.miscIsSet = true;
            }
        }

        internal Dictionary<string, dynamic> ToDictionary()
        {
            var dict = new Dictionary<string, dynamic>();
            if (this.nameIsSet)
            {
                dict["name"] = this.Name;
            }

            if (this.inviteNameOrEmailIsSet)
            {
                dict["invite_name_or_email"] = this.InviteNameOrEmail;
            }

            if (this.seedIsSet)
            {
                dict["seed"] = this.Seed;
            }

            if (this.miscIsSet)
            {
                dict["misc"] = this.Misc;
            }

            return dict;
        }
    }
}
