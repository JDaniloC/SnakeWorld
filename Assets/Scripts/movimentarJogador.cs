using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentarJogador : MonoBehaviour {
    public float velocidadeDeMovimento;
    private Vector3 direcao;

    void Update()
    {
        // Pega a direção a cada update
        direcao = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        // Se movimenta
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(direcao) * velocidadeDeMovimento * Time.deltaTime);
    }
}
