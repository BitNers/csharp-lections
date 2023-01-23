using LINQ;
using System;
using System.Collections.Generic;
using System.Linq;

List<string> Naipes = new List<string>() {
    "Paus",
    "Ouro",
    "Copas",
    "Espadas"
};


/*
    LINQ em Query
 */

var resultadoQuery = from np in Naipes
                where np.Contains("a") 
                select new { Naipe = np };

foreach (var item in resultadoQuery)
{ 
    Console.WriteLine(item);
}


/*
    LINQ em Métodos
 */


var resultadoMetodos = Naipes.Where(np => np.Contains("a")).ToList();
foreach (var item in resultadoQuery)
{
    Console.WriteLine(item);
}



/*
    Usando EntityFramework + DbContext
 */

UsingDbContext.RegisterUser("Wesley", "wesley@silva.com");
UsingDbContext.RegisterUser("Diego", "diego@silva.com");

var AllUsers = UsingDbContext.GetAllUsers();

foreach (var item in AllUsers)
{
    Console.WriteLine($"Nome: {item.Name} // E-mail: {item.Email} \n");
}


UsingDbContext.AdicionarNovoAluno("João");
UsingDbContext.AdicionarAlunoEmRedes(3, "Banco de Dados");