using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MottuFlowApi.Data;
using MottuFlowApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MottuFlow API",
        Version = "SPRINT 1",
        Description = "API desenvolvida para o projeto MottuFlow, com CRUDs para gerenciamento de motos, pátios, câmeras e status.",
    });
    c.DocumentFilter<Documentacao>();
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "API MottuFlow está ativa!");

#region FUNCIONARIO CRUD

app.MapGet("/funcionarios", async (AppDbContext db) =>
    await db.Funcionarios.ToListAsync())
    .WithName("GetAllFuncionarios")
    .WithTags("Funcionários");


app.MapGet("/funcionarios/{id:int}", async (int id, AppDbContext db) =>
    await db.Funcionarios.FindAsync(id) is Funcionario f
        ? Results.Ok(f)
        : Results.NotFound())
        .WithName("GetFuncionarioById")
        .WithTags("Funcionários");

app.MapGet("/funcionarios/buscar", async (string cpf, AppDbContext db) =>
    await db.Funcionarios.FirstOrDefaultAsync(f => f.Cpf == cpf) is Funcionario f
        ? Results.Ok(f)
        : Results.NotFound())
        .WithName("GetFuncionarioByCpf")
        .WithTags("Funcionários");

app.MapPost("/funcionarios", async (Funcionario funcionario, AppDbContext db) =>
{
    db.Funcionarios.Add(funcionario);
    await db.SaveChangesAsync();
    return Results.Created($"/funcionarios/{funcionario.Id}", funcionario);
})
.WithName("CreateFuncionario")
.WithTags("Funcionários");


app.MapPut("/funcionarios/{id:int}", async (int id, Funcionario input, AppDbContext db) =>
{
    var funcionario = await db.Funcionarios.FindAsync(id);
    if (funcionario is null) return Results.NotFound();

    funcionario.Nome = input.Nome;
    funcionario.Cpf = input.Cpf;
    funcionario.Cargo = input.Cargo;
    funcionario.Telefone = input.Telefone;
    funcionario.Usuario = input.Usuario;
    funcionario.Senha = input.Senha;

    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("UpdateFuncionario")
.WithTags("Funcionários");


app.MapDelete("/funcionarios/{id:int}", async (int id, AppDbContext db) =>
{
    var funcionario = await db.Funcionarios.FindAsync(id);
    if (funcionario is null) return Results.NotFound();

    db.Funcionarios.Remove(funcionario);
    await db.SaveChangesAsync();
    return Results.Ok(funcionario);
})
.WithName("DeleteFuncionario")
.WithTags("Funcionários");

#endregion

#region PATIO CRUD
app.MapGet("/patios", async (AppDbContext db) =>
    await db.Patios
        .Select(p => new PatioDTO
        {
            IdPatio = p.IdPatio,
            Nome = p.Nome,
            Endereco = p.Endereco,
            CapacidadeMaxima = p.CapacidadeMaxima
        })
        .ToListAsync()
).WithName("GetAllPatios").WithTags("Pátios");

app.MapGet("/patios/{id:int}", async (int id, AppDbContext db) =>
{
    var patio = await db.Patios
        .Where(p => p.IdPatio == id)
        .Select(p => new PatioDTO
        {
            IdPatio = p.IdPatio,
            Nome = p.Nome,
            Endereco = p.Endereco,
            CapacidadeMaxima = p.CapacidadeMaxima
        })
        .FirstOrDefaultAsync();

    return patio is not null ? Results.Ok(patio) : Results.NotFound();
})
.WithName("GetPatioById")
.WithTags("Pátios");

app.MapPost("/patios", async (PatioCreateUpdateDTO dto, AppDbContext db) =>
{
    var patio = new Patio
    {
        Nome = dto.Nome,
        Endereco = dto.Endereco,
        CapacidadeMaxima = dto.CapacidadeMaxima
    };

    db.Patios.Add(patio);
    await db.SaveChangesAsync();

    var patioDTO = new PatioDTO
    {
        IdPatio = patio.IdPatio,
        Nome = patio.Nome,
        Endereco = patio.Endereco,
        CapacidadeMaxima = patio.CapacidadeMaxima
    };

    return Results.Created($"/patios/{patio.IdPatio}", patioDTO);
})
.WithName("CreatePatio")
.WithTags("Pátios");

app.MapPut("/patios/{id:int}", async (int id, PatioCreateUpdateDTO input, AppDbContext db) =>
{
    var patio = await db.Patios.FindAsync(id);
    if (patio is null) return Results.NotFound();

    patio.Nome = input.Nome;
    patio.Endereco = input.Endereco;
    patio.CapacidadeMaxima = input.CapacidadeMaxima;

    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("UpdatePatio")
.WithTags("Pátios");

app.MapDelete("/patios/{id:int}", async (int id, AppDbContext db) =>
{
    var patio = await db.Patios.FindAsync(id);
    if (patio is null) return Results.NotFound();

    db.Patios.Remove(patio);
    await db.SaveChangesAsync();

    var patioDTO = new PatioDTO
    {
        IdPatio = patio.IdPatio,
        Nome = patio.Nome,
        Endereco = patio.Endereco,
        CapacidadeMaxima = patio.CapacidadeMaxima
    };

    return Results.Ok(patioDTO);
})
.WithName("DeletePatio")
.WithTags("Pátios");
#endregion

#region MOTO CRUD
app.MapGet("/motos", async (AppDbContext db) =>
    await db.Motos
        .Select(m => new MotoDTO
        {
            IdMoto = m.IdMoto,
            Placa = m.Placa,
            Modelo = m.Modelo,
            Fabricante = m.Fabricante,
            Ano = m.Ano,
            IdPatio = m.IdPatio,
            LocalizacaoAtual = m.LocalizacaoAtual
        })
        .ToListAsync()
).WithName("GetAllMotos").WithTags("Motos");

app.MapGet("/motos/{id:int}", async (int id, AppDbContext db) =>
{
    var moto = await db.Motos
        .Where(m => m.IdMoto == id)
        .Select(m => new MotoDTO
        {
            IdMoto = m.IdMoto,
            Placa = m.Placa,
            Modelo = m.Modelo,
            Fabricante = m.Fabricante,
            Ano = m.Ano,
            IdPatio = m.IdPatio,
            LocalizacaoAtual = m.LocalizacaoAtual
        })
        .FirstOrDefaultAsync();

    return moto is not null ? Results.Ok(moto) : Results.NotFound();
})
.WithName("GetMotoById")
.WithTags("Motos");

app.MapGet("/motos/placa", async (string placa, AppDbContext db) =>
{
    var moto = await db.Motos
        .Where(m => m.Placa == placa)
        .Select(m => new MotoDTO
        {
            IdMoto = m.IdMoto,
            Placa = m.Placa,
            Modelo = m.Modelo,
            Fabricante = m.Fabricante,
            Ano = m.Ano,
            IdPatio = m.IdPatio,
            LocalizacaoAtual = m.LocalizacaoAtual
        })
        .FirstOrDefaultAsync();

    return moto is not null ? Results.Ok(moto) : Results.NotFound();
})
.WithName("GetMotoByPlaca")
.WithTags("Motos");

app.MapPost("/motos", async (MotoCreateUpdateDTO dto, AppDbContext db) =>
{
    var moto = new Moto
    {
        Placa = dto.Placa,
        Modelo = dto.Modelo,
        Fabricante = dto.Fabricante,
        Ano = dto.Ano,
        IdPatio = dto.IdPatio,
        LocalizacaoAtual = dto.LocalizacaoAtual
    };

    db.Motos.Add(moto);
    await db.SaveChangesAsync();

    var motoDTO = new MotoDTO
    {
        IdMoto = moto.IdMoto,
        Placa = moto.Placa,
        Modelo = moto.Modelo,
        Fabricante = moto.Fabricante,
        Ano = moto.Ano,
        IdPatio = moto.IdPatio,
        LocalizacaoAtual = moto.LocalizacaoAtual
    };

    return Results.Created($"/motos/{moto.IdMoto}", motoDTO);
})
.WithName("CreateMoto")
.WithTags("Motos");

app.MapPut("/motos/{id:int}", async (int id, MotoCreateUpdateDTO input, AppDbContext db) =>
{
    var moto = await db.Motos.FindAsync(id);
    if (moto is null) return Results.NotFound();

    moto.Placa = input.Placa;
    moto.Modelo = input.Modelo;
    moto.Fabricante = input.Fabricante;
    moto.Ano = input.Ano;
    moto.IdPatio = input.IdPatio;
    moto.LocalizacaoAtual = input.LocalizacaoAtual;

    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("UpdateMoto")
.WithTags("Motos");

app.MapDelete("/motos/{id:int}", async (int id, AppDbContext db) =>
{
    var moto = await db.Motos.FindAsync(id);
    if (moto is null) return Results.NotFound();

    db.Motos.Remove(moto);
    await db.SaveChangesAsync();

    var motoDTO = new MotoDTO
    {
        IdMoto = moto.IdMoto,
        Placa = moto.Placa,
        Modelo = moto.Modelo,
        Fabricante = moto.Fabricante,
        Ano = moto.Ano,
        IdPatio = moto.IdPatio,
        LocalizacaoAtual = moto.LocalizacaoAtual
    };

    return Results.Ok(motoDTO);
})
.WithName("DeleteMoto")
.WithTags("Motos");
#endregion

#region CAMERA CRUD
app.MapGet("/cameras", async (AppDbContext db) =>
    await db.Cameras
        .Select(c => new CameraDTO
        {
            IdCamera = c.IdCamera,
            StatusOperacional = c.StatusOperacional,
            LocalizacaoFisica = c.LocalizacaoFisica,
            IdPatio = c.IdPatio
        })
        .ToListAsync()
).WithName("GetAllCameras").WithTags("Câmeras");

app.MapGet("/cameras/{id:int}", async (int id, AppDbContext db) =>
{
    var camera = await db.Cameras
        .Where(c => c.IdCamera == id)
        .Select(c => new CameraDTO
        {
            IdCamera = c.IdCamera,
            StatusOperacional = c.StatusOperacional,
            LocalizacaoFisica = c.LocalizacaoFisica,
            IdPatio = c.IdPatio
        })
        .FirstOrDefaultAsync();

    return camera is not null ? Results.Ok(camera) : Results.NotFound();
})
.WithName("GetCameraById")
.WithTags("Câmeras");

app.MapPost("/cameras", async (CameraCreateUpdateDTO dto, AppDbContext db) =>
{
    var camera = new Camera
    {
        StatusOperacional = dto.StatusOperacional,
        LocalizacaoFisica = dto.LocalizacaoFisica,
        IdPatio = dto.IdPatio
    };

    db.Cameras.Add(camera);
    await db.SaveChangesAsync();

    var cameraDTO = new CameraDTO
    {
        IdCamera = camera.IdCamera,
        StatusOperacional = camera.StatusOperacional,
        LocalizacaoFisica = camera.LocalizacaoFisica,
        IdPatio = camera.IdPatio
    };

    return Results.Created($"/cameras/{camera.IdCamera}", cameraDTO);
})
.WithName("CreateCamera")
.WithTags("Câmeras");

app.MapPut("/cameras/{id:int}", async (int id, CameraCreateUpdateDTO input, AppDbContext db) =>
{
    var camera = await db.Cameras.FindAsync(id);
    if (camera is null) return Results.NotFound();

    camera.StatusOperacional = input.StatusOperacional;
    camera.LocalizacaoFisica = input.LocalizacaoFisica;
    camera.IdPatio = input.IdPatio;

    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("UpdateCamera")
.WithTags("Câmeras");

app.MapDelete("/cameras/{id:int}", async (int id, AppDbContext db) =>
{
    var camera = await db.Cameras.FindAsync(id);
    if (camera is null) return Results.NotFound();

    db.Cameras.Remove(camera);
    await db.SaveChangesAsync();

    var cameraDTO = new CameraDTO
    {
        IdCamera = camera.IdCamera,
        StatusOperacional = camera.StatusOperacional,
        LocalizacaoFisica = camera.LocalizacaoFisica,
        IdPatio = camera.IdPatio
    };

    return Results.Ok(cameraDTO);
})
.WithName("DeleteCamera")
.WithTags("Câmeras");
#endregion

#region ARUCOTAG CRUD
app.MapGet("/arucotags", async (AppDbContext db) =>
    await db.ArucoTags
        .Select(t => new ArucoTagDTO
        {
            IdTag = t.IdTag,
            Codigo = t.Codigo,
            IdMoto = t.IdMoto,
            Status = t.Status
        })
        .ToListAsync()
).WithName("GetAllArucoTags").WithTags("ArucoTags");

app.MapGet("/arucotags/{id:int}", async (int id, AppDbContext db) =>
{
    var tag = await db.ArucoTags
        .Where(t => t.IdTag == id)
        .Select(t => new ArucoTagDTO
        {
            IdTag = t.IdTag,
            Codigo = t.Codigo,
            IdMoto = t.IdMoto,
            Status = t.Status
        })
        .FirstOrDefaultAsync();

    return tag is not null ? Results.Ok(tag) : Results.NotFound();
})
.WithName("GetArucoTagById")
.WithTags("ArucoTags");

app.MapPost("/arucotags", async (ArucoTagCreateUpdateDTO dto, AppDbContext db) =>
{
    var tag = new ArucoTag
    {
        Codigo = dto.Codigo,
        IdMoto = dto.IdMoto,
        Status = dto.Status
    };

    db.ArucoTags.Add(tag);
    await db.SaveChangesAsync();

    var tagDTO = new ArucoTagDTO
    {
        IdTag = tag.IdTag,
        Codigo = tag.Codigo,
        IdMoto = tag.IdMoto,
        Status = tag.Status
    };

    return Results.Created($"/arucotags/{tag.IdTag}", tagDTO);
})
.WithName("CreateArucoTag")
.WithTags("ArucoTags");

app.MapPut("/arucotags/{id:int}", async (int id, ArucoTagCreateUpdateDTO input, AppDbContext db) =>
{
    var tag = await db.ArucoTags.FindAsync(id);
    if (tag is null) return Results.NotFound();

    tag.Codigo = input.Codigo;
    tag.IdMoto = input.IdMoto;
    tag.Status = input.Status;

    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("UpdateArucoTag")
.WithTags("ArucoTags");

app.MapDelete("/arucotags/{id:int}", async (int id, AppDbContext db) =>
{
    var tag = await db.ArucoTags.FindAsync(id);
    if (tag is null) return Results.NotFound();

    db.ArucoTags.Remove(tag);
    await db.SaveChangesAsync();

    var tagDTO = new ArucoTagDTO
    {
        IdTag = tag.IdTag,
        Codigo = tag.Codigo,
        IdMoto = tag.IdMoto,
        Status = tag.Status
    };

    return Results.Ok(tagDTO);
})
.WithName("DeleteArucoTag")
.WithTags("ArucoTags");
#endregion

#region STATUS CRUD
app.MapGet("/status", async (AppDbContext db) =>
    await db.Status
        .Select(s => new StatusDTO
        {
            IdStatus = s.IdStatus,
            IdMoto = s.IdMoto,
            TipoStatus = s.TipoStatus,
            Descricao = s.Descricao,
            DataStatus = s.DataStatus,
            IdFuncionario = s.IdFuncionario
        })
        .ToListAsync()
).WithName("GetAllStatus").WithTags("Status");

app.MapGet("/status/{id:int}", async (int id, AppDbContext db) =>
{
    var status = await db.Status
        .Where(s => s.IdStatus == id)
        .Select(s => new StatusDTO
        {
            IdStatus = s.IdStatus,
            IdMoto = s.IdMoto,
            TipoStatus = s.TipoStatus,
            Descricao = s.Descricao,
            DataStatus = s.DataStatus,
            IdFuncionario = s.IdFuncionario
        })
        .FirstOrDefaultAsync();

    return status is not null ? Results.Ok(status) : Results.NotFound();
})
.WithName("GetStatusById")
.WithTags("Status");

app.MapPost("/status", async (StatusCreateUpdateDTO dto, AppDbContext db) =>
{
    var status = new Status
    {
        IdMoto = dto.IdMoto,
        TipoStatus = dto.TipoStatus,
        Descricao = dto.Descricao,
        DataStatus = dto.DataStatus,
        IdFuncionario = dto.IdFuncionario
    };

    db.Status.Add(status);
    await db.SaveChangesAsync();

    var statusDTO = new StatusDTO
    {
        IdStatus = status.IdStatus,
        IdMoto = status.IdMoto,
        TipoStatus = status.TipoStatus,
        Descricao = status.Descricao,
        DataStatus = status.DataStatus,
        IdFuncionario = status.IdFuncionario
    };

    return Results.Created($"/status/{status.IdStatus}", statusDTO);
})
.WithName("CreateStatus")
.WithTags("Status");

app.MapPut("/status/{id:int}", async (int id, StatusCreateUpdateDTO input, AppDbContext db) =>
{
    var status = await db.Status.FindAsync(id);
    if (status is null) return Results.NotFound();

    status.IdMoto = input.IdMoto;
    status.TipoStatus = input.TipoStatus;
    status.Descricao = input.Descricao;
    status.DataStatus = input.DataStatus;
    status.IdFuncionario = input.IdFuncionario;

    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("UpdateStatus")
.WithTags("Status");

app.MapDelete("/status/{id:int}", async (int id, AppDbContext db) =>
{
    var status = await db.Status.FindAsync(id);
    if (status is null) return Results.NotFound();

    db.Status.Remove(status);
    await db.SaveChangesAsync();

    var statusDTO = new StatusDTO
    {
        IdStatus = status.IdStatus,
        IdMoto = status.IdMoto,
        TipoStatus = status.TipoStatus,
        Descricao = status.Descricao,
        DataStatus = status.DataStatus,
        IdFuncionario = status.IdFuncionario
    };

    return Results.Ok(statusDTO);
})
.WithName("DeleteStatus")
.WithTags("Status");
#endregion

#region LOCALIDADE CRUD
app.MapGet("/localidades", async (AppDbContext db) =>
    await db.Localidades
        .Select(l => new LocalidadeDTO
        {
            IdLocalidade = l.IdLocalidade,
            DataHora = l.DataHora,
            IdMoto = l.IdMoto,
            IdPatio = l.IdPatio,
            PontoReferencia = l.PontoReferencia,
            IdCamera = l.IdCamera
        })
        .ToListAsync()
).WithName("GetAllLocalidades").WithTags("Localidades");

app.MapGet("/localidades/{id:int}", async (int id, AppDbContext db) =>
{
    var localidade = await db.Localidades
        .Where(l => l.IdLocalidade == id)
        .Select(l => new LocalidadeDTO
        {
            IdLocalidade = l.IdLocalidade,
            DataHora = l.DataHora,
            IdMoto = l.IdMoto,
            IdPatio = l.IdPatio,
            PontoReferencia = l.PontoReferencia,
            IdCamera = l.IdCamera
        })
        .FirstOrDefaultAsync();

    return localidade is not null ? Results.Ok(localidade) : Results.NotFound();
})
.WithName("GetLocalidadeById")
.WithTags("Localidades");

app.MapPost("/localidades", async (LocalidadeCreateUpdateDTO dto, AppDbContext db) =>
{
    var localidade = new Localidade
    {
        DataHora = dto.DataHora,
        IdMoto = dto.IdMoto,
        IdPatio = dto.IdPatio,
        PontoReferencia = dto.PontoReferencia,
        IdCamera = dto.IdCamera
    };

    db.Localidades.Add(localidade);
    await db.SaveChangesAsync();

    var localidadeDTO = new LocalidadeDTO
    {
        IdLocalidade = localidade.IdLocalidade,
        DataHora = localidade.DataHora,
        IdMoto = localidade.IdMoto,
        IdPatio = localidade.IdPatio,
        PontoReferencia = localidade.PontoReferencia,
        IdCamera = localidade.IdCamera
    };

    return Results.Created($"/localidades/{localidade.IdLocalidade}", localidadeDTO);
})
.WithName("CreateLocalidade")
.WithTags("Localidades");

app.MapPut("/localidades/{id:int}", async (int id, LocalidadeCreateUpdateDTO input, AppDbContext db) =>
{
    var localidade = await db.Localidades.FindAsync(id);
    if (localidade is null) return Results.NotFound();

    localidade.DataHora = input.DataHora;
    localidade.IdMoto = input.IdMoto;
    localidade.IdPatio = input.IdPatio;
    localidade.PontoReferencia = input.PontoReferencia;
    localidade.IdCamera = input.IdCamera;

    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("UpdateLocalidade")
.WithTags("Localidades");

app.MapDelete("/localidades/{id:int}", async (int id, AppDbContext db) =>
{
    var localidade = await db.Localidades.FindAsync(id);
    if (localidade is null) return Results.NotFound();

    db.Localidades.Remove(localidade);
    await db.SaveChangesAsync();

    var localidadeDTO = new LocalidadeDTO
    {
        IdLocalidade = localidade.IdLocalidade,
        DataHora = localidade.DataHora,
        IdMoto = localidade.IdMoto,
        IdPatio = localidade.IdPatio,
        PontoReferencia = localidade.PontoReferencia,
        IdCamera = localidade.IdCamera
    };

    return Results.Ok(localidadeDTO);
})
.WithName("DeleteLocalidade")
.WithTags("Localidades");
#endregion

app.Run();