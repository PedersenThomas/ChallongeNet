using System.Collections.Generic;

namespace ChallongeNet.OptionalParameters
{
    public class AttachmentCreateParameters
    {
        private string asset;
        private bool assetIsSet;

        private string url;
        private bool urlIsSet;

        private string description;
        private bool descriptionIsSet;

        public string Asset
        {
            get
            {
                return this.asset;
            }

            set
            {
                this.asset = value;
                this.assetIsSet = true;
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

        internal Dictionary<string, dynamic> ToDictionary()
        {
            var dict = new Dictionary<string, dynamic>();
            if (this.assetIsSet)
            {
                dict["asset"] = this.Asset;
            }

            if (this.urlIsSet)
            {
                dict["url"] = this.Url;
            }

            if (this.descriptionIsSet)
            {
                dict["description"] = this.Description;
            }

            var dictionary = new Dictionary<string, dynamic>();
            dictionary["match_attachment"] = dict;
            return dictionary;
        }
    }
}
