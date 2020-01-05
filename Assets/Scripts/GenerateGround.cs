using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGround : MonoBehaviour
{
    public GameObject GroundPrefab;
    public Transform PlayerTransform;
    public Transform GroundTransform;
    public float UpdateSpeed;
    public List<GameObject> GroundList;
    // Start is called before the first frame update
    void Start()
    {
        UpdateGround();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateGround()
    {
        GameObject nextGround = GenerateNextGround();
        GroundList.Add(nextGround);
        Invoke("DestroyOldestGround", UpdateSpeed);
        Invoke("UpdateGround", UpdateSpeed);
    }

    // create ground
    GameObject GenerateNextGround()
    {
        float playerPositionZ = PlayerTransform.position.z;
        float groundScaleZ = GroundTransform.localScale.z;
        Vector3 nextGroundPosition = new Vector3(0, 0, playerPositionZ + groundScaleZ);
        GameObject nextGround = Instantiate(GroundPrefab, nextGroundPosition, Quaternion.identity);

        return nextGround;
    }

    void DestroyOldestGround()
    {
        GameObject oldestGround = GroundList[0];
        GroundList.RemoveAt(0);
        Destroy(oldestGround);
    }
}
