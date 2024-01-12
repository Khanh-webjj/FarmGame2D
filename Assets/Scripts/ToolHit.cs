using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolHit : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Hit()
    {

    }
    public virtual bool CanBeHit(List<ResourceNodeType> canBeHit)
	{
        return true;
	}
}
