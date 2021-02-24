using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ThirdCam;
    public GameObject FirstCam;
    public GameObject DanceCam;
    public int CamMode;
    private int temp;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CamChange());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if(CamMode == 1)
            {
                CamMode = 0;
                temp = 0;
            }
            else
            {
                CamMode = 1;
                temp = 1;
            }

            StartCoroutine(CamChange());
        }
        else if(Input.GetButtonDown("Extra"))
        {
            CamMode = 2;

            StartCoroutine(CamChange());
        }
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);

        if(CamMode == 0)
        {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
            DanceCam.SetActive(false);
        }

        if(CamMode == 1)
        {
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
            DanceCam.SetActive(false);
        }

        if (CamMode == 2)
        {
            FirstCam.SetActive(false);
            ThirdCam.SetActive(false);
            DanceCam.SetActive(true);
            yield return new WaitForSeconds(15.267f);

            CamMode = temp;

            if (CamMode == 0)
            {
                ThirdCam.SetActive(true);
                FirstCam.SetActive(false);
                DanceCam.SetActive(false);
            }

            if (CamMode == 1)
            {
                FirstCam.SetActive(true);
                ThirdCam.SetActive(false);
                DanceCam.SetActive(false);
            }
        }
    }
}
