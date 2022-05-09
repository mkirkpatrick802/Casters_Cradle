using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    public static ReferenceManager instance { private set; get; }

    private void Awake()
    {
        instance = this;
    }

    public Transform dropItem;
}
