using LevelControl;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement values")]
        private float _speed = 7.0f;
        private Vector3 direction = Vector3.right;

        [Header("Jump values")]
        public float jumpForce = 10f;
        private bool isGrounded = true;

        private bool _correctState = false;

        private void Start()
        {
            LevelStateMachine.Instance.OnGameStateChanged += LevelStateManager_OnGameStateChanged;
        }

        private void LevelStateManager_OnGameStateChanged(object sender, LevelStates e)
        {
            if (e == LevelStates.StartGameplay || e == LevelStates.GameplayInProgress)
            {
                _correctState = true;
                LevelStateMachine.Instance.state = LevelStates.GameplayInProgress;
            }

            if (e == LevelStates.LevelEnd || e == LevelStates.Death)
            {
                _correctState = false;
            }
        }

        private void Update()
        {
            if (_correctState != true)
                return;

            Move();
            Jump();
        }

        private void Move()
        {
            Vector3 newPosition = transform.position + direction.normalized * (_speed * Time.deltaTime);
            transform.position = newPosition;
        }

        private void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.touchCount > 0) && isGrounded)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpForce, 0f);
                isGrounded = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }
    }
}