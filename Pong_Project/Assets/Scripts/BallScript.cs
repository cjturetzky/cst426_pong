using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public int speed = 1;
    public int maxspeed = 20;
    public float dampenAngle = 0.2f;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Paddle"){
            speed *= -1;
            direction.y = (collision.gameObject.transform.position.y - collision.contacts[0].point.y) * dampenAngle;

            if(Mathf.Abs(speed) < maxspeed){
                if(speed < 0){
                    speed -= 1;
                }
                else{
                    speed += 1;
                }
            }
            if(speed > 0){
                direction.y *= -1;
            }
            
            Debug.Log("Point: " + collision.contacts[0].point.y);
            Debug.Log("Paddle: " + collision.gameObject.transform.position.y);
        }
        else if(collision.gameObject.tag == "Wall"){
            direction.y *= -1;
        }
    }
}
