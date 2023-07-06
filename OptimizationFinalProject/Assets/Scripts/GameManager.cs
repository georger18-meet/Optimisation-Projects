using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public int Amount;
    public GameObject ObjectRef;
    public Transform Parent;
    public float TimeTaken;
    public bool UseList;
    public bool UsePooling;
    public bool DestroyAfter;

    public List<GameObject> AllCreatedObjects;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!UseList)
            {
                CreateObjects();
            }
            else
            {
                CreateObjectsToList();
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (AllCreatedObjects.Count != 0)
            {
                ReactivatePooled();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    [ContextMenu("Create Objects")]
    public void CreateObjects()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();


        int counter = 0;
        while (counter < Amount)
        {
            GameObject go = Instantiate(ObjectRef, Parent);
            counter++;
        }


        sw.Stop();
        TimeTaken = sw.ElapsedMilliseconds;
        UnityEngine.Debug.Log(ObjectRef.name + ": " + TimeTaken + " ms");
    }
    
    [ContextMenu("Create Objects To List")]
    public void CreateObjectsToList()
    {
        AllCreatedObjects.Clear();

        Stopwatch sw = new Stopwatch();
        sw.Start();


        int counter = 0;
        while (counter < Amount)
        {
            GameObject go = Instantiate(ObjectRef, Parent);
            AllCreatedObjects.Add(go);
            counter++;
        }

        if (DestroyAfter)
        {
            if (UsePooling)
            {
                foreach (GameObject go in AllCreatedObjects)
                {
                    go.SetActive(false);
                }
            }
            else
            {
                foreach(GameObject go in AllCreatedObjects)
                {
                    Destroy(go);
                }
            }
        }

        sw.Stop();
        TimeTaken = sw.ElapsedMilliseconds;
        UnityEngine.Debug.Log(ObjectRef.name + ": " + TimeTaken + " ms");
    }

    [ContextMenu("Reactivate All Pooled")]
    public void ReactivatePooled()
    {
        if (UsePooling)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            foreach (var item in AllCreatedObjects)
            {
                item.SetActive(true);
            }

            foreach (var item in AllCreatedObjects)
            {
                item.SetActive(false);
            }

            sw.Stop();
            TimeTaken = sw.ElapsedMilliseconds;
            UnityEngine.Debug.Log(ObjectRef.name + ": " + TimeTaken + " ms");
        }
    }
}