using UnityEngine;
using UnityEngine.UI;

public class AI_NPC : MonoBehaviour {

    public GameObject Animal; // животное на сцене
    private Animator animalGo; // анимация движения NPC
    private Animator animalStop; // анимация остановы NPC
    public float speed; // скорость передвижения
    public Transform target_1; // определенная точка

    public Transform target_2;

    public float timeWait; // при достижениии определенной точки, животное останавливается и проигрывается определенная анимация 
	

	void Update ()
    {
       // animalGo.GetComponent<Animator>().enabled = true; // проигрывается анимация движения

        // животное движется
        Animal.transform.position = Vector2.MoveTowards(
            Animal.transform.position, 
            target_1.position, 
            Time.deltaTime * speed);
        //*****************************************
        //*****************************************

        if(Vector2.Distance(Animal.transform.position,target_1.position) < 0.15f)
        {
            Destroy(target_1);
            //animalStop.GetComponent<Animator>().enabled = true; //проигрывается побочная анимация
        }

        Instantiate(target_2, new Vector3(323.0f,-121.0f),Quaternion.identity);
	}
}
