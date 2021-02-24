using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootSteps : MonoBehaviour
{
    private CharacterController cc;
    private AudioSource footstep_Sound;
    [HideInInspector]
    public float volume_Min,volume_Max;
    private float accumlated_Distance;
    [HideInInspector]
    public float step_Distance;
    [SerializeField]
    private AudioClip[] footstep_Clip;
    // Start is called before the first frame update
    void Awake()
    {
        footstep_Sound = GetComponent<AudioSource>();
        cc = GetComponentInParent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        checktoPlayFootStepSound();
       
    }
    void checktoPlayFootStepSound()
    {
        if(!cc.isGrounded)
        {
            return;
        }
        if(cc.velocity.sqrMagnitude > 0)
        {
            accumlated_Distance += Time.deltaTime;

        }
        if(accumlated_Distance>step_Distance)
        {
            footstep_Sound.volume = Random.Range(volume_Min, volume_Max);
            footstep_Sound.clip = footstep_Clip[Random.Range(0, footstep_Clip.Length)];
            footstep_Sound.Play();
            accumlated_Distance = 0f;
        }
        else
        {
            accumlated_Distance = 0f;
        }
    }
}
