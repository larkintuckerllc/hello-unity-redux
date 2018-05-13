using UnityEngine;

public class IncrementAController : MonoBehaviour {
	private void OnTriggerEnter(Collider other)
	{
		Store.storeDispatch.OnNext(A.IncrementA());
	}
}
