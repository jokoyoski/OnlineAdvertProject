using ADit.Domain.Models;
using ADit.Interfaces;
using System;
using System.Web;

namespace ADit.Domain.Factories
{
    public class EmailFactory : IEmailFactory
    {
        /// <summary>
        /// Creates the registration request email.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEmailDetail CreateRegistrationRequestEmail(IRegistrationView registrationInfo, string activationCode)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            string domainName = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);

            var url = string.Format("{0}", "<a href=" + domainName + "/Account/ActivationCode?code=" +
                                           activationCode +
                                           ">Activate Account <a/>");


            var theSubject = "ADit Account Confirmation";
            var recipient = registrationInfo.Email;
            var theBody = "<p>Dear " + registrationInfo.FirstName + ",</p>";
            theBody = string.Format("{0} {1}", theBody,
                "Welcome to ADit. Please click on the confirmation link below to activate your account");
            theBody = string.Format("{0} {1}{2}", theBody, "<p> Your confirmation link is ", url);

            theBody = string.Format("{0} {1}", theBody, "</p> Thank you</p>");

            var mailDetail = new EmailDetail
            {
                Body = theBody,
                Recipients = recipient,
                Subject = theSubject
            };

            return mailDetail;
        }


        /// <summary>
        /// Creates the notification email.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        public IEmailDetail CreateNotificationEmail(IRegistrationView registrationInfo, int registrationId)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            // var token = string.Format("{0},{1},{2}", registrationInfo.FirstName.First(), registrationId, registrationInfo.LastName.Last());
            var theSubject = "Confirm your AA.HRMS Registration Request";
            var recipient = registrationInfo.Email;

            var theBody = "You are now registered for AA>HRMS services.";
            theBody = string.Format("{0} {1}{2}", theBody, "<br><br> Hello, .", registrationInfo.FirstName);
            theBody = string.Format("{0} {1}", theBody,
                "<br><br> You have a new Notification From ADit Scripting Service");
            theBody = string.Format("{0} {1}", theBody,
                "<br><br> Click on the link below to login and view your message");
            theBody = string.Format("{0} {1}", theBody, "<br><br> <a href='www.automataassociates.com'>ADit Login</a>");
            theBody = string.Format("{0} {1}", theBody, "<br><br> Thank you");

            var mailDetail = new EmailDetail
            {
                Body = theBody,
                Recipients = recipient,
                Subject = theSubject
            };

            return mailDetail;
        }

        //mail thhat sends the first message
        public IEmailDetail CreateSendScriptEmail(string userEmail, string FirstName, string LastName,
            string OrderTitle, string SendTo)
        {
            var theSubject = "Review";
            var recipient = userEmail;
            var theBody = string.Format("{0}", "Dear " + FirstName);
            theBody = string.Format("{0}  {1}", theBody, " your order has been reviewed, Login to review and get back to us");



            var email = new EmailDetail
            {
                Body = theBody,
                Recipients = recipient,
                Subject = theSubject
            };
            return email;
        }


        /// <summary>
        /// Creates the send contact us mail.
        /// </summary>
        /// <param name="contactEmail">The contact email.</param>
        /// <param name="userEmail">The user email.</param>
        /// <param name="name">The name.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IEmailDetail CreateSendContactUsMail(string contactEmail, string userEmail, string name,
            string phoneNumber, string message)
        {
            var theSubject = "New Contact Message";
            var recipient = contactEmail;
            var theBody = string.Empty;
            theBody = string.Format("{0}  {1} ", theBody, "<p><b>Name</b> " + name + "</p>");
            theBody = string.Format("{0} {1}", theBody, "<p>  <b>Mobile</b> " + phoneNumber + "</p>");
            theBody = string.Format("{0}{1}", theBody, "<p><b>Email</b> " + userEmail + "</p>");
            theBody = string.Format("{0}{1}", theBody, "<p><b>Message</b><br/> " + message + "</p>");


            var email = new EmailDetail
            {
                Body = theBody,
                Recipients = recipient,
                Subject = theSubject
            };
            return email;
        }

        /// <summary>
        /// Creates the customer message.
        /// </summary>
        /// <param name="receipientEmail">The receipient email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IEmailDetail CreateCustomerMessage(string receipientEmail, string subject, string message)
        {
            message =
                "<p>Dear Customer, we have receieved your message.</p> <p>Be rest assured that we are working on your request and we will get back to you as soon as possible</p> <p>Thanks</p> ";
            var email = new EmailDetail
            {
                Body = message,
                Recipients = receipientEmail,
                Subject = subject
            };
            return email;
        }

        public IEmailDetail CreatePickOrderEmail(int orderFulfilmentId, string customerEmail)
        {
            var message =
                $"<p>Dear Customer,</p> <p>Your order {orderFulfilmentId} is now assigned for fulfilment.</p> <p>Thank you</p>";
            var subject = "Order is now Assigned for Fulfilment";

            var email = new EmailDetail
            {
                Body = message,
                Recipients = customerEmail,
                Subject = subject
            };

            return email;
        }


        /// <summary>
        /// Creates the send email to admin.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="orderTitle">The order title.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="userEmail">The user email.</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEmailDetail CreateSendEmailToAdmin(string orderNumber, string orderTitle, string firstName,
            string userEmail, string type)
        {
            if (type == "Order")
            {
                var AdminSubject = "New Order Alert";
                var AdminRecipient = userEmail;
                var AdminBody = string.Format("<p>Dear Admin</p>");
                AdminBody = string.Format("{0} {1}", AdminBody, "<p>A new Order with Order Number : " + orderNumber);
                AdminBody = string.Format("{0}{1}", AdminBody, " has just been completed and  paid</p>");
                var emailDetails = new EmailDetail
                {
                    Body = AdminBody,
                    Recipients = AdminRecipient,
                    Subject = AdminSubject
                };
                return emailDetails;
            }


            var Subject = "Review";
            var recipients = userEmail;
            var Body = string.Format("{0}", "Dear " + firstName);
            Body = string.Format("{0} {1}", Body, "The order with " + orderNumber);
            Body = string.Format("{0}{1}", Body, "   has been reviewed");
            var emailDetail = new EmailDetail
            {
                Body = Body,
                Recipients = recipients,
                Subject = Subject
            };
            return emailDetail;
        }

        /// <summary>
        /// Sends the fulfilment payment mmail.
        /// </summary>
        /// <param name="orderFulfilmentActivityView">The order fulfilment activity view.</param>
        /// <param name="Name">The name.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public IEmailDetail SendScriptingFulfilmentPaymentMail(IFulfilmentPaymentView fulfilmentPayment, string Name, string Email, string OrderNumber)
        {

            var Subject = "OutStanding Payment";
            var Recipient = Email;
            // var Body = string.Format("<p>Dear {0} </p>", Name);
            var Body = string.Format("Dear " + Name + ", you have an outstanding payment for order " + OrderNumber);

            var emailDetails = new EmailDetail
            {
                Body = Body,
                Recipients = Recipient,
                Subject = Subject
            };
            return emailDetails;
        }



        public IEmailDetail SendMail(string Name, string Email)
        {

            var Subject = "Processing Order";
            var Recipient = Email;
            // var Body = string.Format("<p>Dear {0} </p>", Name);
            var Body = string.Format("Dear " + Name + " Your Order  is been processed and reviewed");

            var emailDetails = new EmailDetail
            {
                Body = Body,
                Recipients = Recipient,
                Subject = Subject
            };
            return emailDetails;
        }








        /// <summary>
        /// Sends the fulfilment mmail.
        /// </summary>
        /// <param name="orderFulfilmentActivityView">The order fulfilment activity view.</param>
        /// <param name="Name">The name.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public IEmailDetail SendFulfilmentMail(IOrderFulfilmentActivityView orderFulfilmentActivityView, string Name, string Email)
        {

            var Subject = "Fulfilment";
            var Recipient = Email;
            var Body = string.Format("<p>Dear {0} </p>", Name);
            Body = string.Format("{0} {1}", Body, orderFulfilmentActivityView.MailMessage);

            var emailDetails = new EmailDetail
            {
                Body = Body,
                Recipients = Recipient,
                Subject = Subject
            };
            return emailDetails;
        }

        /// <summary>
        /// Creates the forget password email.
        /// </summary>
        /// <param name="activationCode">The activation code.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public IEmailDetail CreateForgetPasswordEmail(string activationCode, string email)
        {
            string domainName = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);


            var url = string.Format("{0}", "<a href=" + domainName + "/Account/ConfirmPassword?code=" +
                                           activationCode +
                                           ">Change Password <a/>");

            var subject = "Change Password";
            var recipients = email;


            var body = string.Format("{0} {1} {2}",
                "<p>Dear Customer,</p> <p> We have received a request to change your password. Please click on the link provided to change your password </p> <p>",
                url, "</p><p>Please ignore this mail if you have not made this request</p>" +
                     "<p>ADit Team</p>");


            var emailDetail = new EmailDetail
            {
                Body = body,
                Recipients = recipients,
                Subject = subject
            };
            return emailDetail;
        }



        public IEmailDetail CreateAdminFulfilmentPayment(string email, int amount, string Subject)
        {


            Subject = Subject;
            var recipients = email;

            var Body = string.Format("The fulfilment payment for " + email + " and the sum of " + amount + " was paid");
            var emailDetail = new EmailDetail
            {
                Body = Body,
                Recipients = recipients,
                Subject = Subject
            };
            return emailDetail;
        }

    }
}