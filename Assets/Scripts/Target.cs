using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform spawnPointHolder;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject appearEffect;
    [SerializeField] private TMP_Text scoreText;
    private List<Transform> allSpawns = new List<Transform>();
    private int score;

    private void GetSpawns()
    {
        foreach (Transform spawnPoint in spawnPointHolder)
        {
            allSpawns.Add(spawnPoint);
        }
    }

    private void Respawn()
    {
        score++;
        scoreText.text = score.ToString();
        Instantiate(hitEffect, transform.position, transform.rotation);
        Transform randomSpawn = allSpawns[Random.Range(0, allSpawns.Count)];
        transform.SetPositionAndRotation(randomSpawn.position, randomSpawn.rotation);
        Instantiate(appearEffect, transform.position, transform.rotation);
    }

    private void Awake()
    {
        GetSpawns();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Respawn();
    }
}
