using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Blue_Jays_Manager.Models.Correspondence
{
    public class Email
    {
        public static void RegistrationConfirmation(string username, string password, string firstName, string lastName, string email, int coachNum)
        {
            MailMessage registraionMail = new MailMessage("noreply.bluejays@gmail.com", email);
            registraionMail.IsBodyHtml = true;
            registraionMail.Subject = "Toronto Blue Jays";
            registraionMail.Body = "<h3>Registration Confirmation</h3>" +
                                   "<br/>" +
                                   "<p>Thank you for registering for your coach account with the Toronto Blue Jays</p>" +
                                   "<p>Below you will find your registration details.</p>" +
                                   "<br/>" +
                                   "<p><b>Coach Name:</b> " + firstName + " " + lastName + "<br/>" +
                                   "<b>Coach Number:</b> " + coachNum.ToString() + "<br/>" +
                                   "<b>username:</b> " + username + "<br/>" +
                                   "<b>password:</b> " + password + "</p>" +
                                   "<br>" +
                                   "<p>Thank you<br/>" +
                                   "Blue Jays Administration</p>";



            SmtpClient client = new SmtpClient();
            client.Send(registraionMail);
        }

        public static void PasswordChangeConfirmation(string firstName, string lastName, string username, string password, string role, string email)
        {
            MailMessage registraionMail = new MailMessage("noreply.bluejays@gmail.com", email);
            registraionMail.IsBodyHtml = true;
            registraionMail.Subject = "Toronto Blue Jays";
            registraionMail.Body = "<h3>Password Change Confirmation</h3>" +
                                   "<br/>" +
                                   "<p>You have requested your password to be changed." + "<br/>" +
                                   "Below you will find your details.</p>" +
                                   "<br/>" +
                                   "<p><b>  Coach Name:</b> " + firstName + " " + lastName + "<br/>" +
                                   "<b>     Admin Role:</b> " + role + "<br/>" +
                                   "<b>     username:</b> " + username + "<br/>" +
                                   "<b>     password:</b> " + password + "</p>" +
                                   "<br>" +
                                   "<p>Thank you<br/>" +
                                   "Blue Jays Administration</p>";



            SmtpClient client = new SmtpClient();
            client.Send(registraionMail);
        }

        public static void AccountUnlockedConfirmation(string firstName, string lastName, string email)
        {
            MailMessage registraionMail = new MailMessage("noreply.bluejays@gmail.com", email);
            registraionMail.IsBodyHtml = true;
            registraionMail.Subject = "Toronto Blue Jays";
            registraionMail.Body = "<h3>Coach Account Information</h3>" +
                                   "<br/>" +
                                   "<p>" + firstName + " " + lastName + ", this is just a reminder that your coach user account for the Toronto Blue Jays has been unlocked." +
                                   "<br>" +
                                   "<p>Thank you<br/>" +
                                   "Blue Jays Administration</p>";



            SmtpClient client = new SmtpClient();
            client.Send(registraionMail);
        }

        public static int SendPasswordResetEmail(string email, string firstname, string lastname, string uid)
        {
            MailMessage mailMessage = new MailMessage("noreply.bluejays@gmail.com", email);
            int sent = 0;

            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("<h3>Password Reset Request</h3><br/><br/>");
            sbEmailBody.Append("Dear " + firstname + " " + lastname + ",<br/><br/>");
            sbEmailBody.Append("Please click on the following link to reset your password");
            sbEmailBody.Append("<br/>"); sbEmailBody.Append("http://localhost:3726//PasswordReset.aspx?uid=" + uid);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<p>Thank You,<br/>" +
                                "<b>Blue Jays Administration</b></p>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Toronto Blue Jays";


            SmtpClient client = new SmtpClient();
            client.Send(mailMessage);
            sent = 1;
            return sent;
        }

        public static int SendPasswordChangeConfirmation(string password, string firstName, string LastName, string email, string username)
        {

            MailMessage mailMessage = new MailMessage("noreply.bluejays@gmail.com", email);
            int sent = 0;

            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("<h3>Password Reset Successful</h3><br/><br/>");
            sbEmailBody.Append("Dear " + firstName + " " + LastName + ",<br/><br/>");
            sbEmailBody.Append("Your coach password has been reset");
            sbEmailBody.Append("<br/>");
            sbEmailBody.Append("Username: " + username);
            sbEmailBody.Append("<br/>");
            sbEmailBody.Append("New Password: " + password);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<p>Thank You,<br/>" +
                                "<b>Blue Jays Administration</b></p>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Toronto Blue Jays";


            SmtpClient client = new SmtpClient();
            client.Send(mailMessage);
            sent = 1;
            return sent;
        }

        public static int SendUserNameEmail(string email, string firstName, string lastName, string username)
        {
            MailMessage mailMessage = new MailMessage("noreply.bluejays@gmail.com", email);
            int sent = 0;

            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("<h3>Username Request</h3><br/><br/>");
            sbEmailBody.Append("Dear " + firstName + " " + lastName + ",<br/><br/>");
            sbEmailBody.Append("You have requested your username for your coach account.");
            sbEmailBody.Append("<br/>");
            sbEmailBody.Append("Username: " + username);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<p>Thank You,<br/>" +
                                "<b>Blue Jays Administration</b></p>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Toronto Blue Jays";


            SmtpClient client = new SmtpClient();
            client.Send(mailMessage);
            sent = 1;
            return sent;
        }
    }
}