using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour{

    public float Speed;
    public float Angle;

    private Transform _transform;

    // Start is called before the first frame update
    void Start(){
        _transform = transform;
    }

    // Update is called once per frame
    void Update(){
    }

    private void FixedUpdate(){
        Vector3 velocity = new Vector2(x: Mathf.Cos(Angle), y: Mathf.Sin(Angle)) * Speed;
        _transform.position = _transform.position + (velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other){
        
    }
}
