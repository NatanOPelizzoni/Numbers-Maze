using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour{

    public float Velocidade;
    public float Angulo;

    private Transform _transform;

    // Start is called before the first frame update
    void Start(){
        _transform = transform;
    }

    // Update is called once per frame
    void Update(){
    }

    private void FixedUpdate(){
        Vector3 velocity = new Vector2(x: Mathf.Cos(Angulo), y: Mathf.Sin(Angulo)) * Velocidade;
        _transform.position = _transform.position + (velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Monstros")){
            other.GetComponent<Monstro>().Dano(dano: 1);
            Destroy(gameObject);
        }else if(other.CompareTag("Itens")){
            other.GetComponent<ItemDestrutivel>().Dano(dano: 1);
            Destroy(gameObject);
        }else if(other.CompareTag("Paredes")){
            Destroy(gameObject);
        }
    }
}
