using FSMMono;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidFire : MonoBehaviour
{

    private FlockAgent agent;
    private AIAgent AIAgent;

    private bool isAidFiring = false;
    public bool AidFiring { get {  return isAidFiring; } set { isAidFiring = value; } }

    void Start()
    {
        agent = GetComponent<FlockAgent>();
        AIAgent = GetComponent<AIAgent>();
    }

    
    void Update()
    {
        
    }
}
