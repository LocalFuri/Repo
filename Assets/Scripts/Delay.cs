using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;


public class Delay : MonoBehaviour
{
  void Start()
  {
    StartCoroutine(CallWithDelay());
  }

  IEnumerator CallWithDelay()
  {
    yield return new WaitForSeconds(10f);
    Debug.Log("Called after delay");
  }

}
