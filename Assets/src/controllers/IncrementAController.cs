using UnityEngine;

public class IncrementAController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Store.Dispatch.OnNext(A.Instance.IncrementA());
	}
}
