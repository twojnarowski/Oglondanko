namespace Oglondanko.Core.Domain
{
    public class VodLink
    {
        public string VodName { get; protected set;}
        public string VodUrl {get;protected set;}

        public Guid MovieId {get; protected set;}

        public DateTime CreatedAt {get;protected set;}

        public bool VodAvailable {get; protected set;}

        protected VodLink()
        {

        }

        public VodLink(Movie movie, string vodName, string vodUrl)
        {
            MovieId = movie.Id;
            VodName = vodName;
            VodUrl = vodUrl;
        }
    }
}