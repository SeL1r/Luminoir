using UnityEngine;

public class Pills : MonoBehaviour, IInteractable
{
	[SerializeField] private CharacterSanity characterSanity;
	private int recoverySanity = 30;
	public void InteractObject()
	{
		characterSanity.Sanity += recoverySanity;
		gameObject.SetActive(false);
	}
}
