using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Amount;
    public GameObject ObjectRef;
    public Transform Parent;
    public float TimeTaken;
    public bool UseArray;
    public bool DoNullifyContainer;
    public bool NullifyUsingRefEquals;
    public GameObject[] Container;

    private float startTime;
    private float endTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!UseArray)
            {
                CreateObjects();
            }
            else
            {
                CreateObjectsToArray();
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
        int counter = 0;
        startTime = Time.realtimeSinceStartup;

        while (counter < Amount)
        {
            Instantiate(ObjectRef,Parent);
            counter++;
        }

        endTime = Time.realtimeSinceStartup;

        TimeTaken = endTime - startTime;

        Debug.Log(ObjectRef.name + ": " + TimeTaken);
    }    
    

    [ContextMenu("Create Objects To Array")]
    public void CreateObjectsToArray()
    {
        GameObject[] tempArr = new GameObject[Amount];
        Container = tempArr;

        int counter = 0;
        startTime = Time.realtimeSinceStartup;

        while (counter < Amount)
        {
            GameObject obj = Instantiate(ObjectRef,Parent);
            Container[counter] = obj;
            counter++;
        }

        if (DoNullifyContainer) NullifyContainer();

        endTime = Time.realtimeSinceStartup;

        TimeTaken = endTime - startTime;

        Debug.Log(ObjectRef.name + ": " + TimeTaken);
    }

    private void NullifyContainer()
    {
        if (!NullifyUsingRefEquals)
        {
            for (int i = 0; i < Container.Length; i++)
            {
                if (Container[i] != null)
                {
                    Container[i] = null;
                }
            }
        }
        else
        {
            for (int i = 0; i < Container.Length; i++)
            {
                if (!System.Object.ReferenceEquals(Container, null))
                {
                    Container[i] = null;
                }
            }
        }
    }    
}
