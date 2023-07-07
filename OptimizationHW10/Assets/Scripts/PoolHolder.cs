using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolHolder : MonoBehaviour
{
    public static PoolHolder Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
