using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    [SerializeField] float MoveSpeed = 50f;
    [SerializeField] float RotSpeed = 50f;

	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("a")) MovePosition(gameObject.transform.rotation * Vector3.left);
        if (Input.GetKey("d")) MovePosition(gameObject.transform.rotation * Vector3.right);
        if (Input.GetKey("w")) MovePosition(gameObject.transform.rotation * Vector3.forward);
        if (Input.GetKey("s")) MovePosition(gameObject.transform.rotation * Vector3.back);
        if (Input.GetKey("r")) MovePosition(Vector3.up);
        if (Input.GetKey("f")) MovePosition(Vector3.down);

        if (Input.GetKey("z")) RotateY(-RotSpeed);
        if (Input.GetKey("x")) RotateY(RotSpeed);

        if (Input.GetKey("t")) RotateX(-RotSpeed);
        if (Input.GetKey("g")) RotateX(RotSpeed);
    }

    void MovePosition(Vector3 vec)
    {
        gameObject.transform.position += MoveSpeed * Time.deltaTime * vec;
    }

    void RotateY(float Speed)
    {
        gameObject.transform.rotation *= Quaternion.Euler(Speed * Time.deltaTime * Vector3.up);
    }

    void RotateX(float Speed)
    {
        gameObject.transform.rotation *= Quaternion.Euler(Speed * Time.deltaTime * Vector3.right);
    }

}
