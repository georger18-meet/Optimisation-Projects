using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleBracketsGetComponent : MonoBehaviour
{
    //public float TimeTaken;

    //private float startTime;
    //private float endTime;

    private void Start()
    {
        GetThatComponent();
    }


    [ContextMenu("Get Object's Component")]
    public void GetThatComponent()
    {
        //startTime = Time.realtimeSinceStartup;

        Transform tr = gameObject.GetComponent<Transform>();

        //endTime = Time.realtimeSinceStartup;

        //TimeTaken = endTime - startTime;
    }
}
