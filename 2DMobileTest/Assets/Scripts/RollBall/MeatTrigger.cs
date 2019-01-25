using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatTrigger : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.tag == "Player"){
        GameManager.instance.SetGameResult(true);
        Destroy(gameObject);
      }
  }
}
