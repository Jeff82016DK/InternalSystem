﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InternalSystem.Models
{
    public partial class MSIT44Context : DbContext
    {
        public MSIT44Context()
        {
        }

        public MSIT44Context(DbContextOptions<MSIT44Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BusinessArea> BusinessAreas { get; set; }
        public virtual DbSet<BusinessCategory> BusinessCategories { get; set; }
        public virtual DbSet<BusinessOptional> BusinessOptionals { get; set; }
        public virtual DbSet<BusinessOrder> BusinessOrders { get; set; }
        public virtual DbSet<BusinessOrderDetail> BusinessOrderDetails { get; set; }
        public virtual DbSet<MeetingRecord> MeetingRecords { get; set; }
        public virtual DbSet<MeetingReserve> MeetingReserves { get; set; }
        public virtual DbSet<MeetingRoom> MeetingRooms { get; set; }
        public virtual DbSet<MonitoringProcessAreaStatus> MonitoringProcessAreaStatuses { get; set; }
        public virtual DbSet<MonitoringStatus> MonitoringStatuses { get; set; }
        public virtual DbSet<PcApplication> PcApplications { get; set; }
        public virtual DbSet<PcApplicationRecordSearch> PcApplicationRecordSearches { get; set; }
        public virtual DbSet<PcOrderDetail> PcOrderDetails { get; set; }
        public virtual DbSet<PcPurchaseItemSearch> PcPurchaseItemSearches { get; set; }
        public virtual DbSet<PcSupplierList> PcSupplierLists { get; set; }
        public virtual DbSet<PersonnelAttendanceTime> PersonnelAttendanceTimes { get; set; }
        public virtual DbSet<PersonnelCityList> PersonnelCityLists { get; set; }
        public virtual DbSet<PersonnelDepartmentConnectEmployeeId> PersonnelDepartmentConnectEmployeeIds { get; set; }
        public virtual DbSet<PersonnelDepartmentList> PersonnelDepartmentLists { get; set; }
        public virtual DbSet<PersonnelLeaveAuditStatus> PersonnelLeaveAuditStatuses { get; set; }
        public virtual DbSet<PersonnelLeaveForm> PersonnelLeaveForms { get; set; }
        public virtual DbSet<PersonnelLeaveFormConectStatus> PersonnelLeaveFormConectStatuses { get; set; }
        public virtual DbSet<PersonnelLeaveOver> PersonnelLeaveOvers { get; set; }
        public virtual DbSet<PersonnelLeaveType> PersonnelLeaveTypes { get; set; }
        public virtual DbSet<PersonnelOvertimeForm> PersonnelOvertimeForms { get; set; }
        public virtual DbSet<PersonnelPosition> PersonnelPositions { get; set; }
        public virtual DbSet<PersonnelProfileDetail> PersonnelProfileDetails { get; set; }
        public virtual DbSet<PersonnelRank> PersonnelRanks { get; set; }
        public virtual DbSet<ProductionArea> ProductionAreas { get; set; }
        public virtual DbSet<ProductionBugContext> ProductionBugContexts { get; set; }
        public virtual DbSet<ProductionContext> ProductionContexts { get; set; }
        public virtual DbSet<ProductionOrderProcessStatus> ProductionOrderProcessStatuses { get; set; }
        public virtual DbSet<ProductionProcess> ProductionProcesses { get; set; }
        public virtual DbSet<ProductionProcessList> ProductionProcessLists { get; set; }
        public virtual DbSet<ProductionProcessStatusName> ProductionProcessStatusNames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.0.104.99\\L27\\SQLEXPRESS,1433;Database=MSIT44;Integrated Security=false;User ID = wang;Password= 1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<BusinessArea>(entity =>
            {
                entity.HasKey(e => e.AreaId)
                    .HasName("PK__Business__70B82048542ED421");

                entity.ToTable("BusinessArea");

                entity.Property(e => e.AreaId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<BusinessCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Business__19093A0BF15A2A00");

                entity.ToTable("BusinessCategory");

                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BusinessOptional>(entity =>
            {
                entity.HasKey(e => e.OptionalId)
                    .HasName("PK__Business__7735FFCC2B7F7340");

                entity.ToTable("BusinessOptional");

                entity.Property(e => e.OptionalId).ValueGeneratedNever();

                entity.Property(e => e.OptionalName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BusinessOptionals)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessOptional_BusinessCategory");
            });

            modelBuilder.Entity<BusinessOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Business__C3905BCF88F045D7");

                entity.ToTable("BusinessOrder");

                entity.Property(e => e.OrderDateTime).HasColumnType("datetime");

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.BusinessOrders)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessOrder_BusinessArea");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.BusinessOrders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessOrder_Personnel個人資料");
            });

            modelBuilder.Entity<BusinessOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.OptionalId })
                    .HasName("PK__Business__14E304336494AF1C");

                entity.ToTable("BusinessOrderDetail");

                entity.HasOne(d => d.Optional)
                    .WithMany(p => p.BusinessOrderDetails)
                    .HasForeignKey(d => d.OptionalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessOrderDetail_BusinessOptional");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.BusinessOrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessOrderDetail_BusinessOrder");
            });

            modelBuilder.Entity<MeetingRecord>(entity =>
            {
                entity.HasKey(e => e.RecordSheetId);

                entity.ToTable("MeetingRecord");

                entity.Property(e => e.RecordSheetId).ValueGeneratedNever();

                entity.Property(e => e.Agenda)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.MeetPresident)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("meetPresident");

                entity.Property(e => e.NoAttendPerson).HasMaxLength(50);

                entity.Property(e => e.Participater)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Principal)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Rcorder)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Record)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.BookMeet)
                    .WithMany(p => p.MeetingRecords)
                    .HasForeignKey(d => d.BookMeetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetingRecord_MeetingReserve");

                entity.HasOne(d => d.MeetingPlace)
                    .WithMany(p => p.MeetingRecords)
                    .HasForeignKey(d => d.MeetingPlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetingRecord_MeetingRoom");
            });

            modelBuilder.Entity<MeetingReserve>(entity =>
            {
                entity.HasKey(e => e.BookMeetId)
                    .HasName("PK_預約會議室+查詢預約紀錄_1");

                entity.ToTable("MeetingReserve");

                entity.Property(e => e.BookMeetId).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.MeetType)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.MeetingReserves)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetingReserve_PersonnelProfileDetail");
            });

            modelBuilder.Entity<MeetingRoom>(entity =>
            {
                entity.HasKey(e => e.MeetingPlaceId)
                    .HasName("PK_會議室房號");

                entity.ToTable("MeetingRoom");

                entity.Property(e => e.MeetingPlaceId).ValueGeneratedNever();

                entity.Property(e => e.MeetingRoom1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MeetingRoom");
            });

            modelBuilder.Entity<MonitoringProcessAreaStatus>(entity =>
            {
                entity.HasKey(e => new { e.AreaId, e.ProcessId })
                    .HasName("PK_Production製程與廠區監控狀態");

                entity.ToTable("MonitoringProcessAreaStatus");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.MonitoringProcessAreaStatuses)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Production製程與廠區監控狀態_Production廠區");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.MonitoringProcessAreaStatuses)
                    .HasForeignKey(d => d.ProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Production製程與廠區監控狀態_Production製程");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.MonitoringProcessAreaStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Monitoring製程與廠區監控狀態_Monitoring監控狀態表");
            });

            modelBuilder.Entity<MonitoringStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK_Production監控狀態表");

                entity.ToTable("MonitoringStatus");

                entity.Property(e => e.StatusId).ValueGeneratedNever();

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PcApplication>(entity =>
            {
                entity.HasKey(e => e.PurchaseId);

                entity.ToTable("PC_Application");

                entity.Property(e => e.PurchaseId).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(200);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.SupplierId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Purchase)
                    .WithOne(p => p.PcApplication)
                    .HasForeignKey<PcApplication>(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PC_Application_PC_ApplicationRecordSearch");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.PcApplications)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PC_Application_PC_SupplierList");
            });

            modelBuilder.Entity<PcApplicationRecordSearch>(entity =>
            {
                entity.HasKey(e => e.PurchaseId)
                    .HasName("PK_採購紀錄查詢");

                entity.ToTable("PC_ApplicationRecordSearch");

                entity.Property(e => e.PurchaseId).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PcApplicationRecordSearches)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PC_ApplicationRecordSearch_PersonnelProfileDetail");
            });

            modelBuilder.Entity<PcOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_PC_OrderDetails_1");

                entity.ToTable("PC_OrderDetails");

                entity.Property(e => e.OrderId).HasMaxLength(20);

                entity.Property(e => e.Goods)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PcOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PC_OrderDetails_PC_PurchaseItemSearch");
            });

            modelBuilder.Entity<PcPurchaseItemSearch>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_物品資料查詢");

                entity.ToTable("PC_PurchaseItemSearch");

                entity.Property(e => e.Goods)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SupplierId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.PcPurchaseItemSearches)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PC_PurchaseItemSearch_PC_SupplierList");
            });

            modelBuilder.Entity<PcSupplierList>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK_供應商資料表");

                entity.ToTable("PC_SupplierList");

                entity.Property(e => e.SupplierId).HasMaxLength(10);

                entity.Property(e => e.SupplierContact)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SupplierContactPerson)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SupplierPhone)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<PersonnelAttendanceTime>(entity =>
            {
                entity.HasKey(e => e.AttendId)
                    .HasName("PK_出勤時間表");

                entity.ToTable("PersonnelAttendanceTime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PersonnelAttendanceTimes)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_出勤時間表_個人資料1");
            });

            modelBuilder.Entity<PersonnelCityList>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK_城市清單");

                entity.ToTable("PersonnelCityList");

                entity.Property(e => e.CityId)
                    .ValueGeneratedNever()
                    .HasColumnName("CityID");

                entity.Property(e => e.CityName).HasMaxLength(10);
            });

            modelBuilder.Entity<PersonnelDepartmentConnectEmployeeId>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.DepId });

                entity.ToTable("PersonnelDepartmentConnectEmployeeId");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.PersonnelDepartmentConnectEmployeeIds)
                    .HasForeignKey(d => d.DepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonnelDepartmentConnectEmployeeId_PersonnelDepartmentList");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PersonnelDepartmentConnectEmployeeIds)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonnelDepartmentConnectEmployeeId_PersonnelProfileDetail");
            });

            modelBuilder.Entity<PersonnelDepartmentList>(entity =>
            {
                entity.HasKey(e => e.DepId);

                entity.ToTable("PersonnelDepartmentList");

                entity.Property(e => e.DepId).ValueGeneratedNever();

                entity.Property(e => e.DepName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<PersonnelLeaveAuditStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK_Personnel請假審核時間表");

                entity.ToTable("PersonnelLeaveAuditStatus");

                entity.Property(e => e.StatusId).ValueGeneratedNever();

                entity.Property(e => e.AuditStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PersonnelLeaveForm>(entity =>
            {
                entity.HasKey(e => e.LeaveId)
                    .HasName("PK_請假申請表");

                entity.ToTable("PersonnelLeaveForm");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PersonnelLeaveFormEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_請假申請表_個人資料");

                entity.HasOne(d => d.LeaveTypeNavigation)
                    .WithMany(p => p.PersonnelLeaveForms)
                    .HasForeignKey(d => d.LeaveType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_請假申請表_假別表");

                entity.HasOne(d => d.ProxyNavigation)
                    .WithMany(p => p.PersonnelLeaveFormProxyNavigations)
                    .HasForeignKey(d => d.Proxy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_請假申請表_個人資料1");
            });

            modelBuilder.Entity<PersonnelLeaveFormConectStatus>(entity =>
            {
                entity.HasKey(e => new { e.LeaveId, e.StatusId })
                    .HasName("PK_Personnel請假表連結審核狀態Id");

                entity.ToTable("PersonnelLeaveFormConectStatus");

                entity.Property(e => e.AuditDate).HasColumnType("date");

                entity.Property(e => e.AuditOpinion).HasMaxLength(100);

                entity.HasOne(d => d.Leave)
                    .WithMany(p => p.PersonnelLeaveFormConectStatuses)
                    .HasForeignKey(d => d.LeaveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personnel請假表連結審核狀態Id_Personnel請假申請表");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.PersonnelLeaveFormConectStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personnel請假表連結審核狀態Id_Personnel請假審核時間表");
            });

            modelBuilder.Entity<PersonnelLeaveOver>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.LeaveType })
                    .HasName("PK_員工可請假時數");

                entity.ToTable("PersonnelLeaveOver");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PersonnelLeaveOvers)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_員工可請假時數_個人資料");

                entity.HasOne(d => d.LeaveTypeNavigation)
                    .WithMany(p => p.PersonnelLeaveOvers)
                    .HasForeignKey(d => d.LeaveType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_員工可請假時數_假別表");
            });

            modelBuilder.Entity<PersonnelLeaveType>(entity =>
            {
                entity.HasKey(e => e.LeaveTypeId)
                    .HasName("PK_假別表");

                entity.ToTable("PersonnelLeaveType");

                entity.Property(e => e.LeaveTypeId).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PersonnelOvertimeForm>(entity =>
            {
                entity.HasKey(e => e.StartWorkeId)
                    .HasName("PK_加班申請表");

                entity.ToTable("PersonnelOvertimeForm");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PersonnelOvertimeForms)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personnel加班申請表_Personnel個人資料");
            });

            modelBuilder.Entity<PersonnelPosition>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.ToTable("PersonnelPosition");

                entity.Property(e => e.PositionId).ValueGeneratedNever();

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<PersonnelProfileDetail>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK_個人資料_1");

                entity.ToTable("PersonnelProfileDetail");

                entity.Property(e => e.Acount)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmergencyNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EmergencyPerson)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EmergencyRelation)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EmployeeNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.HomePhone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IdentiyId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Terminationdate).HasColumnType("date");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.PersonnelProfileDetails)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_個人資料_城市清單");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.PersonnelProfileDetails)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonnelProfileDetail_PersonnelPosition");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.PersonnelProfileDetails)
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_個人資料_職等");
            });

            modelBuilder.Entity<PersonnelRank>(entity =>
            {
                entity.HasKey(e => e.RankId)
                    .HasName("PK_職等");

                entity.ToTable("PersonnelRank");

                entity.Property(e => e.RankId).ValueGeneratedNever();

                entity.Property(e => e.Rank).HasMaxLength(20);
            });

            modelBuilder.Entity<ProductionArea>(entity =>
            {
                entity.HasKey(e => e.AreaId)
                    .HasName("PK_廠區");

                entity.ToTable("ProductionArea");

                entity.Property(e => e.AreaId).ValueGeneratedNever();

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ProductionBugContext>(entity =>
            {
                entity.HasKey(e => e.BugContextId);

                entity.ToTable("ProductionBugContext");

                entity.Property(e => e.Context)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductionBugContexts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductionBugContext_ProductionProcessList");
            });

            modelBuilder.Entity<ProductionContext>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProcessId, e.EmployeeId, e.Date });

                entity.ToTable("ProductionContext");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Context)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ProductionContexts)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Production報工內容表_Personnel個人資料");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductionContexts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductionContext_ProductionProcessList");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProductionContexts)
                    .HasForeignKey(d => d.ProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Production報工內容表_Production製程");
            });

            modelBuilder.Entity<ProductionOrderProcessStatus>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProcessId })
                    .HasName("PK_訂單與製程的關係_1");

                entity.ToTable("ProductionOrderProcessStatus");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductionOrderProcessStatuses)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductionOrderProcessStatus_ProductionProcessList");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProductionOrderProcessStatuses)
                    .HasForeignKey(d => d.ProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_訂單與製程的關係_Production製程");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ProductionOrderProcessStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Production訂單與製程的關係_Production製程狀態名稱(監控)");
            });

            modelBuilder.Entity<ProductionProcess>(entity =>
            {
                entity.HasKey(e => e.ProcessId)
                    .HasName("PK_製程");

                entity.ToTable("ProductionProcess");

                entity.Property(e => e.ProcessId).ValueGeneratedNever();

                entity.Property(e => e.ProcessName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<ProductionProcessList>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_ProductionProcessList_1");

                entity.ToTable("ProductionProcessList");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StarDate).HasColumnType("date");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.ProductionProcessLists)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_製程列表_Production廠區");

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.ProductionProcessList)
                    .HasForeignKey<ProductionProcessList>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductionProcessList_BusinessOrder1");
            });

            modelBuilder.Entity<ProductionProcessStatusName>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK_製程狀態");

                entity.ToTable("ProductionProcessStatusName");

                entity.Property(e => e.StatusId).ValueGeneratedNever();

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
