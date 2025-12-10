using UnityEngine;

public class Pills : MonoBehaviour, IInteractable
{
	[SerializeField] private CharacterSanity characterSanity;
	public void InteractObject()
	{
		characterSanity.Sanity += 30;
		gameObject.SetActive(false);
	}
}
