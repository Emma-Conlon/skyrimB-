using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{

    public static float DistanceFromTarget;
    public float toTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit))
        {
            toTarget = hit.distance;
            DistanceFromTarget = toTarget;
        }
    }
}
