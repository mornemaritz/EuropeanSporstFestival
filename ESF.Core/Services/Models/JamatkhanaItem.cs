using System;

namespace ESF.Core.Services
{
    public class JamatkhanaItem
    {
        public JamatkhanaItem(Guid jamatkhanaId, string jamatkhanaName)
        {
            JamatkhanaId = jamatkhanaId;
            JamatkhanaName = jamatkhanaName;
        }

        public Guid JamatkhanaId { get; private set; }
        public string JamatkhanaName { get; private set; }
    }
}
