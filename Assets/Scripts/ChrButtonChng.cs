using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChrButtonChng : MonoBehaviour
{
    public CharacterDatabase characterDatabase;
	public GameObject characterSP;
	private int CharacterCounter = 0;

	private GameObject CreatedChr;

	public void OnButtonClick(Button button)
	{
		
		if(CharacterCounter == 0 )
		{
			CharacterCounter++;
			CreatedChr = Instantiate(characterSP, characterSP.transform.position, Quaternion.identity);
			CreatedChr.GetComponent<SpriteRenderer>().sprite = characterDatabase.characters[int.Parse(button.name)].characterSprite;
			CreatedChr.name = button.name;
			
		}
		else
		{
			Destroy(CreatedChr);
			CreatedChr = Instantiate(characterSP, characterSP.transform.position, Quaternion.identity);
			CreatedChr.GetComponent<SpriteRenderer>().sprite = characterDatabase.characters[int.Parse(button.name)].characterSprite;
			CreatedChr.name = button.name;
		}

		
	}
}


