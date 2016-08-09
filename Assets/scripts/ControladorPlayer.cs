using UnityEngine;
using System;

public enum Swipe { None, Up, Down, Left, Right };

public class ControladorPlayer : MonoBehaviour
{
	// tempo de duração do Swipe 
	public float minSwipeLength = 5f;

	// Swipe
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;
	Vector2 firstClickPos;
	Vector2 secondClickPos;

    ControladorMenu controladorMenu;
	ControladorPlataformas controladorPlataformas;
	ControladorAudio controladorAudio;
	ControladorMorte controladorMorte;

	Camera camera;

	public static Swipe swipeDirection;

	public float velocidade;
    public Vector3 velocity;
	public float pontuacao;

	private float posicaoSwipe;

	int colisaoPlat;

	void Awake(){
		velocity.x = 1;
	}

	void Start(){
		colisaoPlat = 0;

		// sitar pos. swipe
		posicaoSwipe = 0.8f;

		//velocidade, pontuação player inicial;
		velocidade = 2f;
        pontuacao = 0;

        
        controladorMenu = GetComponent < ControladorMenu > ();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

		controladorPlataformas =  GameObject.FindGameObjectWithTag("controladorPlat").GetComponent<ControladorPlataformas>();

		controladorAudio = GameObject.FindGameObjectWithTag ("Audio").GetComponent<ControladorAudio> ();
		controladorMorte =  GameObject.FindGameObjectWithTag ("Morte").GetComponent<ControladorMorte> ();
            
    }

	void Update ()
	{
		calcularPontuacao ();
        transform.Translate(velocity * velocidade * Time.deltaTime);

		calcularVelocidade();
		DetectSwipe();

		gameOver ();


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
		//Atualizar para GAME OVER
		if (coll.gameObject.CompareTag ("T")) {

			PlayerPrefs.SetFloat ("Pontuacao", pontuacao);
			if (pontuacao > PlayerPrefs.GetFloat ("Pontuacao")) {
				PlayerPrefs.SetFloat ("Pontuacao", pontuacao);
			}

			controladorAudio.playGameOver ();

			Application.LoadLevel (2);
			//Destroy (gameObject);
		}


        if (coll.gameObject.CompareTag("platCima")) {

			if (DirecaoY () == 0 && DirecaoX() == 1) {
				velocity.y = velocity.x;
				velocity.x = 0;

			}
			if (DirecaoY () == 0 && DirecaoX() == -1) {
				velocity.y = -velocity.x;
				velocity.x = 0;

			}
				
			controladorPlataformas.InicializarPlataformas();
			controladorMorte.AtualizarPosição (gameObject.transform.position);

			//camera.VirarCima();
			if (DirecaoX () == 1) {
				velocity.y = velocity.x;
				velocity.x = 0;
				return;
			}
			if (DirecaoX () == -1) {
				velocity.y = -velocity.x;
				velocity.x = 0;
				return;
			}


		}
		if (coll.gameObject.CompareTag("platBaixo")){        
				
			if (DirecaoY () == 0 && DirecaoX() == 1) {
				velocity.y = -velocity.x;
				velocity.x = 0;
			}
			if (DirecaoY () == 0 && DirecaoX() == -1) {
				velocity.y = velocity.x;
				velocity.x = 0;
			}

			controladorPlataformas.InicializarPlataformas();
			controladorMorte.AtualizarPosição (gameObject.transform.position);

			if (DirecaoX () == 1) {
				velocity.y = -velocity.x;
				velocity.x = 0;
				return;
			}
			if (DirecaoX () == -1) {
				velocity.y = velocity.x;
				velocity.x = 0;
				return;
			}

		}

		if (coll.gameObject.CompareTag("platDireita"))
		{
			if (DirecaoX () == 0 && DirecaoY() == 1) {
				velocity.x = velocity.y;
				velocity.y = 0;
			}

			if (DirecaoX () == 0 && DirecaoY() == -1) {
				velocity.x = -velocity.y;
				velocity.y = 0;
			}

			controladorPlataformas.InicializarPlataformas();
			controladorMorte.AtualizarPosição (gameObject.transform.position);
		

			if (DirecaoY () == 1) {
				velocity.x = velocity.y;
				velocity.y = 0;
				return;
			}
			if (DirecaoY () == -1) {
				velocity.x = -velocity.y;
				velocity.y = 0;
				return;
			}


		}

		if (coll.gameObject.CompareTag("platEsquerda"))
		{

			if (DirecaoX () == 0 && DirecaoY() == 1) {
				velocity.x = -velocity.y;
				velocity.y = 0;
			}

			if (DirecaoX () == 0 && DirecaoY() == -1) {
				velocity.x = velocity.y;
				velocity.y = 0;
			}

			controladorPlataformas.InicializarPlataformas();
			controladorMorte.AtualizarPosição (gameObject.transform.position);


			if (DirecaoY () == 1) {
				velocity.x = -velocity.y;
				velocity.y = 0;
				return;
			}
			if (DirecaoY () == -1) {
				velocity.x = velocity.y;
				velocity.y = 0;
				return;
			}


		}




    }
	void  calcularPontuacao(){
		float porcentagem;
		float aumento = 1;

		aumento= aumento + 1;
		pontuacao = aumento + pontuacao;

	}

	public void calcularVelocidade(){
		
			if ((float)Math.Log (pontuacao, 2) % 2 == 0 || (float)Math.Log (pontuacao, 2) % 2 == 1) {
				velocidade = (float)Math.Log (pontuacao, 2) ;


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
				}

				// Swipe down
				 else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					swipeDirection = Swipe.Down;
				}

				// Swipe left
				else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
					swipeDirection = Swipe.Left;
					Debug.Log ("Swiped LEFT");

				}
				// Swipe right
				else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
					swipeDirection = Swipe.Right;
					Debug.Log ("Swiped RIGHT");

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
                if(DirecaoX() != 0) { 
					// Swipe up
				    if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					    swipeDirection = Swipe.Up;
						transform.position = new Vector2 (transform.position.x, transform.position.y + posicaoSwipe);
						controladorAudio.playMove ();

				    // Swipe down
				    } else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					    swipeDirection = Swipe.Down;
						transform.position = new Vector2 (transform.position.x, transform.position.y - posicaoSwipe);
						controladorAudio.playMove ();
					    

				    }


                }
                if(DirecaoY() != 0) {
					// Swipe left
					if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
						swipeDirection = Swipe.Left;
						transform.position = new Vector2 (transform.position.x - posicaoSwipe, transform.position.y );
						controladorAudio.playMove ();


					}
					// Swipe right
					else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
						swipeDirection = Swipe.Right;
						transform.position = new Vector2 (transform.position.x + posicaoSwipe, transform.position.y);
						controladorAudio.playMove ();


					}
                }

				/*if (DirecaoX() == -1)
                {
					//Swipe up
                    if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        swipeDirection = Swipe.Up;
                        transform.position = new Vector2(transform.position.x, transform.position.y + 0.8f);
                        Debug.Log("Up");                        
                    }

					// Swipe down
                    else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        swipeDirection = Swipe.Down;
                        transform.position = new Vector2(transform.position.x, transform.position.y - 0.8f);
                        Debug.Log("Down");

                    }
                }*/
                /*if (DirecaoY() == -1)
                {
					// Swipe left
					if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
						swipeDirection = Swipe.Left;
						transform.position = new Vector2 (transform.position.x - 0.8f, transform.position.y );
						Debug.Log ("Swiped LEFT");

					}
					// Swipe right
					else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
						swipeDirection = Swipe.Right;
						transform.position = new Vector2 (transform.position.x + 0.8f, transform.position.y );
						Debug.Log ("Swiped RIGHT");

					}
                }*/
            }

		}
	}

	public Vector3 getPosicaoPlayer(){
		return gameObject.transform.position;
	}

	void gameOver(){
		if (Vector3.Distance(gameObject.transform.position, controladorMorte.gameObject.transform.position) > 20){	
			PlayerPrefs.SetFloat ("Pontuacao", pontuacao);

			if (pontuacao > PlayerPrefs.GetFloat ("Recorde")) {
				PlayerPrefs.SetFloat ("Recorde", pontuacao);
			}

			controladorAudio.playGameOver ();
			Application.LoadLevel (2);
		}
	}
}