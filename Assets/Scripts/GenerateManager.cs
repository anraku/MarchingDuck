using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject trapPrefab;
    public Transform playerTransform;
    public float generateInterval;
    public int generateSpeed;
    public int itemProbability;
    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // generate
    void Generate()
    {
        Vector3 position = new Vector3(0, itemPrefab.transform.position.y, playerTransform.position.z + generateInterval);
        // generate item
        if (GiveProbability(itemProbability))
        {
            Vector3 itemPosition = new Vector3(0, itemPrefab.transform.position.y, playerTransform.position.z + generateInterval);
            Instantiate(itemPrefab, itemPosition, Quaternion.identity);
        }
        else
        {
            Vector3 trapPosition = new Vector3(0, trapPrefab.transform.position.y, playerTransform.position.z + generateInterval);
            Instantiate(trapPrefab, trapPosition, trapPrefab.transform.rotation );
        }
        Invoke("Generate", generateSpeed);
    }

    bool GiveProbability(float probability)
    {
        float random = Random.Range(1.0f, 100.0f);
        return random <= probability;
    }
}
