using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiseButton : MonoBehaviour
{

    public GameObject Jeton;

    public void SummunJeton(Color color)
    {
        GameObject jeton = Instantiate(Jeton,this.gameObject.transform);
        jeton.GetComponent<MeshRenderer>().material.color = color;
    }
}
