using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ComparingTags : MonoBehaviour
{
    public int Amount;
    public GameObject ObjectRef;
    public Transform Parent;
    public bool UseCompareTag;

    public List<GameObject> AllCreatedObjects;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateObjectsToList();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DoTagCheck();
        }
    }


    public void CreateObjectsToList()
    {
        AllCreatedObjects.Clear();

        int counter = 0;
        while (counter < Amount)
        {
            GameObject go = Instantiate(ObjectRef, Parent);
            AllCreatedObjects.Add(go);
            counter++;
        }
    }

    private void DoTagCheck()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        if (UseCompareTag)
        {
            for (int i = 0; i < AllCreatedObjects.Count; i++)
            {
                if (AllCreatedObjects[i].CompareTag("Tester"))
                {
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < AllCreatedObjects.Count; i++)
            {
                if (AllCreatedObjects[i].tag == "Tester")
                {
                    return;
                }
            }
        }


        sw.Stop();
        UnityEngine.Debug.Log(sw.ElapsedMilliseconds + " ms");
    }
}
