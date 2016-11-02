using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using FiasUpdater.DataModel;

namespace FiasUpdater.Enginering
{
    class BusinesLogic
    {
        private const string Patch = @"\\IISEXT\temp\";
        private const string connect = "Data Source=SOMEBD;Initial Catalog=FIAS;User ID=user;Password=password";
        public static string dirName { private get; set; }

        private static T Deserialize<T>(XDocument doc)
        {

            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var result = (T) xmlSerializer.Deserialize(doc.CreateReader());
            return result;

        }

        public void moveDate()
        {
            EventLoger.setEvent("Попытка Актуализации базы адресов!", EventLogEntryType.Information);

            var direct = string.Format("{0}{1}\\", Patch, dirName);

            if (!Directory.Exists(direct)) {
                EventLoger.setEvent(string.Format("Дирректория {0} по пути {1} Не найдена!",dirName,Patch), EventLogEntryType.Error);
                return; }

            #region dictionary
            var AS_HSTSTAT = Directory.GetFiles(direct, "AS_HSTSTAT_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_INTVSTAT = Directory.GetFiles(direct, "AS_INTVSTAT_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_CENTERST = Directory.GetFiles(direct, "AS_CENTERST_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_CURENTST = Directory.GetFiles(direct, "AS_CURENTST_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_SOCRBASE = Directory.GetFiles(direct, "AS_SOCRBASE_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_ACTSTAT = Directory.GetFiles(direct, "AS_ACTSTAT_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_OPERSTAT = Directory.GetFiles(direct, "AS_OPERSTAT_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_ESTSTAT = Directory.GetFiles(direct, "AS_ESTSTAT_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_STRSTAT = Directory.GetFiles(direct, "AS_STRSTAT_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_NDOCTYPE = Directory.GetFiles(direct, "AS_NDOCTYPE_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();

            var AS_ADDROBJ = Directory.GetFiles(direct, "AS_ADDROBJ_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_HOUSE = Directory.GetFiles(direct, "AS_HOUSE_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_HOUSEINT = Directory.GetFiles(direct, "AS_HOUSEINT_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_LANDMARK = Directory.GetFiles(direct, "AS_LANDMARK_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_NORMDOC = Directory.GetFiles(direct, "AS_NORMDOC_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();

            var AS_DEL_ADDROBJ = Directory.GetFiles(direct, "AS_DEL_ADDROBJ_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_DEL_HOUSE = Directory.GetFiles(direct, "AS_DEL_HOUSE_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_DEL_HOUSEINT = Directory.GetFiles(direct, "AS_DEL_HOUSEINT_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();
            var AS_DEL_NORMDOC = Directory.GetFiles(direct, "AS_DEL_NORMDOC_*.XML", SearchOption.TopDirectoryOnly).FirstOrDefault();

            var block = new Dictionary<string, string>
            {
            {"AS_HSTSTAT", AS_HSTSTAT ?? string.Empty},
            {"AS_INTVSTAT",AS_INTVSTAT ?? string.Empty},
            {"AS_CENTERST",AS_CENTERST ?? string.Empty},
            {"AS_CURENTST",AS_CURENTST ?? string.Empty},
            {"AS_SOCRBASE",AS_SOCRBASE ?? string.Empty},
            {"AS_ACTSTAT",AS_ACTSTAT ?? string.Empty},
            {"AS_OPERSTAT",AS_OPERSTAT ?? string.Empty},
            {"AS_ESTSTAT",AS_ESTSTAT ?? string.Empty},
            {"AS_STRSTAT",AS_STRSTAT ?? string.Empty},
            {"AS_NDOCTYPE", AS_NDOCTYPE ?? string.Empty},

            {"AS_ADDROBJ", AS_ADDROBJ ?? string.Empty},
            {"AS_HOUSE", AS_HOUSE ?? string.Empty},
            {"AS_HOUSEINT", AS_HOUSEINT ?? string.Empty},
            {"AS_LANDMARK", AS_LANDMARK ?? string.Empty},
            {"AS_NORMDOC", AS_NORMDOC ?? string.Empty},

            {"AS_DEL_ADDROBJ", AS_DEL_ADDROBJ ?? string.Empty},
            {"AS_DEL_HOUSE", AS_DEL_HOUSE ?? string.Empty},
            {"AS_DEL_HOUSEINT", AS_DEL_HOUSEINT ?? string.Empty},
            {"AS_DEL_NORMDOC", AS_DEL_NORMDOC ?? string.Empty}
            };
            #endregion

            foreach (var patch in block)
            {
               #region kernel
                #region AS_HSTSTAT
                if (patch.Key.Equals("AS_HSTSTAT"))
                {
                    if (patch.Value == string.Empty) continue;

                    var contex = new FiasDBDataContext(connect);
                    IEnumerable<HouseStateStatuses> dess;
                    
                    try
                    {
                        dess = Deserialize<XmlStruct.HouseStateStatuses>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error); continue;
                    }

                    contex.Connection.Open();
                    var i=0;
                    foreach (var row in dess)
                    {
                        var u = from status in contex.HouseStateStatuses where status.HOUSESTID == row.HOUSESTID select status;
                        if (!u.Any())
                        {
                            contex.HouseStateStatuses.InsertOnSubmit(row);
                            i+=1;
                        }
                    }

                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                        
                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "HouseStateStatuses",i), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }
                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_INTVSTAT
                if (patch.Key.Equals("AS_INTVSTAT"))
                {
                    if (patch.Value == string.Empty) continue;

                    var contex = new FiasDBDataContext(connect);
                    IEnumerable<IntervalStatuses> dess;
                    try
                    {
                        dess = Deserialize<XmlStruct.IntervalStatuses>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                       EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error); continue;
                    }

                    contex.Connection.Open();
                    
                    var i = 0;
                    
                    foreach (var row in dess)
                    {
                        var u = from intstatus in contex.IntervalStatuses where intstatus.INTVSTATID == row.INTVSTATID select intstatus;
                        if (!u.Any())
                        {
                            contex.IntervalStatuses.InsertOnSubmit(row);
                            i += 1;
                        }
                    }

                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "IntervalStatuses", i), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }
                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_CENTERST
                if (patch.Key.Equals("AS_CENTERST"))
                {
                    if (patch.Value == string.Empty) continue;

                    var contex = new FiasDBDataContext(connect);
                    IEnumerable<CenterStatuses> dess;
                    try
                    {
                        dess = Deserialize<XmlStruct.CenterStatuses>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(
                            string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key,
                                ex.Message), EventLogEntryType.Error);
                        continue;
                    }


                    contex.Connection.Open();
                    var i = 0;
                    foreach (var row in dess)
                    {
                        var u = from center in contex.CenterStatuses where center.CENTERSTID == row.CENTERSTID select center;
                        if (!u.Any())
                        {
                            contex.CenterStatuses.InsertOnSubmit(row);
                            i += 1;
                        }
                    }
                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "CenterStatuses", i), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }
                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_CURENTST
                if (patch.Key.Equals("AS_CURENTST"))
                {
                    if (patch.Value == string.Empty) continue;

                    FiasDBDataContext contex = new FiasDBDataContext(connect);
                    IEnumerable<CurrentStatuses> dess;
                    try
                    {
                        dess = Deserialize<XmlStruct.CurrentStatuses>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }
                    
                    contex.Connection.Open();

                    foreach (var row in dess)
                    {
                        var u = from variable in contex.CurrentStatuses where variable.CURENTSTID == row.CURENTSTID select variable.CURENTSTID;
                        if (u.Count() == 0)
                        {
                            contex.CurrentStatuses.InsertOnSubmit(row);
                        }
                    }

                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "CurrentStatuses", dess.Count()), EventLogEntryType.Information);

                        if (dess != null) (dess as IDisposable).Dispose();
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }
                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_SOCRBASE
                if (patch.Key.Equals("AS_SOCRBASE"))
                {
                    if (patch.Value == string.Empty) continue;

                    FiasDBDataContext contex = new FiasDBDataContext(connect);

                    IEnumerable<AddressObjectTypes> dess;

                    try
                    {
                        dess = Deserialize<XmlStruct.AddressObjectTypes>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    contex.Connection.Open();

                    foreach (var row in dess)
                    {
                        var u = from variable in contex.AddressObjectTypes where variable.KOD_T_ST.Equals(row.KOD_T_ST) select variable.KOD_T_ST;
                        if (u.Count() == 0)
                        {
                            contex.AddressObjectTypes.InsertOnSubmit(row);
                        }
                    }

                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "AddressObjectTypes", dess.Count()), EventLogEntryType.Information);

                        if (dess != null) (dess as IDisposable).Dispose();
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }
                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_ACTSTAT
                if (patch.Key.Equals("AS_ACTSTAT"))
                {
                    if (patch.Value == string.Empty) continue;

                    FiasDBDataContext contex = new FiasDBDataContext(connect);
                    IEnumerable<ActualStatus> dess;
                    try
                    {
                        dess = Deserialize<XmlStruct.ActualStatuses>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    contex.Connection.Open();

                    foreach (var row in dess)
                    {
                        var u = from variable in contex.ActualStatus where variable.ACTSTATID==row.ACTSTATID select variable.ACTSTATID;
                        if (u.Count() == 0)
                        {
                            contex.ActualStatus.InsertOnSubmit(row);
                        }
                    }

                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "ActualStatus", dess.Count()), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }
                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_OPERSTAT
                if (patch.Key.Equals("AS_OPERSTAT"))
                {
                    if (patch.Value == string.Empty) continue;

                    FiasDBDataContext contex = new FiasDBDataContext(connect);
                    IEnumerable<OperationStatuses> dess;

                    try
                    {
                        dess = Deserialize<XmlStruct.OperationStatuses>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    contex.Connection.Open();

                    foreach (var row in dess)
                    {
                        var u = from variable in contex.OperationStatuses where variable.OPERSTATID == row.OPERSTATID select variable.OPERSTATID;
                        if (u.Count() == 0)
                        {
                            contex.OperationStatuses.InsertOnSubmit(row);
                        }
                    }

                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "OperationStatuses", dess.Count()), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }
                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_ESTSTAT
                if (patch.Key.Equals("AS_ESTSTAT"))
                {
                    if (patch.Value == string.Empty) continue;

                    FiasDBDataContext contex = new FiasDBDataContext(connect);
                    IEnumerable<EstateStatuses> dess;
                    try
                    {
                        dess = Deserialize<XmlStruct.EstateStatuses>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    contex.Connection.Open();

                    foreach (var row in dess)
                    {
                        var u = from variable in contex.EstateStatuses where variable.ESTSTATID == row.ESTSTATID select variable.ESTSTATID;
                        if (u.Count() == 0)
                        {
                            contex.EstateStatuses.InsertOnSubmit(row);
                        }
                    }

                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "EstateStatuses", dess.Count()), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }
                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_STRSTAT
                if (patch.Key.Equals("AS_STRSTAT"))
                {
                    if (patch.Value == string.Empty) continue;

                    FiasDBDataContext contex = new FiasDBDataContext(connect);
                    IEnumerable<StructureStatuses> dess;

                    try
                    {
                        dess = Deserialize<XmlStruct.StructureStatuses>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    contex.Connection.Open();

                    foreach (var row in dess)
                    {
                        var u = from variable in contex.StructureStatuses where variable.STRSTATID == row.STRSTATID select variable.STRSTATID;
                        if (u.Count() == 0)
                        {
                            contex.StructureStatuses.InsertOnSubmit(row);
                        }
                    }

                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "StructureStatuses", dess.Count()), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }
                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_DEL_ADDROBJ
                if (patch.Key.Equals("AS_DEL_ADDROBJ"))
                {
                    if (patch.Value == string.Empty) continue;

                    FiasDBDataContext contex = new FiasDBDataContext(connect);
                    IEnumerable<DellAddressObjects> dess;
                    try
                    {
                        dess = Deserialize<XmlStruct.AddressObjects>(XDocument.Load(patch.Value)).DellBuild();
                    }
                    catch (Exception ex) {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    contex.Connection.Open();

                    foreach (var row in dess)
                    {
                        var u = from variable in contex.DellAddressObjects where variable.AOID.Equals(row.AOID) select variable.AOID;
                        if (u.Count() == 0)
                        {
                            contex.DellAddressObjects.InsertOnSubmit(row);
                        }
                    }

                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "DellAddressObjects", dess.Count()), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }
                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_DEL_HOUSE
                if (patch.Key.Equals("AS_DEL_HOUSE"))
                {
                    if (patch.Value == string.Empty) continue;

                    FiasDBDataContext contex = new FiasDBDataContext(connect);
                    IEnumerable<DellHouses> dess;

                    try
                    {
                        dess = Deserialize<XmlStruct.Houses>(XDocument.Load(patch.Value)).DellBuild();
                    }
                    catch (Exception ex)
                    {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    contex.Connection.Open();

                    foreach (var row in dess)
                    {
                        var u = from variable in contex.DellHouses where variable.HOUSEID.Equals(row.HOUSEID) select variable.HOUSEID;
                        if (u.Count() == 0)
                        {
                            contex.DellHouses.InsertOnSubmit(row);
                        }
                    }

                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "DellHouses", dess.Count()), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }
                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_DEL_HOUSEINT
                if (patch.Key.Equals("AS_DEL_HOUSEINT"))
                {
                    if (patch.Value == string.Empty) continue;

                    FiasDBDataContext contex = new FiasDBDataContext(connect);
                    IEnumerable<DellHouseIntervals> dess;

                    try
                    {
                        dess = Deserialize<XmlStruct.HouseIntervals>(XDocument.Load(patch.Value)).DellBuild();
                    }
                    catch (Exception ex) {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    contex.Connection.Open();

                    foreach (var row in dess)
                    {
                        var u = from variable in contex.DellHouseIntervals where variable.HOUSEINTID.Equals(row.HOUSEINTID) select variable.HOUSEINTID;
                        if (u.Count() == 0)
                        {
                            contex.DellHouseIntervals.InsertOnSubmit(row);
                        }
                    }
                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "DellHouseIntervals", dess.Count()), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }
                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                }
                #endregion

                #region AS_DEL_NORMDOC
                if (patch.Key.Equals("AS_DEL_NORMDOC"))
                {
                    if (patch.Value == string.Empty) continue;

                    FiasDBDataContext contex = new FiasDBDataContext(connect);
                    IEnumerable<DellNormativeDocument> dess;
                    try
                    {
                        dess = Deserialize<XmlStruct.NormativeDocumentes>(XDocument.Load(patch.Value)).DellBuild();
                    }
                    catch  (Exception ex){
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }
                    
                    contex.Connection.Open();

                    foreach (var row in dess)
                    {
                        var u = from variable in contex.DellNormativeDocument where variable.NORMDOCID.Equals(row.NORMDOCID) select variable.NORMDOCID;
                        if (u.Count() == 0)
                        {
                            contex.DellNormativeDocument.InsertOnSubmit(row);
                        }
                    }
                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "DellNormativeDocument", dess.Count()), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }
                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_ADDROBJ
                if (patch.Key.Equals("AS_ADDROBJ"))
                {
                    if (patch.Value == string.Empty) continue;

                    IEnumerable<AddressObjects> dess;

                    try
                    {
                        dess = Deserialize<XmlStruct.AddressObjects>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    using (var contex = new FiasDBDataContext(connect))
                    {


                        contex.Connection.Open();
                        foreach (var row in dess)
                        {
                            try
                            {
                                contex.AddressObjects_INSERT(
                                    row.AOID,
                                    row.AOGUID,
                                    row.PARENTGUID,
                                    row.NEXTID,
                                    row.PREVID,
                                    row.FORMALNAME,
                                    row.REGIONCODE,
                                    row.AUTOCODE,
                                    row.AREACODE,
                                    row.CITYCODE,
                                    row.CTARCODE,
                                    row.PLACECODE,
                                    row.STREETCODE,
                                    row.EXTRCODE,
                                    row.SEXTCODE,
                                    row.OFFNAME,
                                    row.POSTALCODE,
                                    row.IFNSFL,
                                    row.TERRIFNSFL,
                                    row.IFNSUL,
                                    row.TERRIFNSUL,
                                    row.OKATO,
                                    row.OKTMO,
                                    row.UPDATEDATE,
                                    row.SHORTNAME,
                                    row.AOLEVEL,
                                    row.CODE,
                                    row.PLAINCODE,
                                    row.ACTSTATUS,
                                    row.CENTSTATUS,
                                    row.OPERSTATUS,
                                    row.CURRSTATUS,
                                    row.STARTDATE,
                                    row.ENDDATE,
                                    row.NORMDOC,
                                    row.LIVESTATUS);

                            }
                            catch (Exception ex)
                            {
                                EventLoger.setEvent(
                                    string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key,
                                        ex.Message), EventLogEntryType.Error);
                            }
                        }


                        EventLoger.setEvent(
                            string.Format(" В таблица {0} обработанна.", "AddressObjectsAllKey"),
                            EventLogEntryType.Information);

                        contex.Connection.Close();
                        contex.Dispose();
                    }

                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_HOUSE
                if (patch.Key.Equals("AS_HOUSE"))
                {
                    if (patch.Value == string.Empty) continue;

                    IEnumerable<Houses> dess;
                    try
                    {
                        dess = Deserialize<XmlStruct.Houses>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    using (var contex = new FiasDBDataContext(connect))
                    {
                        contex.Connection.Open();

                        foreach (var row in dess)
                        {
                            try
                            {
                                contex.Houses_INSERT(
                                    row.HOUSEID,
                                    row.AOGUID,
                                    row.HOUSEGUID,
                                    row.POSTALCODE,
                                    row.IFNSFL,
                                    row.TERRIFNSFL,
                                    row.IFNSUL,
                                    row.TERRIFNSUL,
                                    row.OKATO,
                                    row.OKTMO,
                                    row.UPDATEDATE,
                                    row.HOUSENUM,
                                    row.ESTSTATUS,
                                    row.BUILDNUM,
                                    row.STRUCNUM,
                                    row.STRSTATUS,
                                    row.STARTDATE,
                                    row.ENDDATE,
                                    row.STATSTATUS,
                                    row.COUNTER,
                                    row.NORMDOC);
                            }
                            catch (Exception ex)
                            {
                                EventLoger.setEvent(
                                    string.Format(
                                        "При обработке '{0}' возникло следующее исключение:\n {1} Ключь: {2} \n",
                                        patch.Key,
                                        ex.Message, row.AOGUID), EventLogEntryType.Error);
                            }

                        }


                        EventLoger.setEvent(
                            string.Format(" В таблицу {0} обработанна.", "Houses"),
                            EventLogEntryType.Information);

                        contex.Connection.Close();
                        contex.Dispose();
                    }
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_HOUSEINT
                if (patch.Key.Equals("AS_HOUSEINT"))
                {
                    if (patch.Value == string.Empty) continue;

                    IEnumerable<HouseIntervals> dess;
                    try
                    {
                        dess = Deserialize<XmlStruct.HouseIntervals>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    using (var contex = new FiasDBDataContext(connect))
                    {

                        contex.Connection.Open();
                        foreach (var row in dess)
                        {
                            try
                            {
                                contex.HouseIntervals_INSERT(
                                    row.HOUSEINTID,
                                    row.INTGUID,
                                    row.AOGUID,
                                    row.POSTALCODE,
                                    row.IFNSFL,
                                    row.TERRIFNSFL,
                                    row.IFNSUL,
                                    row.TERRIFNSUL,
                                    row.OKATO,
                                    row.OKTMO,
                                    row.UPDATEDATE,
                                    row.INTSTART,
                                    row.INTEND,
                                    row.STARTDATE,
                                    row.ENDDATE,
                                    row.INTSTATUS,
                                    row.NORMDOC,
                                    row.COUNTER
                                    );

                            }
                            catch (Exception ex)
                            {
                                EventLoger.setEvent(
                                    string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key,
                                        ex.Message), EventLogEntryType.Error);
                            }
                        }

                        EventLoger.setEvent(
                            string.Format(" В таблицу {0} обработанна.", "HouseIntervals"),
                            EventLogEntryType.Information);

                        contex.Connection.Close();
                        contex.Dispose();
                    }
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                }
                #endregion

                #region AS_LANDMARK
                if (patch.Key.Equals("AS_LANDMARK"))
                {
                    if (patch.Value == string.Empty) continue;

                    IEnumerable<Landmarks> dess;
                    try
                    {
                        dess = Deserialize<XmlStruct.Landmarks>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    using (var contex = new FiasDBDataContext(connect))
                    {

                        contex.Connection.Open();

                        foreach (var row in dess)
                        {
                            try
                            {
                                contex.Landmarks_INSERT(
                                    row.LANDID,
                                    row.LANDGUID,
                                    row.AOGUID,
                                    row.LOCATION,
                                    row.POSTALCODE,
                                    row.IFNSFL,
                                    row.TERRIFNSFL,
                                    row.IFNSUL,
                                    row.TERRIFNSUL,
                                    row.OKATO,
                                    row.OKTMO,
                                    row.UPDATEDATE,
                                    row.STARTDATE,
                                    row.ENDDATE,
                                    row.NORMDOC);

                            }
                            catch (Exception ex)
                            {
                                EventLoger.setEvent(
                                    string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key,
                                        ex.Message), EventLogEntryType.Error);
                            }
                        }

                        EventLoger.setEvent(
                            string.Format(" В таблица {0} обработанна.", "Landmarks"),
                            EventLogEntryType.Information);

                        contex.Connection.Close();
                        contex.Dispose();
                    }
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_NDOCTYPE
                if (patch.Key.Equals("AS_NDOCTYPE"))
                {
                    if (patch.Value == string.Empty) continue;

                    FiasDBDataContext contex = new FiasDBDataContext(connect);
                    IEnumerable<NormativeDocumentTypes> dess;

                    try
                    {
                        dess = Deserialize<XmlStruct.NormativeDocumentTypes>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex)
                    {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    contex.Connection.Open();

                    foreach (var row in dess)
                    {
                        var u = from variable in contex.NormativeDocumentTypes where variable.NDTYPEID == row.NDTYPEID select variable.NDTYPEID;
                        if (u.Count() == 0)
                        {
                            contex.NormativeDocumentTypes.InsertOnSubmit(row);
                        }
                    }

                    try
                    {
                        contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                        EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "NormativeDocumentTypes", dess.Count()), EventLogEntryType.Information);
                    }
                    catch (Exception ex)
                    {
                        EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);
                    }

                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion

                #region AS_NORMDOC
                if (patch.Key.Equals("AS_NORMDOC"))
                {
                    if (patch.Value == string.Empty) continue;

                    FiasDBDataContext contex = new FiasDBDataContext(connect);
                    IEnumerable<NormativeDocument> dess;
                    try
                    {
                        dess = Deserialize<XmlStruct.NormativeDocumentes>(XDocument.Load(patch.Value)).Build();
                    }
                    catch (Exception ex) {
                                            EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1}", patch.Key, ex.Message), EventLogEntryType.Error);  continue;
                    }

                    contex.Connection.Open();

                    foreach (var row in dess)
                    {
                        var u = from variable in contex.NormativeDocument where variable.NORMDOCID.Equals(row.NORMDOCID) select variable.NORMDOCID;
                        if (!u.Any())
                        {
                            try
                            {
                                contex.NormativeDocument.InsertOnSubmit(row);
                                contex.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);

                                EventLoger.setEvent(string.Format("В таблицу {0} добавленно {1} записей.", "NormativeDocument", row.NORMDOCID), EventLogEntryType.Information);
                            }
                            catch (Exception ex)
                            {
                                EventLoger.setEvent(string.Format("При обработке '{0}' возникло следующее исключение:\n {1} | {2}", "NormativeDocument", ex.Message,row.NORMDOCID), EventLogEntryType.Error);
                            }
                            
                        }
                    }


                    contex.Connection.Close();
                    contex.Dispose();
                    dess = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                #endregion
               #endregion
            }

            EventLoger.setEvent(string.Format("Операция заполнения была выполнена"), EventLogEntryType.Information);

            using (var cont = new FiasDBDataContext(connect))
            {
                cont.Connection.Open();
                cont.DELFROM();
                cont.Connection.Close();
            }

        }
    }
}
