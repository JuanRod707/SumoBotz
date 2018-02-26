using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class PlayerHud : MonoBehaviour
    {
        public Image HpBar;
        public Image RobotFace;
        public int PlayerId;
        public float DimmedAlpha;

        private AberratePosition faceAberration;

        public void LoadFace(Sprite face)
        {
            gameObject.SetActive(true);
            RobotFace.sprite = face;
            faceAberration = GetComponent<AberratePosition>();
        }

        public void UpdateHp(float hp)
        {
            HpBar.fillAmount = hp;
            faceAberration.StartEffect();
        }

        public void Dim()
        {
            GetComponent<CanvasGroup>().alpha = DimmedAlpha;
        }
    }
}
