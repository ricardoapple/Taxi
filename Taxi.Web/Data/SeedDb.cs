using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Web.Models;

namespace Taxi.Web.Data
{
    public class SeedDb
    {
        //Esta es una clase que crea la base de datos si no existe con sus respectivas tablas y crea valores de prueba
        private readonly DataContext _dataContext;
        public SeedDb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();//Crea la base de datos si no existe 
            await CheckTaxisAsync();
        }

        private async Task CheckTaxisAsync()
        {
            if (_dataContext.Taxis.Any())//Verifica que hayan datos Taxis
            {
                return;
            }

            //Añadimos nuevos Taxis
            _dataContext.Taxis.Add(new Taxis
            {
                Plaque = "3399BXB",
                Trips = new List<Trip>//Añadimos Viajes
                {
                    new Trip
                    {
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMinutes(30),
                        Qualification = 4.5f,
                        Source = "ITM Fraternidad",
                        Target="ITM Robledo",
                        Remarks="Muy buen Servicio"

                    },
                    
                    new Trip
                    {
                        StartDate = DateTime.UtcNow,//Guarda hora de Londres
                        EndDate = DateTime.UtcNow.AddMinutes(30),
                        Qualification = 4.5f,
                        Source = "ITM Robledo",
                        Target="ITM Fraternidad",
                        Remarks="Conductor muy amable"
                    }
                }
            }) ;

            _dataContext.Taxis.Add(new Taxis
            {
                Plaque = "2211CXC",
                Trips = new List<Trip>
                {
                    new Trip
                    {
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMinutes(30),
                        Qualification = 4.5f,
                        Source = "ITM Fraternidad",
                        Target="ITM Robledo",
                        Remarks="Muy buen Servicio"

                    },

                    new Trip
                    {
                        StartDate = DateTime.UtcNow,//Guarda hora de Londres
                        EndDate = DateTime.UtcNow.AddMinutes(30),
                        Qualification = 4.5f,
                        Source = "ITM Robledo",
                        Target="ITM Fraternidad",
                        Remarks="Conductor muy amable"
                    }
                }
            });

            await _dataContext.SaveChangesAsync();
        }
    }
}
