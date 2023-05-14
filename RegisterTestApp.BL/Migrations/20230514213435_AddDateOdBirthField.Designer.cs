﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegisterTestApp.Service.Db;

#nullable disable

namespace RegisterTestApp.Service.Migrations
{
    [DbContext(typeof(RegistrationAppContext))]
    [Migration("20230514213435_AddDateOdBirthField")]
    partial class AddDateOdBirthField
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("RegisterTestApp.Service.Db.RegistrationPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RegistrationRequestId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RegistrationRequestId");

                    b.ToTable("RegistrationPhone");
                });

            modelBuilder.Entity("RegisterTestApp.Service.Db.RegistrationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RegistrationRequests");
                });

            modelBuilder.Entity("RegisterTestApp.Service.Db.RegistrationPhone", b =>
                {
                    b.HasOne("RegisterTestApp.Service.Db.RegistrationRequest", "RegistrationRequest")
                        .WithMany("RegistrationPhones")
                        .HasForeignKey("RegistrationRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegistrationRequest");
                });

            modelBuilder.Entity("RegisterTestApp.Service.Db.RegistrationRequest", b =>
                {
                    b.Navigation("RegistrationPhones");
                });
#pragma warning restore 612, 618
        }
    }
}
