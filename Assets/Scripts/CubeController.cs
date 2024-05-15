using UnityEngine;

public class CubeController : MonoBehaviour
{
    private bool IsGameStarted = false;
    private float rotationSpeed = 100f;
    private float sizeChangeSpeed = 1f;
    private Vector3 initialScale;
    private float maxSizeTime = 5f;
    private float currentSizeTime = 0f;
    public AudioSource startAudio;
    public AudioSource endAudio;

    void Start()
    {
        initialScale = transform.localScale;
        startAudio.Stop();
        endAudio.Stop();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F) && !IsGameStarted)
        {
            IsGameStarted = true;
            print("Game started!");
            startAudio.Play();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && IsGameStarted)
        {
            IsGameStarted = false;
            print("Game ended!");
            endAudio.Play();   
        }

        if (IsGameStarted)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
            transform.Rotate(Vector3.right, verticalInput * rotationSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space))
            {
                currentSizeTime += Time.deltaTime;
                if (currentSizeTime <= maxSizeTime)
                {
                    Vector3 newSize = transform.localScale + Vector3.one * sizeChangeSpeed * Time.deltaTime;
                    transform.localScale = newSize;
                }
            }
            else
            {
                currentSizeTime = 0f;
            }

            if (!Input.GetKey(KeyCode.Space))
            {
                Vector3 newSize = transform.localScale - Vector3.one * sizeChangeSpeed * Time.deltaTime;
                transform.localScale = Vector3.Max(newSize, initialScale);
            }
        }
    }
}