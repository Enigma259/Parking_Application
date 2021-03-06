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

namespace Console_Server.Database
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="psua0218_1026970")]
	public partial class SQL_DatabaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTableParkingPlace(TableParkingPlace instance);
    partial void UpdateTableParkingPlace(TableParkingPlace instance);
    partial void DeleteTableParkingPlace(TableParkingPlace instance);
    partial void InsertTableReservation(TableReservation instance);
    partial void UpdateTableReservation(TableReservation instance);
    partial void DeleteTableReservation(TableReservation instance);
    #endregion
		
		public SQL_DatabaseDataContext() : 
				base(global::Console_Server.Properties.Settings.Default.psua0218_1026970ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SQL_DatabaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQL_DatabaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQL_DatabaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQL_DatabaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TableParkingPlace> TableParkingPlaces
		{
			get
			{
				return this.GetTable<TableParkingPlace>();
			}
		}
		
		public System.Data.Linq.Table<TableReservation> TableReservations
		{
			get
			{
				return this.GetTable<TableReservation>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TableParkingPlaces")]
	public partial class TableParkingPlace : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private double _longtitude;
		
		private double _latitude;
		
		private double _altitude;
		
		private string _parking_name;
		
		private int _spaces;
		
		private int _vacant;
		
		private string _city;
		
		private string _country;
		
		private EntityRef<TableReservation> _TableReservation;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnlongtitudeChanging(double value);
    partial void OnlongtitudeChanged();
    partial void OnlatitudeChanging(double value);
    partial void OnlatitudeChanged();
    partial void OnaltitudeChanging(double value);
    partial void OnaltitudeChanged();
    partial void Onparking_nameChanging(string value);
    partial void Onparking_nameChanged();
    partial void OnspacesChanging(int value);
    partial void OnspacesChanged();
    partial void OnvacantChanging(int value);
    partial void OnvacantChanged();
    partial void OncityChanging(string value);
    partial void OncityChanged();
    partial void OncountryChanging(string value);
    partial void OncountryChanged();
    #endregion
		
		public TableParkingPlace()
		{
			this._TableReservation = default(EntityRef<TableReservation>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_longtitude", DbType="Float NOT NULL")]
		public double longtitude
		{
			get
			{
				return this._longtitude;
			}
			set
			{
				if ((this._longtitude != value))
				{
					this.OnlongtitudeChanging(value);
					this.SendPropertyChanging();
					this._longtitude = value;
					this.SendPropertyChanged("longtitude");
					this.OnlongtitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_latitude", DbType="Float NOT NULL")]
		public double latitude
		{
			get
			{
				return this._latitude;
			}
			set
			{
				if ((this._latitude != value))
				{
					this.OnlatitudeChanging(value);
					this.SendPropertyChanging();
					this._latitude = value;
					this.SendPropertyChanged("latitude");
					this.OnlatitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_altitude", DbType="Float NOT NULL")]
		public double altitude
		{
			get
			{
				return this._altitude;
			}
			set
			{
				if ((this._altitude != value))
				{
					this.OnaltitudeChanging(value);
					this.SendPropertyChanging();
					this._altitude = value;
					this.SendPropertyChanged("altitude");
					this.OnaltitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_parking_name", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string parking_name
		{
			get
			{
				return this._parking_name;
			}
			set
			{
				if ((this._parking_name != value))
				{
					this.Onparking_nameChanging(value);
					this.SendPropertyChanging();
					this._parking_name = value;
					this.SendPropertyChanged("parking_name");
					this.Onparking_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_spaces", DbType="Int NOT NULL")]
		public int spaces
		{
			get
			{
				return this._spaces;
			}
			set
			{
				if ((this._spaces != value))
				{
					this.OnspacesChanging(value);
					this.SendPropertyChanging();
					this._spaces = value;
					this.SendPropertyChanged("spaces");
					this.OnspacesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vacant", DbType="Int NOT NULL")]
		public int vacant
		{
			get
			{
				return this._vacant;
			}
			set
			{
				if ((this._vacant != value))
				{
					this.OnvacantChanging(value);
					this.SendPropertyChanging();
					this._vacant = value;
					this.SendPropertyChanged("vacant");
					this.OnvacantChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string city
		{
			get
			{
				return this._city;
			}
			set
			{
				if ((this._city != value))
				{
					this.OncityChanging(value);
					this.SendPropertyChanging();
					this._city = value;
					this.SendPropertyChanged("city");
					this.OncityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_country", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string country
		{
			get
			{
				return this._country;
			}
			set
			{
				if ((this._country != value))
				{
					this.OncountryChanging(value);
					this.SendPropertyChanging();
					this._country = value;
					this.SendPropertyChanged("country");
					this.OncountryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TableParkingPlace_TableReservation", Storage="_TableReservation", ThisKey="id", OtherKey="id", IsUnique=true, IsForeignKey=false)]
		public TableReservation TableReservation
		{
			get
			{
				return this._TableReservation.Entity;
			}
			set
			{
				TableReservation previousValue = this._TableReservation.Entity;
				if (((previousValue != value) 
							|| (this._TableReservation.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TableReservation.Entity = null;
						previousValue.TableParkingPlace = null;
					}
					this._TableReservation.Entity = value;
					if ((value != null))
					{
						value.TableParkingPlace = this;
					}
					this.SendPropertyChanged("TableReservation");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TableReservation")]
	public partial class TableReservation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _plate_number;
		
		private System.DateTime _time_from;
		
		private System.DateTime _time_to;
		
		private int _parking_place_id;
		
		private EntityRef<TableParkingPlace> _TableParkingPlace;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onplate_numberChanging(string value);
    partial void Onplate_numberChanged();
    partial void Ontime_fromChanging(System.DateTime value);
    partial void Ontime_fromChanged();
    partial void Ontime_toChanging(System.DateTime value);
    partial void Ontime_toChanged();
    partial void Onparking_place_idChanging(int value);
    partial void Onparking_place_idChanged();
    #endregion
		
		public TableReservation()
		{
			this._TableParkingPlace = default(EntityRef<TableParkingPlace>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					if (this._TableParkingPlace.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_plate_number", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string plate_number
		{
			get
			{
				return this._plate_number;
			}
			set
			{
				if ((this._plate_number != value))
				{
					this.Onplate_numberChanging(value);
					this.SendPropertyChanging();
					this._plate_number = value;
					this.SendPropertyChanged("plate_number");
					this.Onplate_numberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_time_from", DbType="DateTime NOT NULL")]
		public System.DateTime time_from
		{
			get
			{
				return this._time_from;
			}
			set
			{
				if ((this._time_from != value))
				{
					this.Ontime_fromChanging(value);
					this.SendPropertyChanging();
					this._time_from = value;
					this.SendPropertyChanged("time_from");
					this.Ontime_fromChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_time_to", DbType="DateTime NOT NULL")]
		public System.DateTime time_to
		{
			get
			{
				return this._time_to;
			}
			set
			{
				if ((this._time_to != value))
				{
					this.Ontime_toChanging(value);
					this.SendPropertyChanging();
					this._time_to = value;
					this.SendPropertyChanged("time_to");
					this.Ontime_toChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_parking_place_id", DbType="Int NOT NULL")]
		public int parking_place_id
		{
			get
			{
				return this._parking_place_id;
			}
			set
			{
				if ((this._parking_place_id != value))
				{
					this.Onparking_place_idChanging(value);
					this.SendPropertyChanging();
					this._parking_place_id = value;
					this.SendPropertyChanged("parking_place_id");
					this.Onparking_place_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TableParkingPlace_TableReservation", Storage="_TableParkingPlace", ThisKey="id", OtherKey="id", IsForeignKey=true)]
		public TableParkingPlace TableParkingPlace
		{
			get
			{
				return this._TableParkingPlace.Entity;
			}
			set
			{
				TableParkingPlace previousValue = this._TableParkingPlace.Entity;
				if (((previousValue != value) 
							|| (this._TableParkingPlace.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TableParkingPlace.Entity = null;
						previousValue.TableReservation = null;
					}
					this._TableParkingPlace.Entity = value;
					if ((value != null))
					{
						value.TableReservation = this;
						this._id = value.id;
					}
					else
					{
						this._id = default(int);
					}
					this.SendPropertyChanged("TableParkingPlace");
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
