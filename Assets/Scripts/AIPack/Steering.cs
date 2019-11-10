using UnityEngine;
using System.Collections;

//Создание пользовательского класса для хранения данных движения и поворота NPC


public class Steering : MonoBehaviour
{

    public Vector2 linear;
    public float rotation;


    public Steering()
    {
        rotation = 0.0f;
        linear = new Vector2();
    }
}
