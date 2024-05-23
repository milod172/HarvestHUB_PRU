using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //Khi một cảnh mới được tải lên trong Unity, 
    //toàn bộ các đối tượng trong cảnh hiện tại sẽ bị hủy bỏ 
    //và các đối tượng mới trong cảnh mới sẽ được tạo ra. 
    //Tuy nhiên, nếu bạn sử dụng DontDestroyOnLoad(gameObject); 
    //trên một đối tượng cụ thể, đối tượng đó sẽ không bị hủy bỏ khi chuyển đổi giữa các cảnh.

    public void GoInsideHouse()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(): Load một cảnh mới
        //SceneManager.GetActiveScene().buildIndex: Cảnh tiếp theo theo số index bắt đầu từ 0 là cảnh gốc
    }

    public void GoOutside()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        //SceneManager.LoadScene(): Load một cảnh mới
        //SceneManager.GetActiveScene().buildIndex: Cảnh tiếp theo theo số index bắt đầu từ 0 là cảnh gốc
    }

    //Phương thức loadScene theo tên
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

}
