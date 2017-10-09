using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoUpdate
{
    [System.Diagnostics.DebuggerStepThrough(), System.ComponentModel.DesignerCategory("code"), System.Web.Services.WebServiceBinding(Name = "", Namespace = "")]
    public class DynWebService : WS_Update.Update
    {
        public DynWebService()
            : base()
        {
            //设置默认webService的地址
            this.Url = "http://localhost/WebUpdate/Update.asmx";
        }
        public DynWebService(string webUrl)
            : base()
        {
            this.Url = "http://" + webUrl + "/WebUpdate/Update.asmx";
        }
    }
}
