using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on a thing that looks at stuff(ideally, a camera)
// PURPOSE: this will make the thing look at a thing, forever.
public class CameralookFollow : MonoBehaviour
{
    public Transform lookTarget;
    
    // Update is called once per frame
    void Update()
    {
        // technique 1: sue "LookAt"
        // transform.LookAt(lookTarget);
        if (lookTarget == null)
        {
            return; //skip the rest of this function and stop
        }
        
        //technique 2: use quaternions to make the thing look at the thing
        Vector3 forward = lookTarget.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(forward);

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 30f * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);


    }
}
