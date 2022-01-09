﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.225
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.225.
// 
#pragma warning disable 1591

namespace PresentacionWin.ResServicioArticulos {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServicioArticulosSoap", Namespace="http://tempuri.org/")]
    public partial class ServicioArticulos : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback BuscarArticuloOperationCompleted;
        
        private System.Threading.SendOrPostCallback AgregarArticuloOperationCompleted;
        
        private System.Threading.SendOrPostCallback ListarOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ServicioArticulos() {
            this.Url = global::PresentacionWin.Properties.Settings.Default.PresentacionWin_ResServicioArticulos_ServicioArticulos;
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
        public event BuscarArticuloCompletedEventHandler BuscarArticuloCompleted;
        
        /// <remarks/>
        public event AgregarArticuloCompletedEventHandler AgregarArticuloCompleted;
        
        /// <remarks/>
        public event ListarCompletedEventHandler ListarCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/BuscarArticulo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Articulo BuscarArticulo(int pCodigo) {
            object[] results = this.Invoke("BuscarArticulo", new object[] {
                        pCodigo});
            return ((Articulo)(results[0]));
        }
        
        /// <remarks/>
        public void BuscarArticuloAsync(int pCodigo) {
            this.BuscarArticuloAsync(pCodigo, null);
        }
        
        /// <remarks/>
        public void BuscarArticuloAsync(int pCodigo, object userState) {
            if ((this.BuscarArticuloOperationCompleted == null)) {
                this.BuscarArticuloOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBuscarArticuloOperationCompleted);
            }
            this.InvokeAsync("BuscarArticulo", new object[] {
                        pCodigo}, this.BuscarArticuloOperationCompleted, userState);
        }
        
        private void OnBuscarArticuloOperationCompleted(object arg) {
            if ((this.BuscarArticuloCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BuscarArticuloCompleted(this, new BuscarArticuloCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AgregarArticulo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AgregarArticulo(Articulo A) {
            this.Invoke("AgregarArticulo", new object[] {
                        A});
        }
        
        /// <remarks/>
        public void AgregarArticuloAsync(Articulo A) {
            this.AgregarArticuloAsync(A, null);
        }
        
        /// <remarks/>
        public void AgregarArticuloAsync(Articulo A, object userState) {
            if ((this.AgregarArticuloOperationCompleted == null)) {
                this.AgregarArticuloOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAgregarArticuloOperationCompleted);
            }
            this.InvokeAsync("AgregarArticulo", new object[] {
                        A}, this.AgregarArticuloOperationCompleted, userState);
        }
        
        private void OnAgregarArticuloOperationCompleted(object arg) {
            if ((this.AgregarArticuloCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AgregarArticuloCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Listar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Articulo[] Listar() {
            object[] results = this.Invoke("Listar", new object[0]);
            return ((Articulo[])(results[0]));
        }
        
        /// <remarks/>
        public void ListarAsync() {
            this.ListarAsync(null);
        }
        
        /// <remarks/>
        public void ListarAsync(object userState) {
            if ((this.ListarOperationCompleted == null)) {
                this.ListarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnListarOperationCompleted);
            }
            this.InvokeAsync("Listar", new object[0], this.ListarOperationCompleted, userState);
        }
        
        private void OnListarOperationCompleted(object arg) {
            if ((this.ListarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ListarCompleted(this, new ListarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Articulo {
        
        private int codigoField;
        
        private string nombreField;
        
        private decimal precioField;
        
        /// <comentarios/>
        public int Codigo {
            get {
                return this.codigoField;
            }
            set {
                this.codigoField = value;
            }
        }
        
        /// <comentarios/>
        public string Nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
            }
        }
        
        /// <comentarios/>
        public decimal Precio {
            get {
                return this.precioField;
            }
            set {
                this.precioField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void BuscarArticuloCompletedEventHandler(object sender, BuscarArticuloCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BuscarArticuloCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BuscarArticuloCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Articulo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Articulo)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void AgregarArticuloCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ListarCompletedEventHandler(object sender, ListarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ListarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ListarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Articulo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Articulo[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591