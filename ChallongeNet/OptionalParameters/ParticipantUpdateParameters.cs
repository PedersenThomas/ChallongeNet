using System.Collections.Generic;

namespace ChallongeNet.OptionalParameters
{
    public class ParticipantUpdateParameters
    {
        private string name;
        private bool nameIsSet;

        private int seed;
        private bool seedIsSet;

        private string challongeUsername;
        private bool challongeUsernameIsSet;

        private string email;
        private bool emailIsSet;

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

        public string ChallongeUsername
        {
            get
            {
                return this.challongeUsername;
            }

            set
            {
                this.challongeUsername = value;
                this.challongeUsernameIsSet = true;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
                this.emailIsSet = true;
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
                this.misc = value;
                this.miscIsSet = true;
            }
        }

        internal Dictionary<string, dynamic> ToDictionary()
        {
            var participant = new Dictionary<string, dynamic>();
            if (this.nameIsSet)
            {
                participant["name"] = this.Name;
            }

            if (this.seedIsSet)
            {
                participant["seed"] = this.seed;
            }

            if (this.challongeUsernameIsSet)
            {
                participant["challonge_username"] = this.challongeUsername;
            }

            if (this.emailIsSet)
            {
                participant["email"] = this.email;
            }

            if (this.miscIsSet)
            {
                participant["misc"] = this.misc;
            }

            var dictionary = new Dictionary<string, dynamic>();
            dictionary["participant"] = participant;
            return dictionary;
        }
    }
}
