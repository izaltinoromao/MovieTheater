using MovieTheater.Shared.Data.DB;
using MovieTheater_Console;

Dictionary<string, MovieTheaterEntity> MovieTheaterDict = new();

var MovieTheaterEntityDAL = new MovieTheaterEntityDAL(new MovieTheaterContext());
var MovieEntityDAL = new MovieEntityDAL(new MovieTheaterContext());

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

    var movieEntityList = MovieEntityDAL.Read();

    foreach (var movieTheaterEntity in movieEntityList) Console.WriteLine(movieTheaterEntity);
}

void MovieTheaterGet()
{
    Console.Clear();
    Console.WriteLine("Listagem de cinemas\n");

    var movieTheaterEntityList = MovieTheaterEntityDAL.Read();

    foreach(var movieTheaterEntity in movieTheaterEntityList) Console.WriteLine(movieTheaterEntity);
}

void MovieRegister()
{
    Console.Clear();
    Console.WriteLine("Registro de Filmes\n");
    Console.Write("Digite o cinema onde o filme vai ser exibido: ");
    string movieTheaterName = Console.ReadLine();
    Console.Write($"Qual o nome do filme a ser exibido em {movieTheaterName}? ");
    string movieName = Console.ReadLine();
    Console.Write($"Qual a duração do filme {movieName}? ");
    int movieDuration = int.Parse(Console.ReadLine());

    MovieEntityDAL.Create(new MovieEntity(movieName, movieDuration));
    Console.WriteLine($"Filme {movieName} de {movieTheaterName} adicionado!");

}

void MovieTheaterRegister()
{
    Console.Clear();
    Console.WriteLine("Registro de cinemas\n");
    Console.Write("Digite o nome do cinema: ");
    string name = Console.ReadLine();
    Console.Write("Digite o endereço do cinema: ");
    string address = Console.ReadLine();

    MovieTheaterEntityDAL.Create(new MovieTheaterEntity(name, address));

    Console.WriteLine($"cinema {name} adicionado!");
}