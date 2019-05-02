using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseDragger : ChainManager
{

    public Vector3 mousePos;
    public Vector3 reference;
    public bool aligning;
    public Vector3 target;
    
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

        if (aligning)
        {
            if (Vector3.Angle(hand, target) > 0.1)
            {
                //Vector3 newDir = Vector3.RotateTowards(hand, target, Time.deltaTime, 0);
                //Debug.DrawRay(transform.position, newDir, Color.yellow);
                transform.Rotate(0, 0, Vector3.SignedAngle(hand, target, Vector3.forward) / 10);        
            }
            else
            {
                transform.Rotate(0, 0, Vector3.SignedAngle(hand, target, Vector3.forward));
                aligning = false;
            }
        
            
        }
    }

    public void OnMouseDown()
    {
        reference = mousePos - transform.position;
        //print("ref" + reference);
    }

    public void OnMouseDrag()
    {
        transform.Rotate(0, 0, Vector3.SignedAngle(reference, mousePos - transform.position, Vector3.forward));
        reference = mousePos - transform.position;
        //print(Vector3.Angle(reference, mousePos - transform.position));
        
    }

    public void OnMouseUp()
    {
        Align();
        aligning = true;
    }

    void DragRotate()
    {
        
    }

    void Align()
    {
        //Find the closest radius to align by comparing every dot product between the radius and the hand     
        List<float> comparon = new List<float>();
        
        foreach (var radiu in frame)
        {
            comparon.Add(Vector3.Dot(radiu.normalized, hand.normalized));
            //print("radius" + radiu);
            //print(Vector3.Dot(radiu, hand));
        }

        target = frame[comparon.IndexOf(Mathf.Max(comparon.ToArray()))];
        //print("hand" + hand);
        //print("target" + target);

        //print(Vector3.Dot(hand.normalized, target.normalized));
        
        

    }
}
