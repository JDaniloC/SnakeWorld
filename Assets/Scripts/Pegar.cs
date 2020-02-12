using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pegar : MonoBehaviour
{   
    void OnCollisionEnter (Collision outro) 
    {
        if (outro.gameObject.tag == "Reward")
        {
            PlayerController.criarNovoNo = true;
            Spawn.todos.Remove(outro.transform.position);
            Destroy(outro.gameObject);
        }
    }
}
