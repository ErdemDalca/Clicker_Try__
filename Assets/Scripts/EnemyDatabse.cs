using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu]
public class EnemyDatabse : ScriptableObject
{
	public Enemy[] enemies;

	public int enemyCount { get { return enemies.Length; } }

	public Enemy GetEnemy(int index)
	{
		return enemies[index];
	}
}
