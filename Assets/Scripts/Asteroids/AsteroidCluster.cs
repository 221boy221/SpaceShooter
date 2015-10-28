using UnityEngine;
using System.Collections;

// Boy Voesten

public class AsteroidCluster : MonoBehaviour {

    [SerializeField] GameObject[] _clusters;

    // Split the object in two smaller, slower objects.
    public void Cluster() {
        foreach (GameObject cluster in _clusters) {
            Instantiate(cluster, transform.position, transform.rotation);
            cluster.transform.localScale *= 0.5f;
        }
    }
}
