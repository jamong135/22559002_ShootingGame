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
        //충돌하는 Collision의 GameObject의 Tag 명이 "Bullet"이라면...
        if(collision.gameObject.tag == "Bullet")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            ScoreManager scoreManager = gameManager.GetComponent<ScoreManager>();
            scoreManager.nowScore++;
            scoreManager.nowScoreUI.text = "Now Score : " + scoreManager.nowScore;

            

            GameObject explosion0bj = Instantiate(prefabsExplosion);
            explosion0bj.transform.position = transform.position;

            Destroy(collision.gameObject);

            Destroy(gameObject);
        }


    }
}
