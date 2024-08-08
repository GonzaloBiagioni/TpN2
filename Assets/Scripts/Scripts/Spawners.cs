using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public GameObject[] enemigos; // Array para almacenar los prefabs de los enemigos
    public Transform[] puntosDeSpawn; // Puntos donde se pueden spawnear los enemigos
    public float intervaloDeSpawn = 3f; // Intervalo entre los spawns en segundos

    private void Start()
    {
        if (enemigos.Length == 0 || puntosDeSpawn.Length == 0)
        {
            return;
        }

        // Comienza el coroutine para spawnear enemigos
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Elige un enemigo al azar de la lista
            GameObject enemigo = enemigos[Random.Range(0, enemigos.Length)];
            // Elige un punto de spawn al azar de la lista
            Transform puntoDeSpawn = puntosDeSpawn[Random.Range(0, puntosDeSpawn.Length)];
            // Instancia el enemigo en el punto de spawn
            Instantiate(enemigo, puntoDeSpawn.position, Quaternion.identity);
            // Espera el intervalo especificado antes de spawnear el siguiente enemigo
            yield return new WaitForSeconds(intervaloDeSpawn);
        }
    }
}