using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(AudioSource))]
    public class TPSCamNight : MonoBehaviour
    {
        [SerializeField] private MouseLook m_MouseLook;
        [SerializeField] private bool m_UseFovKick;
        [SerializeField] private FOVKick m_FovKick = new FOVKick();
        [SerializeField] private Transform target1;
        [SerializeField] private Transform target2;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float offset_scale;
        [SerializeField] private float height;
        [SerializeField] private float height_scale;
        [SerializeField] private Vector3 offset_cap;
        [SerializeField] private float zoom_amount;
        [SerializeField] private float camRot;


        private Camera m_Camera;
        private float m_YRotation;
        private Vector2 m_Input;
        private Vector3 m_OriginalCameraPosition;
        private CollisionFlags m_CollisionFlags;
        private AudioSource m_AudioSource;
        private Vector3 target_average;
        private float target_dist;
        private Vector3 adjusted_offset;
        private float adjusted_height;
        private Vector3 adjusted_target;

        private void Start()
        {
            m_Camera = Camera.main;
            m_OriginalCameraPosition = m_Camera.transform.localPosition;
            m_FovKick.Setup(m_Camera);
            m_AudioSource = GetComponent<AudioSource>();

            m_MouseLook.Init(transform, m_Camera.transform);
        }

        private void FixedUpdate()
        {
            //keeps the camera in between both characters and scales based on their distance
            target_average = (target1.position + target2.position)/2;
            //target_dist = (target1.position.x - target2.position.x)*(target1.position.x - target2.position.x) + (target1.position.y - target2.position.y)*(target1.position.y - target2.position.y) + (target1.position.z - target2.position.z)*(target1.position.z - target2.position.z);
            target_dist = Vector3.Distance(target1.position, target2.position);
            adjusted_offset = offset * (offset_scale*8/10 * target_dist);
            //adjusts scale factor when players are close together
            if (adjusted_offset.z < offset_cap.z)
            {
                adjusted_offset = offset_cap + (adjusted_offset-offset_cap)*target_dist*8/10*(zoom_amount/10);
            }
            adjusted_height = height+target_dist * (height_scale/20);
            transform.position = target_average - adjusted_offset + Vector3.up * adjusted_height;
        }
    }
}
