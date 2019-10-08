using System;
using System.Collections.Generic;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan your heist!");

            List<TeamMember> team = new List<TeamMember>();

            Console.Write("Bank Difficulty> ");
            int bankDifficulty = int.Parse(Console.ReadLine());

            //get first team member's name
            Console.Write("Name> ");
            string name = Console.ReadLine();

            while (name != "")
            {
                Console.Write("Skill Level> ");
                string skillLevel = (Console.ReadLine());

                Console.Write("Courage Factor> ");
                string courageFactor = (Console.ReadLine());

                TeamMember member = new TeamMember();
                member.Name = name;
                member.SkillLevel = int.Parse(skillLevel);
                member.CourageFactor = double.Parse(courageFactor);

                team.Add(member);

                Console.WriteLine();

                //get next team member's name
                Console.Write("Name> ");
                name = Console.ReadLine();

            }

            Console.WriteLine();
            Console.WriteLine("Number of runs> ");
            int trialRunCount = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int teamSkill = 0;
            foreach (TeamMember member in team)
            {
                teamSkill += member.SkillLevel;
            }
                
            HeistReport report = new HeistReport();

            for (int i = 0; i < trialRunCount; i++)
            {
                Random generator = new Random();
                int luckValue = generator.Next(-10, 11);

                int trialRunBankDifficulty = bankDifficulty + luckValue;

                Console.WriteLine($"Team skill level: {teamSkill}");
                Console.WriteLine($"Bank difficulty: {trialRunBankDifficulty}");

                if (trialRunBankDifficulty > teamSkill)
                {
                    Console.WriteLine("BUSTED!");
                    report.FailureCount++;
                }
                else
                {
                    Console.WriteLine("YOU RICH!");
                    report.SuccessCount++;
                }
            }

            report.Print();
        }
    }
}
        






