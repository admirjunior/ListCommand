using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Command
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> Options { get; set; }
    public string Example { get; set; }
}

class CommandData
{
    public List<Command> Git { get; set; }
    public List<Command> Linux { get; set; }
    public List<Command> Node { get; set; }
    public List<Command> Puppeteer { get; set; }
    public List<Command> Javascript { get; set; }
    public List<Command> Docker { get; set; } // Nova propriedade para comandos Docker
}

class Program
{
    static readonly string jsonFilePath = "commands.json";

    static CommandData InitializeData()
    {
        return new CommandData
        {
            Git = new List<Command>
            {
                new Command { Name = "git init", Description = "Inicializa um novo repositório Git", Options = new List<string> { "--bare", "--quiet" }, Example = "git init" },
                new Command { Name = "git clone", Description = "Clona um repositório existente", Options = new List<string> { "--branch <nome>", "--depth <n>" }, Example = "git clone https://github.com/user/repo.git" },
                new Command { Name = "git status", Description = "Exibe o status do repositório", Options = new List<string> { "-s (status simples)", "-uno (sem exibir arquivos não rastreados)" }, Example = "git status" },
                new Command { Name = "git commit", Description = "Grava as alterações no repositório", Options = new List<string> { "-m <mensagem>", "--amend" }, Example = "git commit -m 'Mensagem do commit'" },
                new Command { Name = "git push", Description = "Envio de alterações para o repositório remoto", Options = new List<string> { "origin", "master", "--force" }, Example = "git push origin master" },
                new Command { Name = "git pull", Description = "Baixa alterações do repositório remoto", Options = new List<string> { "origin", "master" }, Example = "git pull origin master" }
            },
            Linux = new List<Command>
            {
                new Command { Name = "ls", Description = "Lista arquivos e diretórios", Options = new List<string> { "-l", "-a", "-lh" }, Example = "ls -la" },
                new Command { Name = "chmod", Description = "Altera permissões de arquivos", Options = new List<string> { "+x (executável)", "-R (recursivo)" }, Example = "chmod +x script.sh" },
                new Command { Name = "cd", Description = "Muda o diretório atual", Options = new List<string> { "<diretório>" }, Example = "cd /home/user" },
                new Command { Name = "pwd", Description = "Exibe o diretório atual", Options = new List<string> { }, Example = "pwd" },
                new Command { Name = "cp", Description = "Copia arquivos ou diretórios", Options = new List<string> { "-r (recursivo)", "-v (verbose)" }, Example = "cp -r dir1 dir2" },
                new Command { Name = "rm", Description = "Remove arquivos ou diretórios", Options = new List<string> { "-r (recursivo)", "-f (força)" }, Example = "rm -rf /path/to/dir" },
                new Command { Name = "mv", Description = "Move ou renomeia arquivos ou diretórios", Options = new List<string> { }, Example = "mv file1.txt file2.txt" }
            },
            Node = new List<Command>
            {
                new Command { Name = "fs.readFile", Description = "Lê o conteúdo de um arquivo", Options = new List<string> { "path", "encoding", "callback" }, Example = "fs.readFile('file.txt', 'utf8', (err, data) => {...})" },
                new Command { Name = "http.createServer", Description = "Cria um servidor HTTP", Options = new List<string> { "requestListener" }, Example = "http.createServer((req, res) => {...}).listen(3000)" },
                new Command { Name = "require", Description = "Carrega módulos no Node.js", Options = new List<string> { "<module>" }, Example = "const fs = require('fs');" },
                new Command { Name = "setInterval", Description = "Executa uma função em intervalos definidos", Options = new List<string> { "callback", "intervalo" }, Example = "setInterval(() => { console.log('Tick'); }, 1000);" },
                new Command { Name = "setTimeout", Description = "Executa uma função após um tempo definido", Options = new List<string> { "callback", "tempo" }, Example = "setTimeout(() => { console.log('Done'); }, 2000);" }
            },
            Puppeteer = new List<Command>
            {
                new Command { Name = "puppeteer.launch", Description = "Inicia uma instância do navegador", Options = new List<string> { "headless: true", "args: ['--no-sandbox']" }, Example = "const browser = await puppeteer.launch()" },
                new Command { Name = "page.goto", Description = "Navega para uma URL", Options = new List<string> { "waitUntil: 'networkidle0'", "timeout" }, Example = "await page.goto('https://example.com')" },
                new Command { Name = "page.type", Description = "Digita um texto em um campo", Options = new List<string> { "selector", "text", "options" }, Example = "await page.type('#input', 'Hello World')" },
                new Command { Name = "page.click", Description = "Clica em um botão ou link", Options = new List<string> { "selector", "options" }, Example = "await page.click('#submitButton')" },
                new Command { Name = "browser.close", Description = "Fecha o navegador", Options = new List<string> { }, Example = "await browser.close();" }
            },
            Javascript = new List<Command>
            {
                new Command { Name = "Array.map", Description = "Cria um novo array com os resultados de uma função", Options = new List<string> { "callback", "thisArg" }, Example = "[1, 2, 3].map(x => x * 2)" },
                new Command { Name = "console.log", Description = "Exibe uma mensagem no console", Options = new List<string> { "obj1, obj2, ..." }, Example = "console.log('Hello', 42)" },
                new Command { Name = "setTimeout", Description = "Executa uma função após um tempo", Options = new List<string> { "callback", "delay" }, Example = "setTimeout(() => { console.log('Hello!'); }, 1000);" },
                new Command { Name = "setInterval", Description = "Executa uma função repetidamente em intervalos", Options = new List<string> { "callback", "intervalo" }, Example = "setInterval(() => { console.log('Tick'); }, 1000);" },
                new Command { Name = "Object.keys", Description = "Retorna as chaves de um objeto", Options = new List<string> { "objeto" }, Example = "Object.keys({a: 1, b: 2})" },
                new Command { Name = "JSON.stringify", Description = "Converte um valor JavaScript para uma string JSON", Options = new List<string> { "valor", "replacer", "space" }, Example = "JSON.stringify({name: 'John'})" }
            },
            Docker = new List<Command> // Nova seção para comandos Docker
            {
                new Command { Name = "docker run", Description = "Executa um container a partir de uma imagem", Options = new List<string> { "-d (detached)", "-p <host:container>", "--name <nome>" }, Example = "docker run -d -p 8080:80 nginx" },
                new Command { Name = "docker build", Description = "Constrói uma imagem a partir de um Dockerfile", Options = new List<string> { "-t <tag>", "--build-arg <key=value>" }, Example = "docker build -t my-app:latest ." },
                new Command { Name = "docker ps", Description = "Lista os containers em execução", Options = new List<string> { "-a (todos)", "-q (somente IDs)" }, Example = "docker ps -a" },
                new Command { Name = "docker stop", Description = "Para um container em execução", Options = new List<string> { "<container-id/nome>" }, Example = "docker stop my-container" },
                new Command { Name = "docker rm", Description = "Remove um container", Options = new List<string> { "-f (forçar)", "<container-id/nome>" }, Example = "docker rm -f my-container" },
                new Command { Name = "docker images", Description = "Lista as imagens disponíveis", Options = new List<string> { "-a (todos)", "--filter" }, Example = "docker images" },
                new Command { Name = "docker pull", Description = "Baixa uma imagem do Docker Hub", Options = new List<string> { "<imagem:tag>" }, Example = "docker pull ubuntu:20.04" }
            }
        };
    }

    static void CreateJsonFile()
    {
        if (!File.Exists(jsonFilePath))
        {
            var data = InitializeData();
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, jsonString);
            Console.WriteLine($"Arquivo JSON criado em: {Path.GetFullPath(jsonFilePath)}");
        }
    }

    static CommandData LoadJsonFile()
    {
        if (File.Exists(jsonFilePath))
        {
            string jsonString = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<CommandData>(jsonString);
        }
        throw new FileNotFoundException("O arquivo JSON não foi encontrado!");
    }

    static void Main(string[] args)
    {
        CreateJsonFile(); // Cria o JSON na primeira execução
        var commandData = LoadJsonFile(); // Carrega os dados do JSON

        while (true)
        {
            Console.Clear();
            ShowMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": ListCommands(commandData.Git, "Comandos Git"); break;
                case "2": ListCommands(commandData.Linux, "Comandos Linux"); break;
                case "3": ListCommands(commandData.Node, "Funções Node.js"); break;
                case "4": ListCommands(commandData.Puppeteer, "Métodos Puppeteer"); break;
                case "5": ListCommands(commandData.Javascript, "Funções JavaScript"); break;
                case "6": ListCommands(commandData.Docker, "Comandos Docker"); break; // Nova opção para Docker
                case "7": Console.WriteLine("Saindo..."); return;
                default: Console.WriteLine("Opção inválida! Pressione Enter..."); break;
            }
            Console.ReadLine();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("=== Lista de Comandos e Funções ===");
        Console.WriteLine("1. Listar comandos Git");
        Console.WriteLine("2. Listar comandos Linux");
        Console.WriteLine("3. Listar funções Node.js");
        Console.WriteLine("4. Listar métodos Puppeteer");
        Console.WriteLine("5. Listar funções JavaScript");
        Console.WriteLine("6. Listar comandos Docker"); // Nova opção no menu
        Console.WriteLine("7. Sair");
        Console.Write("Escolha uma opção: ");
    }

    static void ListCommands(List<Command> commands, string title)
    {
        Console.Clear();
        Console.WriteLine($"=== {title} ===");
        Console.WriteLine();

        foreach (var command in commands)
        {
            Console.WriteLine($"Nome: {command.Name}");
            Console.WriteLine($"Descrição: {command.Description}");
            Console.WriteLine("Opções:");
            foreach (var option in command.Options)
            {
                Console.WriteLine($"  - {option}");
            }
            Console.WriteLine($"Exemplo: {command.Example}");
            Console.WriteLine(new string('-', 50));
        }

        Console.WriteLine("Pressione Enter para voltar ao menu...");
    }
}