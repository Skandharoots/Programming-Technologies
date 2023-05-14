﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.DataBase
{
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Data;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;
    using System.ComponentModel;
    using System;
    using Data;
    using Data.API;

    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name = "DB")]
    public partial class LinqToSqlDataContext : System.Data.Linq.DataContext
    {

        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

        #region Extensibility Method Definitions
        partial void OnCreated();
        partial void InsertClient(Client instance);
        partial void UpdateClient(Client instance);
        partial void DeleteClient(Client instance);
        partial void InsertProduct(Record instance);
        partial void UpdateProduct(Record instance);
        partial void DeleteProduct(Record instance);
        partial void InsertEvent(Event instance);
        partial void UpdateEvent(Event instance);
        partial void DeleteEvent(Event instance);
        #endregion


        public LinqToSqlDataContext() :
                base(global::Data.Properties.Settings.Default.DBConnectionString, mappingSource)
        {
            OnCreated();
        }
        public LinqToSqlDataContext(string connection) :
                base(connection, mappingSource)
        {
            OnCreated();
        }

        public LinqToSqlDataContext(System.Data.IDbConnection connection) :
                base(connection, mappingSource)
        {
            OnCreated();
        }

        public LinqToSqlDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
                base(connection, mappingSource)
        {
            OnCreated();
        }

        public LinqToSqlDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
                base(connection, mappingSource)
        {
            OnCreated();
        }

        public System.Data.Linq.Table<Client> Clients
        {
            get
            {
                return this.GetTable<Client>();
            }
        }

        public System.Data.Linq.Table<Record> Records
        {
            get
            {
                return this.GetTable<Record>();
            }
        }

        public System.Data.Linq.Table<RecordStatus> RecordStatuses
        {
            get
            {
                return this.GetTable<RecordStatus>();
            }
        }

        public System.Data.Linq.Table<Event> Events
        {
            get
            {
                return this.GetTable<Event>();
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Client")]
    public partial class Client : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _Name;

        private string _Surname;

        private int _Id;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnClientNameChanging(string value);
        partial void OnClientNameChanged();
        partial void OnClientSurnameChanging(string value);
        partial void OnClientSurnameChanged();
        partial void OnClientIDChanging(int value);
        partial void OnClientIDChanged();
        #endregion

        public Client()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnClientIDChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnClientIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this.OnClientNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnClientNameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Surname", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Surname
        {
            get
            {
                return this._Surname;
            }
            set
            {
                if ((this._Surname != value))
                {
                    this.OnClientSurnameChanging(value);
                    this.SendPropertyChanging();
                    this._Surname = value;
                    this.SendPropertyChanged("Surname");
                    this.OnClientSurnameChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Record")]
    public partial class Record : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private string _Author;

        private string _Title;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnRecordIDChanging(int value);
        partial void OnRecordIDChanged();
        partial void OnRecordAuthorChanging(string value);
        partial void OnRecordAuthorChanged();
        partial void OnRecordTitleChanging(string value);
        partial void OnRecordTitleChanged();
        #endregion

        public Record()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnRecordIDChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnRecordIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Author", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Author
        {
            get
            {
                return this._Author;
            }
            set
            {
                if ((this._Author != value))
                {
                    this.OnRecordAuthorChanging(value);
                    this.SendPropertyChanging();
                    this._Author = value;
                    this.SendPropertyChanged("Author");
                    this.OnRecordAuthorChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Title", DbType = "NVarChar(50)", CanBeNull = false)]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                if ((this._Title != value))
                {
                    this.OnRecordTitleChanging(value);
                    this.SendPropertyChanging();
                    this._Title = value;
                    this.SendPropertyChanged("Title");
                    this.OnRecordTitleChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.RecordStatus")]
    public partial class RecordStatus : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _RecordId;

        private bool _Sold;

        private int _Id;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnStatusSoldChanging(bool value);
        partial void OnStatusSoldChanged();
        partial void OnStatusRecordIdChanging(int value);
        partial void OnStatusRecordIdChanged();
        partial void OnStatusIdChanging(int value);
        partial void OnStatusIdChanged();
        #endregion

        public RecordStatus()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnStatusIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnStatusIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_RecordId", DbType = "Int NOT NULL", CanBeNull = false)]
        public int RecordId
        {
            get
            {
                return this._RecordId;
            }
            set
            {
                if ((this._RecordId != value))
                {
                    this.OnStatusRecordIdChanging(value);
                    this.SendPropertyChanging();
                    this._RecordId = value;
                    this.SendPropertyChanged("RecordId");
                    this.OnStatusRecordIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Sold", DbType = "Bit NOT NULL", CanBeNull = false)]
        public bool Sold
        {
            get
            {
                return this._Sold;
            }
            set
            {
                if ((this._Sold != value))
                {
                    this.OnStatusSoldChanging(value);
                    this.SendPropertyChanging();
                    this._Sold = value;
                    this.SendPropertyChanged("Sold");
                    this.OnStatusSoldChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Event")]
    public partial class Event : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private int _ClientId;

        private int _RecordId;

        private System.DateTime _PurchaseDate;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnEventIDChanging(int value);
        partial void OnEventIDChanged();
        partial void OnClientIDChanging(int value);
        partial void OnClientIDChanged();
        partial void OnRecordIDChanging(int value);
        partial void OnRecordIDChanged();
        partial void OnDateChanging(System.DateTime value);
        partial void OnDateChanged();
        #endregion

        public Event()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnEventIDChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnEventIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ClientId", DbType = "Int NOT NULL")]
        public int ClientId
        {
            get
            {
                return this._ClientId;
            }
            set
            {
                if ((this._ClientId != value))
                {
                    this.OnClientIDChanging(value);
                    this.SendPropertyChanging();
                    this._ClientId = value;
                    this.SendPropertyChanged("ClientId");
                    this.OnClientIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_RecordId", DbType = "Int NOT NULL")]
        public int RecordId
        {
            get
            {
                return this._RecordId;
            }
            set
            {
                if ((this._RecordId != value))
                {
                    this.OnRecordIDChanging(value);
                    this.SendPropertyChanging();
                    this._RecordId = value;
                    this.SendPropertyChanged("RecordId");
                    this.OnRecordIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PurchaseDate", DbType = "Date NOT NULL")]
        public System.DateTime PurchaseDate
        {
            get
            {
                return this._PurchaseDate;
            }
            set
            {
                if ((this._PurchaseDate != value))
                {
                    this.OnDateChanging(value);
                    this.SendPropertyChanging();
                    this._PurchaseDate = value;
                    this.SendPropertyChanged("PurchaseDate");
                    this.OnDateChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
#pragma warning restore 1591