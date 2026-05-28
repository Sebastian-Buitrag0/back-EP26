using BackEP26.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEP26.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Candidate> Candidates => Set<Candidate>();
    public DbSet<Vote> Votes => Set<Vote>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vote>(v =>
        {
            v.HasIndex(x => x.GoogleSubHash).IsUnique();
            v.HasIndex(x => x.DeviceId).IsUnique();
            v.HasIndex(x => new { x.IpAddress, x.VotedAt });
        });

        modelBuilder.Entity<Candidate>().HasData(
            new Candidate { Id = 6,  Name = "Iván Cepeda Castro",               Party = "Movimiento Político Pacto Histórico",    PhotoUrl = "cepeda.jpg",           VicePresident = "Aída Marina Quilcué Vivas",              DisplayOrder = 1 },
            new Candidate { Id = 7,  Name = "Abelardo Gabriel de la Espriella", Party = "Defensores de la patria",                PhotoUrl = "abelardo.jpg",         VicePresident = "José Manuel Restrepo Abondano",          DisplayOrder = 2 },
            new Candidate { Id = 10, Name = "Sergio Fajardo Valderrama",        Party = "Partido Dignidad & Compromiso",          PhotoUrl = "fajardo.webp",         VicePresident = "Edna Cristina del Socorro Bonilla Seba", DisplayOrder = 3 },
            new Candidate { Id = 9,  Name = "Paloma Susana Valencia Laserna",   Party = "Partido Centro Democrático",             PhotoUrl = "paloma.jpg",           VicePresident = "Juan Daniel Oviedo Arango",              DisplayOrder = 4 },
            new Candidate { Id = 8,  Name = "Claudia Nayibe López Hernández",   Party = "Con Claudia imparables",                 PhotoUrl = "claudia.jpg",          VicePresident = "Leonardo Humberto Huerta Gutiérrez",     DisplayOrder = 5 },
            new Candidate { Id = 1,  Name = "Clara Eugenia López Obregón",      Party = "Partido Esperanza Democrática",          PhotoUrl = "clara-lopez.jpg",      VicePresident = "María Consuelo del Río Mantilla",        DisplayOrder = 6 },
            new Candidate { Id = 2,  Name = "Óscar Mauricio Lizcano Arango",    Party = "Coalición F.A.M.I.L.I.A",               PhotoUrl = "mauricio-lizcano.jpg", VicePresident = "Adriana María Ramírez Martínez",         DisplayOrder = 7 },
            new Candidate { Id = 3,  Name = "Raúl Santiago Botero Jaramillo",   Party = "Romper el sistema",                      PhotoUrl = "santiago-botero.jpg",  VicePresident = "Carlos Fernando Cuevas Romero",          DisplayOrder = 8 },
            new Candidate { Id = 4,  Name = "Miguel Uribe Londoño",             Party = "Partido Demócrata Colombiano",           PhotoUrl = "miguel-uribe.jpg",     VicePresident = "Luisa Fernanda Villegas Araque",         DisplayOrder = 9 },
            new Candidate { Id = 5,  Name = "Sondra Macollins Garvin Pinto",    Party = "Sondra Macollins, la abogada de hierro", PhotoUrl = "sandra-macollins.jpg", VicePresident = "Leonardo Karam Helo",                   DisplayOrder = 10 },
            new Candidate { Id = 11, Name = "Roy Leonardo Barreras Montealegre",Party = "Partido político La Fuerza",             PhotoUrl = "roy-barreras.jpg",     VicePresident = "Martha Lucía Zamora Ávila",              DisplayOrder = 11 },
            new Candidate { Id = 12, Name = "Gustavo Matamoros Camacho",        Party = "Partido Ecologista Colombiano",          PhotoUrl = "gustavo-matamoros.jpg",VicePresident = "Robinson Alonso Giraldo Mira",           DisplayOrder = 12 },
            new Candidate { Id = 13, Name = "Luis Gilberto Murillo Urrutia",    Party = "Luis Gilberto soy yo",                   PhotoUrl = "gilberto-murillo.avif",VicePresident = "Luz María Zapata Zapata",                DisplayOrder = 13 },
            new Candidate { Id = 14, Name = "Carlos Eduardo Caicedo Omar",      Party = "Caicedo",                                PhotoUrl = "carlos-caicedo.jpg",   VicePresident = "Nelson Javier Alarcón Suárez",           DisplayOrder = 14 }
        );
    }
}
