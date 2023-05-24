using EmpleadosDep.UAPI;
using EmpleadosDep.Modelos;

var uapi = new Crud<Departamento>();
/*
var departamentos = uapi.Select("https://localhost:7119/api/Departamentos");
var departamento = uapi.Select_ById("https://localhost:7119/api/Departamentos", "1");

departamento.Nombre = "Ventas";
departamento.Ubicacion = "Piso 2";

uapi.Update("https://localhost:7119/api/Departamentos", "1" , departamento);
var departamentosDos = uapi.Select("https://localhost:7119/api/Departamentos");

var Atencion = new Departamento
{
    Nombre = "Atención al cliente",
    Ubicacion = "Piso 7"
};

var nuevoDepartamento = uapi.Insert("https://localhost:7119/api/Departamentos",Atencion);
*/
uapi.Delete("https://localhost:7119/api/Departamentos", "7");
Console.WriteLine("Hello, World!");
