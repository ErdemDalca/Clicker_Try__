
using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInventory : MonoBehaviour
{
	public CharacterDatabase characters;
	public GameObject characterInv;
	public GameObject characterPrefab;
	public string characterKey = "SelectedCharacter";

	public GameObject characterSP;

	private GameObject createdChr;

	public static CharacterInventory Instance;

	private int chr�ndeks;

	void Awake()
	{
		Instance = this;
	}


	private void Start()
	{
		int selectedCharacterIndex = PlayerPrefs.GetInt(characterKey, 0);

		for (int i = 0; i < characters.characterCount; i++)
		{
			GameObject character = Instantiate(characterPrefab, characterInv.transform);

			character.name = i.ToString();

			Text buttonText = character.GetComponentInChildren<Text>();
			buttonText.text = characters.GetCharacter(i).characterName;

			Image buttonImage = character.transform.Find("Image").GetComponent<Image>();
			buttonImage.sprite = characters.GetCharacter(i).characterSprite;

			Button buttonComponent = character.GetComponent<Button>();
			int characterIndex = i; // T�klanan butonun hangi karakteri temsil etti�ini belirtmek i�in kullan�l�r
			buttonComponent.onClick.AddListener(delegate { OnCharacterButtonClicked(characterIndex); });

			character.transform.SetParent(characterInv.transform, false);

			if (i == selectedCharacterIndex)
			{
				// Kaydedilmi� karakterin butonunu otomatik olarak se�ili yap
				buttonComponent.Select();
				OnCharacterButtonClicked(selectedCharacterIndex);
			}
		}
	}

	private void OnCharacterButtonClicked(int characterIndex)
	{
		chr�ndeks = characterIndex;
		if (createdChr != null)
		{
			Destroy(createdChr);
		}
		createdChr = Instantiate(characterSP, characterSP.transform.position, Quaternion.identity);
		createdChr.GetComponent<SpriteRenderer>().sprite = characters.characters[characterIndex].characterSprite;
		createdChr.name = characters.GetCharacter(characterIndex).characterName;

		PlayerPrefs.SetInt(characterKey, characterIndex);

	}

	public Tuple<GameObject, int> GetCreatedCharacter()
	{
		// Tuple olu�tur ve geri d�n
		return new Tuple<GameObject, int>(createdChr, chr�ndeks);
		
	}

}
