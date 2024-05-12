using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CharacterDatabase characterDatabase;

    public GameObject SelectedCharacter;
    public GameObject ControlCharacter;
    public int chr›ndeks;

    void Update()
    {
        ControlCharacter =  CharacterInventory.Instance.GetCreatedCharacter().Item1;
        

		if (ControlCharacter != SelectedCharacter)
        {
            SelectedCharacter = ControlCharacter;
			chr›ndeks = CharacterInventory.Instance.GetCreatedCharacter().Item2;
		}
	}

    public void Attack()
    {
        SelectedCharacter.GetComponent<ChrController>().Attack();
        EnemySpawn.Instance.TakeDamage(characterDatabase.GetCharacter(chr›ndeks).characterAttack);
	}
}
