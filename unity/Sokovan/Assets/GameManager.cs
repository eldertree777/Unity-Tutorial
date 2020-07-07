using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{   
    //모든 아이템박스를 알고있어야함
    // 모두 충돌했는지 확인
    // Start is called before the first frame update
    public GameObject winUI;
    public ItemBox[] itemBoxes;
    public bool isGameOver ;
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame


    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)){
            //SceneManager.LoadScene("Main");
            SceneManager.LoadScene(0);
        }

        if(isGameOver == true){
            return;
        }

        int count = 0;
        for(int i=0; i<3 ;i++){
            if(itemBoxes[i].isOveraped == true){
                count++;
            }
        }

        if(count == 3){
            Debug.Log("GameOver");
            isGameOver = true;
            winUI.SetActive(true);
        }
    }
}
