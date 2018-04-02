using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemyManager : MonoBehaviour {

    private int randomInt = 1;
    private Rigidbody2D rb, rbClone;
    public GameObject player;
    private Vector3 startingPosition;
    public GameObject bullet, bubbleBullet, fireBullet, OneOpenShotAttack,coin;
    public Transform bulletSpawnLocation, oneOpenShotLocation;
    public float bossEnemyHealth = 25;
    public static BossEnemyManager instance;
    public Text newBestTime, newHighScore;


    // Use this for initialization
    void Start() {
        StartCoroutine("SingleShotAttack");
        SoundManager.instance.bossBattleAudio.enabled = true;
        SoundManager.instance.bossBattleAudio.Play();
    }
    private void Awake()
    {
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // does not allow for rotation of the rigidbody to disable falling over
        instance = this;
        
        SoundManager.instance.inGameAudio.enabled = false;

    }

    // Update is called once per frame
    void Update() {
        if(GameManager.instance.currentGameState == GameState.nextLevel)
        {
            Destroy(gameObject);

            if (GameManager.instance.playedTime < LevelManager.instance.levelTenTime || LevelManager.instance.levelTenTime == 0.0f)
            {
                LevelManager.instance.levelTenTime = GameManager.instance.playedTime;
                newBestTime.enabled = true;
            }

            if (GameManager.instance.levelScore > LevelManager.instance.levelTenScore || LevelManager.instance.levelTenScore == 0.0f)
            {
                LevelManager.instance.levelTenScore = GameManager.instance.levelScore;
                newHighScore.enabled = true;
            }

            LevelManager.instance.Save();
        }

        if(bossEnemyHealth == 0)
        {
            GameManager.instance.NextLevel();
            Time.timeScale = 0.0f;
            SoundManager.instance.bossBattleAudio.Stop();
            SoundManager.instance.winAudio.Play();
        }
    }


    IEnumerator RandomAttack()
    {

        if (gameObject.transform.position != startingPosition)
        {
            InvokeRepeating("BackStartingPosition", 1.0f, 0.01f);
        }
        rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(2.5f);
        CancelInvoke();
        RandomAttackChoice();

        // Case based on random integer, and performs random attack
        switch (randomInt)
        {
            case 1:
                StartCoroutine("SingleShotAttack");
                break;
            case 2:
                StartCoroutine("BubbleShotAttack");
                break;
            case 3:
                StartCoroutine("FireShotAttack");
                break;
            case 4:
                StartCoroutine("OneDefenseAttack");
                break;
            case 5:
                StartCoroutine("NoAttack");
                break;
        }
    }

    private void RandomAttackChoice()
    {
        randomInt = Random.Range(1, 6);
    }

    IEnumerator SingleShotAttack() // randomInt == 1
    {
        yield return new WaitForSeconds(2.0f);
        StopCoroutine("RandomAttack");
        rb.velocity = new Vector2(Random.Range(2.0f, 5.0f), Random.Range(2.0f, 5.0f));
        InvokeRepeating("SingleShot", 1.0f, 1.0f);
        InvokeRepeating("CoinCreate", 0.0f, 1.5f);
        yield return new WaitForSeconds(10.0f);
        CancelInvoke();
        StartCoroutine("RandomAttack");
    }
    IEnumerator BubbleShotAttack() // randomInt == 2
    {
        StopCoroutine("RandomAttack");
        rb.velocity = new Vector2(2.0f, 0);
        InvokeRepeating("BubbleShot", 1.0f, 2.0f);
        InvokeRepeating("CoinCreate", 0.0f, 1.5f);
        yield return new WaitForSeconds(5.0f);
        CancelInvoke();
        StartCoroutine("RandomAttack");
    }
    IEnumerator FireShotAttack() // randomInt == 3
    {
        StopCoroutine("RandomAttack");
        rb.velocity = new Vector2(0, -3.0f);
        InvokeRepeating("FireShot", 1.0f, 0.5f);
        InvokeRepeating("CoinCreate", 0.0f, 1.5f);
        yield return new WaitForSeconds(5.0f);
        CancelInvoke();
        StartCoroutine("RandomAttack");
    }
    IEnumerator OneDefenseAttack() // randomInt == 4
    {
        StopCoroutine("RandomAttack");
        rb.velocity = new Vector2(0, 3.0f);
        InvokeRepeating("CoinCreate", 0.0f, 1.5f);
        yield return new WaitForSeconds(5.0f);
        StartCoroutine("RandomAttack");
    }


    IEnumerator NoAttack() // randomInt == 5
    {
        StopCoroutine("RandomAttack");
        InvokeRepeating("CoinCreate", 0.0f, 1.5f);
        // Add animation towards Boredom! 
        yield return new WaitForSeconds(3.0f);
        StartCoroutine("RandomAttack");
    }

    private void CoinCreate()
    {
        GameObject clone;
        float randomX = Random.Range(-9.78f, 5.95f);
        float randomY = Random.Range(-1.5f, 0);
        clone = Instantiate(coin, new Vector2(randomX, randomY), transform.rotation) as GameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BoundaryUp" || other.gameObject.tag == "BoundaryDown")
        {
            if (randomInt == 1)
                rb.velocity = new Vector2(Random.Range(1.0f * Mathf.Sign(rb.velocity.x), 5.0f * Mathf.Sign(rb.velocity.x)), Random.Range(-5.0f * Mathf.Sign(rb.velocity.y), -1.0f * Mathf.Sign(rb.velocity.y)));
            else if (randomInt == 2)
            {
                // none
            }
            else if (randomInt == 3)
            {
                rb.velocity = new Vector2(0, -rb.velocity.y);
            }
            else if (randomInt == 4)
            {
                rb.velocity = new Vector2(0, 0);
                OneOpenShot();
            }
        }

        else if (other.gameObject.tag == "BoundaryLeft" || other.gameObject.tag == "BoundaryRight")
        {
            if (randomInt == 1)
                rb.velocity = new Vector2(Random.Range(-5.0f * Mathf.Sign(rb.velocity.x), -1.0f * Mathf.Sign(rb.velocity.x)), Random.Range(1.0f * Mathf.Sign(rb.velocity.y), 5.0f * Mathf.Sign(rb.velocity.y)));
            else if (randomInt == 2)
            {
                rb.velocity = new Vector2(-rb.velocity.x, 0);
            }
            else if (randomInt == 3)
            {
                rb.velocity = new Vector2(-rb.velocity.x, 0);
            }
            else if (randomInt == 4)
            {
                rb.velocity = new Vector2(-rb.velocity.x, 0);
            }

        }

    }


    void BackStartingPosition()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, startingPosition, 0.1f);
    }

    void SingleShot()
    {
        GameObject clone;
        clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        rbClone = clone.GetComponent<Rigidbody2D>();
        float randomX = Random.Range(player.transform.position.x - transform.position.x - 1.0f, player.transform.position.x - transform.position.x + 1.0f);
        float randomY = Random.Range(player.transform.position.y - transform.position.y - 1.0f, player.transform.position.y - transform.position.y + 1.0f);
        rbClone.velocity = new Vector3(randomX, randomY) * 0.75f;
    }

    void BubbleShot()
    {
        GameObject clone;
        clone = Instantiate(bubbleBullet, transform.position, transform.rotation) as GameObject;
        rbClone = clone.GetComponent<Rigidbody2D>();
        float randomX = Random.Range(player.transform.position.x - transform.position.x - 1.0f, player.transform.position.x - transform.position.x + 1.0f);
        float randomY = Random.Range(player.transform.position.y - transform.position.y - 1.0f, player.transform.position.y - transform.position.y + 1.0f);
        rbClone.velocity = new Vector3(randomX, randomY) * 1.00f;
    }

    void FireShot()
    {
        GameObject clone;
        clone = Instantiate(fireBullet, bulletSpawnLocation.position, transform.rotation) as GameObject;
        rbClone = clone.GetComponent<Rigidbody2D>();
        float randomX = Random.Range(player.transform.position.x - transform.position.x - 1.0f, player.transform.position.x - transform.position.x + 1.0f);
        float randomY = Random.Range(player.transform.position.y - transform.position.y - 1.0f, player.transform.position.y - transform.position.y + 1.0f);
        rbClone.velocity = new Vector3(randomX, randomY) * 1.0f;
    }

    void OneOpenShot()
    {
        List<Transform> children;
        children = new List<Transform>();
        GameObject clone;
        clone = Instantiate(OneOpenShotAttack, oneOpenShotLocation.position, transform.rotation) as GameObject;
        for(int i = 0; i < clone.transform.childCount; i++)
        {
            children.Add(clone.transform.GetChild(i));
        }

        int randomInt = Random.Range(0, 31);
        Destroy(children[randomInt].gameObject);
        Destroy(children[randomInt + 1].gameObject);
        Destroy(children[randomInt + 2].gameObject);
    }

    public void BossEnemyHealthDecrease()
    {
        bossEnemyHealth--;
    }

}
