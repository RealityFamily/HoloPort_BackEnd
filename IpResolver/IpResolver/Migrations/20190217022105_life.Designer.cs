﻿// <auto-generated />
using System;
using IpResolver;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IpResolver.Migrations
{
    [DbContext(typeof(DataBase))]
    [Migration("20190217022105_life")]
    partial class life
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IpResolver.Models.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientName");

                    b.Property<string>("IpAddress");

                    b.Property<DateTime>("LifeTime");

                    b.Property<Guid?>("RoomId");

                    b.HasKey("ClientId");

                    b.HasIndex("RoomId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("IpResolver.Models.Room", b =>
                {
                    b.Property<Guid>("RoomId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoomName");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("IpResolver.Models.Client", b =>
                {
                    b.HasOne("IpResolver.Models.Room", "Room")
                        .WithMany("Users")
                        .HasForeignKey("RoomId");
                });
#pragma warning restore 612, 618
        }
    }
}
