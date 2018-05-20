using UnityEngine;

public class DecrementAController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Store.storeDispatch.OnNext(A.Instance.DecrementA());
	}
}
