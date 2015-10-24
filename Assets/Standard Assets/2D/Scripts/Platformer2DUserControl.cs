using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        public float FireRate = 5; //Shotspersecond

        private float ShotTimer_ = 0;
        private float FireTime_;

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            FireTime_ = 1 / FireRate;
        }


        private void Update()
        {

            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            bool fire = CrossPlatformInputManager.GetAxis("Fire1")>0;
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            if (ShotTimer_ > 0)
            {
                ShotTimer_ -= Time.deltaTime;
            }
            else
            {
                if (fire)
                {
                    m_Character.Attack();
                    ShotTimer_ = FireTime_;
                }
            }
            
            m_Jump = false;
        }
    }
}
