using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChrController : MonoBehaviour
{
	public Transform targetTransform; // Hedef konum
	public float moveSpeed = 5f; // Hareket h�z�

	private Vector3 startingPosition; // Ba�lang�� konumu
	private Vector3 targetPosition; // Hedef konumu
	private bool movingForward = false; // �leri mi geri mi gidildi�ini belirten flag
	private bool hasAttacked = false; // Attack fonksiyonunun �a�r�l�p �a�r�lmad���n� kontrol eden flag

	void Start()
	{
		startingPosition = transform.position; // Ba�lang�� konumunu al
		targetPosition = targetTransform.position; // Hedef konumunu al
	}

	void Update()
	{
		// E�er ileri gidiliyorsa
		if (movingForward)
		{
			// Hedefe do�ru ilerle
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

			// Hedefe ula��ld���nda geri d�nmek i�in flag'i de�i�tir
			if (transform.position == targetPosition)
			{
				movingForward = false;
			}
		}
		else
		{
			// Geri gidiliyorsa
			transform.position = Vector3.MoveTowards(transform.position, startingPosition, moveSpeed * Time.deltaTime);

			// Ba�lang�� konumuna ula��ld���nda ileri gitmek i�in flag'i de�i�tir
			if (transform.position == startingPosition)
			{
				// Bu noktada, bir sonraki Attack �a�r�s�na haz�r ol
				hasAttacked = false;
			}
		}
	}

	// Butona bas�ld���nda hareketi ba�latan fonksiyon
	public void Attack()
	{
		// Daha �nce Attack �a�r�lmad�ysa ve hareket yoksa
		if (!hasAttacked && !movingForward)
		{
			movingForward = true;
			hasAttacked = true;


		}
	}
}