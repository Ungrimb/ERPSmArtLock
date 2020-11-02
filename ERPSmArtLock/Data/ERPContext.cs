using System;
using ERPSmArtLock.Entities;
using ERPSmArtLock.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ERPSmArtLock.Data
{
    public partial class ERPContext : DbContext
    {
        public ERPContext()
        {
        }

        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<AllowedInfo> AllowedInfo { get; set; }
        public virtual DbSet<BuildingList> BuildingList { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<EventList> EventList { get; set; }
        public virtual DbSet<LockList> LockList { get; set; }
        public virtual DbSet<Locklist1> Locklist1 { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=lhcp1043.webapps.net;user=ge24skod_root;password=SmartLock123$%^;persistsecurityinfo=True;database=ge24skod_smart_lock_2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");
            });

            modelBuilder.Entity<AllowedInfo>(entity =>
            {
                entity.ToTable("allowed_info");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AllowedMethod)
                    .HasColumnName("allowedMethod")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AllowedStatus)
                    .HasColumnName("allowed_status")
                    .HasColumnType("int(11)")
                    .HasComment("0-new/not-verified/1-verified ");

                entity.Property(e => e.AllowedUserEmail)
                    .IsRequired()
                    .HasColumnName("allowedUserEmail");

                entity.Property(e => e.AllowedUserId)
                    .HasColumnName("allowedUserId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BuildingId)
                    .HasColumnName("buildingId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ChatRoomId)
                    .IsRequired()
                    .HasColumnName("chatRoomId")
                    .HasMaxLength(255);

                entity.Property(e => e.DayWise)
                    .HasColumnName("day_wise")
                    .HasComment("the day entered by user 1-Sunday,2-Monday,3-Tuesday,4-Wednesday,5-Thursday,6-Friday,7-Saturday");

                entity.Property(e => e.EndDate)
                    .IsRequired()
                    .HasColumnName("endDate")
                    .HasMaxLength(255);

                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasColumnName("endTime")
                    .HasMaxLength(255);

                entity.Property(e => e.LockId)
                    .HasColumnName("lockId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OwnerId)
                    .HasColumnName("ownerId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnName("reason")
                    .HasMaxLength(255);

                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasColumnName("startDate")
                    .HasMaxLength(255);

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasColumnName("startTime")
                    .HasMaxLength(255);

                entity.Property(e => e.UnReadMsgCnt)
                    .IsRequired()
                    .HasColumnName("unReadMsgCnt")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<BuildingList>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("building_list");

                entity.Property(e => e.Id)
                    .HasColumnName("buildingId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AllowedUsers)
                    .HasColumnName("allowedUsers")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BuildingAddress)
                    .IsRequired()
                    .HasColumnName("buildingAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.BuildingImage)
                    .IsRequired()
                    .HasColumnName("buildingImage")
                    .HasMaxLength(255);

                entity.Property(e => e.BuildingName)
                    .IsRequired()
                    .HasColumnName("buildingName")
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Lat)
                    .IsRequired()
                    .HasColumnName("lat")
                    .HasMaxLength(255);

                entity.Property(e => e.Lng)
                    .IsRequired()
                    .HasColumnName("lng")
                    .HasMaxLength(255);

                entity.Property(e => e.OwnerEmail)
                    .IsRequired()
                    .HasColumnName("ownerEmail")
                    .HasMaxLength(255);

                entity.Property(e => e.OwnerId)
                    .HasColumnName("ownerId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasColumnName("ownerName")
                    .HasMaxLength(255);

                entity.Property(e => e.Rooms)
                    .HasColumnName("rooms")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasComment("0-pending/-1-verified/2-blocked");

                entity.Property(e => e.VerificationCode)
                    .IsRequired()
                    .HasColumnName("verification_code");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.ToTable("documents");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasColumnName("document_name");

                entity.Property(e => e.Signature)
                    .IsRequired()
                    .HasColumnName("signature");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasComment("0-pending/1-completed");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<EventList>(entity =>
            {
                entity.ToTable("event_list");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BuildingId)
                    .HasColumnName("building_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LockId)
                    .HasColumnName("lock_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<LockList>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("lock_list");

                entity.Property(e => e.Id)
                    .HasColumnName("lockId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AllowedUsers)
                    .HasColumnName("allowedUsers")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BuildingId)
                    .HasColumnName("buildingId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CheckDoubletick)
                    .IsRequired()
                    .HasColumnName("check_doubletick");

                entity.Property(e => e.CheckIn).HasColumnName("checkIn");

                entity.Property(e => e.CheckOut).HasColumnName("checkOut");

                entity.Property(e => e.Doubletick)
                    .IsRequired()
                    .HasColumnName("doubletick");

                entity.Property(e => e.IsFavorite)
                    .HasColumnName("isFavorite")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsLimited)
                    .HasColumnName("isLimited")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OwnerId)
                    .HasColumnName("ownerId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Qrcode)
                    .IsRequired()
                    .HasColumnName("qrcode")
                    .HasMaxLength(255);

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasColumnName("roomName")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Locklist1>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("locklist");

                entity.Property(e => e.Id)
                    .HasColumnName("lockId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AllowedUsers)
                    .HasColumnName("allowedUsers")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BuildingId)
                    .HasColumnName("buildingId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CheckIn).HasColumnName("checkIn");

                entity.Property(e => e.CheckOut).HasColumnName("checkOut");

                entity.Property(e => e.IsFavorite)
                    .HasColumnName("isFavorite")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsLimited)
                    .HasColumnName("isLimited")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LockImage)
                    .IsRequired()
                    .HasColumnName("lockImage")
                    .HasMaxLength(255);

                entity.Property(e => e.OwnerId)
                    .HasColumnName("ownerId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Qrcode)
                    .IsRequired()
                    .HasColumnName("qrcode")
                    .HasMaxLength(255);

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasColumnName("roomName")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.ToTable("settings");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aboutus)
                    .IsRequired()
                    .HasColumnName("aboutus");

                entity.Property(e => e.Privacy)
                    .IsRequired()
                    .HasColumnName("privacy");

                entity.Property(e => e.SupportEmail)
                    .IsRequired()
                    .HasColumnName("support_email");

                entity.Property(e => e.Terms)
                    .IsRequired()
                    .HasColumnName("terms");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountStatus)
                    .HasColumnName("account_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdditionalInfo)
                    .IsRequired()
                    .HasColumnName("additional_info")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.BackImage)
                    .IsRequired()
                    .HasColumnName("back_image")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.CardPhoto)
                    .IsRequired()
                    .HasColumnName("card_photo");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.CityOfBirth)
                    .IsRequired()
                    .HasColumnName("city_of_birth")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.CodeVerify)
                    .HasColumnName("code_verify")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.CountryOfBirth)
                    .IsRequired()
                    .HasColumnName("country_of_birth")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.CountryTaxLiability)
                    .IsRequired()
                    .HasColumnName("country_tax_liability")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.DeviceToken)
                    .IsRequired()
                    .HasColumnName("device_token")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.DeviceType)
                    .HasColumnName("device_type")
                    .HasColumnType("int(11)")
                    .HasComment("1-android / 2-ios");

                entity.Property(e => e.DinNie)
                    .IsRequired()
                    .HasColumnName("din_nie")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.EmailStatus)
                    .HasColumnName("email_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FrontImage)
                    .IsRequired()
                    .HasColumnName("front_image")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("int(11)")
                    .HasComment("1-male/2-female");

                entity.Property(e => e.HouseNo)
                    .IsRequired()
                    .HasColumnName("house_no")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.ImeiNo)
                    .IsRequired()
                    .HasColumnName("imei_no")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsFaceEnabled)
                    .HasColumnName("is_face_enabled")
                    .HasColumnType("int(11)")
                    .HasComment("1-yes/0-no");

                entity.Property(e => e.IsFingerprintEnabled)
                    .HasColumnName("is_fingerprint_enabled")
                    .HasColumnType("int(11)")
                    .HasComment("1-yes/0-no");

                entity.Property(e => e.IsMobileVerified)
                    .HasColumnName("is_mobile_verified")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MobileOtp)
                    .IsRequired()
                    .HasColumnName("mobile_otp")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasColumnName("nationality")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasColumnName("passport")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.PassportImage)
                    .IsRequired()
                    .HasColumnName("passport_image")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("photo")
                    .HasMaxLength(255);

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasColumnName("postcode")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.ProfileStatus)
                    .HasColumnName("profile_status")
                    .HasColumnType("int(11)")
                    .HasComment("0-pending/1-verified/2-rejected");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasColumnName("pwd")
                    .HasMaxLength(255);

                entity.Property(e => e.RandomCode)
                    .IsRequired()
                    .HasColumnName("random_code");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(255);

                entity.Property(e => e.VerificationCode)
                    .IsRequired()
                    .HasColumnName("verification_code")
                    .HasColumnType("mediumtext");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
