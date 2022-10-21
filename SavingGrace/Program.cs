using System.IO;
using System.Text.Json;


string file = "skill.json";
File.Exists(file);
Skill skill;
if (File.Exists(file)) {
    skill = JsonSerializer.Deserialize<Skill>(File.ReadAllText(file));
} else {
    skill = new Skill();
}

Skill skills = new Skill();

ChooseSkill();
void ChooseSkill() {
    Console.Clear();
    Console.WriteLine("Welcome! \n(1) Create a new skill \n(2) Load an already existing skill");
    string choice = Console.ReadLine();
    Console.Clear();
    if(choice == "1") {
        Console.WriteLine("Are you sure? \nThis will delete the previous skill \nPress (Y) to continue");
        choice = Console.ReadLine().ToLower();
        if(choice == "y") {
            Console.Clear();
            Console.WriteLine("What is the skills name?");
            skill.name = Console.ReadLine();

            Console.WriteLine("What is the skills ability?");
            skill.ability = Console.ReadLine();

            Console.WriteLine("What is the skills cooldown?");
            skill.time = Console.ReadLine();
            string json = JsonSerializer.Serialize<Skill>(skill);
            File.WriteAllText(file, json);
        } else {
            ChooseSkill();
        }
    
    } else if(choice == "2") {
        if(skill.name != null && skill.ability != null && skill.time != null) {
            Console.WriteLine($"Skill name: {skill.name} \nSkill ability : {skill.ability} \nSkill cooldown: {skill.time}");
            Console.ReadLine();
   
        } else {
            ChooseSkill();
        }
    } else {
        ChooseSkill();
    }
}

