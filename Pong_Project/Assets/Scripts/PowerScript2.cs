using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript2 : MonoBehaviour
{
    public GameObject ball;
    public BallScript ballScript;
    public float powerupTime = 30.0f;
    public bool active = false;
    private float activeTime;
    MeshRenderer rend;
    CapsuleCollider coll;
    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<MeshRenderer>();
        coll = this.GetComponent<CapsuleCollider>();
        ballScript = ball.GetComponent<BallScript>();
        active = true;
        activeTime = powerupTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            activeTime -= Time.deltaTime;
            if(activeTime <= 0){
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
        ballScript.speed = ballScript.speed / 2;
        active = true;
        rend.enabled = false;
        coll.enabled = false;
    }
}
