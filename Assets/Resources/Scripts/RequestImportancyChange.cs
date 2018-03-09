using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Request
{
    // enum ChangeType { all, group, single }

    public struct RequestImportancyChange
    {
        int value;
        ChangeType type;
        string[] ids;
    }
}
