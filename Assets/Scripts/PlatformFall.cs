using UnityEngine;

public class PlatformFall : MonoBehaviour {

    public float FallDelayInSec = 4f;
    private bool _touched;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_touched && collision.gameObject.CompareTag("Player"))
        {
            _touched = true;
            Invoke("MakeMeFall", FallDelayInSec);
        }
    }

    private void MakeMeFall()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

}
