using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Boy Voesten

public class Spawner : MonoBehaviour {

    
    public Vector3 spawnValues;
    public Text waveCountText;
    public Text waveTimeText;

    private GameObject[] _asteroids = new GameObject[0];
    private float _spawnTimer = 0.0f;
    private float _spawnDelay = 2.0f;
    private float _waveWait = 20.0f;
    private bool _spawnWave = false;
    private int _maxAsteroids = 10;
    private int _waveCounter = 0;
    private int _asteroidCount;

    void Awake() {
        //
    }

    void Update() {
        Waves();
        Count();
    }

    // Wave system
    void Waves() {
        _waveWait -= Time.deltaTime;
        waveTimeText.text = "Next wave in: " + Mathf.RoundToInt(_waveWait);

        if (_waveWait <= 0) {
            // Wave Start (enable the enemies to spawn)
            _spawnWave = true;
            // Reset values
            _waveWait = 90.0f;
            // Todo: Play startwave sound

            // Decrease SpawnDelay
            if (_spawnDelay >= 0.2f) {
                _spawnDelay -= 0.1f;
            }
            // Set the wave text to the corresponding wave
            _waveCounter++;
            waveCountText.text = "Wave: " + _waveCounter;
        }
    }

    void Count() {
        if (_spawnWave) {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= _spawnDelay) {
                _spawnTimer = 0.0f;
                _asteroidCount++;
                SpawnAsteroid();
            }
        }
        if (_asteroidCount >= (_maxAsteroids * _waveCounter) / 2) {
            _spawnWave = false;
            _asteroidCount = 0;
        }
    }

    void SpawnAsteroid() {
        Vector3 spawnPostition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        GameObject tempObj;

        // Do fancy stuff on certain waves
        if (_waveCounter == 10) {
            // 
        } else {
            tempObj = (GameObject)Instantiate(_asteroids[Random.Range(0, _asteroids.Length - 1)], spawnPostition, spawnRotation);
            Debug.Log("Spawn " + tempObj.name);
        }
    }

    // For the ingame button to skip timer
    public void NextWave() {
        _waveWait = 0.0f;
    }
}