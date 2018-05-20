using UnityEngine;

public class DecrementAController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Provider.Dispatch(A.Instance.DecrementA());
	}
}
