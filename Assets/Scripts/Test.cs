using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject cube;
    List<int> intList = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cube);
        intList.Add(9);
        intList.Add(3);
        intList.Add(2);

        intList.RemoveAt(2);
        Debug.Log(intList[1]);
        Debug.Log(intList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
