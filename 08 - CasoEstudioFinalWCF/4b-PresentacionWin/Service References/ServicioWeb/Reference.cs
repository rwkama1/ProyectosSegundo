﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.225
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PresentacionWin.ServicioWeb {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Cliente", Namespace="http://schemas.datacontract.org/2004/07/EntidadesCompartidas")]
    [System.SerializableAttribute()]
    public partial class Cliente : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DirCliField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ListaTelefonosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomCliField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumCliField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PassCliField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuCliField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DirCli {
            get {
                return this.DirCliField;
            }
            set {
                if ((object.ReferenceEquals(this.DirCliField, value) != true)) {
                    this.DirCliField = value;
                    this.RaisePropertyChanged("DirCli");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] ListaTelefonos {
            get {
                return this.ListaTelefonosField;
            }
            set {
                if ((object.ReferenceEquals(this.ListaTelefonosField, value) != true)) {
                    this.ListaTelefonosField = value;
                    this.RaisePropertyChanged("ListaTelefonos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NomCli {
            get {
                return this.NomCliField;
            }
            set {
                if ((object.ReferenceEquals(this.NomCliField, value) != true)) {
                    this.NomCliField = value;
                    this.RaisePropertyChanged("NomCli");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NumCli {
            get {
                return this.NumCliField;
            }
            set {
                if ((this.NumCliField.Equals(value) != true)) {
                    this.NumCliField = value;
                    this.RaisePropertyChanged("NumCli");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PassCli {
            get {
                return this.PassCliField;
            }
            set {
                if ((object.ReferenceEquals(this.PassCliField, value) != true)) {
                    this.PassCliField = value;
                    this.RaisePropertyChanged("PassCli");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UsuCli {
            get {
                return this.UsuCliField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuCliField, value) != true)) {
                    this.UsuCliField = value;
                    this.RaisePropertyChanged("UsuCli");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Cuenta", Namespace="http://schemas.datacontract.org/2004/07/EntidadesCompartidas")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PresentacionWin.ServicioWeb.CuentaCAhorro))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PresentacionWin.ServicioWeb.CuentaCorriente))]
    public partial class Cuenta : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MiClienteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumCtaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double SaldoCuentaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TipoCuentaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PresentacionWin.ServicioWeb.Cliente UnClienteField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MiCliente {
            get {
                return this.MiClienteField;
            }
            set {
                if ((object.ReferenceEquals(this.MiClienteField, value) != true)) {
                    this.MiClienteField = value;
                    this.RaisePropertyChanged("MiCliente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NumCta {
            get {
                return this.NumCtaField;
            }
            set {
                if ((this.NumCtaField.Equals(value) != true)) {
                    this.NumCtaField = value;
                    this.RaisePropertyChanged("NumCta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double SaldoCuenta {
            get {
                return this.SaldoCuentaField;
            }
            set {
                if ((this.SaldoCuentaField.Equals(value) != true)) {
                    this.SaldoCuentaField = value;
                    this.RaisePropertyChanged("SaldoCuenta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TipoCuenta {
            get {
                return this.TipoCuentaField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoCuentaField, value) != true)) {
                    this.TipoCuentaField = value;
                    this.RaisePropertyChanged("TipoCuenta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PresentacionWin.ServicioWeb.Cliente UnCliente {
            get {
                return this.UnClienteField;
            }
            set {
                if ((object.ReferenceEquals(this.UnClienteField, value) != true)) {
                    this.UnClienteField = value;
                    this.RaisePropertyChanged("UnCliente");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CuentaCAhorro", Namespace="http://schemas.datacontract.org/2004/07/EntidadesCompartidas")]
    [System.SerializableAttribute()]
    public partial class CuentaCAhorro : PresentacionWin.ServicioWeb.Cuenta {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double CostoMovsCtaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MovsCtaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double CostoMovsCta {
            get {
                return this.CostoMovsCtaField;
            }
            set {
                if ((this.CostoMovsCtaField.Equals(value) != true)) {
                    this.CostoMovsCtaField = value;
                    this.RaisePropertyChanged("CostoMovsCta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MovsCta {
            get {
                return this.MovsCtaField;
            }
            set {
                if ((this.MovsCtaField.Equals(value) != true)) {
                    this.MovsCtaField = value;
                    this.RaisePropertyChanged("MovsCta");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CuentaCorriente", Namespace="http://schemas.datacontract.org/2004/07/EntidadesCompartidas")]
    [System.SerializableAttribute()]
    public partial class CuentaCorriente : PresentacionWin.ServicioWeb.Cuenta {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double MinimoCtaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double MinimoCta {
            get {
                return this.MinimoCtaField;
            }
            set {
                if ((this.MinimoCtaField.Equals(value) != true)) {
                    this.MinimoCtaField = value;
                    this.RaisePropertyChanged("MinimoCta");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Movimiento", Namespace="http://schemas.datacontract.org/2004/07/EntidadesCompartidas")]
    [System.SerializableAttribute()]
    public partial class Movimiento : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaMovField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdMovField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double MontoMovField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TipoMovField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PresentacionWin.ServicioWeb.Cuenta UnaCuentaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaMov {
            get {
                return this.FechaMovField;
            }
            set {
                if ((this.FechaMovField.Equals(value) != true)) {
                    this.FechaMovField = value;
                    this.RaisePropertyChanged("FechaMov");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdMov {
            get {
                return this.IdMovField;
            }
            set {
                if ((this.IdMovField.Equals(value) != true)) {
                    this.IdMovField = value;
                    this.RaisePropertyChanged("IdMov");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double MontoMov {
            get {
                return this.MontoMovField;
            }
            set {
                if ((this.MontoMovField.Equals(value) != true)) {
                    this.MontoMovField = value;
                    this.RaisePropertyChanged("MontoMov");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TipoMov {
            get {
                return this.TipoMovField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoMovField, value) != true)) {
                    this.TipoMovField = value;
                    this.RaisePropertyChanged("TipoMov");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PresentacionWin.ServicioWeb.Cuenta UnaCuenta {
            get {
                return this.UnaCuentaField;
            }
            set {
                if ((object.ReferenceEquals(this.UnaCuentaField, value) != true)) {
                    this.UnaCuentaField = value;
                    this.RaisePropertyChanged("UnaCuenta");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Empleado", Namespace="http://schemas.datacontract.org/2004/07/EntidadesCompartidas")]
    [System.SerializableAttribute()]
    public partial class Empleado : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CiEmpField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomEmpField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PassEmpField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CiEmp {
            get {
                return this.CiEmpField;
            }
            set {
                if ((this.CiEmpField.Equals(value) != true)) {
                    this.CiEmpField = value;
                    this.RaisePropertyChanged("CiEmp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NomEmp {
            get {
                return this.NomEmpField;
            }
            set {
                if ((object.ReferenceEquals(this.NomEmpField, value) != true)) {
                    this.NomEmpField = value;
                    this.RaisePropertyChanged("NomEmp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PassEmp {
            get {
                return this.PassEmpField;
            }
            set {
                if ((object.ReferenceEquals(this.PassEmpField, value) != true)) {
                    this.PassEmpField = value;
                    this.RaisePropertyChanged("PassEmp");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Prestamo", Namespace="http://schemas.datacontract.org/2004/07/EntidadesCompartidas")]
    [System.SerializableAttribute()]
    public partial class Prestamo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool AprobadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double MontoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PresentacionWin.ServicioWeb.Cliente UnClienteField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Aprobado {
            get {
                return this.AprobadoField;
            }
            set {
                if ((this.AprobadoField.Equals(value) != true)) {
                    this.AprobadoField = value;
                    this.RaisePropertyChanged("Aprobado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Fecha {
            get {
                return this.FechaField;
            }
            set {
                if ((this.FechaField.Equals(value) != true)) {
                    this.FechaField = value;
                    this.RaisePropertyChanged("Fecha");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Monto {
            get {
                return this.MontoField;
            }
            set {
                if ((this.MontoField.Equals(value) != true)) {
                    this.MontoField = value;
                    this.RaisePropertyChanged("Monto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PresentacionWin.ServicioWeb.Cliente UnCliente {
            get {
                return this.UnClienteField;
            }
            set {
                if ((object.ReferenceEquals(this.UnClienteField, value) != true)) {
                    this.UnClienteField = value;
                    this.RaisePropertyChanged("UnCliente");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioWeb.IWcfService")]
    public interface IWcfService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/AltaCliente", ReplyAction="http://tempuri.org/IWcfService/AltaClienteResponse")]
        void AltaCliente(PresentacionWin.ServicioWeb.Cliente unCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/BajaCliente", ReplyAction="http://tempuri.org/IWcfService/BajaClienteResponse")]
        void BajaCliente(PresentacionWin.ServicioWeb.Cliente unCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/ModificarCliente", ReplyAction="http://tempuri.org/IWcfService/ModificarClienteResponse")]
        void ModificarCliente(PresentacionWin.ServicioWeb.Cliente unCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/BuscarCliente", ReplyAction="http://tempuri.org/IWcfService/BuscarClienteResponse")]
        PresentacionWin.ServicioWeb.Cliente BuscarCliente(int pNumCli);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/LogueoCliente", ReplyAction="http://tempuri.org/IWcfService/LogueoClienteResponse")]
        PresentacionWin.ServicioWeb.Cliente LogueoCliente(string pUsu, string pPass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/ListarTodosClientes", ReplyAction="http://tempuri.org/IWcfService/ListarTodosClientesResponse")]
        PresentacionWin.ServicioWeb.Cliente[] ListarTodosClientes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/ListaCuentasDeCliente", ReplyAction="http://tempuri.org/IWcfService/ListaCuentasDeClienteResponse")]
        PresentacionWin.ServicioWeb.Cuenta[] ListaCuentasDeCliente(PresentacionWin.ServicioWeb.Cliente pCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/ListaMovsDeCliente", ReplyAction="http://tempuri.org/IWcfService/ListaMovsDeClienteResponse")]
        string ListaMovsDeCliente(PresentacionWin.ServicioWeb.Cliente pCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/AltaCuenta", ReplyAction="http://tempuri.org/IWcfService/AltaCuentaResponse")]
        void AltaCuenta(PresentacionWin.ServicioWeb.Cuenta unaCuenta);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/BajaCuenta", ReplyAction="http://tempuri.org/IWcfService/BajaCuentaResponse")]
        void BajaCuenta(PresentacionWin.ServicioWeb.Cuenta unaCuenta);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/BuscarCuenta", ReplyAction="http://tempuri.org/IWcfService/BuscarCuentaResponse")]
        PresentacionWin.ServicioWeb.Cuenta BuscarCuenta(int pNumCta);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/ListarTodasCuentas", ReplyAction="http://tempuri.org/IWcfService/ListarTodasCuentasResponse")]
        PresentacionWin.ServicioWeb.Cuenta[] ListarTodasCuentas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/ListarCuentaCorriente", ReplyAction="http://tempuri.org/IWcfService/ListarCuentaCorrienteResponse")]
        PresentacionWin.ServicioWeb.CuentaCorriente[] ListarCuentaCorriente();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/ListarMovimientosDeCuenta", ReplyAction="http://tempuri.org/IWcfService/ListarMovimientosDeCuentaResponse")]
        PresentacionWin.ServicioWeb.Movimiento[] ListarMovimientosDeCuenta(PresentacionWin.ServicioWeb.Cuenta unaCuenta);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/LogueoEmpleado", ReplyAction="http://tempuri.org/IWcfService/LogueoEmpleadoResponse")]
        PresentacionWin.ServicioWeb.Empleado LogueoEmpleado(int pCI, string pPass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/AltaMovimiento", ReplyAction="http://tempuri.org/IWcfService/AltaMovimientoResponse")]
        void AltaMovimiento(PresentacionWin.ServicioWeb.Movimiento pMovimiento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/ListarTodosMovimientos", ReplyAction="http://tempuri.org/IWcfService/ListarTodosMovimientosResponse")]
        PresentacionWin.ServicioWeb.Movimiento[] ListarTodosMovimientos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/AltaPrestamo", ReplyAction="http://tempuri.org/IWcfService/AltaPrestamoResponse")]
        void AltaPrestamo(PresentacionWin.ServicioWeb.Prestamo pPrestamo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/ListoPrestamosCliente", ReplyAction="http://tempuri.org/IWcfService/ListoPrestamosClienteResponse")]
        PresentacionWin.ServicioWeb.Prestamo[] ListoPrestamosCliente(PresentacionWin.ServicioWeb.Cliente unCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWcfService/ListoTodosPrestamos", ReplyAction="http://tempuri.org/IWcfService/ListoTodosPrestamosResponse")]
        PresentacionWin.ServicioWeb.Prestamo[] ListoTodosPrestamos();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWcfServiceChannel : PresentacionWin.ServicioWeb.IWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WcfServiceClient : System.ServiceModel.ClientBase<PresentacionWin.ServicioWeb.IWcfService>, PresentacionWin.ServicioWeb.IWcfService {
        
        public WcfServiceClient() {
        }
        
        public WcfServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AltaCliente(PresentacionWin.ServicioWeb.Cliente unCliente) {
            base.Channel.AltaCliente(unCliente);
        }
        
        public void BajaCliente(PresentacionWin.ServicioWeb.Cliente unCliente) {
            base.Channel.BajaCliente(unCliente);
        }
        
        public void ModificarCliente(PresentacionWin.ServicioWeb.Cliente unCliente) {
            base.Channel.ModificarCliente(unCliente);
        }
        
        public PresentacionWin.ServicioWeb.Cliente BuscarCliente(int pNumCli) {
            return base.Channel.BuscarCliente(pNumCli);
        }
        
        public PresentacionWin.ServicioWeb.Cliente LogueoCliente(string pUsu, string pPass) {
            return base.Channel.LogueoCliente(pUsu, pPass);
        }
        
        public PresentacionWin.ServicioWeb.Cliente[] ListarTodosClientes() {
            return base.Channel.ListarTodosClientes();
        }
        
        public PresentacionWin.ServicioWeb.Cuenta[] ListaCuentasDeCliente(PresentacionWin.ServicioWeb.Cliente pCliente) {
            return base.Channel.ListaCuentasDeCliente(pCliente);
        }
        
        public string ListaMovsDeCliente(PresentacionWin.ServicioWeb.Cliente pCliente) {
            return base.Channel.ListaMovsDeCliente(pCliente);
        }
        
        public void AltaCuenta(PresentacionWin.ServicioWeb.Cuenta unaCuenta) {
            base.Channel.AltaCuenta(unaCuenta);
        }
        
        public void BajaCuenta(PresentacionWin.ServicioWeb.Cuenta unaCuenta) {
            base.Channel.BajaCuenta(unaCuenta);
        }
        
        public PresentacionWin.ServicioWeb.Cuenta BuscarCuenta(int pNumCta) {
            return base.Channel.BuscarCuenta(pNumCta);
        }
        
        public PresentacionWin.ServicioWeb.Cuenta[] ListarTodasCuentas() {
            return base.Channel.ListarTodasCuentas();
        }
        
        public PresentacionWin.ServicioWeb.CuentaCorriente[] ListarCuentaCorriente() {
            return base.Channel.ListarCuentaCorriente();
        }
        
        public PresentacionWin.ServicioWeb.Movimiento[] ListarMovimientosDeCuenta(PresentacionWin.ServicioWeb.Cuenta unaCuenta) {
            return base.Channel.ListarMovimientosDeCuenta(unaCuenta);
        }
        
        public PresentacionWin.ServicioWeb.Empleado LogueoEmpleado(int pCI, string pPass) {
            return base.Channel.LogueoEmpleado(pCI, pPass);
        }
        
        public void AltaMovimiento(PresentacionWin.ServicioWeb.Movimiento pMovimiento) {
            base.Channel.AltaMovimiento(pMovimiento);
        }
        
        public PresentacionWin.ServicioWeb.Movimiento[] ListarTodosMovimientos() {
            return base.Channel.ListarTodosMovimientos();
        }
        
        public void AltaPrestamo(PresentacionWin.ServicioWeb.Prestamo pPrestamo) {
            base.Channel.AltaPrestamo(pPrestamo);
        }
        
        public PresentacionWin.ServicioWeb.Prestamo[] ListoPrestamosCliente(PresentacionWin.ServicioWeb.Cliente unCliente) {
            return base.Channel.ListoPrestamosCliente(unCliente);
        }
        
        public PresentacionWin.ServicioWeb.Prestamo[] ListoTodosPrestamos() {
            return base.Channel.ListoTodosPrestamos();
        }
    }
}
