using UnityEngine;

public class FoodCannon : MonoBehaviour
{
    [SerializeField] private float shootSpeed = 30;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject food;

    private void Shoot()
    {
        GameObject newFood = Instantiate(food, shootPoint.position, Random.rotation);
        newFood.GetComponent<Rigidbody>().velocity = shootPoint.forward * shootSpeed;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
}
