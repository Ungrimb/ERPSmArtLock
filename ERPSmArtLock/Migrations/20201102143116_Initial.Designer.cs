﻿// <auto-generated />
using System;
using ERPSmArtLock.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERPSmArtLock.Migrations
{
    [DbContext(typeof(ERPContext))]
    [Migration("20201102143116_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ERPSmArtLock.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("BackImage")
                        .HasColumnType("text");

                    b.Property<string>("CardPhoto")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CityOfBirth")
                        .HasColumnType("text");

                    b.Property<int>("CodeVerify")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("CountryOfBirth")
                        .HasColumnType("text");

                    b.Property<string>("CountryTaxLiability")
                        .HasColumnType("text");

                    b.Property<string>("DeviceToken")
                        .HasColumnType("text");

                    b.Property<int>("DeviceType")
                        .HasColumnType("int");

                    b.Property<string>("DinNie")
                        .HasColumnType("text");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("EmailStatus")
                        .HasColumnType("int");

                    b.Property<string>("FrontImage")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("HouseNo")
                        .HasColumnType("text");

                    b.Property<string>("ImeiNo")
                        .HasColumnType("text");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<int>("IsFaceEnabled")
                        .HasColumnType("int");

                    b.Property<int>("IsFingerprintEnabled")
                        .HasColumnType("int");

                    b.Property<int>("IsMobileVerified")
                        .HasColumnType("int");

                    b.Property<string>("MobileOtp")
                        .HasColumnType("text");

                    b.Property<string>("Nationality")
                        .HasColumnType("text");

                    b.Property<string>("Passport")
                        .HasColumnType("text");

                    b.Property<string>("PassportImage")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Photo")
                        .HasColumnType("text");

                    b.Property<string>("Postcode")
                        .HasColumnType("text");

                    b.Property<int>("ProfileStatus")
                        .HasColumnType("int");

                    b.Property<string>("Pwd")
                        .HasColumnType("text");

                    b.Property<string>("RandomCode")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<string>("VerificationCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ERPSmArtLock.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("address")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnName("image")
                        .HasColumnType("text");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnName("mobile")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("admin");
                });

            modelBuilder.Entity("ERPSmArtLock.Models.AllowedInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<int>("AllowedMethod")
                        .HasColumnName("allowedMethod")
                        .HasColumnType("int(11)");

                    b.Property<int>("AllowedStatus")
                        .HasColumnName("allowed_status")
                        .HasColumnType("int(11)")
                        .HasComment("0-new/not-verified/1-verified ");

                    b.Property<string>("AllowedUserEmail")
                        .IsRequired()
                        .HasColumnName("allowedUserEmail")
                        .HasColumnType("text");

                    b.Property<int>("AllowedUserId")
                        .HasColumnName("allowedUserId")
                        .HasColumnType("int(11)");

                    b.Property<int>("BuildingId")
                        .HasColumnName("buildingId")
                        .HasColumnType("int(11)");

                    b.Property<string>("ChatRoomId")
                        .IsRequired()
                        .HasColumnName("chatRoomId")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("DayWise")
                        .HasColumnName("day_wise")
                        .HasColumnType("text")
                        .HasComment("the day entered by user 1-Sunday,2-Monday,3-Tuesday,4-Wednesday,5-Thursday,6-Friday,7-Saturday");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnName("endDate")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnName("endTime")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("LockId")
                        .HasColumnName("lockId")
                        .HasColumnType("int(11)");

                    b.Property<int>("OwnerId")
                        .HasColumnName("ownerId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnName("reason")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnName("startDate")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnName("startTime")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("UnReadMsgCnt")
                        .IsRequired()
                        .HasColumnName("unReadMsgCnt")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("allowed_info");
                });

            modelBuilder.Entity("ERPSmArtLock.Models.BuildingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("buildingId")
                        .HasColumnType("int(11)");

                    b.Property<int>("AllowedUsers")
                        .HasColumnName("allowedUsers")
                        .HasColumnType("int(11)");

                    b.Property<string>("BuildingAddress")
                        .IsRequired()
                        .HasColumnName("buildingAddress")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("BuildingImage")
                        .IsRequired()
                        .HasColumnName("buildingImage")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("BuildingName")
                        .IsRequired()
                        .HasColumnName("buildingName")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("Lat")
                        .IsRequired()
                        .HasColumnName("lat")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Lng")
                        .IsRequired()
                        .HasColumnName("lng")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("OwnerEmail")
                        .IsRequired()
                        .HasColumnName("ownerEmail")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("OwnerId")
                        .HasColumnName("ownerId")
                        .HasColumnType("int(11)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnName("ownerName")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Rooms")
                        .HasColumnName("rooms")
                        .HasColumnType("int(11)");

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("int(11)")
                        .HasComment("0-pending/-1-verified/2-blocked");

                    b.Property<string>("VerificationCode")
                        .IsRequired()
                        .HasColumnName("verification_code")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("building_list");
                });

            modelBuilder.Entity("ERPSmArtLock.Models.Documents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnName("document_name")
                        .HasColumnType("text");

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasColumnName("signature")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("int(11)")
                        .HasComment("0-pending/1-completed");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.ToTable("documents");
                });

            modelBuilder.Entity("ERPSmArtLock.Models.EventList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<int>("BuildingId")
                        .HasColumnName("building_id")
                        .HasColumnType("int(11)");

                    b.Property<int>("LockId")
                        .HasColumnName("lock_id")
                        .HasColumnType("int(11)");

                    b.Property<int>("RoomId")
                        .HasColumnName("room_id")
                        .HasColumnType("int(11)");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.ToTable("event_list");
                });

            modelBuilder.Entity("ERPSmArtLock.Models.LockList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("lockId")
                        .HasColumnType("int(11)");

                    b.Property<int>("AllowedUsers")
                        .HasColumnName("allowedUsers")
                        .HasColumnType("int(11)");

                    b.Property<int>("BuildingId")
                        .HasColumnName("buildingId")
                        .HasColumnType("int(11)");

                    b.Property<string>("CheckDoubletick")
                        .IsRequired()
                        .HasColumnName("check_doubletick")
                        .HasColumnType("text");

                    b.Property<TimeSpan>("CheckIn")
                        .HasColumnName("checkIn")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("CheckOut")
                        .HasColumnName("checkOut")
                        .HasColumnType("time");

                    b.Property<string>("Doubletick")
                        .IsRequired()
                        .HasColumnName("doubletick")
                        .HasColumnType("text");

                    b.Property<int>("IsFavorite")
                        .HasColumnName("isFavorite")
                        .HasColumnType("int(11)");

                    b.Property<int>("IsLimited")
                        .HasColumnName("isLimited")
                        .HasColumnType("int(11)");

                    b.Property<int>("OwnerId")
                        .HasColumnName("ownerId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Qrcode")
                        .IsRequired()
                        .HasColumnName("qrcode")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnName("roomName")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("lock_list");
                });

            modelBuilder.Entity("ERPSmArtLock.Models.Locklist1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("lockId")
                        .HasColumnType("int(11)");

                    b.Property<int>("AllowedUsers")
                        .HasColumnName("allowedUsers")
                        .HasColumnType("int(11)");

                    b.Property<int>("BuildingId")
                        .HasColumnName("buildingId")
                        .HasColumnType("int(11)");

                    b.Property<TimeSpan>("CheckIn")
                        .HasColumnName("checkIn")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("CheckOut")
                        .HasColumnName("checkOut")
                        .HasColumnType("time");

                    b.Property<int>("IsFavorite")
                        .HasColumnName("isFavorite")
                        .HasColumnType("int(11)");

                    b.Property<int>("IsLimited")
                        .HasColumnName("isLimited")
                        .HasColumnType("int(11)");

                    b.Property<string>("LockImage")
                        .IsRequired()
                        .HasColumnName("lockImage")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("OwnerId")
                        .HasColumnName("ownerId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Qrcode")
                        .IsRequired()
                        .HasColumnName("qrcode")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnName("roomName")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("locklist");
                });

            modelBuilder.Entity("ERPSmArtLock.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<string>("Aboutus")
                        .IsRequired()
                        .HasColumnName("aboutus")
                        .HasColumnType("text");

                    b.Property<string>("Privacy")
                        .IsRequired()
                        .HasColumnName("privacy")
                        .HasColumnType("text");

                    b.Property<string>("SupportEmail")
                        .IsRequired()
                        .HasColumnName("support_email")
                        .HasColumnType("text");

                    b.Property<string>("Terms")
                        .IsRequired()
                        .HasColumnName("terms")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("settings");
                });

            modelBuilder.Entity("ERPSmArtLock.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("userId")
                        .HasColumnType("int(11)");

                    b.Property<int>("AccountStatus")
                        .HasColumnName("account_status")
                        .HasColumnType("int(11)");

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnName("additional_info")
                        .HasColumnType("mediumtext");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("address")
                        .HasColumnType("mediumtext");

                    b.Property<string>("BackImage")
                        .IsRequired()
                        .HasColumnName("back_image")
                        .HasColumnType("mediumtext");

                    b.Property<string>("CardPhoto")
                        .IsRequired()
                        .HasColumnName("card_photo")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasColumnType("mediumtext");

                    b.Property<string>("CityOfBirth")
                        .IsRequired()
                        .HasColumnName("city_of_birth")
                        .HasColumnType("mediumtext");

                    b.Property<int>("CodeVerify")
                        .HasColumnName("code_verify")
                        .HasColumnType("int(11)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("country")
                        .HasColumnType("mediumtext");

                    b.Property<string>("CountryOfBirth")
                        .IsRequired()
                        .HasColumnName("country_of_birth")
                        .HasColumnType("mediumtext");

                    b.Property<string>("CountryTaxLiability")
                        .IsRequired()
                        .HasColumnName("country_tax_liability")
                        .HasColumnType("mediumtext");

                    b.Property<string>("DeviceToken")
                        .IsRequired()
                        .HasColumnName("device_token")
                        .HasColumnType("mediumtext");

                    b.Property<int>("DeviceType")
                        .HasColumnName("device_type")
                        .HasColumnType("int(11)")
                        .HasComment("1-android / 2-ios");

                    b.Property<string>("DinNie")
                        .IsRequired()
                        .HasColumnName("din_nie")
                        .HasColumnType("mediumtext");

                    b.Property<DateTime>("Dob")
                        .HasColumnName("dob")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("EmailStatus")
                        .HasColumnName("email_status")
                        .HasColumnType("int(11)");

                    b.Property<string>("FrontImage")
                        .IsRequired()
                        .HasColumnName("front_image")
                        .HasColumnType("mediumtext");

                    b.Property<int>("Gender")
                        .HasColumnName("gender")
                        .HasColumnType("int(11)")
                        .HasComment("1-male/2-female");

                    b.Property<string>("HouseNo")
                        .IsRequired()
                        .HasColumnName("house_no")
                        .HasColumnType("mediumtext");

                    b.Property<string>("ImeiNo")
                        .IsRequired()
                        .HasColumnName("imei_no")
                        .HasColumnType("mediumtext");

                    b.Property<int>("IsDeleted")
                        .HasColumnName("isDeleted")
                        .HasColumnType("int(11)");

                    b.Property<int>("IsFaceEnabled")
                        .HasColumnName("is_face_enabled")
                        .HasColumnType("int(11)")
                        .HasComment("1-yes/0-no");

                    b.Property<int>("IsFingerprintEnabled")
                        .HasColumnName("is_fingerprint_enabled")
                        .HasColumnType("int(11)")
                        .HasComment("1-yes/0-no");

                    b.Property<int>("IsMobileVerified")
                        .HasColumnName("is_mobile_verified")
                        .HasColumnType("int(11)");

                    b.Property<string>("MobileOtp")
                        .IsRequired()
                        .HasColumnName("mobile_otp")
                        .HasColumnType("mediumtext");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnName("nationality")
                        .HasColumnType("mediumtext");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnName("passport")
                        .HasColumnType("mediumtext");

                    b.Property<string>("PassportImage")
                        .IsRequired()
                        .HasColumnName("passport_image")
                        .HasColumnType("mediumtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasColumnType("mediumtext");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnName("photo")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnName("postcode")
                        .HasColumnType("mediumtext");

                    b.Property<int>("ProfileStatus")
                        .HasColumnName("profile_status")
                        .HasColumnType("int(11)")
                        .HasComment("0-pending/1-verified/2-rejected");

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasColumnName("pwd")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("RandomCode")
                        .IsRequired()
                        .HasColumnName("random_code")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("userName")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("VerificationCode")
                        .IsRequired()
                        .HasColumnName("verification_code")
                        .HasColumnType("mediumtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
