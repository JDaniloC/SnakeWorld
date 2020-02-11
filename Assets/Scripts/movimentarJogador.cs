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
        if (direcao[0] == -1) {
            PlayerController.direction = "LEFT";
        } else if (direcao[0] == 1) {
            PlayerController.direction = "RIGHT";
        } else if (direcao[2] == -1) {
            PlayerController.direction = "DOWN";
        } else if (direcao[2] == 1) {
            PlayerController.direction = "UP";
        }
    }

    void FixedUpdate()
    {
        // Se movimenta
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(direcao) * velocidadeDeMovimento * Time.deltaTime);
    }
}
