using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public enum Swipe { None, Up, Down, Left, Right };

public class ControladorPlayer : MonoBehaviour{
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

	ControladorGravidade controladorGravidade;
	public bool estado;

	RaycastHit2D solo;
	public LayerMask linha;

	Camera camera;

	public static Swipe swipeDirection;

	public float velocidade;
    public Vector3 velocity;
	public float gravidade;
	public float pontuacao;

	ParticleSystem particula;

	private float posicaoSwipe;

	private Vector3 posicaoVelha;

//	bool cima,baixo,direita,esquerda;
	public bool detectSwipe;
	int colisaoPlat;

	bool isAlive;

	void Awake(){
		velocity.x = 1;
	}

	void Start(){
		gravidade = -5;

		estado = true;
		detectSwipe = true;
		colisaoPlat = 0;

		// sitar pos. swipe
		posicaoSwipe = 0.7f;

		//velocidade, pontuação player inicial;
		velocidade = 2f;
        pontuacao = 0;

		particula = GameObject.FindGameObjectWithTag ("controladorLinha").GetComponent<ParticleSystem> ();
      
		controladorMenu = GetComponent < ControladorMenu > ();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

		controladorPlataformas =  GameObject.FindGameObjectWithTag("controladorPlat").GetComponent<ControladorPlataformas>();

		controladorAudio = GameObject.FindGameObjectWithTag ("Audio").GetComponent<ControladorAudio> ();
		controladorMorte =  GameObject.FindGameObjectWithTag ("Morte").GetComponent<ControladorMorte> ();
		controladorGravidade =  GetComponent<ControladorGravidade>();
		isAlive = true;      

    }

	void Update (){
		//ResetarPosicoes (cima, baixo,direita,esquerda);
		posicaoVelha = transform.position;
		verificarDistancia ();

		if (getIsAlive()) {
			calcularPontuacao ();
			transform.Translate (velocity * velocidade * Time.deltaTime);

			if (DirecaoX () != 0) {
				controladorGravidade.modificarGravidade (ref gravidade,DirecaoX(),DirecaoY(), estado);
				solo = Physics2D.Raycast (transform.position , Vector2.up*Math.Sign(gravidade),4f,linha);

				if (solo) {
					gravidade = 0;
				} else {
					transform.Translate (Vector3.up * gravidade * Time.deltaTime);
				}			
			}

			if (DirecaoY () != 0) {
				controladorGravidade.modificarGravidade (ref gravidade,DirecaoX(),DirecaoY(), estado);
				solo = Physics2D.Raycast (transform.position , Vector2.right*Math.Sign(gravidade),4,linha);

				if (solo) {
					gravidade = 0;
				} else {
					transform.Translate (Vector3.right * gravidade * Time.deltaTime);
				}
			}

			calcularVelocidade ();

			if (detectSwipe) {
				DetectSwipe ();
			}
		}	
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
		if (coll.gameObject.CompareTag ("T")) {		
			Destroy (coll.gameObject);
			gameOver ();
		}

        if (coll.gameObject.CompareTag("platCima")) {
			if (DirecaoY () == 0 && DirecaoX() == 1) {				
				velocity.y = velocity.x;
				velocity.x = 0;
				estado = false;
			}

			if (DirecaoY () == 0 && DirecaoX() == -1) {
				velocity.y = -velocity.x;
				velocity.x = 0;
				estado = true;
			}

			controladorPlataformas.InicializarPlataformas();
			controladorMorte.AtualizarPosição (gameObject.transform.position);

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
			
			controladorGravidade.modificarGravidade (ref gravidade,DirecaoX(),DirecaoY(), estado);	

		}

		if (coll.gameObject.CompareTag("platBaixo")){        
			if (DirecaoY () == 0 && DirecaoX() == 1) {
				velocity.y = -velocity.x;
				velocity.x = 0;
				estado = false;
			}

			if (DirecaoY () == 0 && DirecaoX() == -1) {
				velocity.y = velocity.x;
				velocity.x = 0;
				estado = true;
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

			controladorGravidade.modificarGravidade (ref gravidade,DirecaoX(),DirecaoY(), estado);
		}

		if (coll.gameObject.CompareTag("platDireita"))		{
			if (DirecaoX () == 0 && DirecaoY() == 1) {
				velocity.x = velocity.y;
				velocity.y = 0;
				estado = false;
			}

			if (DirecaoX () == 0 && DirecaoY() == -1) {
				velocity.x = -velocity.y;
				velocity.y = 0;
				estado = true;
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
			controladorGravidade.modificarGravidade (ref gravidade,DirecaoX(),DirecaoY(), estado);
		}

		if (coll.gameObject.CompareTag("platEsquerda"))
		{
			if (DirecaoX () == 0 && DirecaoY() == 1) {
				velocity.x = -velocity.y;
				velocity.y = 0;
				estado = false;
			}

			if (DirecaoX () == 0 && DirecaoY() == -1) {
				velocity.x = velocity.y;
				velocity.y = 0;
				estado = true;
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

			controladorGravidade.modificarGravidade (ref gravidade,DirecaoX(),DirecaoY(), estado);
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

	public void DetectSwipe (){
		if (Input.touches.Length > 0) {
			Touch t = Input.GetTouch(0);

			if (t.phase == TouchPhase.Began) {
				firstPressPos = new Vector2(t.position.x, t.position.y);
			}

			if (t.phase == TouchPhase.Ended) {
				secondPressPos = new Vector2 (t.position.x, t.position.y);
				currentSwipe = new Vector3 (secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

				if (currentSwipe.magnitude < minSwipeLength) {
					swipeDirection = Swipe.None;
					return;
				}

				currentSwipe.Normalize ();

				//Swipe directional check
				if (DirecaoX () != 0) { 
					// Swipe up
					if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
						if (estado) {
							velocity = Vector3.up;
							detectSwipe = false;
						} else {
							estado = true;
						}

						controladorGravidade.modificarGravidade (ref gravidade, DirecaoX (), DirecaoY (), estado);
						swipeDirection = Swipe.Up;
						transform.position = new Vector2 (transform.position.x, transform.position.y + posicaoSwipe);
						controladorAudio.playMove ();

						// Swipe down
					} else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
						if (!estado) {
							velocity = Vector3.down;
							detectSwipe = false;
						} else {
							estado = false;
						}

						controladorGravidade.modificarGravidade (ref gravidade, DirecaoX (), DirecaoY (), estado);
						swipeDirection = Swipe.Down;
						transform.position = new Vector2 (transform.position.x, transform.position.y - posicaoSwipe);
						controladorAudio.playMove ();
					}
				}
				if (DirecaoY () != 0) {
					// Swipe left
					if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
						if (!estado) {
							velocity = Vector3.left;
							detectSwipe = false;
						} else {
							estado = false;
						}

						controladorGravidade.modificarGravidade (ref gravidade, DirecaoX (), DirecaoY (), estado);
						swipeDirection = Swipe.Left;
						transform.position = new Vector2 (transform.position.x - posicaoSwipe, transform.position.y);
						controladorAudio.playMove ();
					}

					// Swipe right
					else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
						if (estado) {
							velocity = Vector3.right;
							detectSwipe = false;
						} else {
							estado = true;
						}

						controladorGravidade.modificarGravidade (ref gravidade, DirecaoX (), DirecaoY (), estado);
						swipeDirection = Swipe.Right;
						transform.position = new Vector2 (transform.position.x + posicaoSwipe, transform.position.y);
						controladorAudio.playMove ();
					}
				}
			}

		} else {
			if (Input.GetMouseButtonDown(0)) {
				firstClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			} else {
				swipeDirection = Swipe.None;
			}

			if (Input.GetMouseButtonUp (0)){
				secondClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				currentSwipe = new Vector3(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);

				currentSwipe.Normalize();

				//Swipe directional check
                if(DirecaoX() != 0) { 
					// Swipe up
				    if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
						if (estado) {
							velocity = Vector3.up;
							detectSwipe = false;
						} else {
							estado = true;
						}
						controladorGravidade.modificarGravidade (ref gravidade, DirecaoX (), DirecaoY (), estado);

					    swipeDirection = Swipe.Up;
						transform.position = new Vector2 (transform.position.x, transform.position.y + posicaoSwipe);
						controladorAudio.playMove ();

				    // Swipe down
				    } else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
						if (!estado) {
							velocity = Vector3.down;
							detectSwipe = false;
						} else {
							estado = false;
						}
						controladorGravidade.modificarGravidade (ref gravidade, DirecaoX (), DirecaoY (), estado);

						swipeDirection = Swipe.Down;
						transform.position = new Vector2 (transform.position.x, transform.position.y - posicaoSwipe);
						controladorAudio.playMove ();
					}
				}
                if(DirecaoY() != 0) {
					// Swipe left
					if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
						if (!estado) {
							velocity = Vector3.left;
							detectSwipe = false;
						} else {
							estado = false;
						}

						controladorGravidade.modificarGravidade (ref gravidade, DirecaoX (), DirecaoY (), estado);

						swipeDirection = Swipe.Left;
						transform.position = new Vector2 (transform.position.x - posicaoSwipe, transform.position.y );
						controladorAudio.playMove ();
					}
					// Swipe right
					else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
						if (estado) {
							velocity = Vector3.right;
							detectSwipe = false;
						} else {
							estado = true;
						}

						controladorGravidade.modificarGravidade (ref gravidade, DirecaoX (), DirecaoY (), estado);

						swipeDirection = Swipe.Right;
						transform.position = new Vector2 (transform.position.x + posicaoSwipe, transform.position.y);
						controladorAudio.playMove ();
					}
                }
            }
		}
	}

	public Vector3 getPosicaoPlayer(){
		return gameObject.transform.position;
	}

	void verificarDistancia(){
		if(getIsAlive()){			
			if (Vector3.Distance(gameObject.transform.position, controladorMorte.gameObject.transform.position) > 20){	
				gameOver ();
			}				
		}
	}

	void gameOver(){
		
		PlayerPrefs.SetFloat ("Pontuacao", pontuacao);

		if (pontuacao > PlayerPrefs.GetFloat ("Recorde")) {
			PlayerPrefs.SetFloat ("Recorde", pontuacao);
		}

		controladorAudio.playGameOver ();
		velocity = Vector3.right;
		controladorGravidade.gravidade = -0.97f;
		estado = true;

		particula.maxParticles = 0;
		controladorMorte.transform.position = new Vector3(0,2,0);
		transform.position = new Vector3 (0,2,0);

		isAlive = false;
		SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
	}

	public bool getIsAlive(){
		return isAlive;
	}

	public void setIsAlive(bool isAlive){
		this.isAlive = isAlive;
		controladorPlataformas.continuePlataforma (controladorMorte.gameObject.transform.position);
	}
}