using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trofeu : MonoBehaviour{
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Professor")){
            if(Professor.ProfessorObjeto.CenaAtual.name == "Level 1"){
                Professor.ProfessorObjeto.Parabens();
            }else{
                Professor.ProfessorObjeto.Vitoria();
            }
            gameObject.SetActive(value: false);
        }
    }
}
