using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TrafficInfinity
{
    public class PlayerController : MonoBehaviour
    {
        public Action onPauseActivate;
        public float m_speedMove = 17f;
        public float maxSpeed = 30f;
        public float increaseSpeedDistance = 30f;
        public Transform zero;

        [SerializeField] private Transform m_characterController;
        [SerializeField] private InputActionAsset m_inputActionAsset;

        private InputActionMap m_playerMap;
        private InputAction m_moveAction;
        private InputAction m_pauseAction;
        private float m_lastDistance = 0f;

        private bool m_isInputActive = true;

        private void Awake()
        {
            m_playerMap = m_inputActionAsset.FindActionMap("Player");
            m_moveAction = m_playerMap.FindAction("Move");
            m_pauseAction = m_playerMap.FindAction("Pause");
        }

        private void Start()
        {
            m_lastDistance = Mathf.Abs(zero.position.z - transform.position.z);
        }

        private void OnEnable()
        {
            m_playerMap.Enable();
            m_pauseAction.performed += OnPauseAction;
        }

        private void OnDisable()
        {
            m_playerMap.Disable();
            m_pauseAction.performed -= OnPauseAction;
        }

        private void OnPauseAction(InputAction.CallbackContext obj)
        {
            onPauseActivate?.Invoke();
        }

        public void ActivateInput(bool value)
        {
            m_isInputActive = value;
        }

        private void Update()
        {
            if (!m_isInputActive)
            {
                return;
            }

            Vector2 move = m_moveAction.ReadValue<Vector2>();
            if (move != Vector2.zero)
            {
                Vector3 dir = new Vector3(move.x, 0f, move.y);
                m_characterController.position += dir * m_speedMove * Time.deltaTime;
            }

            float currentDistance = Mathf.Abs(zero.position.z - transform.position.z);

            if (currentDistance >= m_lastDistance + increaseSpeedDistance)
            {
                m_speedMove += 1f;
                m_lastDistance = currentDistance;
                Debug.Log("Скорость авто увеличена! Текущее значение: " + m_speedMove);
            }

            if (m_speedMove >= maxSpeed)
            {
                m_speedMove = maxSpeed;
            }
        }
    }
}