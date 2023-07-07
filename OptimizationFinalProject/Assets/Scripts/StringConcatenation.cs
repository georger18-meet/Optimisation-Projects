using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Text;

public class StringConcatenation : MonoBehaviour
{
    public int AmountOfStrings;
    public bool UseStringBuilder;
    public List<string> StringList = new List<string>();
    public List<string> ConcatenatedList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < AmountOfStrings; i++)
        {
            string str = Random.Range(0, AmountOfStrings).ToString();

            StringList.Add(str);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConcatenateStrings();
        }
    }


    private void ConcatenateStrings()
    {
        ConcatenatedList.Clear();

        Stopwatch sw = new Stopwatch();
        sw.Start();


        if (!UseStringBuilder)
        {
            string tempStr;

            for (int i = 0; i < StringList.Count; i++)
            {
                if (i + 1 < StringList.Count)
                {
                    tempStr = StringList[i] + StringList[i + 1];
                    ConcatenatedList.Add(tempStr);
                    i++;
                }
            }
        }
        else
        {
            for (int i = 0; i < StringList.Count; i++)
            {
                if (i + 1 < StringList.Count)
                {
                    StringBuilder s1 = new StringBuilder(StringList[i]); 
                    StringBuilder s2 = new StringBuilder(StringList[i + 1]);
                    StringBuilder s = s1.Append(s2);
                    ConcatenatedList.Add(s.ToString());
                    i++;
                }
            }
        }

        sw.Stop();
        UnityEngine.Debug.Log(sw.ElapsedMilliseconds + " ms");
    }
}
