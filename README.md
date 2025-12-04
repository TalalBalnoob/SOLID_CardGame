CardGame

A tiny object-oriented card battle engine written in C# as a practice prject For the SOLID principles.
Monsters punch each other. Players pretend they have strategy. Life is good.

Features

Fully OOP design 

Card Factory + Card Library system

Deck/Hand/Board system

Game Engine that controls turn flow

Cloning templates for unlimited duplicates

Attack, damage, heal, and board slots

Project Structure
CardGame/
 ├── Cards/
 │    ├── BaseCard.cs
 │    ├── RegularMonsterCard.cs
 │    ├── CardFactory.cs
 │    ├── CardLibrary.cs
 │    └── ...
 ├── Player/
 │    ├── Player.cs
 │    ├── Deck.cs
 │    ├── Hand.cs
 │    └── ...
 ├── Game/
 │    ├── GameEngine.cs
 │    └── GameBoard.cs
 └── Program.cs

How It Works

CardLibrary.Init() loads all card templates.

GameEngine initializes players, decks, hands, and boards.

Players draw cards, play cards, and smash each other’s monsters.

When something dies—you remove it. No funerals.

Example Startup
CardLibrary.Init();
var engine = new GameEngine(new IPlayer[] {
    new Player("Player 1"),
    new Player("Player 2")
});

engine.StartGame();

Console.WriteLine(engine.Players[0].Hand);
Console.WriteLine(engine.Players[1].Hand);

Requirements

.NET 8+

A brain cell or two

Preferably coffee

License

You own it. Do whatever you want.
If it breaks, that's on you.
