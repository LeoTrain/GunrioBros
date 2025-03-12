using UnityEngine;

public class GrabGunScript : MonoBehaviour
{
    [SerializeField] private Transform _grabPoint;
    [SerializeField] private GameObject _grabbedGun;
    public bool isGrabbed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_grabbedGun != null)
            return;
        if (collision.gameObject.CompareTag("Weapon"))
        {
            AddWeapon(collision.gameObject);
        }   
    }

    public bool AddWeapon(GameObject weapon)
    {
        // Check if the weapon is in the correct layer and is a weapon and there is no weapon in the grab point
        // if all the conditions are met, create a new weapon in the grab point
        if (weapon.CompareTag("Weapon") && _grabbedGun == null)
        {
            weapon.transform.position = _grabPoint.position;
            weapon.transform.SetParent(_grabPoint);
            _grabbedGun = weapon;
            isGrabbed = true;
            weapon.GetComponent<GunScript>().GunPickedUp();
            return true;
        }
        return false;
    }

    public void RemoveWeapon()
    {
        if (_grabbedGun != null)
        {
            _grabbedGun.transform.SetParent(null);
            _grabbedGun = null;
            isGrabbed = false;
        }
    }
}
