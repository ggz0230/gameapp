using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    internal class Game
    {
        /// <summary>
        /// 行信息
        /// </summary>
        private List<int> _lines = new List<int>();

        /// <summary>
        /// 玩家信息
        /// </summary>
        private List<Player> _players = new List<Player>();

        /// <summary>
        /// 初始化游戏行列规则
        /// </summary>
        /// <param name="lines"></param>
        public Game(params int[] lines)
        {
            foreach (var item in lines)
            {
                _lines.Add(item);
            }
        }

        /// <summary>
        /// 开始玩游戏
        /// </summary>
        /// <param name="playerNames">玩家们姓名 姓名不可重复</param>
        /// <returns>输家</returns>
        public string StartGame(params string[] playerNames)
        {
            if (playerNames.Distinct().Count() != playerNames.Count())
            {
                throw new Exception("请勿输入重复的玩家");
            }
            Random r = new Random();

            //玩家随机排序 越靠前越先拿牙签 同时随机决定拿第几行
            _players = playerNames.OrderBy(q => Guid.NewGuid()).Select(q => new Player()
            {
                LineNo = r.Next(0, _lines.Count),
                Name = q
            }).ToList();

            PlayGame(_players);
            Console.WriteLine("行信息： " + string.Join(",", _lines));
            Console.WriteLine("玩家信息：" + JsonConvert.SerializeObject(_players));

            int maxPlayNum = _players.Max(q => q.PlayNum); //获取玩家们最大的场次
            return _players.LastOrDefault(q => q.PlayNum == maxPlayNum).Name;
        }

        /// <summary>
        /// 每一轮的开始 玩游戏 递归
        /// </summary>
        public void PlayGame(List<Player> players)
        {
            Console.WriteLine("行信息： " + string.Join(",", _lines));
            Console.WriteLine("玩家信息：" + JsonConvert.SerializeObject(players));
            Console.WriteLine("-------------------");
            foreach (Player player in players)
            {
                if (_lines[player.LineNo] != 0)
                {
                    player.PlayNum++;
                    _lines[player.LineNo]--;
                }
            }
            players = players.Where(q => _lines[q.LineNo] != 0).ToList();
            if (players.Count >= 1)
            {
                PlayGame(players);
            }
        }

    }

}
