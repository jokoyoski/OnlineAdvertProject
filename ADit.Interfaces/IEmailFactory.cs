 namespace ADit.Interfaces
{
    public interface IEmailFactory
    {
        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        IEmailDetail SendMail(string Name, string Email);
        /// <summary>
        /// Creates the admin fulfilment payment.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        IEmailDetail CreateAdminFulfilmentPayment(string email, int amount,string Subject);
        /// <summary>
        /// Sends the scripting fulfilment payment mmail.
        /// </summary>
        /// <param name="fulfilmentPayment">The fulfilment payment.</param>
        /// <param name="Name">The name.</param>
        /// <param name="Email">The email.</param>
        /// <param name="OrderNumber">The order number.</param>
        /// <returns></returns>
        IEmailDetail SendScriptingFulfilmentPaymentMail(IFulfilmentPaymentView fulfilmentPayment, string Name, string Email, string OrderNumber);
        /// <summary>
        /// Sends the fulfilment mmail.
        /// </summary>
        /// <param name="orderFulfilmentActivityView">The order fulfilment activity view.</param>
        /// <param name="Name">The name.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        IEmailDetail SendFulfilmentMail(IOrderFulfilmentActivityView orderFulfilmentActivityView, string Name, string Email);
        /// <summary>
        /// Creates the forget password email.
        /// </summary>
        /// <param name="activationCode">The activation code.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        IEmailDetail CreateForgetPasswordEmail(string activationCode, string email);

        /// <summary>
        /// Creates the send email to admin.
        /// </summary>
        /// <param name="OrderNumber">The order number.</param>
        /// <param name="OrderTitle">The order title.</param>
        /// <param name="FirstName">The first name.</param>
        /// <param name="userEmail">The user email.</param>
        /// <returns></returns>
        IEmailDetail CreateSendEmailToAdmin(string OrderNumber, string OrderTitle, string FirstName, string userEmail,
            string Type);

        /// <summary>
        /// Creates the send script email.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <param name="FirstName">The first name.</param>
        /// <param name="LastName">The last name.</param>
        /// <param name="OrderTitle">The order title.</param>
        /// <param name="OrderNumber">The order number.</param>
        /// <param name="SendTo">The send to.</param>
        /// <returns></returns>
        IEmailDetail CreateSendScriptEmail(string userEmail, string FirstName, string LastName, string OrderTitle,
             string SendTo);

        /// <summary>
        /// Creates the registration request email.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        IEmailDetail CreateRegistrationRequestEmail(IRegistrationView registrationInfo, string code);


        /// <summary>
        /// Creates the send contact us mail.
        /// </summary>
        /// <param name="contactEmail">The contact email.</param>
        /// <param name="userEmail">The user email.</param>
        /// <param name="Name">The name.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="Message">The message.</param>
        /// <returns></returns>
        IEmailDetail CreateSendContactUsMail(string contactEmail, string userEmail, string Name, string phoneNumber,
            string message);


        /// <summary>
        /// Creates the customer message.
        /// </summary>
        /// <param name="receipientEmail">The receipient email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmailDetail CreateCustomerMessage(string receipientEmail, string subject, string message);

        /// <summary>
        /// Creates the pick order email.
        /// </summary>
        /// <param name="orderFulfilmentId">The order fulfilment identifier.</param>
        /// <param name="customerEmail">The customer email.</param>
        /// <returns>IEmailDetail.</returns>
        IEmailDetail CreatePickOrderEmail(int orderFulfilmentId, string customerEmail);
    }
}