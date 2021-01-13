using UnityEngine;

public class SingletonObject<T> : MonoBehaviour
{
    public static T instance;
    protected virtual void Awake() {
        if(instance != null) {
            Destroy(this.gameObject);
            return;
        } else {
            DontDestroyOnLoad(this.gameObject);
            instance = this.GetComponent<T>();
        }
    }
}
