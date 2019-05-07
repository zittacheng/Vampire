using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class AnimControl : MonoBehaviour {
        public Character C;
        public Animator Anim;
        [Space]
        public List<string> AttackKeys;
        [Space]
        public Direction InputDirection;
        public int VXConfirmValue;
        public float InputSpeedConfirmValue;
        public int QueuedAttackIndex = -1;
        [Space]
        public float PositionInputScale = 1;
        public bool LockSpeed;
        public bool KeepDirection;
        public bool LockDirectionInput;
        public bool QueueAttack;
        public bool CanJump;
        public bool CanDodge;
        public bool CanFall;
        public bool CanBacked;

        public void Awake()
        {
            Anim.SetBool("GhostForm", Character.Main.GhostForm);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            InputUpdate();
            DirectionUpdate();
            XUpdate();
            YUpdate();
            QueuedAttackUpdate();
            Anim.SetBool("GhostForm", Character.Main.GhostForm);
        }

        public void InputUpdate()
        {
            if (InputSpeedConfirmValue == 0 && C.InputSpeed == 0)
                SetLongAnim("Move", false);
            else
                SetLongAnim("Move", true);
            StartCoroutine(DelayInputConfirm(C.InputSpeed));
        }

        public IEnumerator DelayInputConfirm(float Value)
        {
            yield return new WaitForSeconds(0.05f);
            InputSpeedConfirmValue = Value;
        }

        public void DirectionUpdate()
        {
            if (!KeepDirection)
            {
                SetLongAnim("ChangeDirection", false);
                if (C.direction != InputDirection)
                    C.SetDirection(InputDirection);
            }
            else if (C.direction != InputDirection)
                SetLongAnim("ChangeDirection", true);
        }

        public void XUpdate()
        {
            if (C.GetAbsoluteSpeed().x > 0)
            {
                if (VXConfirmValue == 1)
                    SetIntAnim("X", 1);
                else
                    VXConfirmValue = 1;
            }
            else if (C.GetAbsoluteSpeed().x < 0)
            {
                if (VXConfirmValue == -1)
                    SetIntAnim("X", -1);
                else
                    VXConfirmValue = -1;
            }
            else
            {
                if (VXConfirmValue == 0)
                    SetIntAnim("X", 0);
                else
                    VXConfirmValue = 0;
            }
        }

        public void YUpdate()
        {
            if (C.GetAbsoluteSpeed().y >= 5f)
                SetIntAnim("Y", 1);
            else if (C.GetAbsoluteSpeed().y <= -5f)
                SetIntAnim("Y", -1);
            else
                SetIntAnim("Y", 0);

            if (C.GetAbsoluteSpeed().y <= -5f && CanFall)
                SetLongAnim("Fall", true);
            else
                SetLongAnim("Fall", false);
        }

        public void QueuedAttackUpdate()
        {
            if (!QueueAttack && QueuedAttackIndex != -1)
            {
                SetLongAnim(AttackKeys[QueuedAttackIndex], false);
                QueuedAttackIndex = -1;
            }
        }

        public void SetDirection(Direction D)
        {
            if (LockDirectionInput)
                return;

            InputDirection = D;
            if (D == C.direction || D == Direction.Both)
                return;
            if (!KeepDirection)
                C.SetDirection(D);
        }

        public void AttackInput(int Index)
        {
            if (QueueAttack)
            {
                SetLongAnim(AttackKeys[Index], true);
                QueuedAttackIndex = Index;
            }
            else
                SetBoolAnim(AttackKeys[Index]);
        }

        public void TouchDown()
        {
            SetBoolAnim("TouchDown");
        }

        public void OnGround()
        {
            SetLongAnim("Air", false);
        }

        public void Jump()
        {
            if (!CanJump)
                return;
            C.Jump();
            SetBoolAnim("Jump");
        }

        public void Dodge()
        {
            if (!CanDodge)
                return;
            SetBoolAnim("Dodge");
        }

        public void LeaveGround()
        {
            SetLongAnim("Air", true);
        }

        public void StartInterObject(InterObject IO)
        {
            string s = IO.GetCharacterAnimKey();
            if (s != "")
                SetBoolAnim(s);
        }

        public void StopInterObject()
        {
            SetBoolAnim("StopInterObject");
        }

        public void StartKill()
        {
            SetBoolAnim("Kill");
        }

        public void SetBoolAnim(string Key)
        {
            StartCoroutine(SetBoolAnimIE(Key));
        }

        public IEnumerator SetBoolAnimIE(string Key)
        {
            Anim.SetBool(Key, true);
            yield return 0;
            Anim.SetBool(Key, false);
        }

        public void SetLongAnim(string Key, bool Status)
        {
            Anim.SetBool(Key, Status);
        }

        public void SetIntAnim(string Key, int Value)
        {
            Anim.SetInteger(Key, Value);
        }
    }
}