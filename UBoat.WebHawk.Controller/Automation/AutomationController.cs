using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBoat.Utils.Common;
using UBoat.WebHawk.Controller.Common;
using UBoat.WebHawk.Controller.Persistence;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Data;

namespace UBoat.WebHawk.Controller.Automation
{
    public class AutomationController : ControllerBase
    {
        public AutomationController(string connectionString)
            : base(connectionString)
        {
        }

        public void SaveSequence(SequenceDetail sequenceDetail)
        {
            sequenceDetail.Sequence.StepCount = sequenceDetail.CalculateStepCount();

            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                data.SaveSequence(sequenceDetail);
            }
        }

        public void DeleteSequence(Sequence sequence, bool softDelete = true)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                if (softDelete)
                {
                    data.DeleteSequence(sequence.SequenceId);
                    sequence.IsDeleted = true;
                }
                else
                {
                    data.HardDeleteSequence(sequence.SequenceId);
                }
            }
        }

        public List<Sequence> GetAllSequences(DeletedInclusion deletedInclusion = DeletedInclusion.NotDeletedOnly)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                return data.GetAllSequences(deletedInclusion);
            }
        }

        public Sequence GetSequence(long sequenceId, DeletedInclusion deletedInclusion = DeletedInclusion.NotDeletedOnly)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                return data.GetSequence(sequenceId, deletedInclusion);
            }
        }

        public SequenceDetail GetSequenceDetail(long sequenceId, DeletedInclusion deletedInclusion = DeletedInclusion.NotDeletedOnly)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                return data.GetSequenceDetail(sequenceId, deletedInclusion);
            }
        }

        public bool ValidateNewSequenceName(string name)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                return !data.SequenceNameExists(name);
            }
        }

        public Dictionary<string, IStateVariable> GetSequencePersistedData(long sequenceId)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                return data.GetSequencePersistedData(sequenceId);
            }
        }

        public void SetSequencePersistedData(long sequenceId, Dictionary<string, IStateVariable> persistedData)
        {
            using (WebHawkDataProvider data = new WebHawkDataProvider(ConnectionString))
            {
                data.SetSequencePersistedData(sequenceId, persistedData);
            }
        }
    }
}
