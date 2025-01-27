using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStarted : MonoBehaviour
{
    public float BlackWallFallRate = 2f;
    public float FadeWallRate = 1.0f;  
    public GameObject FadeWall;
    public GameObject Blackwall;
    private bool startIt = false;
    private void Awake()
    {
        StartCoroutine(startDelay());
    }
    private void FixedUpdate()
    {
        if(startIt)
        {
            TranisitonBlackWall();
            ColorTransition();
        }
        
    }
    IEnumerator startDelay() 
    {
        yield return new WaitForSeconds(3);
        startIt = true;
    }
    void TranisitonBlackWall()
    {
        Blackwall.transform.position = new Vector3(Blackwall.transform.position.x, Blackwall.transform.position.y - (Time.deltaTime * BlackWallFallRate), Blackwall.transform.position.z);
    }
    void ColorTransition()
    {
        Color BaseFadeWall = FadeWall.GetComponent<MeshRenderer>().material.color;
        FadeWall.GetComponent<MeshRenderer>().material.color = new Color(BaseFadeWall.r, BaseFadeWall.g, BaseFadeWall.b,BaseFadeWall.a - (Time.deltaTime * FadeWallRate));
    }
}

