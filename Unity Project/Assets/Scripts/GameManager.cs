using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] public Transform vampTarget;
    [SerializeField] public GameObject firstArea;

    [SerializeField] private TMP_Text waveDisplay;
    [SerializeField] private TMP_Text waveStaticText;
    [SerializeField] private TMP_Text enemyCountText;

    [SerializeField] private EnemySpawner[] spawners;

    public float baseSpawnRate = 3f;
    public float spawnRate;
    public int vampsEntered;
    public int maxVamps = 3;
    public float vampResetFreq = 30f;
    public float vampResetTime;

    public int wave = 1;
    // public float vampSpeed = 1.5f;
    // public float vampHealth = 100f;
    public float waveMult = 1f;
    public int baseEnemyPer = 5;
    public int enemyPerSpawner = 5;
    public int enemyCount;
    private int spawnerCount;

    public float powerUpChance = 0.1f;

    void Awake() {
        if (gameManager != null)
        {
            Destroy(gameManager);
        }
        else
        {
            gameManager = this;
        }
    }

    void Start() {
        spawnerCount = 3;
        StartCoroutine(DisplayWaveText());
        SpawnEnemies();

    }

    void Update()
    {
        if (vampsEntered >= 1) {
            vampResetTime += Time.deltaTime;

            if (vampResetTime >= vampResetFreq) {
                vampsEntered--;
                vampResetTime = 0;
            }
        }

        if (enemyCount <= 0) {
            NewWave();
        }
    }

    public void VampEnter() {
        vampsEntered++;
        vampResetTime = 0f;
        if (vampsEntered == maxVamps) {
            Lose();
        }
        VampDeath();
    }

    void Lose() {
        SceneManager.LoadScene(2);
        HighScore.instance.lastScore = wave;
        if (wave > HighScore.instance.highScore) {
            HighScore.instance.highScore = wave;
        }
    }

    public void Menu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    void NewWave() {
        wave++;
        waveMult += 0.05f;
        spawnRate = baseSpawnRate / waveMult;
        waveStaticText.text = "" + wave;
        StartCoroutine(DisplayWaveText());

        SpawnEnemies();

        powerUpChance = 1f / enemyCount;
    }

    void SpawnEnemies() {
        enemyPerSpawner = (int)((wave / spawnerCount) + baseSpawnRate);
        enemyCount = spawnerCount * enemyPerSpawner;
        enemyCountText.text = "" + enemyCount;
        foreach (EnemySpawner spawner in spawners) {
            StartCoroutine(spawner.Spawner(enemyPerSpawner));
        }
    }

    IEnumerator DisplayWaveText() {
        string waveText = "Wave " + wave;
        waveDisplay.text = waveText;
        waveDisplay.enabled = true;

        yield return new WaitForSeconds(3f);

        waveDisplay.enabled = false;
    }

    public void VampDeath() {
        enemyCount--;
        enemyCountText.text = "" + enemyCount;
    }
}
