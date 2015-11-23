using UnityEngine;
using System.Collections;

public class AsteroidFactory : MonoBehaviour {

    public const uint SMALL     = 0;
    public const uint MEDIUM    = 1;
    public const uint BIG       = 2;

    [SerializeField] private GameObject[] _smallAsteroids;
    [SerializeField] private GameObject[] _mediumAsteroids;
    [SerializeField] private GameObject[] _bigAsteroids;

    public void CreateAsteroid(GameObject asteroid, Vector3 pos, Quaternion rot) {
        Instantiate(asteroid, pos, rot);
    }

    public GameObject AsteroidType(uint type) {
        switch (type) {
            case SMALL:
                    Debug.Log("Spawn SMALL Asteroid");
                return _smallAsteroids[Random.Range(0, _smallAsteroids.Length)];
            case MEDIUM:
                    Debug.Log("Spawn MEDIUM Asteroid");
                return _mediumAsteroids[Random.Range(0, _mediumAsteroids.Length)];
            case BIG:
                    Debug.Log("Spawn BIG Asteroid");
                return _bigAsteroids[Random.Range(0, _bigAsteroids.Length)];
            default:
                throw new System.ArgumentException("No Asteroid type given");
        }
    }



}
