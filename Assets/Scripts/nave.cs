using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nave : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tiro"))
        {
            SoundManager.PlaySound(SoundManager.Sound.Dead_nave);
            Score.AddScore();
            this.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}
