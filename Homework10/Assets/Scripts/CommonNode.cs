using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonNode : MonoBehaviour
{
    public List<GameObject> chainsInvolved;
    public List<GameObject> nodesInvolved;
    public Vector3 refLineRoot;
    public Vector3 refLineTip;
    public Vector3 refLine;
    public Vector3 mousePos;

    public bool chainDetermined;
    public MouseDragger chainControlled;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Node"))
        {
            nodesInvolved.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Node"))
        {
            nodesInvolved.Remove(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (refLine.magnitude > 0.1 && !chainDetermined)
        {
            chainDetermined = true;
            chainControlled = ChainDetermine();
            chainControlled.OnMouseDown();
        }

        if (chainDetermined)
        {
            chainControlled.OnMouseDrag();
        }
    }

    void OnMouseDown()
    {
        
        refLineRoot = mousePos;
        //print(refLineRoot);
    }

    private void OnMouseDrag()
    {
        refLineTip = mousePos;
        refLine = refLineTip - refLineRoot;
        Debug.DrawRay(refLineRoot, refLine, Color.cyan);
    }

    private void OnMouseUp()
    {
        refLine = Vector3.zero;
        chainDetermined = false;
        chainControlled.OnMouseUp();
    }

    MouseDragger ChainDetermine()
    {
        List<float> comparon = new List<float>();
        List<GameObject> nodesCompared = new List<GameObject>();

        foreach (var node in nodesInvolved)
        {
            Vector3 tangent = node.GetComponent<NodeInfo>().tangent;
            float dotProPos = Vector3.Dot(refLine.normalized, tangent.normalized);
            float dotProNeg = Vector3.Dot(refLine.normalized, -tangent.normalized);
            comparon.Add(Mathf.Max(dotProPos, dotProNeg));
            nodesCompared.Add(node);
        }
        
        print(comparon[0] + " " + comparon[1]);
        print(nodesCompared[0].name + " " +nodesCompared[1].name);

        return nodesCompared[comparon.IndexOf(Mathf.Max(comparon.ToArray()))].transform.parent.gameObject.GetComponent<MouseDragger>();
    }
}
