using UnityEngine;

public class DecrementBController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Store.Instance.storeDispatch.OnNext(B.Instance.DecrementB());
	}
}
