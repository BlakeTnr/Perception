using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalTransform
{

    Transform parent;
    Transform child;
    private Transform childActualParent;

    public LocalTransform(Transform parent, Transform child)
    {
        this.parent = parent;
        this.child = child;
        childActualParent = child.parent;
    }

    private void setChildToParent()
    {
        child.parent = parent;
    }

    private void setChildToActualParent()
    {
        child.parent = childActualParent;
    }
}
