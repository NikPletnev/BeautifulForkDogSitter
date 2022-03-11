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

        public static string NewComment(int idOrder, int idComment)
        {
            string mess = $"New comment{idComment} left on order {idOrder}";
            return mess;
        }

        public static string NewOrderStatus(int idOrder, Status status)
        {
            string mess = $"Order{idOrder} status updated to {status}";
            return mess;
        }

    }
}
