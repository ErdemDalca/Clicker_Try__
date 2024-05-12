using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public EnemyDatabse enemyDatabase;
    public GameObject enemyPrefab;

    private GameObject createdEnemy;

	Enemy enemyData ;

	public static EnemySpawn Instance;

	public float hp;
	public Sprite enemyLifeSprite;
	public Sprite enemyDeadSprite;
	public float damage;
	public float attackSpeed;

    public Text enemyDeadText;
    public int enemyDeadCount;

	private bool isRespawning = true;
	private bool isEnemyDead;

	void Awake()
	{
		Instance = this;
	}

	void Start()
    {
        enemyDeadText.text = enemyDeadCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(createdEnemy == null && isRespawning)
        {
            CreateEnemy();
            isEnemyDead = false;
        }
    }

    public void CreateEnemy()
    {
        int random = Random.Range(0, enemyDatabase.enemyCount);
        enemyData= enemyDatabase.GetEnemy(random);

		hp = enemyData.hp;
		enemyLifeSprite = enemyData.enemyLifeSprite;
		enemyDeadSprite = enemyData.enemyDeadSprite;
		damage = enemyData.damage;
		attackSpeed = enemyData.attackSpeed;

		createdEnemy = Instantiate(enemyPrefab);
        createdEnemy.name = "CreatedEnemy";
    }

    public void TakeDamage(float damage)
    {
        if (createdEnemy != null && !isEnemyDead)
        {
            if (hp - damage > 0)
            {
                hp -= damage;
                createdEnemy.GetComponentInChildren<Slider>().value = hp;
            }
            else if (hp - damage <= 0)
            {
                isEnemyDead = true;
                hp = 0;
                createdEnemy.GetComponent<SpriteRenderer>().sprite = enemyDeadSprite;
                createdEnemy.GetComponentInChildren<Slider>().value = hp;
				StartCoroutine(waitForSeconds(1f));
				
				enemyDeadCount += 1;
                enemyDeadText.text = enemyDeadCount.ToString();
            }
        }
    }

    private IEnumerator waitForSeconds(float delay)
    {
		isRespawning = false;

		yield return new WaitForSeconds(delay);
		Destroy(createdEnemy);
		yield return new WaitForSeconds(delay/4);
		isRespawning = true;
	}
}
