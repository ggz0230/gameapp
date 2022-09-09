// See https://aka.ms/new-console-template for more information

using GameApp;


Game game = new Game(3, 5, 7);
string result = game.StartGame("小明", "老李");

Console.WriteLine("输家：" + result);

