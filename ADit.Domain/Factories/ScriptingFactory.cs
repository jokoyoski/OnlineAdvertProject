using ADit.Domain.Models;
using ADit.Interfaces;
using System;
using System.Collections.Generic;

namespace ADit.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IScriptingFactory" />
    public class ScriptingFactory : IScriptingFactory
    {


        /// <summary>
        /// Creates the scripting message view.
        /// </summary>
        /// <param name="transactionInfo">The transaction information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">transactionInfo</exception>
        public IScriptingViewList CreateScriptingMessageView(IList<IScriptingDetailModel> transactionInfo, string message)
        {
            if (transactionInfo == null)
            {
                throw new ArgumentNullException(nameof(transactionInfo));
            }
             

            var viewModel = new ScriptingViewList
            {
               ScriptingDetailCollection = transactionInfo,
               ProcessingMessage = message
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the scripting detail view.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <param name="pictureDetail">The picture detail.</param>
        /// <returns></returns>
        public IScriptingView CreateScriptingDetailView(IScriptingDetailModel transaction, IDigitalFile pictureDetail)
        {
            var viewModel = new ScriptingView
            {
                pictures = pictureDetail,
                Topic = transaction.Topic,
                Comment = transaction.ScripterComment

            };
            return viewModel;
        }
    }
}
