using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBoat.Utils.Common
{
    public enum DeletedInclusion
    {
        NotDeletedOnly,
        DeletedOnly,
        All
    }

    public static class DeletedInclusionExtensions
    {
        public static bool? ToBoolean(this DeletedInclusion deletedInclusion)
        {
            switch (deletedInclusion)
            {
                case DeletedInclusion.NotDeletedOnly:
                    return false;
                case DeletedInclusion.DeletedOnly:
                    return true;
                default:
                    return null;
            }
        }
    }
}
