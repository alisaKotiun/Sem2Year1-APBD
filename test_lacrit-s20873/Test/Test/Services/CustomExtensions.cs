using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Services
{
    public static class CustomExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firefighter>().HasData(
                new Firefighter() {IdFirefighter = 1, FirstName = "Alisa", LastName = "Kotiun" },
                new Firefighter() { IdFirefighter = 2, FirstName = "Ann", LastName = "Kotiun" }

                );

            modelBuilder.Entity<FireTruck>().HasData(
                new FireTruck() { IdFireTruck = 1, OperationalNumber = "123", SpecialEquipment = true},
                new FireTruck() { IdFireTruck = 2, OperationalNumber = "124", SpecialEquipment = false }

                );

            modelBuilder.Entity<Models.Action>().HasData(
                new Models.Action() { IdAction = 1, StartTime = DateTime.Now, EndTime = null, NeedSpecialEquipment= true},
                new Models.Action() { IdAction = 2, StartTime = DateTime.Now, EndTime = null, NeedSpecialEquipment = false }

                );

            modelBuilder.Entity<FirefighterAction>().HasData(
                new FirefighterAction() { IdAction = 1, IdFirefighter = 1}
                );
            modelBuilder.Entity<FireTruckAction>().HasData(
                new FireTruckAction() { IdFireTruckAction = 1, IdAction = 1, IdFireTruck = 1, AssignmentDate = DateTime.Now}
                );
        }
    }
}
