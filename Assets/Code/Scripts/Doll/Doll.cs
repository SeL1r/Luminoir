using UnityEngine;

public class Doll : MonoBehaviour
{
	[SerializeField] private Transform character;

	private void Update()
	{
		gameObject.transform.LookAt(character);
	}
}
