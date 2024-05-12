using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChrController : MonoBehaviour
{
	public Transform targetTransform; // Hedef konum
	public float moveSpeed = 5f; // Hareket hýzý

	private Vector3 startingPosition; // Baþlangýç konumu
	private Vector3 targetPosition; // Hedef konumu
	private bool movingForward = false; // Ýleri mi geri mi gidildiðini belirten flag
	private bool hasAttacked = false; // Attack fonksiyonunun çaðrýlýp çaðrýlmadýðýný kontrol eden flag

	void Start()
	{
		startingPosition = transform.position; // Baþlangýç konumunu al
		targetPosition = targetTransform.position; // Hedef konumunu al
	}

	void Update()
	{
		// Eðer ileri gidiliyorsa
		if (movingForward)
		{
			// Hedefe doðru ilerle
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

			// Hedefe ulaþýldýðýnda geri dönmek için flag'i deðiþtir
			if (transform.position == targetPosition)
			{
				movingForward = false;
			}
		}
		else
		{
			// Geri gidiliyorsa
			transform.position = Vector3.MoveTowards(transform.position, startingPosition, moveSpeed * Time.deltaTime);

			// Baþlangýç konumuna ulaþýldýðýnda ileri gitmek için flag'i deðiþtir
			if (transform.position == startingPosition)
			{
				// Bu noktada, bir sonraki Attack çaðrýsýna hazýr ol
				hasAttacked = false;
			}
		}
	}

	// Butona basýldýðýnda hareketi baþlatan fonksiyon
	public void Attack()
	{
		// Daha önce Attack çaðrýlmadýysa ve hareket yoksa
		if (!hasAttacked && !movingForward)
		{
			movingForward = true;
			hasAttacked = true;


		}
	}
}