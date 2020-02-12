using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public GameObject calda;
    public int velocidade;
    public Text texto;
    private List<Rigidbody> nos;
    public static string direction;
    public static bool criarNovoNo;
    public int pontos;
    private Rigidbody cabecaPrincipal;
    private Rigidbody corpoPrincipal;
    private Transform tr;
    private int contador;
    private Vector3 posicaoDaCabeca;
    // Start is called before the first frame update
    void Awake()
    {
       tr = transform;
       corpoPrincipal = GetComponent<Rigidbody>();

       iniciarNos(); 
       iniciarJogador();
       posicaoDaCabeca = nos[0].position;
       texto = GameObject.Find("Filhos").GetComponent<Text>();
    }

    void iniciarNos() 
    {
        nos = new List<Rigidbody>();

        nos.Add(tr.GetChild(0).GetComponent<Rigidbody>());
        nos.Add(tr.GetChild(1).GetComponent<Rigidbody>());
        nos.Add(tr.GetChild(2).GetComponent<Rigidbody>());

        cabecaPrincipal = nos[0];
    }

    void Update() {
        contador ++;
        
        if (contador == velocidade) {
            mover();
        }

        if (criarNovoNo) {
            adicionarNo();
        }
    }

    void iniciarJogador () {
        switch (direction) {
            case "RIGHT":
                nos[1].position = nos[0].position - new Vector3(0.2f, 0f, 0f);
                nos[2].position = nos[0].position - new Vector3(0.2f * 2f, 0f, 0f);
                break;
            case "LEFT":
                nos[1].position = nos[0].position + new Vector3(0.2f, 0f, 0f);
                nos[2].position = nos[0].position + new Vector3(0.2f * 2f, 0f, 0f);
                break;
            case "UP":
                nos[1].position = nos[0].position + new Vector3(0.2f, 0f, 0f);
                nos[2].position = nos[0].position + new Vector3(0.2f * 2f, 0f, 0f);
                break;
            case "DOWN":
                nos[1].position = nos[0].position - new Vector3(0.2f, 0f, 0f);
                nos[2].position = nos[0].position - new Vector3(0.2f * 2f, 0f, 0f);
                break;
        }
    }

    void mover () {
        if (posicaoDaCabeca != nos[0].position) {
            Vector3 posicaoAnterior = nos[1].position;
            Vector3 auxiliar;
            nos[1].position = posicaoDaCabeca;

            for (int i = 2; i < nos.Count; i++) {
                auxiliar = nos[i].position;
                nos[i].position = posicaoAnterior;
                posicaoAnterior = auxiliar;
            }

        }

        contador = 0;

        posicaoDaCabeca = nos[0].position;
    }

    void adicionarNo() {
        criarNovoNo = false;

        pontos ++;

        texto.text = "Recued sons: " + pontos;

        GameObject novo = Instantiate(calda, nos[nos.Count - 1].position + new Vector3(0.2f * 2, 0f, 0f), Quaternion.identity);

        novo.transform.SetParent(transform, true);
        novo.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

        nos.Add(novo.GetComponent<Rigidbody>());
    }

}
