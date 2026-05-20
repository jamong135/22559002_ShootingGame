using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float spd = 5.0f;
    Vector3 direct = Vector3.down;

    public GameObject prefabsExplosion;

    private void Update()
    {
        transform.position = transform.position + direct * spd * Time.deltaTime;
    }
         private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion0bi = Instantiate(prefabsExplosion);
        explosion0bi.transform.position = transform.position;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
