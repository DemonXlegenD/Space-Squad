using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    private Material MaterialInst;

    private void Awake()
    {
        Renderer rend = GetComponent<Renderer>();
        MaterialInst = rend.material;
    }
    public void SetCloseTarget()
    {
        MaterialInst.color = Color.green;
    }

    public void SetFarTarget()
    {
        MaterialInst.color = Color.red;
    } 
}
