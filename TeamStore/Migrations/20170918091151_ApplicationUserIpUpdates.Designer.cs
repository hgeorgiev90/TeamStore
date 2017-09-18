﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using TeamStore.DataAccess;
using TeamStore.Enums;

namespace TeamStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170918091151_ApplicationUserIpUpdates")]
    partial class ApplicationUserIpUpdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("TeamStore.Models.AccessIdentifier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int?>("CreatedById");

                    b.Property<int?>("IdentityId");

                    b.Property<DateTime>("Modified");

                    b.Property<int?>("ModifiedById");

                    b.Property<int>("ProjectForeignKey");

                    b.Property<string>("Role");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("IdentityId");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("ProjectForeignKey");

                    b.ToTable("AccessIdentifiers");
                });

            modelBuilder.Entity("TeamStore.Models.ApplicationIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AzureAdObjectIdentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("DisplayName");

                    b.Property<string>("TenantId");

                    b.HasKey("Id");

                    b.ToTable("ApplicationIdentities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationIdentity");
                });

            modelBuilder.Entity("TeamStore.Models.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("IsEnabled");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("ProjectForeignKey");

                    b.HasKey("Id");

                    b.HasIndex("ProjectForeignKey");

                    b.ToTable("Assets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Asset");
                });

            modelBuilder.Entity("TeamStore.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AssetForeignKey");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("NewValue");

                    b.Property<string>("OldValue");

                    b.Property<int>("Type");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AssetForeignKey");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("TeamStore.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<bool>("IsArchived");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TeamStore.Models.ApplicationGroup", b =>
                {
                    b.HasBaseType("TeamStore.Models.ApplicationIdentity");


                    b.ToTable("ApplicationGroup");

                    b.HasDiscriminator().HasValue("ApplicationGroup");
                });

            modelBuilder.Entity("TeamStore.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("TeamStore.Models.ApplicationIdentity");

                    b.Property<string>("AccessIpAddress");

                    b.Property<string>("AzureAdName");

                    b.Property<string>("AzureAdNameIdentifier");

                    b.Property<string>("SignInIpAddress");

                    b.Property<string>("Upn");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("TeamStore.Models.Credential", b =>
                {
                    b.HasBaseType("TeamStore.Models.Asset");

                    b.Property<string>("Login");

                    b.ToTable("Credential");

                    b.HasDiscriminator().HasValue("Credential");
                });

            modelBuilder.Entity("TeamStore.Models.Note", b =>
                {
                    b.HasBaseType("TeamStore.Models.Asset");

                    b.Property<string>("Body");

                    b.Property<string>("Title");

                    b.ToTable("Note");

                    b.HasDiscriminator().HasValue("Note");
                });

            modelBuilder.Entity("TeamStore.Models.AccessIdentifier", b =>
                {
                    b.HasOne("TeamStore.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("TeamStore.Models.ApplicationIdentity", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");

                    b.HasOne("TeamStore.Models.ApplicationUser", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.HasOne("TeamStore.Models.Project", "Project")
                        .WithMany("AccessIdentifiers")
                        .HasForeignKey("ProjectForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TeamStore.Models.Asset", b =>
                {
                    b.HasOne("TeamStore.Models.Project", "Project")
                        .WithMany("Assets")
                        .HasForeignKey("ProjectForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TeamStore.Models.Event", b =>
                {
                    b.HasOne("TeamStore.Models.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetForeignKey");

                    b.HasOne("TeamStore.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
