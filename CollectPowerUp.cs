using UnityEngine;
using System.Collections;

public class CollectPowerUp : MonoBehaviour {

    public static bool isInvulnerable;
    public static bool fasterShooting;

    GameObject player;
    PlayerHealth playerHealth;

    void Start()
    {
        isInvulnerable = false;
        fasterShooting = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
	void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Coin" && other.tag == "Player")
        {
            Destroy(gameObject);
            ScoreManager.coin += 1;
        }
        if (gameObject.tag == "Health" && other.tag == "Player")
        {
            Destroy(gameObject);
            playerHealth.TakeDamage(-10);
        }
        if (gameObject.tag == "FasterShooting" && other.tag == "Player")
        {
            Destroy(gameObject);
            fasterShooting = true;
            StartCoroutine(RapidFireWait(gameObject));
        }
        if (gameObject.tag == "Invulnerability" && other.tag == "Player")
        {
            Destroy(gameObject);
            isInvulnerable = true;
            StartCoroutine(InvulnWait(gameObject));
        }

    }
    IEnumerator RapidFireWait(GameObject gameObject)
    {
        yield return new WaitForSeconds(20);
        fasterShooting = false;
    }
    IEnumerator InvulnWait(GameObject gameObject)
    {
        yield return new WaitForSeconds(20);
        isInvulnerable = false;
    }
}
