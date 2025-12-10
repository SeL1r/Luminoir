using UnityEditor.Build;
using UnityEngine;

public class Lighter : ObjectWhichDrop, IActivate
{
	[SerializeField] private ParticleSystem fire;
	public void ActiveObject()
	{
		print(1);
	}
}
