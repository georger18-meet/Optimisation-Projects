using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Amount;
    public GameObject ObjectRef;
    public float TimeTaken;

    private float startTime;
    private float endTime;

    [ContextMenu("Create Objects")]
    public void CreateObjects()
    {
        startTime = Time.realtimeSinceStartup;
        for (int i = 0; i < Amount; i++)
        {
            Instantiate(ObjectRef);
        }
        endTime = Time.realtimeSinceStartup;

        TimeTaken = endTime - startTime;
    }
}
