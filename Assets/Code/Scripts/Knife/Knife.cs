using UnityEngine;

public class Knife : MonoBehaviour
{
	public void OnTrigger()
	{
		gameObject.GetComponent<Animator>().SetBool("IsTrigger", true);
	}
}
