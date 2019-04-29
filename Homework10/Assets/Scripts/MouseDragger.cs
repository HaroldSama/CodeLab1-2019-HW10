using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragger : MonoBehaviour
{

    public Vector3 mousePos;
    public Vector3 reference;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                
        print(mousePos);
    }

    private void OnMouseDown()
    {
        reference = mousePos - transform.position;
        //print("ref" + reference);
    }

    private void OnMouseDrag()
    {
        transform.Rotate(0, 0, Vector3.SignedAngle(reference, mousePos - transform.position, Vector3.forward));
        reference = mousePos - transform.position;
        //print(Vector3.Angle(reference, mousePos - transform.position));
        
    }
}
