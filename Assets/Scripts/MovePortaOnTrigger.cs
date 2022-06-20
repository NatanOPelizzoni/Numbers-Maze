using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePortaOnTrigger : MonoBehaviour{
    public Transform AffectedObject;
    public bool ReturnDoorOnRelease;
    public Vector2 EndPosition;
    public float Speed;

    private Vector2 StartPosition;
    private bool PressurePlatePressed;

    // Start is called before the first frame update
    void Start(){
        StartPosition = AffectedObject.position;
    }

    // Update is called once per frame
    void Update(){
    }

    private void FixedUpdate(){
        if(GetComponent<Collider2D>().IsTouchingLayers(layerMask: 1)){
            SetPressurePlateState(true);
        }else{
            SetPressurePlateState(false);
        }

        if(PressurePlatePressed){
            AffectedObject.position = Vector2.MoveTowards(current: AffectedObject.position, target: EndPosition, maxDistanceDelta: Speed * Time.fixedDeltaTime);
        }else{
            if(ReturnDoorOnRelease){
                AffectedObject.position = Vector2.MoveTowards(current: AffectedObject.position, target: StartPosition, maxDistanceDelta: Speed * Time.fixedDeltaTime);
            }
        }

    }

    private void SetPressurePlateState(bool newState){
        if(PressurePlatePressed != newState){
            PressurePlatePressed = newState;

            if(PressurePlatePressed){
                transform.Find("Superficie").localPosition = new Vector3(x:0, y:0, z:0);//pressionada
            }else{
                transform.Find("Superficie").localPosition = new Vector3(x:0, y:0.5f, z:0);//nao pressionada
            }
        }
    }
}