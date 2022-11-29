using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Spawner : MonoBehaviour
{
    public int wait1;
    public enum spawnstate { SPWANING, WAITING, COUNTING };

    [System.Serializable]
    public class wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Transform[] spawnPoints;

    public wave[] waves;
    [HideInInspector]
    public int nextwave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown = 0f;

    //public float levelnameCountdown = 3f;

    private float searchCountdown = 1f;

    private spawnstate state = spawnstate.COUNTING;
    private ui_manager ui_Mgr;

    private void Start()
    {
        waveCountdown = wait1;
        ui_Mgr = GameObject.FindGameObjectWithTag("UI_MGR").GetComponent<ui_manager>();
    }

    private void Update()
    {
        if (state == spawnstate.WAITING)
        {
            if (!EmemyisAlive())
            {
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != spawnstate.SPWANING)
            {
                ui_Mgr.Count_down.gameObject.SetActive(false);
                StartCoroutine(SpawnWave(waves[nextwave]));
            }

            if(ui_Mgr.Disclaimer.activeInHierarchy == true)
            {
                ui_Mgr.Disclaimer.SetActive(false);
            }
        }
        else
        {
            ui_Mgr.Count_down.gameObject.SetActive(true);
            waveCountdown -= Time.deltaTime;
            ui_Mgr.CountDown(waveCountdown);
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        state = spawnstate.COUNTING;
        waveCountdown = timeBetweenWaves;
        if (nextwave + 1 > waves.Length - 1)
        {
            Debug.Log("Waves Completed");
            ui_Mgr.upgradeSystem.SetActive(true);
            ui_Mgr.Count_down.gameObject.SetActive(true);
        }
        else
        {
            ui_Mgr.Count_down.gameObject.SetActive(true);
            nextwave++;
        }
    }

    bool EmemyisAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                Debug.LogError("Searching Enemy : Completed");
                //waveCountdown = timeBetweenWaves;
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(wave _wave)
    {
        Debug.Log("Spawning Wave" + _wave.name);
        state = spawnstate.SPWANING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = spawnstate.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Enemy" + _enemy.name);
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No Spawn Points Added");
        }

        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, sp.position, sp.rotation);
    }
}