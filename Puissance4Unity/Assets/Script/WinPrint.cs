using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinPrint : MonoBehaviour
{
    // Start is called before the first frame update
    public void PrintWin(string player)
    {
        GetComponent<TextMeshPro>().text = player + " A GAGNER";
    }
}
