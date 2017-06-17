using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using UBoat.Utils;
using UBoat.Utils.Common;
using dataAccess = UBoat.Utils.DataAccess;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Model.Scheduling;
using UBoat.WebHawk.Controller.Data;

namespace UBoat.WebHawk.Controller.Persistence
{
    /// <summary>
    /// Provides database access methods for Sequences, ScheduledTasks, and Settings.
    /// </summary>
    public class WebHawkDataProvider : IDisposable
    {
        #region Private Members

        private dataAccess.IDataAccess m_DataAccess;

        #endregion

        #region Constructor and Lifecycle

        public WebHawkDataProvider(string connectionString)
        {
            m_DataAccess = dataAccess.DataAccessFactory.CreateDataAccess(dataAccess.DataAccessType.SQLite, connectionString);
        }

        public void Dispose()
        {
            if (m_DataAccess != null)
            {
                m_DataAccess.Dispose();
                m_DataAccess = null;
            }
        }

        #endregion

        #region Sequence Operations

        public List<Sequence> GetAllSequences(DeletedInclusion deletedInclusion = DeletedInclusion.NotDeletedOnly)
        {
            List<Sequence> list = new List<Sequence>();
            m_DataAccess.ExecuteQueryReader(dataAccess.CommandType.StoredProcedure, "usp_Seq_GetAllSequences", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@isDeleted", deletedInclusion.ToBoolean())
            }, reader =>
            {
                while (reader.Read())
                {
                    Sequence seq = zMapToSequence(reader);
                    list.Add(seq);
                }
            });
            return list;
        }

        public Sequence GetSequence(long sequenceId, DeletedInclusion deletedInclusion = DeletedInclusion.NotDeletedOnly)
        {
            Sequence sequence = null;
            m_DataAccess.ExecuteQueryReader(dataAccess.CommandType.StoredProcedure, "usp_Seq_GetSequence", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@sequenceId", sequenceId),
                paramBuilder.CreateParameter("@isDeleted", deletedInclusion.ToBoolean())
            }, reader =>
            {
                while (reader.Read())
                {
                    sequence = zMapToSequence(reader);
                }
            });
            return sequence;
        }

        public SequenceDetail GetSequenceDetail(long sequenceId, DeletedInclusion deletedInclusion = DeletedInclusion.NotDeletedOnly)
        {
            SequenceDetail sequenceDetail = null;
            m_DataAccess.ExecuteQueryReader(dataAccess.CommandType.StoredProcedure, "usp_Seq_GetSequenceDetail", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@sequenceId", sequenceId),
                paramBuilder.CreateParameter("@isDeleted", deletedInclusion.ToBoolean())
            }, reader =>
            {
                while (reader.Read())
                {
                    sequenceDetail = zMapToSequenceDetail(reader);
                }
            });
            return sequenceDetail;
        }

        public Dictionary<string, IStateVariable> GetSequencePersistedData(long sequenceId)
        {
            byte[] persistedDataBytes = m_DataAccess.ExecuteScalar(dataAccess.CommandType.StoredProcedure, "usp_Seq_GetSequencePersistedData", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@sequenceId", sequenceId)
            }).Value as byte[];
            if (persistedDataBytes != null)
            {
                return Converter.FromBinary<Dictionary<string, IStateVariable>>(persistedDataBytes);
            }
            return new Dictionary<string, IStateVariable>();
        }

        public void SetSequencePersistedData(long sequenceId, Dictionary<string, IStateVariable> persistedData)
        {
            byte[] persistedDataBytes = null;
            if (persistedData != null && persistedData.Count > 0)
            {
                persistedDataBytes = Converter.ToBinary(persistedData);
            }
            m_DataAccess.ExecuteNonQuery(dataAccess.CommandType.StoredProcedure, "usp_Seq_SetSequencePersistedData", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@sequenceId", sequenceId),
                paramBuilder.CreateParameter("@persistedData", persistedDataBytes)
            });
        }

        public bool SequenceNameExists(string name)
        {
            long count = (long)m_DataAccess.ExecuteScalar(dataAccess.CommandType.StoredProcedure, "usp_Seq_SequenceNameExists", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@sequenceName", name)
            }).Value;
            return count > 0;
        }

        public void SaveSequence(SequenceDetail sequenceDetail)
        {
            if (sequenceDetail != null)
            {
                long count = (long)m_DataAccess.ExecuteScalar(dataAccess.CommandType.StoredProcedure, "usp_Seq_SequenceIdExists", paramBuilder => new List<DbParameter>()
                {
                    paramBuilder.CreateParameter("@sequenceId", sequenceDetail.Sequence.SequenceId)
                }).Value;

                if (count == 0)
                {
                    //Insert
                    long sequenceId = (long)m_DataAccess.ExecuteScalar(dataAccess.CommandType.StoredProcedure, "usp_Seq_InsertSequenceDetail", paramBuilder => 
                        zMapFromSequenceDetail(paramBuilder, sequenceDetail, false)).Value;
                    sequenceDetail.Sequence.SequenceId = sequenceId;
                }
                else
                {
                    //Update
                    m_DataAccess.ExecuteNonQuery(dataAccess.CommandType.StoredProcedure, "usp_Seq_UpdateSequenceDetail", paramBuilder => 
                        zMapFromSequenceDetail(paramBuilder, sequenceDetail, true));
                }
            }
        }

        public void DeleteSequence(long sequenceId)
        {
            m_DataAccess.ExecuteNonQuery(dataAccess.CommandType.StoredProcedure, "usp_Seq_DeleteSequence", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@sequenceId", sequenceId)
            });
        }

        public void HardDeleteSequence(long sequenceId)
        {
            m_DataAccess.ExecuteNonQuery(dataAccess.CommandType.StoredProcedure, "usp_Seq_HardDeleteSequence", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@sequenceId", sequenceId)
            });
        }

        private Sequence zMapToSequence(dataAccess.DataReaderHelper reader)
        {
            Sequence seq = new Sequence();
            seq.SequenceId = reader.GetInt64("SequenceId");
            seq.Name = reader.GetString("SequenceName");
            seq.SequenceType = (SequenceType)reader.GetInt64("SequenceTypeId");
            seq.StepCount = reader.GetInt64("StepCount");
            seq.IsDeleted = reader.GetBoolean("SequenceIsDeleted");
            return seq;
        }
        private SequenceDetail zMapToSequenceDetail(dataAccess.DataReaderHelper reader)
        {
            Sequence sequence = zMapToSequence(reader);
            List<Step> sequenceSteps = Converter.FromBinary<List<Step>>(reader.GetFieldValue<byte[]>("Sequence"));
            SequenceDetail sequenceDetail = new SequenceDetail(sequence, sequenceSteps);
            return sequenceDetail;
        }
        private List<DbParameter> zMapFromSequence(dataAccess.ParameterBuilder paramBuilder, Sequence sequence, bool includeSequenceId)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            if (includeSequenceId)
            {
                parameters.Add(paramBuilder.CreateParameter("@sequenceId", sequence.SequenceId));
            }
            parameters.Add(paramBuilder.CreateParameter("@sequenceName", sequence.Name));
            parameters.Add(paramBuilder.CreateParameter("@sequenceTypeId", (long)sequence.SequenceType));
            parameters.Add(paramBuilder.CreateParameter("@stepCount", sequence.StepCount));
            parameters.Add(paramBuilder.CreateParameter("@isDeleted", sequence.IsDeleted));
            return parameters;
        }
        private List<DbParameter> zMapFromSequenceDetail(dataAccess.ParameterBuilder paramBuilder, SequenceDetail sequenceDetail, bool includeSequenceId)
        {
            List<DbParameter> parameters = zMapFromSequence(paramBuilder, sequenceDetail.Sequence, includeSequenceId);
            parameters.Add(paramBuilder.CreateParameter("@sequence", Converter.ToBinary(sequenceDetail.SequenceSteps)));
            return parameters;
        }

        #endregion

        #region ScheduledTask Operations

        public List<ScheduledTask> GetAllScheduledTasks(DeletedInclusion deletedInclusion = DeletedInclusion.NotDeletedOnly)
        {
            List<ScheduledTask> list = new List<ScheduledTask>();
            m_DataAccess.ExecuteQueryReader(dataAccess.CommandType.StoredProcedure, "usp_Sched_GetAllScheduledTasks", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@isDeleted", deletedInclusion.ToBoolean())
            }, reader =>
            {
                while (reader.Read())
                {
                    ScheduledTask scheduledTask = zMapToScheduledTask(reader);
                    list.Add(scheduledTask);
                }
            });
            return list;
        }

        public ScheduledTask GetScheduledTask(long scheduledTaskId, DeletedInclusion deletedInclusion = DeletedInclusion.NotDeletedOnly)
        {
            ScheduledTask scheduledTask = null;
            m_DataAccess.ExecuteQueryReader(dataAccess.CommandType.StoredProcedure, "usp_Sched_GetScheduledTask", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@scheduledTaskId", scheduledTaskId),
                paramBuilder.CreateParameter("@isDeleted", deletedInclusion.ToBoolean())
            }, reader =>
            {
                while (reader.Read())
                {
                    scheduledTask = zMapToScheduledTask(reader);
                }
            });
            return scheduledTask;
        }

        public bool ScheduledTaskNameExists(string taskName)
        {
            long count = (long)m_DataAccess.ExecuteScalar(dataAccess.CommandType.StoredProcedure, "usp_Sched_ScheduledTaskNameExists", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@taskName", taskName)
            }).Value;
            return count > 0;
        }

        public void SaveScheduledTask(ScheduledTask scheduledTask)
        {
            if (scheduledTask != null)
            {
                long count = (long)m_DataAccess.ExecuteScalar(dataAccess.CommandType.StoredProcedure, "usp_Sched_ScheduledTaskIdExists", paramBuilder => new List<DbParameter>()
                {
                    paramBuilder.CreateParameter("@scheduledTaskId", scheduledTask.ScheduledTaskId)
                }).Value;

                if (count == 0)
                {
                    //Insert
                    long scheduledTaskId = (long)m_DataAccess.ExecuteScalar(dataAccess.CommandType.StoredProcedure, "usp_Sched_InsertScheduledTask", paramBuilder => 
                        zMapFromScheduledTask(paramBuilder, scheduledTask, false)).Value;
                    scheduledTask.ScheduledTaskId = scheduledTaskId;
                }
                else
                {
                    //Update
                    m_DataAccess.ExecuteNonQuery(dataAccess.CommandType.StoredProcedure, "usp_Sched_UpdateScheduledTask", paramBuilder => 
                        zMapFromScheduledTask(paramBuilder, scheduledTask, true));
                }
            }
        }

        public void SetScheduledTaskLastRunStatistics(long scheduledTaskId, ScheduledTaskRunStatistics lastRunStatistics)
        {
            m_DataAccess.ExecuteNonQuery(dataAccess.CommandType.StoredProcedure, "usp_Sched_SetScheduledTaskRunStatistics", paramBuilder =>
                zMapFromScheduledTaskRunStatistics(paramBuilder, scheduledTaskId, lastRunStatistics));
        }

        public void SetScheduledTaskNextScheduledRunTime(long scheduledTaskId, DateTime? nextScheduledRunTimeUtc)
        {
            m_DataAccess.ExecuteNonQuery(dataAccess.CommandType.StoredProcedure, "usp_Sched_SetScheduledTaskNextScheduledRunTime", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@scheduledTaskId", scheduledTaskId),
                paramBuilder.CreateParameter("@nextScheduledRunTimeUtc", nextScheduledRunTimeUtc)
            });
        }

        public void DeleteScheduledTask(long scheduledTaskId)
        {
            m_DataAccess.ExecuteNonQuery(dataAccess.CommandType.StoredProcedure, "usp_Sched_DeleteScheduledTask", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@scheduledTaskId", scheduledTaskId)
            });
        }

        public void HardDeleteScheduledTask(long scheduledTaskId)
        {
            m_DataAccess.ExecuteNonQuery(dataAccess.CommandType.StoredProcedure, "usp_Sched_HardDeleteScheduledTask", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@scheduledTaskId", scheduledTaskId)
            });
        }

        private ScheduledTask zMapToScheduledTask(dataAccess.DataReaderHelper reader)
        {
            ScheduledTaskRunStatistics lastRunStatistics = zMapToScheduledTaskRunStatistics(reader);
            ScheduledTask scheduledTask = new ScheduledTask(lastRunStatistics);
            scheduledTask.ScheduledTaskId = reader.GetInt64("ScheduledTaskId");
            scheduledTask.TaskName = reader.GetString("TaskName");
            scheduledTask.RunSchedule = Converter.FromBinary<Schedule>(reader.GetFieldValue<byte[]>("Schedule"));
            string runDurationLimit = reader.GetNullableString("RunDurationLimit");
            scheduledTask.RunDurationLimit = runDurationLimit != null ? TimeSpan.Parse(runDurationLimit) : new TimeSpan?();
            scheduledTask.Enabled = reader.GetBoolean("Enabled");
            scheduledTask.IsDeleted = reader.GetBoolean("ScheduledTaskIsDeleted");
            scheduledTask.NextScheduledRunTimeUtc = reader.GetNullableDateTime("NextScheduledRunTimeUtc");
            if (!reader.IsDBNull("SequenceId"))
            {
                scheduledTask.TaskSequence = zMapToSequence(reader);
            }
            return scheduledTask;
        }
        private ScheduledTaskRunStatistics zMapToScheduledTaskRunStatistics(dataAccess.DataReaderHelper reader)
        {
            ScheduledTaskRunStatistics scheduledTaskRunStatistics = new ScheduledTaskRunStatistics();
            scheduledTaskRunStatistics.StartTimeUtc = reader.GetNullableDateTime("LastRunStartTimeUtc");
            scheduledTaskRunStatistics.EndTimeUtc = reader.GetNullableDateTime("LastRunEndTimeUtc");
            scheduledTaskRunStatistics.Status = !reader.IsDBNull("LastRunStatusId") ? (ScheduledTaskStatus)reader.GetInt64("LastRunStatusId") : new ScheduledTaskStatus?();
            scheduledTaskRunStatistics.Error = reader.GetNullableString("LastRunError");
            return scheduledTaskRunStatistics;
        }

        private List<DbParameter> zMapFromScheduledTask(dataAccess.ParameterBuilder paramBuilder, ScheduledTask scheduledTask, bool includeScheduledTaskId)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            if (includeScheduledTaskId)
            {
                parameters.Add(paramBuilder.CreateParameter("@scheduledTaskId", scheduledTask.ScheduledTaskId));
            }
            parameters.Add(paramBuilder.CreateParameter("@taskName", scheduledTask.TaskName));
            parameters.Add(paramBuilder.CreateParameter("@sequenceId", scheduledTask.TaskSequence.SequenceId));
            parameters.Add(paramBuilder.CreateParameter("@schedule", Converter.ToBinary(scheduledTask.RunSchedule)));
            parameters.Add(paramBuilder.CreateParameter("@runDurationLimit", scheduledTask.RunDurationLimit));
            parameters.Add(paramBuilder.CreateParameter("@enabled", scheduledTask.Enabled));
            parameters.Add(paramBuilder.CreateParameter("@isDeleted", scheduledTask.IsDeleted));
            //NextScheduledRunTimeUtc is not set by updating the scheduled task, instead it is set by calling SetScheduledTaskNextScheduledRunTime.

            return parameters;
        }
        private List<DbParameter> zMapFromScheduledTaskRunStatistics(dataAccess.ParameterBuilder paramBuilder, long scheduledTaskId, ScheduledTaskRunStatistics scheduledTaskRunStatistics)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(paramBuilder.CreateParameter("@scheduledTaskId", scheduledTaskId));
            parameters.Add(paramBuilder.CreateParameter("@lastRunStartTimeUtc", scheduledTaskRunStatistics.StartTimeUtc));
            parameters.Add(paramBuilder.CreateParameter("@lastRunEndTimeUtc", scheduledTaskRunStatistics.EndTimeUtc));
            parameters.Add(paramBuilder.CreateParameter("@lastRunStatusId", scheduledTaskRunStatistics.Status.HasValue ? (long)scheduledTaskRunStatistics.Status.Value : new long?()));
            parameters.Add(paramBuilder.CreateParameter("@lastRunError", scheduledTaskRunStatistics.Error));
            
            return parameters;
        }

        #endregion

        #region Settings Operations

        public string GetSettingValue(string settingName)
        {
            string value = (string)m_DataAccess.ExecuteScalar(dataAccess.CommandType.StoredProcedure, "usp_Settings_GetSettingValue", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@settingName", settingName)
            }).Value;
            return value;
        }

        public void SetSettingValue(string settingName, string settingValue)
        {
            long count = (long)m_DataAccess.ExecuteScalar(dataAccess.CommandType.StoredProcedure, "usp_Settings_SettingNameExists", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@settingName", settingName)
            }).Value;

            string procName = count == 0 ? "usp_Settings_InsertSetting" : "usp_Settings_UpdateSetting";
            m_DataAccess.ExecuteNonQuery(dataAccess.CommandType.StoredProcedure, procName, paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@settingName", settingName),
                paramBuilder.CreateParameter("@settingValue", settingValue)
            });
        }

        public void DeleteSetting(string settingName)
        {
            m_DataAccess.ExecuteNonQuery(dataAccess.CommandType.StoredProcedure, "usp_Settings_DeleteSetting", paramBuilder => new List<DbParameter>()
            {
                paramBuilder.CreateParameter("@settingName", settingName)
            });
        }

        #endregion
    }
}
