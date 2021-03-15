using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectible : MonoBehaviour
{
    public void Select()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void Deselect()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
