﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace DatabaseAccess
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class MVCDemoDBEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new MVCDemoDBEntities object using the connection string found in the 'MVCDemoDBEntities' section of the application configuration file.
        /// </summary>
        public MVCDemoDBEntities() : base("name=MVCDemoDBEntities", "MVCDemoDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new MVCDemoDBEntities object.
        /// </summary>
        public MVCDemoDBEntities(string connectionString) : base(connectionString, "MVCDemoDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new MVCDemoDBEntities object.
        /// </summary>
        public MVCDemoDBEntities(EntityConnection connection) : base(connection, "MVCDemoDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Login> Logins
        {
            get
            {
                if ((_Logins == null))
                {
                    _Logins = base.CreateObjectSet<Login>("Logins");
                }
                return _Logins;
            }
        }
        private ObjectSet<Login> _Logins;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<PropertyMaster> PropertyMasters
        {
            get
            {
                if ((_PropertyMasters == null))
                {
                    _PropertyMasters = base.CreateObjectSet<PropertyMaster>("PropertyMasters");
                }
                return _PropertyMasters;
            }
        }
        private ObjectSet<PropertyMaster> _PropertyMasters;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Logins EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToLogins(Login login)
        {
            base.AddObject("Logins", login);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the PropertyMasters EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPropertyMasters(PropertyMaster propertyMaster)
        {
            base.AddObject("PropertyMasters", propertyMaster);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MVCDemoDBModel", Name="Login")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Login : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Login object.
        /// </summary>
        /// <param name="loginID">Initial value of the LoginID property.</param>
        /// <param name="userName">Initial value of the UserName property.</param>
        /// <param name="password">Initial value of the Password property.</param>
        /// <param name="lastModifiedUserID">Initial value of the LastModifiedUserID property.</param>
        /// <param name="lastModfiedDateTime">Initial value of the LastModfiedDateTime property.</param>
        public static Login CreateLogin(global::System.Int32 loginID, global::System.String userName, global::System.String password, global::System.Int32 lastModifiedUserID, global::System.DateTime lastModfiedDateTime)
        {
            Login login = new Login();
            login.LoginID = loginID;
            login.UserName = userName;
            login.Password = password;
            login.LastModifiedUserID = lastModifiedUserID;
            login.LastModfiedDateTime = lastModfiedDateTime;
            return login;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 LoginID
        {
            get
            {
                return _LoginID;
            }
            set
            {
                if (_LoginID != value)
                {
                    OnLoginIDChanging(value);
                    ReportPropertyChanging("LoginID");
                    _LoginID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("LoginID");
                    OnLoginIDChanged();
                }
            }
        }
        private global::System.Int32 _LoginID;
        partial void OnLoginIDChanging(global::System.Int32 value);
        partial void OnLoginIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                OnUserNameChanging(value);
                ReportPropertyChanging("UserName");
                _UserName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("UserName");
                OnUserNameChanged();
            }
        }
        private global::System.String _UserName;
        partial void OnUserNameChanging(global::System.String value);
        partial void OnUserNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                OnPasswordChanging(value);
                ReportPropertyChanging("Password");
                _Password = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Password");
                OnPasswordChanged();
            }
        }
        private global::System.String _Password;
        partial void OnPasswordChanging(global::System.String value);
        partial void OnPasswordChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 LastModifiedUserID
        {
            get
            {
                return _LastModifiedUserID;
            }
            set
            {
                OnLastModifiedUserIDChanging(value);
                ReportPropertyChanging("LastModifiedUserID");
                _LastModifiedUserID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastModifiedUserID");
                OnLastModifiedUserIDChanged();
            }
        }
        private global::System.Int32 _LastModifiedUserID;
        partial void OnLastModifiedUserIDChanging(global::System.Int32 value);
        partial void OnLastModifiedUserIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LastModfiedDateTime
        {
            get
            {
                return _LastModfiedDateTime;
            }
            set
            {
                OnLastModfiedDateTimeChanging(value);
                ReportPropertyChanging("LastModfiedDateTime");
                _LastModfiedDateTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastModfiedDateTime");
                OnLastModfiedDateTimeChanged();
            }
        }
        private global::System.DateTime _LastModfiedDateTime;
        partial void OnLastModfiedDateTimeChanging(global::System.DateTime value);
        partial void OnLastModfiedDateTimeChanged();

        #endregion

    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MVCDemoDBModel", Name="PropertyMaster")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class PropertyMaster : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new PropertyMaster object.
        /// </summary>
        /// <param name="propertyID">Initial value of the PropertyID property.</param>
        /// <param name="propertyName">Initial value of the PropertyName property.</param>
        /// <param name="propertyDescription">Initial value of the PropertyDescription property.</param>
        /// <param name="lastModifiedUserID">Initial value of the LastModifiedUserID property.</param>
        /// <param name="lastModfiedDateTime">Initial value of the LastModfiedDateTime property.</param>
        public static PropertyMaster CreatePropertyMaster(global::System.Int32 propertyID, global::System.String propertyName, global::System.String propertyDescription, global::System.Int32 lastModifiedUserID, global::System.DateTime lastModfiedDateTime)
        {
            PropertyMaster propertyMaster = new PropertyMaster();
            propertyMaster.PropertyID = propertyID;
            propertyMaster.PropertyName = propertyName;
            propertyMaster.PropertyDescription = propertyDescription;
            propertyMaster.LastModifiedUserID = lastModifiedUserID;
            propertyMaster.LastModfiedDateTime = lastModfiedDateTime;
            return propertyMaster;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 PropertyID
        {
            get
            {
                return _PropertyID;
            }
            set
            {
                if (_PropertyID != value)
                {
                    OnPropertyIDChanging(value);
                    ReportPropertyChanging("PropertyID");
                    _PropertyID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("PropertyID");
                    OnPropertyIDChanged();
                }
            }
        }
        private global::System.Int32 _PropertyID;
        partial void OnPropertyIDChanging(global::System.Int32 value);
        partial void OnPropertyIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String PropertyName
        {
            get
            {
                return _PropertyName;
            }
            set
            {
                if (_PropertyName != value)
                {
                    OnPropertyNameChanging(value);
                    ReportPropertyChanging("PropertyName");
                    _PropertyName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("PropertyName");
                    OnPropertyNameChanged();
                }
            }
        }
        private global::System.String _PropertyName;
        partial void OnPropertyNameChanging(global::System.String value);
        partial void OnPropertyNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String PropertyDescription
        {
            get
            {
                return _PropertyDescription;
            }
            set
            {
                if (_PropertyDescription != value)
                {
                    OnPropertyDescriptionChanging(value);
                    ReportPropertyChanging("PropertyDescription");
                    _PropertyDescription = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("PropertyDescription");
                    OnPropertyDescriptionChanged();
                }
            }
        }
        private global::System.String _PropertyDescription;
        partial void OnPropertyDescriptionChanging(global::System.String value);
        partial void OnPropertyDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 LastModifiedUserID
        {
            get
            {
                return _LastModifiedUserID;
            }
            set
            {
                if (_LastModifiedUserID != value)
                {
                    OnLastModifiedUserIDChanging(value);
                    ReportPropertyChanging("LastModifiedUserID");
                    _LastModifiedUserID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("LastModifiedUserID");
                    OnLastModifiedUserIDChanged();
                }
            }
        }
        private global::System.Int32 _LastModifiedUserID;
        partial void OnLastModifiedUserIDChanging(global::System.Int32 value);
        partial void OnLastModifiedUserIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LastModfiedDateTime
        {
            get
            {
                return _LastModfiedDateTime;
            }
            set
            {
                if (_LastModfiedDateTime != value)
                {
                    OnLastModfiedDateTimeChanging(value);
                    ReportPropertyChanging("LastModfiedDateTime");
                    _LastModfiedDateTime = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("LastModfiedDateTime");
                    OnLastModfiedDateTimeChanged();
                }
            }
        }
        private global::System.DateTime _LastModfiedDateTime;
        partial void OnLastModfiedDateTimeChanging(global::System.DateTime value);
        partial void OnLastModfiedDateTimeChanged();

        #endregion

    
    }

    #endregion

    
}
