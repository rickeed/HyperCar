using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
   [SerializeField] float carspeed;
   [SerializeField] float maxSpeed;
   [SerializeField] float steerAngle;
   [SerializeField] float Traction;
   Vector3 _moveVec;
   public GameObject tLeft;
   public GameObject tRight;
   public int score;
   public Text scoreText;

   float drugAmount = 0.99f;
   public Transform lw,rw;
   Vector3 _rotVec;
   

    
    void Update()
    { 
       scoreText.text=score.ToString();
        _moveVec+=transform.forward * carspeed * Time.deltaTime;
        transform.position+=_moveVec * Time.deltaTime;

        _rotVec+=new Vector3(0,Input.GetAxis("Horizontal"),0);
       transform.Rotate(Vector3.up*Input.GetAxis("Horizontal")*steerAngle*Time.deltaTime*_moveVec.magnitude);
       if(Input.GetKeyDown(KeyCode.D))
       {
          tLeft.SetActive(true);
          tRight.SetActive(true);
          
       }
       if(Input.GetKeyDown(KeyCode.A))
       {
          tLeft.SetActive(true);
          tRight.SetActive(true);
          
       }

       if(Input.GetKeyUp(KeyCode.D))
       {
          tLeft.SetActive(false);
          tRight.SetActive(false);
          
       }
       if(Input.GetKeyUp(KeyCode.A))
       {
          tLeft.SetActive(false);
          tRight.SetActive(false);
       }
       if(Input.GetKey(KeyCode.D))
       {
         score++;
       }
       if(Input.GetKey(KeyCode.A))
       {
         score++;
       }
        _moveVec*= drugAmount;
        _moveVec=Vector3.ClampMagnitude(_moveVec,maxSpeed);
        _moveVec=Vector3.Lerp(_moveVec.normalized,transform.forward,Traction*Time.deltaTime)*_moveVec.magnitude;
        _rotVec=Vector3.ClampMagnitude(_rotVec,steerAngle);

        lw.localRotation=Quaternion.Euler(_rotVec);
        rw.localRotation=Quaternion.Euler(_rotVec);
    }
}
