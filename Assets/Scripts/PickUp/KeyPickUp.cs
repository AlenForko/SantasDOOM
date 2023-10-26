using UI;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public bool key1, key2, key3;

    private KeyPickUpSound _keyPickUpSound;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponentInChildren<KeyPickUpSound>().PickUpSoundPlay();
            if (key1)
            {
                other.GetComponent<Inventory>().hasKey1 = true;
                CanvasManager.Instance.UpdateKeys(0);
            }

            if (key2)
            {
                other.GetComponent<Inventory>().hasKey2 = true;
                CanvasManager.Instance.UpdateKeys(1);
            }

            if (key3)
            {
                other.GetComponent<Inventory>().hasKey3 = true;
                CanvasManager.Instance.UpdateKeys(2);
            }
            Destroy(gameObject);
        }
    }
}
