using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour {
    void Awake()
    {
        Store.Instance.Initialize();
    }
}
