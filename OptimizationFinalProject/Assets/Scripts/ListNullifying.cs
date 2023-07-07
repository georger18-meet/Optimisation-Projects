using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ListNullifying : MonoBehaviour
{
    public int Amount;
    public GameObject ObjectRef;
    public Transform Parent;
    public bool UseRefEquals;

    public List<GameObject> AllCreatedObjects;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateObjectsToList();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            NullList();
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

    private void NullList()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        if (UseRefEquals)
        {
            for (int i = 0; i < AllCreatedObjects.Count; i++)
            {
                if (!System.Object.ReferenceEquals(AllCreatedObjects[i], null))
                {
                    AllCreatedObjects[i] = null;
                }
            }
        }
        else
        {
            for (int i = 0; i < AllCreatedObjects.Count; i++)
            {
                if (AllCreatedObjects[i] != null)
                {
                    AllCreatedObjects[i] = null;
                }
            }
        }


        sw.Stop();
        UnityEngine.Debug.Log(sw.ElapsedMilliseconds + " ms");
    }
}
