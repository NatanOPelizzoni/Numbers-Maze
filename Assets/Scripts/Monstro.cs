using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstro : MonoBehaviour{

    public int VidaMax;
    public Sprite[] Sprites;

    private int Vida;

    // Start is called before the first frame update
    void Start(){
        Vida = VidaMax;
    }

    // Update is called once per frame
    void Update(){
    }

    public void Dano(int dano){
        Vida -= dano;
        if(Vida <= 0){
            gameObject.SetActive(value: false);
        }else{
            GetComponent<SpriteRenderer>().sprite = Sprites[Vida - 1];
        }
    }
}
