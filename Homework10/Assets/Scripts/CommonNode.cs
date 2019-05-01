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

        if (refLine.magnitude > 0.1)
        {
            ChainDetermine();
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

    void ChainDetermine()
    {
        List<float> comparon;
        Dictionary<float, GameObject> nodeDeterminator;

        foreach (var node in nodesInvolved)
        {
            
        }
    }
}
