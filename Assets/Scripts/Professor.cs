using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Professor : MonoBehaviour{

    public static Professor ProfessorObjeto;

    private const float PROFESSOR_VELOCIDADE = 40;
    private const float PROJETIL_MAX_INTERVALO = 0.2f;
    private float ProjetilIntervalo;
    private bool Vivo = true;
    private Scene CenaAtual;


    // Start is called before the first frame update
    void Start(){
        ProfessorObjeto = this;
        CenaAtual = SceneManager.GetActiveScene();
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

        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(sceneName: CenaAtual.name);
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    public void Vitoria(){
        transform.Find("VitoriaTexto").gameObject.SetActive(value: true);
        StartCoroutine(ReiniciaLevelComDelay(3f));
    }

    public void Derrota(){
        transform.Find("DerrotaTexto").gameObject.SetActive(value: true);

        {
            Vivo = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().simulated = false;
        }

        StartCoroutine(ReiniciaLevelComDelay(2f));
    }

    IEnumerator ReiniciaLevelComDelay(float delay){
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName: CenaAtual.name);
    }
}
