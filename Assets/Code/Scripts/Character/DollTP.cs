using Unity.VisualScripting;
using UnityEngine;

public class DollTP : MonoBehaviour
{
	[SerializeField] private Animator animatorDoll;
	[SerializeField] private GameObject[] triggerDoll;
	private int i = 2;
	private void OnTriggerEnter(Collider other)
	{
		foreach (var trigger in triggerDoll)
		{
			if (trigger == other.gameObject)
			{
				animatorDoll.SetBool("Pos" + i.ToString(), true);
				i++;
				break;
			}
		}
	}
}
