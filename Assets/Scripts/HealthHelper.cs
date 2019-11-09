using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HealthHelper : MonoBehaviour
{
    [SerializeField]
    int MaxHealth = 100;
    int Health = 100;

    SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    public bool isDead = false;
    //Есть же GetDamage() - он по умолчанию есть в каждом наследнике MonoBehavior
    public void GetHit(int damage)
    {
        if(!isDead)
        Health -= damage;

        if (Health <= 0)
        {
            //Просто "Временная херня". Сорян
            SRender(false);
            isDead = true;
            Debug.Log("Died!");
            Invoke("SRender", 1f);
            Health = MaxHealth;
        }
    }

    void SRender()
    {
        isDead = false;
        sp.enabled = false;
    }

    //Этот метод бесполезен, просто забей
    void SRender(bool on)
    {
        sp.enabled = false;
    }
}
