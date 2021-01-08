using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float cooldown;
    public List<GameObject> Spawners;

    void Start()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            Spawners.Add(this.transform.GetChild(i).gameObject);
        }

        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(cooldown);
        int random = Random.Range(0, Spawners.Count);
        var tmp = Instantiate(enemyPrefab);
        tmp.transform.position = Spawners[random].transform.position;
        tmp.transform.rotation = new Quaternion(0, 180, 0, 0);
        tmp = null;
        Spawners[random].GetComponentInChildren<Animator>().SetTrigger("Spawn");
        StartCoroutine(Spawn());
    }
}
