using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misaligner : MonoBehaviour
{
    float tilt;
    float fade;
    float twist;
    float offset;

    public OVRHand leftHand;
    public OVRHand rightHand;

    public GameObject fadeQuad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            twist+=60.0f*Time.deltaTime;
        }
        if(leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            twist-=60.0f*Time.deltaTime;
        }
        if(rightHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky))
        {
            offset+=3.0f*Time.deltaTime;
            print(offset);
        }
        if(leftHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky))
        {
            offset-=3.0f*Time.deltaTime;
            print(offset);
        }


        if(leftHand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
        {
            tilt+=360f*Time.deltaTime;
        }else
        {
            tilt-=240f*Time.deltaTime;
        }
        tilt=Mathf.Clamp(tilt,0,90f);

        if(rightHand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
        {
            fade+=5.0f*Time.deltaTime;
        }else
        {
            fade-=5.0f*Time.deltaTime;
        }
        fade=Mathf.Clamp(fade,0,1);
        fadeQuad.GetComponent<MeshRenderer>().material.color=new Color(0f,0f,0f,fade);
        Transform t=GetComponent<Transform>();
        t.localEulerAngles=new Vector3(0,twist,tilt);
        t.localPosition=new Vector3(offset,0,0);
    }
}
