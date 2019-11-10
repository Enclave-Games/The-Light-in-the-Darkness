using UnityEngine;
using System.Collections;

//Основной скрипт для интеллектульного мышления NPC

public class Agent : MonoBehaviour
{

    public float maxSpeed;
    public float maxAccel;
    public float orientation;
    public float rotation;
    public Vector2 velocity;
    protected Steering steering;

   public void SetSteering(Steering steering)
    {
        this.steering = steering;
    }


    public virtual void Update()
    {
        Vector2 displacement = velocity * Time.deltaTime;
        orientation += rotation * Time.deltaTime;

        if (orientation < 0.0f)
        {
            orientation += 360.0f;
        }
        else if (orientation > 360.0f)
        {
            orientation -= 360.0f;
        }
        transform.Translate(displacement, Space.World);
        transform.rotation = new Quaternion();
        transform.Rotate(Vector2.up,orientation);
    }
}