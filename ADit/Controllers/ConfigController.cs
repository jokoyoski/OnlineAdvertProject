using System.Web.Mvc;
using AA.Infrastructure.Interfaces;
using ADit.Domain.Attributes;
using ADit.Interfaces.ValueTypes.Jobs4Moi.Interfaces.ValueTypes;

namespace ADit.Controllers
{
    [AccessAuthorize(Roles = new[]{AppAction.AppConfig})]
    public class ConfigController : Controller
    {
        private readonly IAesEncryption encryptionService;

        public ActionResult Index()
        {
            return this.View("Index");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigController"/> class.
        /// </summary>
        /// <param name="encryptionService">The encryption service.</param>
        public ConfigController(IAesEncryption encryptionService)
        {
            this.encryptionService = encryptionService;
        }

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns>ActionResult.</returns>
        [AccessAuthorize(Roles = new[] { AppAction.AppConfig })]
        public ActionResult Encrypt(string plainText)
        {
            this.ViewBag.PlainText = plainText ?? "";
            this.ViewBag.EncryptedValue = string.IsNullOrEmpty(plainText) ? string.Empty : this.encryptionService.Encrypt(plainText);

            return this.View("Encrypt");
        }

        /// <summary>
        /// Decrypts the specified encrypted value.
        /// </summary>
        /// <param name="encryptedValue">The encrypted value.</param>
        /// <returns>ActionResult.</returns>
        [AccessAuthorize(Roles = new[] { AppAction.AppConfig })]
        public ActionResult Decrypt(string encryptedValue)
        {
            this.ViewBag.PlainText = string.IsNullOrEmpty(encryptedValue) ? string.Empty : this.encryptionService.Decrypt(encryptedValue);
            this.ViewBag.EncryptedValue = encryptedValue ?? "";

            return this.View("Decrypt");
        }



    }
}