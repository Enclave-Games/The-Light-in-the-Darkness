﻿using UnityEngine;
using System.Collections;

//Шаблон для модели поведения NPC

public class AgentBehaviour : MonoBehaviour
{
    public GameObject target;
    protected Agent agent;

    public virtual void Awake()
    {
        agent = gameObject.GetComponent<Agent>();
    }

    public virtual void Update()
    {
        agent.SetSteering(GetSteering());
    }

    public virtual Steering GetSteering()
    {
        return new Steering();
    }
}
