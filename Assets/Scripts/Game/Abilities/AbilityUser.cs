using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUser : MonoBehaviour
{
    public void Visit(ItemData item)
    {
        Visit((dynamic)item);
    }

    public void Visit(FreezTime freezTime)
    {

    }
}
