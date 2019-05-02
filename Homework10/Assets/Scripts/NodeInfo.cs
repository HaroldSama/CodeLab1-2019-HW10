using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfo : MonoBehaviour
{
    public Vector3 tangent;
    public Vector3 radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        radius = transform.position - transform.parent.position;
        Debug.DrawRay(transform.parent.position, radius, Color.magenta);
        
        tangent = Vector3.Cross(radius, transform.forward);
        Debug.DrawRay(transform.position, tangent, Color.green);
    }
}
