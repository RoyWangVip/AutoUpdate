﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18063.
// 
#pragma warning disable 1591

namespace AutoUpdate.WS_Update {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="UpdateSoap", Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(object[]))]
    public partial class Update : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetAllUpdateInfosCompressedOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetFileCompressedOperationCompleted;
        
        private System.Threading.SendOrPostCallback UploadFileCompressedOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Update() {
            this.Url = global::AutoUpdate.Properties.Settings.Default.AutoUpdate_WS_Update_Update;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

	/// <remarks/>
        public Update(string ip) {
             this.Url = string.Format("http://{0}/WebUpdate/Update.asmx",ip);
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetAllUpdateInfosCompressedCompletedEventHandler GetAllUpdateInfosCompressedCompleted;
        
        /// <remarks/>
        public event GetFileCompressedCompletedEventHandler GetFileCompressedCompleted;
        
        /// <remarks/>
        public event UploadFileCompressedCompletedEventHandler UploadFileCompressedCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllUpdateInfosCompressed", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] GetAllUpdateInfosCompressed(string version) {
            object[] results = this.Invoke("GetAllUpdateInfosCompressed", new object[] {
                        version});
            return ((object[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllUpdateInfosCompressedAsync(string version) {
            this.GetAllUpdateInfosCompressedAsync(version, null);
        }
        
        /// <remarks/>
        public void GetAllUpdateInfosCompressedAsync(string version, object userState) {
            if ((this.GetAllUpdateInfosCompressedOperationCompleted == null)) {
                this.GetAllUpdateInfosCompressedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllUpdateInfosCompressedOperationCompleted);
            }
            this.InvokeAsync("GetAllUpdateInfosCompressed", new object[] {
                        version}, this.GetAllUpdateInfosCompressedOperationCompleted, userState);
        }
        
        private void OnGetAllUpdateInfosCompressedOperationCompleted(object arg) {
            if ((this.GetAllUpdateInfosCompressedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllUpdateInfosCompressedCompleted(this, new GetAllUpdateInfosCompressedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetFileCompressed", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public UpdateInfos GetFileCompressed(string version, string fpath) {
            object[] results = this.Invoke("GetFileCompressed", new object[] {
                        version,
                        fpath});
            return ((UpdateInfos)(results[0]));
        }
        
        /// <remarks/>
        public void GetFileCompressedAsync(string version, string fpath) {
            this.GetFileCompressedAsync(version, fpath, null);
        }
        
        /// <remarks/>
        public void GetFileCompressedAsync(string version, string fpath, object userState) {
            if ((this.GetFileCompressedOperationCompleted == null)) {
                this.GetFileCompressedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFileCompressedOperationCompleted);
            }
            this.InvokeAsync("GetFileCompressed", new object[] {
                        version,
                        fpath}, this.GetFileCompressedOperationCompleted, userState);
        }
        
        private void OnGetFileCompressedOperationCompleted(object arg) {
            if ((this.GetFileCompressedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetFileCompressedCompleted(this, new GetFileCompressedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UploadFileCompressed", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string UploadFileCompressed(string version, string fpath, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] content) {
            object[] results = this.Invoke("UploadFileCompressed", new object[] {
                        version,
                        fpath,
                        content});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void UploadFileCompressedAsync(string version, string fpath, byte[] content) {
            this.UploadFileCompressedAsync(version, fpath, content, null);
        }
        
        /// <remarks/>
        public void UploadFileCompressedAsync(string version, string fpath, byte[] content, object userState) {
            if ((this.UploadFileCompressedOperationCompleted == null)) {
                this.UploadFileCompressedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUploadFileCompressedOperationCompleted);
            }
            this.InvokeAsync("UploadFileCompressed", new object[] {
                        version,
                        fpath,
                        content}, this.UploadFileCompressedOperationCompleted, userState);
        }
        
        private void OnUploadFileCompressedOperationCompleted(object arg) {
            if ((this.UploadFileCompressedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UploadFileCompressedCompleted(this, new UploadFileCompressedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class UpdateInfos {
        
        private string softnameField;
        
        private string versionField;
        
        private string filepathField;
        
        private byte[] binField;
        
        private System.DateTime timeField;
        
        /// <remarks/>
        public string softname {
            get {
                return this.softnameField;
            }
            set {
                this.softnameField = value;
            }
        }
        
        /// <remarks/>
        public string version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
        
        /// <remarks/>
        public string filepath {
            get {
                return this.filepathField;
            }
            set {
                this.filepathField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] bin {
            get {
                return this.binField;
            }
            set {
                this.binField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime time {
            get {
                return this.timeField;
            }
            set {
                this.timeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetAllUpdateInfosCompressedCompletedEventHandler(object sender, GetAllUpdateInfosCompressedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllUpdateInfosCompressedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllUpdateInfosCompressedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public object[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((object[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetFileCompressedCompletedEventHandler(object sender, GetFileCompressedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetFileCompressedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetFileCompressedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public UpdateInfos Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((UpdateInfos)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void UploadFileCompressedCompletedEventHandler(object sender, UploadFileCompressedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UploadFileCompressedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UploadFileCompressedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591