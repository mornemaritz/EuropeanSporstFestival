using System;
using System.Collections.Generic;
using ESF.Core.Services;
using ESF.Domain;

namespace ESF.Core.Repositories
{
    public interface IJamatkhanaRepository
    {
        IList<JamatkhanaItem> FindJamatkhanas();
        Jamatkhana Load(Guid jamatkhanaId);
    }
}
