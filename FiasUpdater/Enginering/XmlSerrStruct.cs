using System;
using System.Collections.Generic;
using System.Linq;
namespace FiasUpdater.XmlStruct
{
    #region AS_ACTSTAT

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(IsNullable = false)]
    public partial class ActualStatuses
    {
        private ActualStatusesActualStatus[] actualStatusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActualStatus")]
        public ActualStatusesActualStatus[] ActualStatus
        {
            get
            {
                return this.actualStatusField;
            }
            set
            {
                this.actualStatusField = value;
            }
        }

        public IEnumerable<DataModel.ActualStatus> Build() { return ActualStatus.Select<ActualStatusesActualStatus, DataModel.ActualStatus>(x => x.Build()); }
        
    }

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ActualStatusesActualStatus
    {
        private string aCTSTATIDField;

        private string nAMEField;


        public DataModel.ActualStatus Build() { return new DataModel.ActualStatus {  ACTSTATID = int.Parse(aCTSTATIDField), NAME = nAMEField }; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string ACTSTATID
        {
            get
            {
                return this.aCTSTATIDField;
            }
            set
            {
                this.aCTSTATIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NAME
        {
            get
            {
                return this.nAMEField;
            }
            set
            {
                this.nAMEField = value;
            }
        }
    }

    #endregion AS_ACTSTAT

    #region AS_ADDROBJ/AS_DADDROBJ

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class AddressObjects
    {
        private AddressObjectsObject[] objectField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Object")]
        public AddressObjectsObject[] Object
        {
            get
            {
                return this.objectField;
            }
            set
            {
                this.objectField = value;
            }
        }
        
        public IEnumerable<DataModel.AddressObjects> Build() {
            var filter = Object.Where(e => e.REGIONCODE.Equals("23") || e.REGIONCODE.Equals("01"));
            return filter.Select<AddressObjectsObject, DataModel.AddressObjects>(x => x.Build());
        }

        public IEnumerable<DataModel.DellAddressObjects> DellBuild() {
            var filter = Object.Where(e => e.REGIONCODE.Equals("23") || e.REGIONCODE.Equals("01"));
            return filter.Select<AddressObjectsObject, DataModel.DellAddressObjects>(x => x.DellBuild());
        }

    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AddressObjectsObject
    {
        private string aOGUIDField;
        private string fORMALNAMEField;
        private string rEGIONCODEField;
        private string aUTOCODEField;
        private string aREACODEField;
        private string cITYCODEField;
        private string cTARCODEField;
        private string pLACECODEField;
        private string sTREETCODEField;
        private string eXTRCODEField;
        private string sEXTCODEField;
        private string oFFNAMEField;
        private string pOSTALCODEField;
        private string iFNSFLField;
        private string tERRIFNSFLField;
        private string iFNSULField;
        private string tERRIFNSULField;
        private string oKATOField;
        private string oKTMOField;
        private System.DateTime uPDATEDATEField;
        private string sHORTNAMEField;
        private string aOLEVELField;
        private string pARENTGUIDField;
        private string aOIDField;
        private string pREVIDField;
        private string nEXTIDField;
        private string cODEField;
        private string pLAINCODEField;
        private string aCTSTATUSField;
        private string cENTSTATUSField;
        private string oPERSTATUSField;
        private string cURRSTATUSField;
        private System.DateTime sTARTDATEField;
        private System.DateTime eNDDATEField;
        private string nORMDOCField;
        private sbyte lIVESTATUSField;


        public DataModel.AddressObjects Build() { return new DataModel.AddressObjects {

            AOID = new Guid(AOID),
            AOGUID = new Guid(AOGUID),
            ACTSTATUS = int.Parse(ACTSTATUS),
            AOLEVEL = int.Parse(AOLEVEL),
            AREACODE = AREACODE,
            AUTOCODE = AUTOCODE,
            CENTSTATUS = int.Parse(CENTSTATUS),
            CITYCODE = CITYCODE,
            CODE = CODE,
            CTARCODE = CTARCODE,
            CURRSTATUS = int.Parse(CURRSTATUS),
            ENDDATE = ENDDATE,
            EXTRCODE = EXTRCODE,
            FORMALNAME = FORMALNAME,
            IFNSFL = IFNSFL,
            IFNSUL = IFNSUL,
            LIVESTATUS = LIVESTATUS == 0 ? false : true,
            NEXTID = NEXTID == null ? new Guid?() : new Guid(NEXTID),
            NORMDOC = NORMDOC == null ? new Guid?() : new Guid(NORMDOC),
            OFFNAME = OFFNAME,
            OKATO = OKATO,
            OKTMO = OKTMO,
            OPERSTATUS = int.Parse(OPERSTATUS),
            PARENTGUID = PARENTGUID == null ? new Guid?() : new Guid(PARENTGUID),
            PLACECODE = PLACECODE,
            PLAINCODE = PLAINCODE,
            POSTALCODE = POSTALCODE,
            PREVID = PREVID == null ? new Guid?() : new Guid(PREVID),
            REGIONCODE = REGIONCODE,
            SEXTCODE = SEXTCODE,
            SHORTNAME = SHORTNAME,
            STARTDATE = STARTDATE,
            STREETCODE = STREETCODE,
            TERRIFNSFL = TERRIFNSFL,
            TERRIFNSUL = TERRIFNSUL,
            UPDATEDATE = UPDATEDATE

        }; }

        public DataModel.DellAddressObjects DellBuild()
        {
            return new DataModel.DellAddressObjects
            {

                AOID = new Guid(AOID),
                AOGUID = new Guid(AOGUID),
                ACTSTATUS = int.Parse(ACTSTATUS),
                AOLEVEL = int.Parse(AOLEVEL),
                AREACODE = AREACODE,
                AUTOCODE = AUTOCODE,
                CENTSTATUS = int.Parse(CENTSTATUS),
                CITYCODE = CITYCODE,
                CODE = CODE,
                CTARCODE = CTARCODE,
                CURRSTATUS = int.Parse(CURRSTATUS),
                ENDDATE = ENDDATE,
                EXTRCODE = EXTRCODE,
                FORMALNAME = FORMALNAME,
                IFNSFL = IFNSFL,
                IFNSUL = IFNSUL,
                LIVESTATUS = LIVESTATUS == 0 ? false : true,
                NEXTID = NEXTID == null ? new Guid?() : new Guid(NEXTID),
                NORMDOC = NORMDOC == null ? new Guid?() : new Guid(NORMDOC),
                OFFNAME = OFFNAME,
                OKATO = OKATO,
                OKTMO = OKTMO,
                OPERSTATUS = int.Parse(OPERSTATUS),
                PARENTGUID = PARENTGUID == null ? new Guid?() : new Guid(PARENTGUID),
                PLACECODE = PLACECODE,
                PLAINCODE = PLAINCODE,
                POSTALCODE = POSTALCODE,
                PREVID = PREVID == null ? new Guid?() : new Guid(PREVID),
                REGIONCODE = REGIONCODE,
                SEXTCODE = SEXTCODE,
                SHORTNAME = SHORTNAME,
                STARTDATE = STARTDATE,
                STREETCODE = STREETCODE,
                TERRIFNSFL = TERRIFNSFL,
                TERRIFNSUL = TERRIFNSUL,
                UPDATEDATE = UPDATEDATE

            };
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AOGUID
        {
            get
            {
                return this.aOGUIDField;
            }
            set
            {
                this.aOGUIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FORMALNAME
        {
            get
            {
                return this.fORMALNAMEField;
            }
            set
            {
                this.fORMALNAMEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string REGIONCODE
        {
            get
            {
                return this.rEGIONCODEField;
            }
            set
            {
                this.rEGIONCODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AUTOCODE
        {
            get
            {
                return this.aUTOCODEField;
            }
            set
            {
                this.aUTOCODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AREACODE
        {
            get
            {
                return this.aREACODEField;
            }
            set
            {
                this.aREACODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CITYCODE
        {
            get
            {
                return this.cITYCODEField;
            }
            set
            {
                this.cITYCODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CTARCODE
        {
            get
            {
                return this.cTARCODEField;
            }
            set
            {
                this.cTARCODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PLACECODE
        {
            get
            {
                return this.pLACECODEField;
            }
            set
            {
                this.pLACECODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string STREETCODE
        {
            get
            {
                return this.sTREETCODEField;
            }
            set
            {
                this.sTREETCODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string EXTRCODE
        {
            get
            {
                return this.eXTRCODEField;
            }
            set
            {
                this.eXTRCODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SEXTCODE
        {
            get
            {
                return this.sEXTCODEField;
            }
            set
            {
                this.sEXTCODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OFFNAME
        {
            get
            {
                return this.oFFNAMEField;
            }
            set
            {
                this.oFFNAMEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string POSTALCODE
        {
            get
            {
                return this.pOSTALCODEField;
            }
            set
            {
                this.pOSTALCODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IFNSFL
        {
            get
            {
                return this.iFNSFLField;
            }
            set
            {
                this.iFNSFLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TERRIFNSFL
        {
            get
            {
                return this.tERRIFNSFLField;
            }
            set
            {
                this.tERRIFNSFLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IFNSUL
        {
            get
            {
                return this.iFNSULField;
            }
            set
            {
                this.iFNSULField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TERRIFNSUL
        {
            get
            {
                return this.tERRIFNSULField;
            }
            set
            {
                this.tERRIFNSULField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OKATO
        {
            get
            {
                return this.oKATOField;
            }
            set
            {
                this.oKATOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OKTMO
        {
            get
            {
                return this.oKTMOField;
            }
            set
            {
                this.oKTMOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime UPDATEDATE
        {
            get
            {
                return this.uPDATEDATEField;
            }
            set
            {
                this.uPDATEDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SHORTNAME
        {
            get
            {
                return this.sHORTNAMEField;
            }
            set
            {
                this.sHORTNAMEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string AOLEVEL
        {
            get
            {
                return this.aOLEVELField;
            }
            set
            {
                this.aOLEVELField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PARENTGUID
        {
            get
            {
                return this.pARENTGUIDField;
            }
            set
            {
                this.pARENTGUIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AOID
        {
            get
            {
                return this.aOIDField;
            }
            set
            {
                this.aOIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PREVID
        {
            get
            {
                return this.pREVIDField;
            }
            set
            {
                this.pREVIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NEXTID
        {
            get
            {
                return this.nEXTIDField;
            }
            set
            {
                this.nEXTIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CODE
        {
            get
            {
                return this.cODEField;
            }
            set
            {
                this.cODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PLAINCODE
        {
            get
            {
                return this.pLAINCODEField;
            }
            set
            {
                this.pLAINCODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string ACTSTATUS
        {
            get
            {
                return this.aCTSTATUSField;
            }
            set
            {
                this.aCTSTATUSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string CENTSTATUS
        {
            get
            {
                return this.cENTSTATUSField;
            }
            set
            {
                this.cENTSTATUSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string OPERSTATUS
        {
            get
            {
                return this.oPERSTATUSField;
            }
            set
            {
                this.oPERSTATUSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string CURRSTATUS
        {
            get
            {
                return this.cURRSTATUSField;
            }
            set
            {
                this.cURRSTATUSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime STARTDATE
        {
            get
            {
                return this.sTARTDATEField;
            }
            set
            {
                this.sTARTDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime ENDDATE
        {
            get
            {
                return this.eNDDATEField;
            }
            set
            {
                this.eNDDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NORMDOC
        {
            get
            {
                return this.nORMDOCField;
            }
            set
            {
                this.nORMDOCField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public sbyte LIVESTATUS
        {
            get
            {
                return this.lIVESTATUSField;
            }
            set
            {
                this.lIVESTATUSField = value;
            }
        }
    }

    #endregion AS_ADDROBJ/AS_DADDROBJ

    #region AS_CENTERS

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class CenterStatuses
    {
        private CenterStatusesCenterStatus[] centerStatusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CenterStatus")]
        public CenterStatusesCenterStatus[] CenterStatus
        {
            get
            {
                return this.centerStatusField;
            }
            set
            {
                this.centerStatusField = value;
            }
        }

        public IEnumerable<DataModel.CenterStatuses> Build() { return CenterStatus.Select<CenterStatusesCenterStatus, DataModel.CenterStatuses>(x => x.Build()); }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CenterStatusesCenterStatus
    {
        private string cENTERSTIDField;

        private string nAMEField;

        public DataModel.CenterStatuses Build() { return new DataModel.CenterStatuses { CENTERSTID = int.Parse(cENTERSTIDField),NAME = nAMEField }; }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string CENTERSTID
        {
            get
            {
                return this.cENTERSTIDField;
            }
            set
            {
                this.cENTERSTIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NAME
        {
            get
            {
                return this.nAMEField;
            }
            set
            {
                this.nAMEField = value;
            }
        }
    }

    #endregion AS_CENTERS

    #region AS_CURENTST

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class CurrentStatuses
    {
        private CurrentStatusesCurrentStatus[] currentStatusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CurrentStatus")]
        public CurrentStatusesCurrentStatus[] CurrentStatus
        {
            get
            {
                return this.currentStatusField;
            }
            set
            {
                this.currentStatusField = value;
            }
        }

        public IEnumerable<DataModel.CurrentStatuses> Build() { return CurrentStatus.Select<CurrentStatusesCurrentStatus, DataModel.CurrentStatuses>(x => x.Build()); }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CurrentStatusesCurrentStatus
    {
        private string cURENTSTIDField;

        private string nAMEField;

        public DataModel.CurrentStatuses Build() { return new DataModel.CurrentStatuses { CURENTSTID = int.Parse(cURENTSTIDField), NAME = nAMEField }; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string CURENTSTID
        {
            get
            {
                return this.cURENTSTIDField;
            }
            set
            {
                this.cURENTSTIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NAME
        {
            get
            {
                return this.nAMEField;
            }
            set
            {
                this.nAMEField = value;
            }
        }
    }

    #endregion AS_CURENTST

    #region AS_ESTSTAT

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class EstateStatuses
    {
        private EstateStatusesEstateStatus[] estateStatusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EstateStatus")]
        public EstateStatusesEstateStatus[] EstateStatus
        {
            get
            {
                return this.estateStatusField;
            }
            set
            {
                this.estateStatusField = value;
            }
        }

        public IEnumerable<DataModel.EstateStatuses> Build() { return EstateStatus.Select<EstateStatusesEstateStatus, DataModel.EstateStatuses>(x => x.Build()); }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EstateStatusesEstateStatus
    {
        private string eSTSTATIDField;
        private string nAMEField;
        private string sHORTNAMEField;

        public DataModel.EstateStatuses Build() { return new DataModel.EstateStatuses { ESTSTATID = byte.Parse(eSTSTATIDField), NAME = nAMEField, SHORTNAME = sHORTNAMEField }; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string ESTSTATID
        {
            get
            {
                return this.eSTSTATIDField;
            }
            set
            {
                this.eSTSTATIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NAME
        {
            get
            {
                return this.nAMEField;
            }
            set
            {
                this.nAMEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SHORTNAME
        {
            get
            {
                return this.sHORTNAMEField;
            }
            set
            {
                this.sHORTNAMEField = value;
            }
        }
    }

    #endregion AS_ESTSTAT

    #region AS_HOUSE/AS_DHOUSE

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Houses
    {
        private HousesHouse[] houseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("House")]
        public HousesHouse[] House
        {
            get
            {
                return this.houseField;
            }
            set
            {
                this.houseField = value;
            }
        }

        public IEnumerable<DataModel.Houses> Build() { return houseField.Select<HousesHouse, DataModel.Houses>(x => x.Build()); }
        public IEnumerable<DataModel.DellHouses> DellBuild() { return houseField.Select<HousesHouse, DataModel.DellHouses>(x => x.DellBuild()); }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class HousesHouse
    {
        private string pOSTALCODEField;
        private string iFNSFLField;
        private string tERRIFNSFLField;
        private string iFNSULField;
        private string tERRIFNSULField;
        private string oKATOField;
        private string oKTMOField;
        private System.DateTime uPDATEDATEField;
        private string hOUSENUMField;
        private string eSTSTATUSField;
        private string bUILDNUMField;
        private string sTRUCNUMField;
        private string sTRSTATUSField;
        private string hOUSEIDField;
        private string hOUSEGUIDField;
        private string aOGUIDField;
        private System.DateTime sTARTDATEField;
        private System.DateTime eNDDATEField;
        private string sTATSTATUSField;
        private string nORMDOCField;
        private string cOUNTERField;

        public DataModel.Houses Build() { return new DataModel.Houses {
            HOUSEID = new Guid(HOUSEID),
            HOUSEGUID = new Guid(HOUSEGUID),
            AOGUID = new Guid(AOGUID),
            BUILDNUM = BUILDNUM,
            COUNTER = int.Parse(COUNTER),
            ENDDATE = ENDDATE,
            ESTSTATUS = byte.Parse(ESTSTATUS),
            HOUSENUM = HOUSENUM,
            IFNSFL = IFNSFL,
            IFNSUL = IFNSUL,
            NORMDOC = NORMDOC == null ? new Guid?() : new Guid(NORMDOC),
            OKATO = OKATO,
            OKTMO = OKTMO,
            POSTALCODE = POSTALCODE,
            STARTDATE = STARTDATE,
            STATSTATUS = int.Parse(STATSTATUS),
            STRSTATUS = int.Parse(STRSTATUS),
            STRUCNUM = STRUCNUM,
            TERRIFNSFL = TERRIFNSFL,
            TERRIFNSUL = TERRIFNSUL,
            UPDATEDATE = UPDATEDATE
        }; }

        public DataModel.DellHouses DellBuild()
        {
            return new DataModel.DellHouses
            {
                HOUSEID = new Guid(HOUSEID),
                HOUSEGUID = new Guid(HOUSEGUID),
                AOGUID = new Guid(AOGUID),
                BUILDNUM = BUILDNUM,
                COUNTER = int.Parse(COUNTER),
                ENDDATE = ENDDATE,
                ESTSTATUS = byte.Parse(ESTSTATUS),
                HOUSENUM = HOUSENUM,
                IFNSFL = IFNSFL,
                IFNSUL = IFNSUL,
                NORMDOC = NORMDOC == null ? new Guid?() : new Guid(NORMDOC),
                OKATO = OKATO,
                OKTMO = OKTMO,
                POSTALCODE = POSTALCODE,
                STARTDATE = STARTDATE,
                STATSTATUS = int.Parse(STATSTATUS),
                STRSTATUS = int.Parse(STRSTATUS),
                STRUCNUM = STRUCNUM,
                TERRIFNSFL = TERRIFNSFL,
                TERRIFNSUL = TERRIFNSUL,
                UPDATEDATE = UPDATEDATE
            };
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string POSTALCODE
        {
            get
            {
                return this.pOSTALCODEField;
            }
            set
            {
                this.pOSTALCODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IFNSFL
        {
            get
            {
                return this.iFNSFLField;
            }
            set
            {
                this.iFNSFLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TERRIFNSFL
        {
            get
            {
                return this.tERRIFNSFLField;
            }
            set
            {
                this.tERRIFNSFLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IFNSUL
        {
            get
            {
                return this.iFNSULField;
            }
            set
            {
                this.iFNSULField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TERRIFNSUL
        {
            get
            {
                return this.tERRIFNSULField;
            }
            set
            {
                this.tERRIFNSULField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OKATO
        {
            get
            {
                return this.oKATOField;
            }
            set
            {
                this.oKATOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OKTMO
        {
            get
            {
                return this.oKTMOField;
            }
            set
            {
                this.oKTMOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime UPDATEDATE
        {
            get
            {
                return this.uPDATEDATEField;
            }
            set
            {
                this.uPDATEDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string HOUSENUM
        {
            get
            {
                return this.hOUSENUMField;
            }
            set
            {
                this.hOUSENUMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string ESTSTATUS
        {
            get
            {
                return this.eSTSTATUSField;
            }
            set
            {
                this.eSTSTATUSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BUILDNUM
        {
            get
            {
                return this.bUILDNUMField;
            }
            set
            {
                this.bUILDNUMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string STRUCNUM
        {
            get
            {
                return this.sTRUCNUMField;
            }
            set
            {
                this.sTRUCNUMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string STRSTATUS
        {
            get
            {
                return this.sTRSTATUSField;
            }
            set
            {
                this.sTRSTATUSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string HOUSEID
        {
            get
            {
                return this.hOUSEIDField;
            }
            set
            {
                this.hOUSEIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string HOUSEGUID
        {
            get
            {
                return this.hOUSEGUIDField;
            }
            set
            {
                this.hOUSEGUIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AOGUID
        {
            get
            {
                return this.aOGUIDField;
            }
            set
            {
                this.aOGUIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime STARTDATE
        {
            get
            {
                return this.sTARTDATEField;
            }
            set
            {
                this.sTARTDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime ENDDATE
        {
            get
            {
                return this.eNDDATEField;
            }
            set
            {
                this.eNDDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string STATSTATUS
        {
            get
            {
                return this.sTATSTATUSField;
            }
            set
            {
                this.sTATSTATUSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NORMDOC
        {
            get
            {
                return this.nORMDOCField;
            }
            set
            {
                this.nORMDOCField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string COUNTER
        {
            get
            {
                return this.cOUNTERField;
            }
            set
            {
                this.cOUNTERField = value;
            }
        }
    }

    #endregion AS_HOUSE/AS_DHOUSE

    #region AS_HOUSINT/AS_DHOUSINT

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class HouseIntervals
    {
        private HouseIntervalsHouseInterval[] houseIntervalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HouseInterval")]
        public HouseIntervalsHouseInterval[] HouseInterval
        {
            get
            {
                return this.houseIntervalField;
            }
            set
            {
                this.houseIntervalField = value;
            }
        }

        public IEnumerable<DataModel.HouseIntervals> Build() { return HouseInterval.Select<HouseIntervalsHouseInterval, DataModel.HouseIntervals>(x => x.Build()); }
        public IEnumerable<DataModel.DellHouseIntervals> DellBuild() { return HouseInterval.Select<HouseIntervalsHouseInterval, DataModel.DellHouseIntervals>(x => x.DellBuild()); }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class HouseIntervalsHouseInterval
    {
        private string pOSTALCODEField;
        private string iFNSFLField;
        private string tERRIFNSFLField;
        private string iFNSULField;
        private string tERRIFNSULField;
        private string oKATOField;
        private string oKTMOField;
        private System.DateTime uPDATEDATEField;
        private string iNTSTARTField;
        private string iNTENDField;
        private string hOUSEINTIDField;
        private string iNTGUIDField;
        private string aOGUIDField;
        private System.DateTime sTARTDATEField;
        private System.DateTime eNDDATEField;
        private string iNTSTATUSField;
        private string nORMDOCField;
        private string cOUNTERField;


        public DataModel.HouseIntervals Build()
        {
            return new DataModel.HouseIntervals
            {
                HOUSEINTID = new Guid(HOUSEINTID),
                AOGUID = new Guid(AOGUID),
                COUNTER = int.Parse(COUNTER),
                ENDDATE = ENDDATE,
                IFNSFL = IFNSFL,
                IFNSUL = IFNSUL,
                INTEND = int.Parse(INTEND),
                INTGUID = new Guid(INTGUID),
                INTSTART = int.Parse(INTSTART),
                INTSTATUS = int.Parse(INTSTATUS),
                NORMDOC = NORMDOC == null ? new Guid?() : new Guid(NORMDOC),
                OKATO = OKATO,
                OKTMO = OKTMO,
                POSTALCODE = POSTALCODE,
                STARTDATE = STARTDATE,
                TERRIFNSFL = TERRIFNSFL,
                TERRIFNSUL = TERRIFNSUL,
                UPDATEDATE = UPDATEDATE
            };
        }

        public DataModel.DellHouseIntervals DellBuild()
        {
            return new DataModel.DellHouseIntervals
            {
                HOUSEINTID = new Guid(HOUSEINTID),
                AOGUID = new Guid(AOGUID),
                COUNTER = int.Parse(COUNTER),
                ENDDATE = ENDDATE,
                IFNSFL = IFNSFL,
                IFNSUL = IFNSUL,
                INTEND = int.Parse(INTEND),
                INTGUID = new Guid(INTGUID),
                INTSTART = int.Parse(INTSTART),
                INTSTATUS = int.Parse(INTSTATUS),
                NORMDOC = NORMDOC == null ? new Guid?() : new Guid(NORMDOC),
                OKATO = OKATO,
                OKTMO = OKTMO,
                POSTALCODE = POSTALCODE,
                STARTDATE = STARTDATE,
                TERRIFNSFL = TERRIFNSFL,
                TERRIFNSUL = TERRIFNSUL,
                UPDATEDATE = UPDATEDATE
            };
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string POSTALCODE
        {
            get
            {
                return this.pOSTALCODEField;
            }
            set
            {
                this.pOSTALCODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IFNSFL
        {
            get
            {
                return this.iFNSFLField;
            }
            set
            {
                this.iFNSFLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TERRIFNSFL
        {
            get
            {
                return this.tERRIFNSFLField;
            }
            set
            {
                this.tERRIFNSFLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IFNSUL
        {
            get
            {
                return this.iFNSULField;
            }
            set
            {
                this.iFNSULField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TERRIFNSUL
        {
            get
            {
                return this.tERRIFNSULField;
            }
            set
            {
                this.tERRIFNSULField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OKATO
        {
            get
            {
                return this.oKATOField;
            }
            set
            {
                this.oKATOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OKTMO
        {
            get
            {
                return this.oKTMOField;
            }
            set
            {
                this.oKTMOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime UPDATEDATE
        {
            get
            {
                return this.uPDATEDATEField;
            }
            set
            {
                this.uPDATEDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string INTSTART
        {
            get
            {
                return this.iNTSTARTField;
            }
            set
            {
                this.iNTSTARTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string INTEND
        {
            get
            {
                return this.iNTENDField;
            }
            set
            {
                this.iNTENDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string HOUSEINTID
        {
            get
            {
                return this.hOUSEINTIDField;
            }
            set
            {
                this.hOUSEINTIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string INTGUID
        {
            get
            {
                return this.iNTGUIDField;
            }
            set
            {
                this.iNTGUIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AOGUID
        {
            get
            {
                return this.aOGUIDField;
            }
            set
            {
                this.aOGUIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime STARTDATE
        {
            get
            {
                return this.sTARTDATEField;
            }
            set
            {
                this.sTARTDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime ENDDATE
        {
            get
            {
                return this.eNDDATEField;
            }
            set
            {
                this.eNDDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string INTSTATUS
        {
            get
            {
                return this.iNTSTATUSField;
            }
            set
            {
                this.iNTSTATUSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NORMDOC
        {
            get
            {
                return this.nORMDOCField;
            }
            set
            {
                this.nORMDOCField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string COUNTER
        {
            get
            {
                return this.cOUNTERField;
            }
            set
            {
                this.cOUNTERField = value;
            }
        }
    }

    #endregion AS_HOUSINT/AS_DHOUSINT

    #region AS_HSTSTAT

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class HouseStateStatuses
    {
        private HouseStateStatusesHouseStateStatus[] houseStateStatusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HouseStateStatus")]
        public HouseStateStatusesHouseStateStatus[] HouseStateStatus
        {
            get
            {
                return this.houseStateStatusField;
            }
            set
            {
                this.houseStateStatusField = value;
            }
        }

        public IEnumerable<DataModel.HouseStateStatuses> Build() { return HouseStateStatus.Select<HouseStateStatusesHouseStateStatus, DataModel.HouseStateStatuses>(x => x.Build()); }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class HouseStateStatusesHouseStateStatus
    {
        private string hOUSESTIDField;

        private string nAMEField;

        public DataModel.HouseStateStatuses Build() { return new DataModel.HouseStateStatuses { HOUSESTID = int.Parse(hOUSESTIDField), NAME = nAMEField }; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string HOUSESTID
        {
            get
            {
                return this.hOUSESTIDField;
            }
            set
            {
                this.hOUSESTIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NAME
        {
            get
            {
                return this.nAMEField;
            }
            set
            {
                this.nAMEField = value;
            }
        }
    }

    #endregion AS_HSTSTAT

    #region AS_INTVSTAT

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class IntervalStatuses
    {
        private IntervalStatusesIntervalStatus[] intervalStatusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IntervalStatus")]
        public IntervalStatusesIntervalStatus[] IntervalStatus
        {
            get
            {
                return this.intervalStatusField;
            }
            set
            {
                this.intervalStatusField = value;
            }
        }

        public IEnumerable<DataModel.IntervalStatuses> Build() { return IntervalStatus.Select<IntervalStatusesIntervalStatus, DataModel.IntervalStatuses>(x => x.Build()); }

    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class IntervalStatusesIntervalStatus
    {
        private string iNTVSTATIDField;

        private string nAMEField;

        public DataModel.IntervalStatuses Build() { return new DataModel.IntervalStatuses {INTVSTATID = int.Parse(iNTVSTATIDField), NAME = nAMEField }; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string INTVSTATID
        {
            get
            {
                return this.iNTVSTATIDField;
            }
            set
            {
                this.iNTVSTATIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NAME
        {
            get
            {
                return this.nAMEField;
            }
            set
            {
                this.nAMEField = value;
            }
        }
    }

    #endregion AS_INTVSTAT

    #region AS_LANDMRK

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Landmarks
    {
        private LandmarksLandmark[] landmarkField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Landmark")]
        public LandmarksLandmark[] Landmark
        {
            get
            {
                return this.landmarkField;
            }
            set
            {
                this.landmarkField = value;
            }
        }
        public IEnumerable<DataModel.Landmarks> Build() { return landmarkField.Select<LandmarksLandmark, DataModel.Landmarks>(x => x.Build()); }

    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class LandmarksLandmark
    {
        private string lOCATIONField;
        private string pOSTALCODEField;
        private string iFNSFLField;
        private string tERRIFNSFLField;
        private string iFNSULField;
        private string tERRIFNSULField;
        private string oKATOField;
        private string oKTMOField;
        private System.DateTime uPDATEDATEField;
        private string lANDIDField;
        private string lANDGUIDField;
        private string aOGUIDField;
        private System.DateTime sTARTDATEField;
        private System.DateTime eNDDATEField;
        private string nORMDOCField;

        public DataModel.Landmarks Build()
        {
          return  new DataModel.Landmarks
            {
                LANDID = new Guid(LANDID),
                AOGUID = new Guid(AOGUID),
                LANDGUID = new Guid(LANDGUID),
                ENDDATE = ENDDATE,
                IFNSFL = IFNSFL,
                IFNSUL = IFNSUL,
                LOCATION = LOCATION,
                NORMDOC = NORMDOC == null ? new Guid?() : new Guid(NORMDOC),
                OKATO = OKATO,
                OKTMO = OKTMO,
                POSTALCODE = POSTALCODE,
                STARTDATE = STARTDATE,
                TERRIFNSFL = TERRIFNSFL,
                TERRIFNSUL = TERRIFNSUL,
                UPDATEDATE = UPDATEDATE
                
            };
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LOCATION
        {
            get
            {
                return this.lOCATIONField;
            }
            set
            {
                this.lOCATIONField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string POSTALCODE
        {
            get
            {
                return this.pOSTALCODEField;
            }
            set
            {
                this.pOSTALCODEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IFNSFL
        {
            get
            {
                return this.iFNSFLField;
            }
            set
            {
                this.iFNSFLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TERRIFNSFL
        {
            get
            {
                return this.tERRIFNSFLField;
            }
            set
            {
                this.tERRIFNSFLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IFNSUL
        {
            get
            {
                return this.iFNSULField;
            }
            set
            {
                this.iFNSULField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TERRIFNSUL
        {
            get
            {
                return this.tERRIFNSULField;
            }
            set
            {
                this.tERRIFNSULField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OKATO
        {
            get
            {
                return this.oKATOField;
            }
            set
            {
                this.oKATOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OKTMO
        {
            get
            {
                return this.oKTMOField;
            }
            set
            {
                this.oKTMOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime UPDATEDATE
        {
            get
            {
                return this.uPDATEDATEField;
            }
            set
            {
                this.uPDATEDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LANDID
        {
            get
            {
                return this.lANDIDField;
            }
            set
            {
                this.lANDIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LANDGUID
        {
            get
            {
                return this.lANDGUIDField;
            }
            set
            {
                this.lANDGUIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AOGUID
        {
            get
            {
                return this.aOGUIDField;
            }
            set
            {
                this.aOGUIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime STARTDATE
        {
            get
            {
                return this.sTARTDATEField;
            }
            set
            {
                this.sTARTDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime ENDDATE
        {
            get
            {
                return this.eNDDATEField;
            }
            set
            {
                this.eNDDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NORMDOC
        {
            get
            {
                return this.nORMDOCField;
            }
            set
            {
                this.nORMDOCField = value;
            }
        }
    }

    #endregion AS_LANDMRK/AS_DLANDMRK

    #region AS_NDOCTYPE

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class NormativeDocumentTypes
    {
        private NormativeDocumentTypesNormativeDocumentType[] normativeDocumentTypeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NormativeDocumentType")]
        public NormativeDocumentTypesNormativeDocumentType[] NormativeDocumentType
        {
            get
            {
                return this.normativeDocumentTypeField;
            }
            set
            {
                this.normativeDocumentTypeField = value;
            }
        }

        public IEnumerable<DataModel.NormativeDocumentTypes> Build() { return NormativeDocumentType.Select<NormativeDocumentTypesNormativeDocumentType, DataModel.NormativeDocumentTypes>(x => x.Build()); }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class NormativeDocumentTypesNormativeDocumentType
    {
        private string nDTYPEIDField;

        private string nAMEField;

        public DataModel.NormativeDocumentTypes Build() { return new DataModel.NormativeDocumentTypes { NDTYPEID = int.Parse(NDTYPEID), NAME = nAMEField }; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string NDTYPEID
        {
            get
            {
                return this.nDTYPEIDField;
            }
            set
            {
                this.nDTYPEIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NAME
        {
            get
            {
                return this.nAMEField;
            }
            set
            {
                this.nAMEField = value;
            }
        }
    }

    #endregion AS_NDOCTYPE

    #region AS_NORMDOC/AS_DNORDOC

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class NormativeDocumentes
    {
        private NormativeDocumentesNormativeDocument[] normativeDocumentField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NormativeDocument")]
        public NormativeDocumentesNormativeDocument[] NormativeDocument
        {
            get
            {
                return this.normativeDocumentField;
            }
            set
            {
                this.normativeDocumentField = value;
            }
        }
        public IEnumerable<DataModel.NormativeDocument> Build() { return NormativeDocument.Select<NormativeDocumentesNormativeDocument, DataModel.NormativeDocument>(x => x.Build()); }
        public IEnumerable<DataModel.DellNormativeDocument> DellBuild() { return NormativeDocument.Select<NormativeDocumentesNormativeDocument, DataModel.DellNormativeDocument>(x => x.DellBuild()); }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class NormativeDocumentesNormativeDocument
    {
        private string nORMDOCIDField;
        private string dOCNAMEField;
        private System.DateTime dOCDATEField;
        private bool dOCDATEFieldSpecified;
        private string dOCNUMField;
        private string dOCTYPEField;
        private string dOCIMGIDField;

        public DataModel.NormativeDocument Build() {
            return new DataModel.NormativeDocument
            {
                NORMDOCID = new Guid(NORMDOCID),
                DOCDATE = DOCDATE == DateTime.MinValue || DOCDATE == DateTime.MaxValue ? (DateTime?)null : DOCDATE,
                DOCIMGID = DOCIMGID == null ? new int?() : int.Parse(DOCIMGID),
                DOCNAME = DOCNAME,
                DOCNUM = DOCNUM,
                DOCTYPE = int.Parse(DOCTYPE)
            };
        }

        public DataModel.DellNormativeDocument DellBuild()
        {
            return new DataModel.DellNormativeDocument
            {
                NORMDOCID = new Guid(NORMDOCID),
                DOCDATE = DOCDATE,
                DOCIMGID = DOCIMGID == null ? new int?() : int.Parse(DOCIMGID),
                DOCNAME = DOCNAME,
                DOCNUM = DOCNUM,
                DOCTYPE = int.Parse(DOCTYPE)
            };
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NORMDOCID
        {
            get
            {
                return this.nORMDOCIDField;
            }
            set
            {
                this.nORMDOCIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DOCNAME
        {
            get
            {
                return this.dOCNAMEField;
            }
            set
            {
                this.dOCNAMEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime DOCDATE
        {
            get
            {
                return this.dOCDATEField;
            }
            set
            {
                this.dOCDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DOCDATESpecified
        {
            get
            {
                return this.dOCDATEFieldSpecified;
            }
            set
            {
                this.dOCDATEFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DOCNUM
        {
            get
            {
                return this.dOCNUMField;
            }
            set
            {
                this.dOCNUMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string DOCTYPE
        {
            get
            {
                return this.dOCTYPEField;
            }
            set
            {
                this.dOCTYPEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string DOCIMGID
        {
            get
            {
                return this.dOCIMGIDField;
            }
            set
            {
                this.dOCIMGIDField = value;
            }
        }
    }

    #endregion AS_NORMDOC/AS_DNORDOC

    #region AS_OPERSTAT

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class OperationStatuses
    {
        private OperationStatusesOperationStatus[] operationStatusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OperationStatus")]
        public OperationStatusesOperationStatus[] OperationStatus
        {
            get
            {
                return this.operationStatusField;
            }
            set
            {
                this.operationStatusField = value;
            }
        }
        public IEnumerable<DataModel.OperationStatuses> Build() { return OperationStatus.Select<OperationStatusesOperationStatus, DataModel.OperationStatuses>(x => x.Build()); }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OperationStatusesOperationStatus
    {
        private string oPERSTATIDField;
        private string nAMEField;

        public DataModel.OperationStatuses Build() { return new DataModel.OperationStatuses { OPERSTATID = int.Parse(oPERSTATIDField), NAME = nAMEField }; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string OPERSTATID
        {
            get
            {
                return this.oPERSTATIDField;
            }
            set
            {
                this.oPERSTATIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NAME
        {
            get
            {
                return this.nAMEField;
            }
            set
            {
                this.nAMEField = value;
            }
        }
    }

    #endregion AS_OPERSTAT

    #region AS_SOCRBASE

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class AddressObjectTypes
    {
        private AddressObjectTypesAddressObjectType[] addressObjectTypeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AddressObjectType")]
        public AddressObjectTypesAddressObjectType[] AddressObjectType
        {
            get
            {
                return this.addressObjectTypeField;
            }
            set
            {
                this.addressObjectTypeField = value;
            }
        }
        public IEnumerable<DataModel.AddressObjectTypes> Build() { return AddressObjectType.Select<AddressObjectTypesAddressObjectType, DataModel.AddressObjectTypes>(x => x.Build()); }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AddressObjectTypesAddressObjectType
    {
        private string lEVELField;
        private string sCNAMEField;
        private string sOCRNAMEField;
        private string kOD_T_STField;

        public DataModel.AddressObjectTypes Build() { return new DataModel.AddressObjectTypes { KOD_T_ST = kOD_T_STField, SOCRNAME = sOCRNAMEField, SCNAME = sCNAMEField, LEVEL = int.Parse(lEVELField) }; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string LEVEL
        {
            get
            {
                return this.lEVELField;
            }
            set
            {
                this.lEVELField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SCNAME
        {
            get
            {
                return this.sCNAMEField;
            }
            set
            {
                this.sCNAMEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SOCRNAME
        {
            get
            {
                return this.sOCRNAMEField;
            }
            set
            {
                this.sOCRNAMEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string KOD_T_ST
        {
            get
            {
                return this.kOD_T_STField;
            }
            set
            {
                this.kOD_T_STField = value;
            }
        }
    }

    #endregion AS_SOCRBASE

    #region AS_STRSTAT

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class StructureStatuses
    {
        private StructureStatusesStructureStatus[] structureStatusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StructureStatus")]
        public StructureStatusesStructureStatus[] StructureStatus
        {
            get
            {
                return this.structureStatusField;
            }
            set
            {
                this.structureStatusField = value;
            }
        }
        public IEnumerable<DataModel.StructureStatuses> Build() { return StructureStatus.Select<StructureStatusesStructureStatus, DataModel.StructureStatuses>(x => x.Build()); }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class StructureStatusesStructureStatus
    {
        private string sTRSTATIDField;
        private string nAMEField;
        private string sHORTNAMEField;

        public DataModel.StructureStatuses Build() { return new DataModel.StructureStatuses {STRSTATID = int.Parse(sTRSTATIDField), NAME = nAMEField, SHORTNAME = sHORTNAMEField }; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string STRSTATID
        {
            get
            {
                return this.sTRSTATIDField;
            }
            set
            {
                this.sTRSTATIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NAME
        {
            get
            {
                return this.nAMEField;
            }
            set
            {
                this.nAMEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SHORTNAME
        {
            get
            {
                return this.sHORTNAMEField;
            }
            set
            {
                this.sHORTNAMEField = value;
            }
        }
    }

    #endregion AS_STRSTAT
}