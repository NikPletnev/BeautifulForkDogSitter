using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Helpers
{
    public static class EmailTopic
    {
        public const string ProfileCreated = "Profile created";
        public const string NewSitter = "New sitter";
        public const string ProfileDeleted = "Profile deleted";
        public const string Verify = "Your profile has been verified";
        public const string Restore = "Your profile has been restored";
        public const string Block = "Your profile is blocked";
        public const string NewOrder = "You have received a new order";
        public const string UpdateOrder = "One of your orders has changes";
        public const string UpdateRating = "You have been given a new rating";
        public const string NewCommentForSitter = "You have a new review";
        public const string NewCommentForAdmin = "The website has a new review";

    }
}
