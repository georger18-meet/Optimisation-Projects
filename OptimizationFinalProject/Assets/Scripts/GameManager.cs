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

    public List<GameObject> Children;


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
        Stopwatch sw = new Stopwatch();
        sw.Start();


        int counter = 0;
        while (counter < Amount)
        {
            GameObject go = Instantiate(ObjectRef, Parent);
            Children.Add(go);
            counter++;
        }


        sw.Stop();
        TimeTaken = sw.ElapsedMilliseconds;
        UnityEngine.Debug.Log(ObjectRef.name + ": " + TimeTaken + " ms");
    }
}