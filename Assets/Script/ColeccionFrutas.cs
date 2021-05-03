using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColeccionFrutas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            //animacion coleccion frutas
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //Destruye Manzana
            Destroy(gameObject, 0.5f );
        }
    }
}
