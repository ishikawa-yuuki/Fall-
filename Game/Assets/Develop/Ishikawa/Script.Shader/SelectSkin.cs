using UnityEngine;
using UnityEngine.EventSystems;

namespace SelectCharacter
{
    public class SelectSkin : MonoBehaviour
    {
        [SerializeField]
        private MyGameManagerData myGameManagerData = null;
        [SerializeField]
        private Spawn_skin   skin = null;

        //　キャラクターを選択した時に実行しキャラクターデータをMyGameManagerDataにセット
        public void OnSelectCharacter(GameObject character)
        {
            //　ボタンの選択状態を解除して選択したボタンのハイライト表示を可能にする為に実行
            EventSystem.current.SetSelectedGameObject(null);
            //　MyGameManagerDataにキャラクターデータをセットする
            myGameManagerData.SetCharacter(character);
            skin.Skin_select();
        }
        //　キャラクターを選択した時に背景をオンにする
        public void SwitchButtonBackground(int buttonNumber)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (i == buttonNumber - 1)
                {
                    transform.GetChild(i).Find("Background").gameObject.SetActive(true);
                }
                else
                {
                    transform.GetChild(i).Find("Background").gameObject.SetActive(false);
                }
            }
        }
    }
}