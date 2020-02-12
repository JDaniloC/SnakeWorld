using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject reward;
    public float tempoDeSpawn;
    public Transform[] pontosDeSpawn;
    public static List<Vector3> todos = new List<Vector3>();

    void Start()
    {
        InvokeRepeating ("Aparecer", tempoDeSpawn, tempoDeSpawn);
    }

    void Aparecer ()
    {
        print("Aparecendo!");
        int index = Random.Range (0, pontosDeSpawn.Length);

        bool verificador = true;

        foreach (Vector3 pivo in todos) {
            if (pivo == pontosDeSpawn[index].position) {
                verificador = false;
            }
        }

        if (verificador) {
            todos.Add(pontosDeSpawn[index].position);
            Instantiate (reward, pontosDeSpawn[index].position, pontosDeSpawn[index].rotation);
        } else {
            print("Já tem!");
        }
    }
}
