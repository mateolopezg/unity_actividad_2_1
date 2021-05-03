using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Rana_Ninja : MonoBehaviour
{

    public float runSpeed = 2;
    public float jumpSpeed = 3;
    Rigidbody2D rd2D;

    public bool mejorSalto = false;
    public float fallMultiplier = 0.5f;
    public float lowMultiplier = 1f;
    public SpriteRenderer sprRenderer;
    public Animator animacion;

    void Start()
    {
        rd2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rd2D.velocity = new Vector2(runSpeed, rd2D.velocity.y);
            sprRenderer.flipX = false;
            animacion.SetBool("Corre", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rd2D.velocity = new Vector2(-runSpeed, rd2D.velocity.y);
            sprRenderer.flipX = true;
            animacion.SetBool("Corre", true);
        }
        else
        {
            rd2D.velocity = new Vector2(0, rd2D.velocity.y);
            animacion.SetBool("Corre", false);
        }

        //Salto
        if (Input.GetKey("space")  && Salto.esSuelo)
        {
            rd2D.velocity = new Vector2(rd2D.velocity.x, jumpSpeed);
            animacion.SetBool("Corre", false);
        }
        if (Salto.esSuelo==false)
        {
            animacion.SetBool("Salto", true);
            animacion.SetBool("Corre", false);
        }
        if (Salto.esSuelo==true)
        {
            animacion.SetBool("Salto", false);
        }

        /*
        //Salto
        if (Input.GetKey("w")  && Salto.esSuelo)
        {
            rd2D.velocity = new Vector2(rd2D.velocity.x, jumpSpeed);
        }*/

        //SaltoMejorado
        if (mejorSalto)
        {
            if (rd2D.velocity.y < 0)
            {
                rd2D.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if (rd2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rd2D.velocity += Vector2.up * Physics2D.gravity.y * (lowMultiplier) * Time.deltaTime;
            }
            
            /*
            if (rd2D.velocity.y > 0 && Input.GetKey("w"))
            {
                rd2D.velocity += Vector2.up * Physics2D.gravity.y * (lowMultiplier) * Time.deltaTime;
            }*/
        }
    }
}
