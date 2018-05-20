using UnityEngine;

public class DecrementAController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Store.Dispatch.OnNext(A.Instance.DecrementA());
	}
}
