using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GenerateHeroData
{
    class Program
    {
        static void Main(string[] args)
        {
            // 英雄名称列表
            var heroNames = new List<string>
            {
                "崔三娘", "顾清寒", "哈迪", "胡桃", "胡为", "季莹莹", "济沧海", "迦南",
                "蓝梦", "李寻欢", "刘炼", "宁红叶", "沈妙", "特木尔", "天海", "万钧",
                "魏轻", "无尘", "武田信忠", "席拉", "妖刀姬", "殷紫萍", "玉玲珑", "岳山", "张起灵"
            };

            // 游戏模式
            var gameModes = new[] { 0, 1 }; // 0: 排位赛, 1: 快速比赛

            // 团队规模
            var teamSizes = new[] { 1, 2, 3 }; // 1: 单排, 2: 双排, 3: 三排

            // 赛季类型
            var seasonTypes = new[] { 0, 1, 2, 3 }; // 0: 所有赛季, 1: 当前赛季, 2: 第18赛季·侠风, 3: 第17赛季·裂变

            var heroDataList = new List<HeroDataModel>();

            // 为每个英雄生成数据
            for (int heroIndex = 0; heroIndex < heroNames.Count; heroIndex++)
            {
                var heroName = heroNames[heroIndex];
                
                // 为每个游戏模式生成数据
                foreach (var gameMode in gameModes)
                {
                    // 为每个团队规模生成数据
                    foreach (var teamSize in teamSizes)
                    {
                        // 为每个赛季类型生成数据
                        foreach (var seasonType in seasonTypes)
                        {
                            // 基于英雄索引、游戏模式、团队规模和赛季类型生成随机种子，确保相同参数生成相同数据
                            int seed = heroIndex * 1000 + gameMode * 100 + teamSize * 10 + seasonType;
                            var random = new Random(seed);

                            // 生成随机游戏时间（小时）
                            double gameTime;
                            if (heroIndex == 24 && gameMode == 0 && teamSize == 2) // 特殊处理张起灵的数据，保留现有值
                            {
                                if (seasonType == 0) gameTime = 4;
                                else if (seasonType == 1) gameTime = 381;
                                else if (seasonType == 2) gameTime = 78;
                                else gameTime = 94;
                            }
                            else
                            {
                                gameTime = random.NextDouble() * 500; // 0-500小时
                            }

                            // 生成英雄分数
                            int heroScore = (int)(gameTime * 10);
                            if (heroScore > 4000) heroScore = 4000;
                            if (heroIndex == 24 && gameMode == 0 && teamSize == 2) // 特殊处理张起灵的数据，保留现有值
                            {
                                heroScore = 4077;
                            }

                            // 生成排名描述
                            string rankDescription;
                            if (heroScore > 3500)
                            {
                                rankDescription = $"衡阳市第十{heroName}，距离湖南省榜还差{4000 - heroScore}分";
                            }
                            else if (heroScore > 2000)
                            {
                                rankDescription = $"距离衡阳市榜还差{4000 - heroScore}分";
                            }
                            else if (heroScore > 1000)
                            {
                                rankDescription = $"距离蒸湘区榜还差{2000 - heroScore}分";
                            }
                            else
                            {
                                rankDescription = "";
                            }

                            // 生成历史最高排名
                            string historicalHighestRank;
                            if (heroScore > 3000 && random.NextDouble() > 0.5)
                            {
                                historicalHighestRank = $"湖南省第{random.Next(1, 100)}名";
                            }
                            else if (heroScore > 2000 && random.NextDouble() > 0.7)
                            {
                                historicalHighestRank = $"衡阳市第{random.Next(1, 50)}名";
                            }
                            else
                            {
                                historicalHighestRank = "";
                            }

                            // 生成最近12场比赛数据
                            var recent12Games = new Recent12GamesData
                            {
                                TopFiveRate = Math.Round(random.NextDouble() * 50, 1),
                                AverageDamage = random.Next(5000, 15000),
                                KillDeathRatio = Math.Round(random.NextDouble() * 3, 2),
                                IsTop1_5Percent = random.NextDouble() > 0.985
                            };

                            // 生成所有比赛数据
                            var allGames = new AllGamesData
                            {
                                TopFiveRate = Math.Round(random.NextDouble() * 50, 1),
                                ChampionRate = Math.Round(random.NextDouble() * 20, 1),
                                WinCount = (int)(gameTime / 10),
                                AverageDamage = random.Next(5000, 15000),
                                MaxDamagePerGame = random.Next(20000, 60000),
                                AverageHeal = random.Next(3000, 10000),
                                TotalEliminations = (int)(gameTime * 10),
                                KillDeathRatio = Math.Round(random.NextDouble() * 3, 2),
                                MaxKillsPerGame = random.Next(10, 30),
                                AverageKills = Math.Round(random.NextDouble() * 5, 2),
                                TotalKills = (int)(gameTime * 10)
                            };
                            
                            // 生成特殊技能数据
                            var specialSkill = new SpecialSkillData
                            {
                                SkillName = $"{heroName}特殊技能命中次数",
                                SkillEffectData = (int)(gameTime * 20),
                                AverageData = Math.Round(random.NextDouble() * 20, 2)
                            };
                            
                            // 创建英雄数据模型
                            var heroData = new HeroDataModel
                            {
                                HeroIndex = heroIndex,
                                GameMode = gameMode,
                                TeamSize = teamSize,
                                SeasonType = seasonType,
                                GameTime = gameTime,
                                HeroScore = heroScore,
                                RankDescription = rankDescription,
                                HistoricalHighestRank = historicalHighestRank,
                                Recent12Games = recent12Games,
                                AllGames = allGames,
                                SpecialSkill = specialSkill
                            };
                            
                            heroDataList.Add(heroData);
                        }
                    }
                }
            }

            // 将数据写入JSON文件
            var json = JsonConvert.SerializeObject(heroDataList, Formatting.Indented);
            File.WriteAllText(@"..\NarakaBladepoint.Shared\Datas\Jsons\HeroDataModel.json", json);

            Console.WriteLine($"生成了 {heroDataList.Count} 条英雄数据");
        }
    }

    // 数据模型类定义
    public class HeroDataModel
    {
        public int HeroIndex { get; set; }
        public int GameMode { get; set; }
        public int TeamSize { get; set; }
        public int SeasonType { get; set; }
        public double GameTime { get; set; }
        public int HeroScore { get; set; }
        public string RankDescription { get; set; }
        public string HistoricalHighestRank { get; set; }
        public Recent12GamesData Recent12Games { get; set; }
        public AllGamesData AllGames { get; set; }
        public SpecialSkillData SpecialSkill { get; set; }
    }

    public class Recent12GamesData
    {
        public double TopFiveRate { get; set; }
        public int AverageDamage { get; set; }
        public double KillDeathRatio { get; set; }
        public bool IsTop1_5Percent { get; set; }
    }

    public class AllGamesData
    {
        public double TopFiveRate { get; set; }
        public double ChampionRate { get; set; }
        public int WinCount { get; set; }
        public int AverageDamage { get; set; }
        public int MaxDamagePerGame { get; set; }
        public int AverageHeal { get; set; }
        public int TotalEliminations { get; set; }
        public double KillDeathRatio { get; set; }
        public int MaxKillsPerGame { get; set; }
        public double AverageKills { get; set; }
        public int TotalKills { get; set; }
    }

    public class SpecialSkillData
    {
        public string SkillName { get; set; }
        public int SkillEffectData { get; set; }
        public double AverageData { get; set; }
    }
}
