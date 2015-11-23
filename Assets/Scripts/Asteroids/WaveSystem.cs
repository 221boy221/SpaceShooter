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
    private float _waveTimer = 5.0f; // Tweak this
    private float _waveDelay = 45.0f;
    private bool _spawnWave = false;
    private int _maxAsteroids = 5;
    private int _waveCounter = 0;
    private int _asteroidCount;
    private AsteroidFactory _asteroidFactory;
    private uint _difficulty;
    
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
        _waveTimer -= Time.deltaTime;
        _waveTimeText.text = "Next wave in: " + Mathf.RoundToInt(_waveTimer);

        if (_waveTimer <= 0) {
            // Wave Start (enable the enemies to spawn)
            _spawnWave = true;
            // Reset values
            _waveTimer = _waveDelay;
            // Todo: Play startwave sound
            _waveCounter++;
            // Set the wave text to the corresponding wave
            _waveCountText.text = "Wave: " + _waveCounter;
            
            // Every 10th wave
            if (_waveCounter % 5 == 0) {
                Debug.Log("5th");
                _difficulty++;
            }
            // Decrease asteroid SpawnDelay
            if (_spawnDelay >= 0.2f) {
                _spawnDelay -= 0.1f;
            }
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

        _asteroidFactory.CreateAsteroid(_asteroidFactory.AsteroidType((uint)Random.Range(1, _difficulty)), spawnPos, spawnRot);
    }

    // For possible ingame buttons to skip timer
    public void NextWave() {
        _waveTimer = 0.0f;
    }
}