using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class FloatingPlayer2DController : MonoBehaviour
{
    public float moveForce = 0.5f;
    public float boostMultiplier = 2;
    public float rotationDamping = 0.01f;
    public bool refueling = false;
    Rigidbody2D myBody;

    public GameObject fireanimation;

    void Start ()
	{
		myBody = this.GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate ()
	{
		Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
		Vector3 lookVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), 4096);

        if (lookVec.x != 0 && lookVec.y != 0)
        {
            Quaternion inputRotation = Quaternion.LookRotation(lookVec, Vector3.back);
            transform.rotation = Quaternion.Lerp(transform.rotation, inputRotation, rotationDamping);
        }

        bool isBoosting = CrossPlatformInputManager.GetButton("Boost");
		myBody.AddForce(moveVec * (isBoosting ? boostMultiplier : 1));

        if (moveVec.sqrMagnitude > 0.0f)
        {
            fireanimation.SetActive(true);
            if (GameObject.Find("FuelCont").GetComponent<Fuel>().fuelAmount > 0)
            {
                if (isBoosting)
                {
                    GameObject.Find("FuelCont").GetComponent<Fuel>().fuelAmount -= 0.005f * Time.timeSinceLevelLoad;
                }
                else
                {
                    GameObject.Find("FuelCont").GetComponent<Fuel>().fuelAmount -= 0.001f * Time.timeSinceLevelLoad;
                }
            }
        }
        else
        {
            fireanimation.SetActive(false);
        }

        if (refueling && GameObject.Find("FuelCont").GetComponent<Fuel>().fuelAmount < 100)
        {
            GameObject.Find("FuelCont").GetComponent<Fuel>().fuelAmount += 0.01f * Time.timeSinceLevelLoad;
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            refueling = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            refueling = false;
        }
    }
}