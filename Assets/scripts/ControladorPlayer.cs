using UnityEngine;
using System;

public enum Swipe { None, Up, Down, Left, Right };

public class ControladorPlayer : MonoBehaviour
{
	public float minSwipeLength = 5f;

	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	Vector2 firstClickPos;
	Vector2 secondClickPos;

    ControladorMenu controladorMenu;
    Camera camera;

	public static Swipe swipeDirection;

	public float velocidade;
    Vector3 velocity;
	public int pontuacao;

	private float posicaoUp;
	private float posicaoDown;

	void Awake(){
		velocity.x = 1;
	}

	void Start(){
		posicaoUp = 0.14f;
		posicaoDown = -0.14f;

		velocidade = 0.33f;
        pontuacao = 0;

        
        controladorMenu = GetComponent < ControladorMenu > ();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            
    }

	void Update ()
	{

        transform.Translate(velocity * velocidade * Time.deltaTime);

		calcularVelocidade();
		DetectSwipe();
	}

    public int DirecaoX()
    {
        return Math.Sign(velocity.x);
    }

    public int DirecaoY()
    {
        return Math.Sign(velocity.y);
    }
   

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        /*if(coll.gameObject.CompareTag ("platT"))
        {            
            if (pontuacao > controladorMenu.GetRecord())
            {
                controladorMenu.SetRecorde(pontuacao);
             }
        }*/

        if (coll.gameObject.CompareTag("platCima")) {
                  
            if (DirecaoX() == 1 && DirecaoY() == 0)
            {                
                camera.VirarCima();
                velocity.y = velocity.x;
                velocity.x = 0;
                return;
            }

            if (DirecaoX() == -1 && DirecaoY() == 0)
            {
                camera.VirarBaixo();
                velocity.y = velocity.x;
                velocity.x = 0;
                return;
            }

            if (DirecaoX() == 0 && DirecaoY() == 1)
            {
                camera.VirarBaixo();
                velocity.x = velocity.y;
                velocity.y = 0;
                return;
            }

            if (DirecaoX() == 0 && DirecaoY() == -1)
            {
                camera.VirarCima();
                velocity.x = velocity.y;
                velocity.y = 0;
                return;
            }

        }
        if (coll.gameObject.CompareTag("platBaixo"))
        {
            if (DirecaoX() == 1 && DirecaoY() == 0)
            {
                camera.VirarBaixo();
                velocity.y = -velocity.x;
                velocity.x = 0;
                return;
            }

            if (DirecaoX() == -1 && DirecaoY() == 0)
            {
                camera.VirarCima();
                velocity.y = -velocity.x;
                velocity.x = 0;
                return;
            }

            if (DirecaoX() == 0 && DirecaoY() == 1)
            {
                camera.VirarBaixo();
                velocity.x = -velocity.y;
                velocity.y = 0;
                return;
            }

            if (DirecaoX() == 0 && DirecaoY() == -1)
            {
                camera.VirarCima();
                velocity.x = -velocity.y;
                velocity.y = 0;
                return;
            }
        }
    }

	public void calcularVelocidade(){
		if (pontuacao == 4) {
			velocidade = 0.66f;
		}

		if (pontuacao > 4) {
			if ((float)Math.Log (pontuacao, 2) % 2 == 0 || (float)Math.Log (pontuacao, 2) % 2 == 1) {
				velocidade = (float)Math.Log (pontuacao, 2) ;
				Debug.Log (velocidade);
			}
		}
	
	}

	public void DetectSwipe ()
	{
		if (Input.touches.Length > 0) {
			Touch t = Input.GetTouch(0);

			if (t.phase == TouchPhase.Began) {
				firstPressPos = new Vector2(t.position.x, t.position.y);
			}

			if (t.phase == TouchPhase.Ended) {
				secondPressPos = new Vector2(t.position.x, t.position.y);
				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

				// Make sure it was a legit swipe, not a tap
				/*if (currentSwipe.magnitude < minSwipeLength) {
					swipeDirection = Swipe.None;
					return;
				}*/

				currentSwipe.Normalize();

				// Swipe up
				if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					swipeDirection = Swipe.Up;

				// Swipe down
				} else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					swipeDirection = Swipe.Down;
				}	 
			}

		} else {
			if (Input.GetMouseButtonDown(0)) {
				firstClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			} else {
				swipeDirection = Swipe.None;
				//Debug.Log ("None");
			}

			if (Input.GetMouseButtonUp (0)){
				secondClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				currentSwipe = new Vector3(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);

				// Make sure it was a legit swipe, not a tap
				/*if (currentSwipe.magnitude < minSwipeLength) {
					swipeDirection = Swipe.None;
					Debug.Log ("f");
					return;
				}*/

				currentSwipe.Normalize();

				//Swipe directional check
				// Swipe up
                if(DirecaoX() == 1) { 
				    if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					    swipeDirection = Swipe.Up;
					    transform.position = new Vector2 (transform.position.x, transform.position.y + 0.8f);
					    Debug.Log ("Up");

				    // Swipe down
				    } else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					    swipeDirection = Swipe.Down;
					    transform.position = new Vector2 (transform.position.x, transform.position.y - 0.8f);
					    Debug.Log ("Down");

				    }
                }
                if(DirecaoY() == 1) {
                    if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        swipeDirection = Swipe.Up;
                        transform.position = new Vector2(transform.position.x - 0.8f, transform.position.y);
                        Debug.Log("Up");

                        // Swipe down
                    }
                    else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        swipeDirection = Swipe.Down;
                        transform.position = new Vector2(transform.position.x + 0.8f, transform.position.y);
                        Debug.Log("Down");

                    }
                }

                if (DirecaoX() == -1)
                {
                    if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        swipeDirection = Swipe.Up;
                        transform.position = new Vector2(transform.position.x, transform.position.y + 0.8f);
                        Debug.Log("Up");

                        // Swipe down
                    }
                    else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        swipeDirection = Swipe.Down;
                        transform.position = new Vector2(transform.position.x, transform.position.y - 0.8f);
                        Debug.Log("Down");

                    }
                }
                if (DirecaoY() == -1)
                {
                    if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        swipeDirection = Swipe.Up;
                        transform.position = new Vector2(transform.position.x +0.8f, transform.position.y );
                        Debug.Log("Up");

                        // Swipe down
                    }
                    else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        swipeDirection = Swipe.Down;
                        transform.position = new Vector2(transform.position.x - 0.8f, transform.position.y );
                        Debug.Log("Down");

                    }
                }
            }

		}
	}

	public Vector3 getPosicaoPlayer(){
		return gameObject.transform.position;
	}
}