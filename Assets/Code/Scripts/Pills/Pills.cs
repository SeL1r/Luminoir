using UnityEngine;

public class Pills : MonoBehaviour, IInteractable
{
	[SerializeField] private CharacterSanity characterSanity;
	[SerializeField] private AudioSource pickUp;
	private int recoverySanity = 30;
	public void InteractObject()
	{
		pickUp.Play();
		characterSanity.Sanity += recoverySanity;
		transform.position = new Vector3(1000,1000,1000);
	}
}
