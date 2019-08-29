using System.Collections.Generic;

namespace ADit.Interfaces
{
    public interface IScriptingFactory
    {
        IScriptingViewList CreateScriptingMessageView(IList<IScriptingDetailModel> transactionInfo, string message);
        IScriptingView CreateScriptingDetailView(IScriptingDetailModel transaction, IDigitalFile pictureDetail);
    }
}
