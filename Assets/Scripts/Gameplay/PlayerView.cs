using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
   private const float FlipPositionXDelta = 0.68f;
   
   [SerializeField]
   private Animator _animator;
   [SerializeField]
   private PlayerMove _playerMove;
   [SerializeField]
   private SpriteRenderer _spriteRenderer;

   private void Update()
   {
      SetMirroring();
      SetAnimations();
   }

   private void SetMirroring()
   {
      var speed = _playerMove.CurrentSpeed;
      if(speed > 0.1 && _spriteRenderer.flipX)
      {
         _spriteRenderer.flipX = false;
         transform.position = new Vector2(transform.position.x + FlipPositionXDelta, transform.position.y);
      }
      else if(speed < -0.1 && !_spriteRenderer.flipX)
      {
         _spriteRenderer.flipX = true;
         transform.position = new Vector2(transform.position.x - FlipPositionXDelta, transform.position.y);
      }
   }

   private void SetAnimations()
   {
      _animator.SetFloat("MoveSpeed", Mathf.Abs(_playerMove.CurrentSpeed));
      _animator.SetBool("Jumping", !_playerMove.IsGrounded);
   }
}