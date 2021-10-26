using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    [SerializeField] private Transform throwPoint;
    [SerializeField] private GameObject[] throwables;
    [SerializeField] private float throwingPower;
    private int selectedThrowable;


    private void Start()
    {
        selectedThrowable = 1;
    }

    void Update()
    {
        CheckForAndUpdateChosenThrowable();
        
        if(Input.GetKeyDown(KeyCode.E))
            ThrowSelectedPotion();
            
    }
    
    private void CheckForAndUpdateChosenThrowable()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedThrowable = 1;
        else if(Input.GetKeyDown(KeyCode.Alpha2))
            selectedThrowable = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            selectedThrowable = 3;
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            selectedThrowable = 4;
    }

    private void ThrowSelectedPotion()
    {
        switch (selectedThrowable)
        {
            case 1:
                InstantiatePotionObject(throwables[0]);
                break;
            case 2:
                InstantiatePotionObject(throwables[1]);
                break;
            case 3:
                InstantiatePotionObject(throwables[2]);
                break;
            case 4:
                InstantiatePotionObject(throwables[3]);
                break;
        }
    }

    private void InstantiatePotionObject(GameObject go)
    {
        if (go == null)
            return;

        var instance = Instantiate(go, throwPoint);
        instance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * throwingPower);
    }
}
