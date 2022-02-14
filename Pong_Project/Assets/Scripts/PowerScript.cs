using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public GameObject ball;
    public GameObject paddleL;
    public GameObject paddleR;
    public float powerupTime = 20.0f;
    public bool active = false;
    private float activeTime;
    MeshRenderer rend;
    CapsuleCollider coll;
    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<MeshRenderer>();
        coll = this.GetComponent<CapsuleCollider>();
        active = true;
        activeTime = powerupTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            activeTime -= Time.deltaTime;
            if(activeTime <= 0){
                paddleL.GetComponent<PaddleMovement>().paddleSpeed = 7.0f;
                paddleR.GetComponent<PaddleMovement>().paddleSpeed = 7.0f;
                active = false;
                rend.enabled = true;
                coll.enabled = true;
                activeTime = powerupTime;
            }
        }
    }

    void OnTriggerEnter(Collider collider){
        Debug.Log("Powerup hit!");
        // speed up paddle
        if(ball.GetComponent<BallScript>().speed > 0){
            paddleL.GetComponent<PaddleMovement>().paddleSpeed = 10.0f;
        }
        else{
            paddleR.GetComponent<PaddleMovement>().paddleSpeed = 10.0f;
        }
        active = true;
        rend.enabled = false;
        coll.enabled = false;
    }
}
