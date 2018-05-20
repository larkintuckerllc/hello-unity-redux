using UnityEngine;

public class DecrementAController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Store.Instance.storeDispatch.OnNext(A.DecrementA());
	}
}
