using UnityEngine;

public class Pills : MonoBehaviour, IInteractable
{
	[SerializeField] private CharacterManager characterManager;
	public void InteractObject()
	{
		characterManager.Sanity += 30;
		gameObject.SetActive(false);
	}
}
