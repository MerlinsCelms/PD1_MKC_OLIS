OlasSitejs3000 - Ping Pong Spēle (C# WinForms)
________________________________________
1. Projekta pārskats
Projekta nosaukums: OlasSitejs3000
Valoda: C# (.NET Framework vai .NET 6+, WinForms)
Mērķis:
•	Vienkārša Ping Pong (Pong) spēle ar OOP dizainu.
•	Labās puses paddle kontrolēta ar ↑/↓ taustiņiem.
•	Kreisās puses paddle kontrolē AI.
•	Bumba attēlota ar Martins.png (20x20) no Resources.
•	Lietotāja vārds tiek pieprasīts pirms spēles sākuma.
•	Rezultāts saglabāts HighScores.txt.
•	Spēle beidzas, kad kāds spēlētājs sasniedz 10 punktus.
________________________________________
2. Klases un to apraksts
2.1 Form1
Mērķis: Galvenā forma, kas kontrolē UI, taustiņu ievadi, spēles cilpu un rezultātu saglabāšanu.
Īpašība / Metode	Tips	Apraksts
GameEngine game	GameEngine	Spēles loģikas dzinējs
bool moveUp	bool	Vai labais paddle kustas uz augšu
bool moveDown	bool	Vai labais paddle kustas uz leju
Timer gameTimer	Timer	Laika cilpa spēles atjaunošanai (~50 FPS)
string playerName	string	Lietotāja ievadītais vārds
GameLoop()	void	Galvenā cilpa: pārvieto paddle, atjauno spēli, pārbauda beigas
DrawGame()	void	Izsauc game.Draw() zīmēšanai
KeyIsDown/KeyIsUp()	void	Kontrolē paddle kustību ar taustiņiem ↑/↓
SaveScore(string name, int score)	void	Saglabā spēlētāja vārdu un rezultātu txt failā
2.2 NameForm
Mērķis: Custom dialog forma lietotāja vārda ievadei.
Īpašība / Metode	Apraksts
string PlayerName	Saglabā lietotāja ievadīto vārdu
Konstruktorā NameForm()	Izveido Label, TextBox un OK pogu; validē ievadi
2.3 GameEngine
Mērķis: Spēles loģikas pārvaldība.
Īpašība	Tips	Apraksts
Paddle RightPaddle	Paddle	Labais paddle (spēlētājs)
Paddle LeftPaddle	Paddle	Kreisais paddle (AI)
Ball Ball	Ball	Spēles bumba
int RightScore	int	Labā spēlētāja punkti
int LeftScore	int	Kreisā AI punkti
bool GameOver	bool	Spēles beigu stāvoklis
Svarīgākās metodes: - Reset() - Update() - Draw(Graphics g) - ResetBall() - MoveLeftPaddle()
2.4 GameObject (abstract)
Mērķis: Abstrakta klase, no kuras manto Paddle un Ball.
Īpašība	Apraksts
Point Position	Augšējā kreisā stūra pozīcija
Size Size	Platums un augstums
Rectangle Bounds	Ģenerē taisnstūra formu no Position un Size
Metodes: Draw(Graphics g, Brush brush)
2.5 Paddle
Mērķis: Spēlētāja vai AI paddle, nodrošina vertikālu kustību.
Metodes: - MoveUp() - MoveDown(int screenHeight)
2.6 Ball
Mērķis: Bumba, kas pārvietojas, atsitās pret sienām un paddle.
Metodes: - Move() - BounceX() - BounceY() - ResetSpeed() - Draw(Graphics g) — attēls Martins.png
________________________________________
3. Resursi
•	Martins.png — bumba (20x20 px, Resources)
•	HighScores.txt — saglabā spēlētāja vārdu, rezultātu, grūtības līmeni un datumu
________________________________________
4. Spēles gaita
1.	Dialoga logā ievada vārdu.
2.	Spēle sākas ar bumbu centrā un diviem paddle.
3.	Spēlētājs kontrolē labo paddle ar ↑/↓.
4.	AI pārvieto kreiso paddle.
5.	Bumba atsitās pret paddle un sienām.
6.	Ja bumba iziet no ekrāna, piešķir punktu otram spēlētājam.
7.	Spēle beidzas, kad kāds sasniedz 10 punktus.
8.	Rezultāts saglabāts HighScores.txt.
________________________________________
5. OOP principi
Princips	Kā tas ir izmantots
Abstrakcija	GameObject nosaka kopīgas īpašības un metodes
Encapsulation	Paddle un Ball pārvalda savas pozīcijas, izmērus un kustību
Inheritance	Paddle un Ball manto no GameObject
Polymorphism	Draw() metode pārrakstīta Ball klasē, lai izmantotu attēlu
Single Responsibility	GameEngine atbild par spēles loģiku, Form1 — UI un ievadi, NameForm — vārda ievade
________________________________________
6. Kā palaist
1.	Atveriet projektu Visual Studio.
2.	Pievienojiet Martins.png Resources.
3.	Saglabājiet klases (Form1, NameForm, GameEngine, GameObject, Paddle, Ball, PauseMenuForm, DifficultyForm).
4.	Uzstādiet C# 7.3 vai jaunāku.
5.	Palaidiet (F5).
6.	Ievadiet savu vārdu dialogā.
7.	Izvēlieties grūtības līmeni (Easy, Normal, Insane).
8.	Spēlējiet labo paddle ar ↑/↓.
9.	Kad spēle beidzas, rezultāts tiek saglabāts HighScores.txt.
________________________________________
7. Diagrammas un hierarhija
•	Form1 → izmanto → GameEngine
•	GameEngine → satur → Ball, RightPaddle, LeftPaddle
•	Ball, Paddle → manto no → GameObject
•	Dialoga formas: NameForm, DifficultyForm, PauseMenuForm → komunicē ar Form1
