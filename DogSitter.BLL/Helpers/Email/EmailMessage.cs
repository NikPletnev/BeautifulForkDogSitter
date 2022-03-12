using DogSitter.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Helpers
{
    public static class EmailMessage
    {

        public const string SitterCreated = "The profile has been successfully created, " +
            "when your documents pass the verification, you will receive an email. Thanks!";
        
        public const string SitterVerified = "Your profile has been verified";

        public const string SitterBlocked = "Your profile is blocked, to find out more contact the site administration";

        public const string CustomerCreated = "The profile has been successfully created";

        public const string ProfileDeleted = "Your profile has been deleted, please contact the site administration to restore it";

        public const string ProfileRestore = "We are glad to see you again, your profile has been restored!";

        public static string SitterCreatedForAdmin(int id)
        {
            string mess = $"Created a new sitter with id {id}, check its docs";
            return mess;
        }

        public static string NewOrderForSitter(int id)
        {
            string mess = $"You have received a new order {id}";
            return mess;
        }

        public static string UpdateOrderForSitter(int id)
        {
            string mess = $"The customer made changes to the order {id}";
            return mess;
        }

        public static string NewComment(int idOrder)
        {
            string mess = $"New comment left on order {idOrder}. Visit the site to see";
            return mess;
        }

        public static string NewOrderStatus(int idOrder, Status status)
        {
            string mess = $"Order{idOrder} status updated to {status}";
            return mess;
        }

        public static string UpdateRatingSitter(double oldRating, double newRating)
        {
            string mess = $"You have been given a new mark. Your rating has been updated. Old rating: {oldRating}. New rating: {newRating}.";
            return mess;
        }

    }
}
