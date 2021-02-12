using UnityEngine;

namespace SelectCharacter
{
    public class Spawn_skin : MonoBehaviour
    {
        [SerializeField]
        private MyGameManagerData myGameManagerData = null;
        private GameObject player =null;
        // Start is called before the first frame update
        void Start()
        {
            player = Instantiate(myGameManagerData.GetCharacter(), this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform.parent);
            player.transform.localScale = this.gameObject.transform.localScale;
        }
        public void Skin_select()
        {
            Destroy(player);
            player = Instantiate(myGameManagerData.GetCharacter(), this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform.parent);
            player.transform.localScale = this.gameObject.transform.localScale;
        }
    }
}
