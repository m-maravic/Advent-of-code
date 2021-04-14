using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputList = File.ReadAllLines(@"D:\Advent of code\Advent-of-code\AdventOfCode2020\Day8\input.txt");
            List<Command> commandsList = GetCommandsList(inputList);

            RunCommands(commandsList);

            Console.ReadLine();
        }

        public static void RunCommands(List<Command> commandsList)
        {
            int timeToStop = 0;
            int index = 0;
            int accumulator = 0;
            int jmpChangeIndex = 0;
            int nopeChangeIndex = 0;
            int value = 0;

            List<Command> commandListCopy = commandsList;

            while (timeToStop == 0)
            {
                Console.WriteLine("Running: {0} {1}{2}", commandsList[index].CommandName, commandsList[index].Operation, commandsList[index].Value);
                value = commandsList[index].Operation == "+" ? commandsList[index].Value : -commandsList[index].Value;

                switch (commandsList[index].CommandName)
                {
                    case "acc":
                        accumulator += value;
                        commandsList[index].Done = true;
                        index += 1;
                        break;
                    case "jmp":
                        commandsList[index].Done = true;
                        index += value;
                        break;
                    case "nop": 
                        commandsList[index].Done = true;
                        index += 1;
                        break;
                }

                Console.WriteLine("acc = " + accumulator);

                if (commandsList.Count <= index)
                {
                    timeToStop = 1;
                    continue;
                }

                if (commandsList[index].Done == true) 
                {
                    List<Command> listJmp = commandsList.Where(c => c.CommandName == "jmp").ToList();
                   
                    if (jmpChangeIndex < listJmp.Count())
                    {
                        if (jmpChangeIndex > 0) 
                        {
                            Command temp = commandsList.Where(c => c.ChangedName == true).FirstOrDefault();
                            temp.ChangedName = false;
                            temp.CommandName = "jmp";
                        }

                        listJmp[jmpChangeIndex].CommandName = "nop";
                        listJmp[jmpChangeIndex].ChangedName = true;

                        jmpChangeIndex++;

                        commandsList.ForEach(c => c.Done = false);
                        accumulator = 0;
                        index = 0;
                        Console.WriteLine("-----------------------------");
                    }
                    else
                    {
                        List<Command> listNope = commandsList.Where(c => c.CommandName == "nop").ToList();
                        accumulator = 0;
                        index = 0;

                        if (nopeChangeIndex < listNope.Count())
                        {
                            if (listNope[nopeChangeIndex].Value != 0)
                            {
                                if (nopeChangeIndex > 0)
                                {
                                    Command temp = commandsList.Where(c => c.ChangedName == true).FirstOrDefault();
                                    temp.ChangedName = false;
                                    temp.CommandName = "nop";
                                }

                                listNope[nopeChangeIndex].CommandName = "jmp";
                                listNope[nopeChangeIndex].ChangedName = true;

                                nopeChangeIndex++;

                                commandsList.ForEach(c => c.Done = false);
                                Console.WriteLine("-----------------------------");
                            }
                        }
                    }
                }
            }

            Console.WriteLine(accumulator);
        }

        static List<Command> GetCommandsList(string[] input)
        {
            List<Command> commands = new List<Command>();
            Regex regex = new Regex(@"(?<name>(\w{3})) (?<operation>(\W{1}))(?<value>(\d*))", RegexOptions.Compiled);

            foreach(string inputLine in input)
            {
                MatchCollection matches = Regex.Matches(inputLine, regex.ToString());
                Command command = new Command
                {
                    CommandName = matches[0].Groups["name"].Value,
                    Operation = matches[0].Groups["operation"].Value,
                    Value = Int32.Parse(matches[0].Groups["value"].Value)
                };

                commands.Add(command);
            }

            return commands;
        }


    }
}
