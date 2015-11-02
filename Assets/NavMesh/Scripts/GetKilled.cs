using UnityEngine;
using System.Collections;

public class GetKilled : MonoBehaviour {

    [SerializeField]
    private string tagName;

    [SerializeField]
    private GameObject startPoint;

    void OnCollisionEnter(Collision obj) {
        if (obj.gameObject.tag == tagName) {
            transform.position = startPoint.transform.position;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies) {
                enemy.GetComponent<Respawning>().Respawn();
            }
        }
    }
}
