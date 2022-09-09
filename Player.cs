using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    /// <summary>
    /// 玩家
    /// </summary>
    internal class Player
    {
        /// <summary>
        /// 玩家姓名 唯一标识
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 第几行
        /// </summary>
        public int LineNo { get; set; }

        /// <summary>
        /// 游戏场次
        /// </summary>
        public int PlayNum { get; set; }
    }

}
