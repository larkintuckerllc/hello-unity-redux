using UnityEngine;

public class IncrementAController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Store.Instance.storeDispatch.OnNext(A.Instance.IncrementA());
	}
}
