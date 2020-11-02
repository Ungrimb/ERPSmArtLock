using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ERPSmArtLock.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    image = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    mobile = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "allowed_info",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    allowedUserId = table.Column<int>(type: "int(11)", nullable: false),
                    ownerId = table.Column<int>(type: "int(11)", nullable: false),
                    buildingId = table.Column<int>(type: "int(11)", nullable: false),
                    lockId = table.Column<int>(type: "int(11)", nullable: false),
                    allowedMethod = table.Column<int>(type: "int(11)", nullable: false),
                    startDate = table.Column<string>(maxLength: 255, nullable: false),
                    endDate = table.Column<string>(maxLength: 255, nullable: false),
                    startTime = table.Column<string>(maxLength: 255, nullable: false),
                    endTime = table.Column<string>(maxLength: 255, nullable: false),
                    reason = table.Column<string>(maxLength: 255, nullable: false),
                    chatRoomId = table.Column<string>(maxLength: 255, nullable: false),
                    unReadMsgCnt = table.Column<string>(maxLength: 255, nullable: false),
                    allowedUserEmail = table.Column<string>(nullable: false),
                    allowed_status = table.Column<int>(type: "int(11)", nullable: false, comment: "0-new/not-verified/1-verified "),
                    day_wise = table.Column<string>(nullable: true, comment: "the day entered by user 1-Sunday,2-Monday,3-Tuesday,4-Wednesday,5-Thursday,6-Friday,7-Saturday")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allowed_info", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "building_list",
                columns: table => new
                {
                    buildingId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ownerId = table.Column<int>(type: "int(11)", nullable: false),
                    buildingName = table.Column<string>(maxLength: 255, nullable: false),
                    ownerName = table.Column<string>(maxLength: 255, nullable: false),
                    ownerEmail = table.Column<string>(maxLength: 255, nullable: false),
                    buildingAddress = table.Column<string>(maxLength: 255, nullable: false),
                    buildingImage = table.Column<string>(maxLength: 255, nullable: false),
                    description = table.Column<string>(nullable: false),
                    lat = table.Column<string>(maxLength: 255, nullable: false),
                    lng = table.Column<string>(maxLength: 255, nullable: false),
                    rooms = table.Column<int>(type: "int(11)", nullable: false),
                    allowedUsers = table.Column<int>(type: "int(11)", nullable: false),
                    verification_code = table.Column<string>(nullable: false),
                    status = table.Column<int>(type: "int(11)", nullable: false, comment: "0-pending/-1-verified/2-blocked")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.buildingId);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    document_name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    status = table.Column<int>(type: "int(11)", nullable: false, comment: "0-pending/1-completed"),
                    signature = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "event_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    building_id = table.Column<int>(type: "int(11)", nullable: false),
                    lock_id = table.Column<int>(type: "int(11)", nullable: false),
                    room_id = table.Column<int>(type: "int(11)", nullable: false),
                    user_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_list", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lock_list",
                columns: table => new
                {
                    lockId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ownerId = table.Column<int>(type: "int(11)", nullable: false),
                    buildingId = table.Column<int>(type: "int(11)", nullable: false),
                    roomName = table.Column<string>(maxLength: 255, nullable: false),
                    checkIn = table.Column<TimeSpan>(nullable: false),
                    checkOut = table.Column<TimeSpan>(nullable: false),
                    isLimited = table.Column<int>(type: "int(11)", nullable: false),
                    qrcode = table.Column<string>(maxLength: 255, nullable: false),
                    check_doubletick = table.Column<string>(nullable: false),
                    doubletick = table.Column<string>(nullable: false),
                    allowedUsers = table.Column<int>(type: "int(11)", nullable: false),
                    isFavorite = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.lockId);
                });

            migrationBuilder.CreateTable(
                name: "locklist",
                columns: table => new
                {
                    lockId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ownerId = table.Column<int>(type: "int(11)", nullable: false),
                    buildingId = table.Column<int>(type: "int(11)", nullable: false),
                    lockImage = table.Column<string>(maxLength: 255, nullable: false),
                    roomName = table.Column<string>(maxLength: 255, nullable: false),
                    checkIn = table.Column<TimeSpan>(nullable: false),
                    checkOut = table.Column<TimeSpan>(nullable: false),
                    isLimited = table.Column<int>(type: "int(11)", nullable: false),
                    qrcode = table.Column<string>(maxLength: 255, nullable: false),
                    allowedUsers = table.Column<int>(type: "int(11)", nullable: false),
                    isFavorite = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.lockId);
                });

            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    terms = table.Column<string>(nullable: false),
                    privacy = table.Column<string>(nullable: false),
                    aboutus = table.Column<string>(nullable: false),
                    support_email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Pwd = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Passport = table.Column<string>(nullable: true),
                    PassportImage = table.Column<string>(nullable: true),
                    DinNie = table.Column<string>(nullable: true),
                    FrontImage = table.Column<string>(nullable: true),
                    BackImage = table.Column<string>(nullable: true),
                    CardPhoto = table.Column<string>(nullable: true),
                    RandomCode = table.Column<string>(nullable: true),
                    CodeVerify = table.Column<int>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    HouseNo = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    CityOfBirth = table.Column<string>(nullable: true),
                    CountryOfBirth = table.Column<string>(nullable: true),
                    CountryTaxLiability = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    AccountStatus = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<int>(nullable: false),
                    DeviceType = table.Column<int>(nullable: false),
                    DeviceToken = table.Column<string>(nullable: true),
                    IsFingerprintEnabled = table.Column<int>(nullable: false),
                    IsFaceEnabled = table.Column<int>(nullable: false),
                    VerificationCode = table.Column<string>(nullable: true),
                    ImeiNo = table.Column<string>(nullable: true),
                    ProfileStatus = table.Column<int>(nullable: false),
                    EmailStatus = table.Column<int>(nullable: false),
                    MobileOtp = table.Column<string>(nullable: true),
                    IsMobileVerified = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(maxLength: 255, nullable: false),
                    email = table.Column<string>(maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "mediumtext", nullable: false),
                    pwd = table.Column<string>(maxLength: 255, nullable: false),
                    photo = table.Column<string>(maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "mediumtext", nullable: false),
                    passport = table.Column<string>(type: "mediumtext", nullable: false),
                    passport_image = table.Column<string>(type: "mediumtext", nullable: false),
                    din_nie = table.Column<string>(type: "mediumtext", nullable: false),
                    front_image = table.Column<string>(type: "mediumtext", nullable: false),
                    back_image = table.Column<string>(type: "mediumtext", nullable: false),
                    card_photo = table.Column<string>(nullable: false),
                    random_code = table.Column<string>(nullable: false),
                    code_verify = table.Column<int>(type: "int(11)", nullable: false),
                    dob = table.Column<DateTime>(type: "date", nullable: false),
                    gender = table.Column<int>(type: "int(11)", nullable: false, comment: "1-male/2-female"),
                    house_no = table.Column<string>(type: "mediumtext", nullable: false),
                    city = table.Column<string>(type: "mediumtext", nullable: false),
                    country = table.Column<string>(type: "mediumtext", nullable: false),
                    postcode = table.Column<string>(type: "mediumtext", nullable: false),
                    nationality = table.Column<string>(type: "mediumtext", nullable: false),
                    city_of_birth = table.Column<string>(type: "mediumtext", nullable: false),
                    country_of_birth = table.Column<string>(type: "mediumtext", nullable: false),
                    country_tax_liability = table.Column<string>(type: "mediumtext", nullable: false),
                    additional_info = table.Column<string>(type: "mediumtext", nullable: false),
                    account_status = table.Column<int>(type: "int(11)", nullable: false),
                    isDeleted = table.Column<int>(type: "int(11)", nullable: false),
                    device_type = table.Column<int>(type: "int(11)", nullable: false, comment: "1-android / 2-ios"),
                    device_token = table.Column<string>(type: "mediumtext", nullable: false),
                    is_fingerprint_enabled = table.Column<int>(type: "int(11)", nullable: false, comment: "1-yes/0-no"),
                    is_face_enabled = table.Column<int>(type: "int(11)", nullable: false, comment: "1-yes/0-no"),
                    verification_code = table.Column<string>(type: "mediumtext", nullable: false),
                    imei_no = table.Column<string>(type: "mediumtext", nullable: false),
                    profile_status = table.Column<int>(type: "int(11)", nullable: false, comment: "0-pending/1-verified/2-rejected"),
                    email_status = table.Column<int>(type: "int(11)", nullable: false),
                    mobile_otp = table.Column<string>(type: "mediumtext", nullable: false),
                    is_mobile_verified = table.Column<int>(type: "int(11)", nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.userId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "allowed_info");

            migrationBuilder.DropTable(
                name: "building_list");

            migrationBuilder.DropTable(
                name: "documents");

            migrationBuilder.DropTable(
                name: "event_list");

            migrationBuilder.DropTable(
                name: "lock_list");

            migrationBuilder.DropTable(
                name: "locklist");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
