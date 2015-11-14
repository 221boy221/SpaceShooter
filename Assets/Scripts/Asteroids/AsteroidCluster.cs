using UnityEngine;
using System.Collections;

// Boy Voesten

public class AsteroidCluster : MonoBehaviour {

    [SerializeField] GameObject[] _clusters;

    // Split the object in two smaller, slower objects.
    public void Cluster() {
        

        for (int i = 0; i < _clusters.Length; i++) {
            GameObject cluster = (GameObject)Instantiate(_clusters[i], transform.position, transform.rotation);
            cluster.transform.localScale = this.gameObject.transform.localScale / 2.0f;
        }
    }
}
