using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePortaOnTrigger : MonoBehaviour{
    public Transform ObjetoAfetado;
    public bool RetornoPorta;
    public Vector2 PosicaoFinal;
    public float Velocidade; 
    public int PesoNecessarioPlaca; 

    private Vector2 PosicaoInicial;
    private bool PlacaDePressaoPrecionada;

    // Start is called before the first frame update
    void Start(){
        PosicaoInicial = ObjetoAfetado.position;
    }

    // Update is called once per frame
    void Update(){
    }

    private void FixedUpdate(){   
        if(GetComponent<Collider2D>().IsTouchingLayers(layerMask: 1)){
            SetEstadoPlacaDePressao(true);
        }else{
            SetEstadoPlacaDePressao(false);
        }

        float aux = 0;
        var pesonecessario = false;
        foreach(var item in GameObject.FindGameObjectsWithTag("Itens")){
            if(GetComponent<Collider2D>().IsTouching(item.GetComponent<Collider2D>())){
                if(aux < PesoNecessarioPlaca){
                    aux += item.GetComponent<Rigidbody2D>().mass;
                }
                if(aux == PesoNecessarioPlaca){
                    pesonecessario = true;
                    break;
                }
            }
        }

        if(PlacaDePressaoPrecionada && (pesonecessario || PesoNecessarioPlaca == 0)){
            ObjetoAfetado.position = Vector2.MoveTowards(current: ObjetoAfetado.position, target: PosicaoFinal, maxDistanceDelta: Velocidade * Time.fixedDeltaTime);
        }else{
            if(RetornoPorta){
                ObjetoAfetado.position = Vector2.MoveTowards(current: ObjetoAfetado.position, target: PosicaoInicial, maxDistanceDelta: Velocidade * Time.fixedDeltaTime);
            }
        }

    }

    private void SetEstadoPlacaDePressao(bool NovoEstado){
        if(PlacaDePressaoPrecionada != NovoEstado){
            PlacaDePressaoPrecionada = NovoEstado;

            if(PlacaDePressaoPrecionada){
                transform.Find("Superficie").localPosition = new Vector3(x:0, y:0, z:0);//pressionada                
            }else{
                transform.Find("Superficie").localPosition = new Vector3(x:0, y:0.5f, z:0);//nao pressionada
            }
        }
    }
}