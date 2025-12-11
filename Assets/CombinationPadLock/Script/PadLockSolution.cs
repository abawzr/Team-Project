using System.Linq;
using UnityEngine;

public class PadLockSolution : MonoBehaviour
{
    [Header("References")]
    public MoveRuller moveRull;                   // سكربت تحريك الأقراص
    public Animator padLockAnimator;              // انيميشن القفل
    public string idleAnimationName = "idle lo";  // الانيميشن الافتراضي
    public string openAnimationName = "opine lo"; // انيميشن فتح القفل

    [Header("Password")]
    public int[] numberPassword = { 8, 4, 7, 5 }; // الرقم الصحيح

    private bool isUnlocked = false; // لمنع تكرار الحل

    void Start()
    {
        if (padLockAnimator != null)
            padLockAnimator.Play(idleAnimationName);

        if (moveRull == null)
            moveRull = FindObjectOfType<MoveRuller>();
    }

    void Update()
    {
        CheckPassword();
    }

    void CheckPassword()
    {
        if (!isUnlocked && moveRull._numberArray.SequenceEqual(numberPassword))
        {
            isUnlocked = true;
            Debug.Log("Password correct! Lock opening...");

            // تشغيل انيميشن فتح القفل
            if (padLockAnimator != null)
                padLockAnimator.Play(openAnimationName);

            // إيقاف البصريات على الأقراص
            for (int i = 0; i < moveRull._rullers.Count; i++)
            {
                var padLockColor = moveRull._rullers[i].GetComponent<PadLockEmissionColor>();
                padLockColor._isSelect = false;
                padLockColor.BlinkingMaterial();
            }

            // 🔔 أحداث إضافية عند الحل:
            // مثال: فتح باب
            // DoorController.Instance.OpenDoor();
            // تشغيل صوت
            // AudioManager.Instance.Play("LockOpen");
        }
    }
}