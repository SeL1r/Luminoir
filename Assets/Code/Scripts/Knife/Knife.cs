using UnityEngine;

public class Knife : MonoBehaviour
{
	[SerializeField] private AudioSource stuk;
	[SerializeField] private GameObject character;
	private bool characterInMinDist = true;

	private void Update()
	{
		if(characterInMinDist && Vector3.Distance(transform.position, character.transform.position) < 12)
		{
			stuk.Play();
			characterInMinDist = false;
		}
	}
	public void OnTrigger()
	{
		stuk.Stop();
		gameObject.GetComponent<Animator>().SetBool("IsTrigger", true);
	}
}
