using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//USAGE: put under a chain Loop to get data from it
//[ExecuteInEditMode]
public class ChainManager : MonoBehaviour
{
    public List<GameObject> nodes = new List<GameObject>();
    public List<Vector3> radius = new List<Vector3>();
    public List<Vector3> tangents = new List<Vector3>();
    public Vector3 hand;
    
    void Awake()
    {
        foreach (Transform child in transform)
        {
            //Get the nodes
            nodes.Add(child.gameObject);
            
            //Get the vectors that point from the center to the nodes
            Vector3 radiu = child.position - transform.position;
            radius.Add(radiu);
            Debug.DrawRay(transform.position, radiu, Color.red, float.MaxValue);
            
            //Get the vectors that tangent with this chain loop
            Vector3 tangent = Vector3.Cross(radiu, transform.forward);
            tangents.Add(tangent);
            Debug.DrawRay(child.position, tangent, Color.green, float.MaxValue);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
