using MovieTheater_Console;

Dictionary<string, MovieTheater> MovieTheaterDict = new();

bool exit = false;
while (!exit)
{
    Console.WriteLine("Bem vindo a Movie Theater chooser!\n");
    Console.WriteLine("Digite 1 para registrar um cinema");
    Console.WriteLine("Digite 2 para registrar um filme no cinema");
    Console.WriteLine("Digite 3 para mostrar todos os cinemas");
    Console.WriteLine("Digite 4 para mostrar os filmes de um cinema");
    Console.WriteLine("Digite -1 para sair\n");

    Console.Write("Digite sua opção: ");
    int option = int.Parse(Console.ReadLine());

    switch (option)
    {
        case 1:
            MovieTheaterRegister();
            break;
        case 2:
            MovieRegister();
            break;
        case 3:
            MovieTheaterGet();
            break;
        case 4:
            MovieGet();
            break;
        case -1:
            Console.WriteLine("Tchau, obrigado!");
            exit = true;
            break;
        default:
            Console.WriteLine("Escolha inválida");
            break;
    }
    Thread.Sleep(1500);
    Console.Clear();
}

void MovieGet()
{
    Console.Clear();
    Console.WriteLine("Listagem de filme\n");
    Console.Write("Digite o cinema cujo filmes você quer listar: ");
    string movieTheaterName = Console.ReadLine();
    if (MovieTheaterDict.ContainsKey(movieTheaterName))
    {
        MovieTheater movieTheater = MovieTheaterDict[movieTheaterName];
        movieTheater.ShowMovies();
    }
    else Console.WriteLine($"Cinema {movieTheaterName} não encontrado");
}

void MovieTheaterGet()
{
    Console.Clear();
    Console.WriteLine("Listagem de cinemas\n");
    foreach (var movieTheaters in MovieTheaterDict.Values)
    {
        Console.WriteLine(movieTheaters);
    }
}

void MovieRegister()
{
    Console.Clear();
    Console.WriteLine("Registro de Filmes\n");
    Console.Write("Digite o cinema onde o filme vai ser exibido: ");
    string movieTheaterName = Console.ReadLine();
    if (MovieTheaterDict.ContainsKey(movieTheaterName))
    {
        Console.Write($"Qual o nome do filme a ser exibido em {movieTheaterName}? ");
        string movieName = Console.ReadLine();
        MovieTheater movieTheater = MovieTheaterDict[movieTheaterName];
        movieTheater.AddMovie(new Movie(movieName));
        Console.WriteLine($"Filme {movieName} de {movieTheaterName} adicionado!");
    }
    else Console.WriteLine($"Cinema {movieTheaterName} não encontrado");
}

void MovieTheaterRegister()
{
    Console.Clear();
    Console.WriteLine("Registro de cinemas\n");
    Console.Write("Digite o nome do cinema: ");
    string name = Console.ReadLine();
    Console.Write("Digite o endereço do cinema: ");
    string address = Console.ReadLine();
    MovieTheater movieTheater = new MovieTheater(name, address);
    MovieTheaterDict.Add(name, movieTheater);
    Console.WriteLine($"cinema {name} adicionado!");
}