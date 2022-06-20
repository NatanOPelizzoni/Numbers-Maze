using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Monstro : MonoBehaviour{

    public int VidaMax;
    public Sprite[] Sprites;

    private int Vida;
    private const float Velocidade = 30;

    // Start is called before the first frame update
    void Start(){
        Vida = VidaMax;
    }

    // Update is called once per frame
    void Update(){
    }

    private void FixedUpdate(){
        float Distancia = Vector2.Distance(a: Professor.ProfessorObjeto.transform.position, b:transform.position);

        if(Distancia <= 80){
            float Angulo = Random.Range(-1.5f, 1.5f) + Mathf.Atan2(y: Professor.ProfessorObjeto.transform.position.y - transform.position.y, x: Professor.ProfessorObjeto.transform.position.x - transform.position.x);
            GetComponent<Rigidbody2D>().velocity = new Vector2(x: Mathf.Cos(Angulo), y: Mathf.Sin(Angulo)) * Velocidade;
        }else{
            float Angulo = Random.Range(0, Mathf.PI * 2f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(x: Mathf.Cos(Angulo), y: Mathf.Sin(Angulo)) * Velocidade;
        }
    }

    public void Dano(int dano){
        Vida -= dano;
        if(Vida <= 0){
            gameObject.SetActive(value: false);
        }else{
            GetComponent<SpriteRenderer>().sprite = Sprites[Vida - 1];
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Professor")){
            Professor.ProfessorObjeto.Derrota();
        }
    }
}
