using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Boy Voesten

public class WaveSystem : MonoBehaviour {

    [SerializeField] private Text _waveCountText;
    [SerializeField] private Text _waveTimeText;
    //[SerializeField] private GameObject[] _asteroids = new GameObject[0];
    private Vector3 _randomLocation;
    private int _spawnRadius = 5;
    private float _spawnTimer = 0.0f;
    private float _spawnDelay = 2.0f;
    private float _waveWait = 5.0f;
    private bool _spawnWave = false;
    private int _maxAsteroids = 3;
    private int _waveCounter = 0;
    private int _asteroidCount;
    private AsteroidFactory _asteroidFactory;
    
    void Awake() {
        _randomLocation = Random.insideUnitSphere * _spawnRadius;
        _asteroidFactory = GetComponentInChildren<AsteroidFactory>();
    }

    void Update() {
        Waves();
        Count();
    }

    // Wave system
    void Waves() {
        _waveWait -= Time.deltaTime;
        _waveTimeText.text = "Next wave in: " + Mathf.RoundToInt(_waveWait);

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
            _waveCountText.text = "Wave: " + _waveCounter;
        }
    }

    void Count() {
        if (_spawnWave) {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= _spawnDelay) {
                _spawnTimer = 0.0f;
                SpawnAsteroid();
                _asteroidCount++;
            }
        }
        if (_asteroidCount >= (_maxAsteroids * _waveCounter) / 2) {
            _spawnWave = false;
            _asteroidCount = 0;
        }
    }

    void SpawnAsteroid() {
        Vector3 spawnPos = new Vector3(_randomLocation.x, _randomLocation.y, _randomLocation.z);
        Quaternion spawnRot = Quaternion.identity;
        GameObject tempObj;

        // Do fancy stuff on certain waves
        if (_waveCounter > 10) {
            // Spawn Normal ones only
            //tempObj = (GameObject)Instantiate(_asteroids[]);
            //Instantiate(_asteroidFactory(_asteroidFactory.SMALL));
            _asteroidFactory.CreateAsteroid(_asteroidFactory.AsteroidType(2), spawnPos, spawnRot);
        } else {
            //tempObj = (GameObject)Instantiate(_asteroids[Random.Range(0, _asteroids.Length - 1)], spawnPos, spawnRot);
            //Debug.Log("Spawn " + tempObj.name);

            _asteroidFactory.CreateAsteroid(_asteroidFactory.AsteroidType(1), spawnPos, spawnRot);

        }
    }

    // For the ingame button to skip timer
    public void NextWave() {
        _waveWait = 0.0f;
    }
}