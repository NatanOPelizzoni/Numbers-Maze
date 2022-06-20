using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Professor : MonoBehaviour
{
    private const float PROFESSOR_VELOCIDADE = 40;
    private const float PROJETIL_MAX_INTERVALO = 0.2f;
    private float ProjetilIntervalo;
    private bool Vivo = true;


    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        if(Vivo){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                GameObject Projetil = Instantiate(Resources.Load(path: "Projetil")) as GameObject;
                Projetil.transform.position = transform.position;
                Projetil.GetComponent<Projetil>().Velocidade = 100;
                Projetil.GetComponent<Projetil>().Angulo = Mathf.Atan2(y: Input.mousePosition.y - Screen.height / 2f, x: Input.mousePosition.x - Screen.width / 2f);
            }
        }
    }

    private void FixedUpdate(){
        //controles de movimentacao
        if(Vivo){
            float moveX = 0;
            float moveY = 0;
            if(Input.GetKey(KeyCode.D)){
                moveX += 1;
            }
            if(Input.GetKey(KeyCode.A)){
                moveX -= 1;
            }
            if(Input.GetKey(KeyCode.W)){
                moveY += 1;
            }
            if(Input.GetKey(KeyCode.S)){
                moveY -= 1;
            }

            Vector2 NovaVelocidade = new Vector2(moveX, moveY).normalized * PROFESSOR_VELOCIDADE;

            GetComponent<Rigidbody2D>().velocity = NovaVelocidade;
        }
    }
}
