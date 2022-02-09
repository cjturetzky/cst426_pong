using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float paddleSpeed = 5.0f;
    public bool useArrow = true;
    public AudioSource audio;
    public GameObject ball;

    void Start(){
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(useArrow){
            if(Input.GetKey("up")){
                transform.position += Vector3.up * paddleSpeed * Time.deltaTime;
            }
            if(Input.GetKey("down")){
                transform.position += Vector3.down * paddleSpeed * Time.deltaTime;
            }
        }
        else{
            if(Input.GetKey("w")){
                transform.position += Vector3.up * paddleSpeed * Time.deltaTime;
            }
            if(Input.GetKey("s")){
                transform.position += Vector3.down * paddleSpeed * Time.deltaTime;
            }
        }
        
    }

    void OnCollisionEnter(Collision collision){
        audio.pitch = ball.GetComponent<BallScript>().speed/4.0f;
        if(audio.pitch < 0){ audio.pitch *= -1; }
        Debug.Log($"pitch: {audio.pitch}");
        audio.Play();
    }
}
