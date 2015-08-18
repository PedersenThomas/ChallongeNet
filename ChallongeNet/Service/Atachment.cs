using System;
using System.Collections.Generic;
using System.Net;
using ChallongeNet.OptionalParameters;

namespace ChallongeNet
{
    public partial class ChallongeV1
    {
        public Attachment AttachmentIndex(Tournament tournament, int matchId)
        {
            throw new NotImplementedException();
        }

        public Attachment AttachmentCreate(Tournament tournament, int matchId, AttachmentCreateParameters parameters = null)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            Dictionary<string, dynamic> param = parameters.ToDictionary();

            string url = string.Format("tournaments/{0}/matches/{1}/attachments", this.TournamentIdentifier(tournament), matchId);
            var json = this.MakeJsonRequest(url, WebRequestMethods.Http.Post, param);

            return Deserializer.Attachment(json);
        }

        public Attachment AttachmentShow(Tournament tournament, int matchId, int attachmentId)
        {
            throw new NotImplementedException();
        }

        public Attachment AttachmentUpdate(Tournament tournament, int matchId, AttachmentUpdateParameters parameters = null)
        {
            throw new NotImplementedException();
        }

        public Attachment AttachmentDelete(Tournament tournament, int matchId, int attachmentId)
        {
            throw new NotImplementedException();
        }
    }
}
