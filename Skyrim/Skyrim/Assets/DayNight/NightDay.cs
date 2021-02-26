using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NightDay : MonoBehaviour

{

    public float cyclemins = 15.0f;
    private float cyclecalc = 0.1f / -0.005f * -1;
    public bool pause = false;
    //private float cyclecalc = 0.1f/1.0f*-1;
    // Start is called before the first frame update
    void Start()
    {
        //cyclecalc = 0.1 /cyclemins * -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (pause == false)
        {
            transform.Rotate(0, 0, cyclecalc, Space.World);
        }

    }
}
