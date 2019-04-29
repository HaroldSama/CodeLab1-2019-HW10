using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragger : ChainManager
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
        
        hand = nodes[0].transform.position - transform.position;
        Debug.DrawRay(transform.position, hand, Color.blue);
        //print(hand);
                
        //print(mousePos);
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

    private void OnMouseUp()
    {
        Align();
    }

    void Align()
    {
        //Find the closest radius to align by comparing every dot product between the radius and the hand     
        List<float> comparon = new List<float>();
        
        foreach (var radiu in radius)
        {
            comparon.Add(Vector3.Dot(radiu, hand));
            //print("radius" + radiu);
            //print(Vector3.Dot(radiu, hand));
        }

        Vector3 target = radius[comparon.IndexOf(Mathf.Max(comparon.ToArray()))];
        //print("hand" + hand);
        //print("target" + target);

        transform.Rotate(0, 0, Vector3.SignedAngle(hand, target, Vector3.forward));
    }
}
