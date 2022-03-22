using DogSitter.DAL.Enums;

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

        public const string PasswordChange = "Your password has been successfully changed. If it was not you, " +
            "please inform the administration of the site about it.";

        public const string ChangeUserEmailForNewEmail = "Your email has been successfully updated.";

        public const string ChangeUserEmailForOldEmail = "Your email has been successfully updated. " +
            "This email is no longer linked to your account, if this action was not committed by you, please contact the site administration.";

        public static string SitterCreatedForAdmin(int id) => $"Created a new sitter with id {id}, check its docs";

        public static string NewOrderForSitter(int id) => $"You have received a new order {id}";

        public static string UpdateOrderForSitter(int id) => $"The customer made changes to the order {id}";

        public static string NewComment(int idOrder) => $"New comment left on order {idOrder}. Visit the site to see";

        public static string NewOrderStatus(int idOrder, Status status) => $"Order{idOrder} status updated to {status}";

        public static string UpdateRatingSitter(double oldRating, double newRating) => $"You have been given a new mark. " +
            $"Your rating has been updated. Old rating: {oldRating}. New rating: {newRating}.";

        public static string ConfirmNewEmail(string token) => $"To confirm your mail, use the following token {token}";
        public static string RestorePessword(string token) => $"Use this token to recover your password {token} . If it was not you, " +
            "please inform the administration of the site about it.";


    }
}
