using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    
    public static bool esSuelo;

    private void OnTriggerEnter2D(Collider2D col)
    {
        esSuelo = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        esSuelo = false;
    }
}
