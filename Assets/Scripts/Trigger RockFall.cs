using UnityEngine;

public class TriggerRockFall : MonoBehaviour
{
    private GameObject[] _allChildren;


    private void Start()
    {
        _allChildren = new GameObject[gameObject.transform.childCount];
        for (int i = 0; i < _allChildren.Length; i++)
        {
            _allChildren[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            for (int i = 0; i < _allChildren.Length; i++)
            {
                Rigidbody crb = _allChildren[i].GetComponent<Rigidbody>();
                crb.useGravity = true;
                crb.linearDamping = Random.Range(3f, 5f);
            }
        }
    }
}
