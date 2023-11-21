using System;
using System.Collections.Generic;
using AdminPanel.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Data;

public partial class TicketsPetrekircheContext : DbContext
{
    public TicketsPetrekircheContext()
    {
    }

    public TicketsPetrekircheContext(DbContextOptions<TicketsPetrekircheContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<LogEvent> LogEvents { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ScannedTicket> ScannedTickets { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<StatusOrder> StatusOrders { get; set; }

    public virtual DbSet<StatusTicket> StatusTickets { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketsInCart> TicketsInCarts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("en_US.UTF-8")
            .HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("agents_pk");

            entity.ToTable("agents");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Identify).HasName("carts_pk");

            entity.ToTable("carts");

            entity.Property(e => e.Identify).HasColumnName("identify");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carts_fk");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_pkey");

            entity.ToTable("events");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EventDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("event_date");
            entity.Property(e => e.EventName).HasColumnName("event_name");
            entity.Property(e => e.ImagePath).HasColumnName("image_path");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("logs_pk");

            entity.ToTable("logs");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('logs_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.LogDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("log_date");
            entity.Property(e => e.LogEventId).HasColumnName("log_event_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Event).WithMany(p => p.Logs)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("logs_events_fk");

            entity.HasOne(d => d.LogEvent).WithMany(p => p.Logs)
                .HasForeignKey(d => d.LogEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("logs_log_events_fk");

            entity.HasOne(d => d.Order).WithMany(p => p.Logs)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("logs_orders_fk");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Logs)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("logs_tickets_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Logs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("logs_users_fk");
        });

        modelBuilder.Entity<LogEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("log_events_pk");

            entity.ToTable("log_events");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('logs_event_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('orders_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.AgentId).HasColumnName("agent_id");
            entity.Property(e => e.AnnulateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("annulate_date");
            entity.Property(e => e.OrderDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("order_date");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.StatusId)
                .HasDefaultValueSql("1")
                .HasColumnName("status_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Agent).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("orders_agent_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("orders_user_fk");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("places_pk");

            entity.ToTable("places");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Place1).HasColumnName("place");
            entity.Property(e => e.Row).HasColumnName("row");
            entity.Property(e => e.SectorId).HasColumnName("sector_id");
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");

            entity.HasOne(d => d.Sector).WithMany(p => p.Places)
                .HasForeignKey(d => d.SectorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("places_fk");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('roles_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<ScannedTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scanned_ticket_pkey");

            entity.ToTable("scanned_ticket");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('scanned_ticket_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Dates)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dates");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WrongTicketBarcode).HasColumnName("wrong_ticket_barcode");

            entity.HasOne(d => d.Ticket).WithMany(p => p.ScannedTickets)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("scanned_ticket_ticket_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.ScannedTickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("scanned_ticket_user_id_fkey");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sectors_pkey");

            entity.ToTable("sectors");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<StatusOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("newtable_pk");

            entity.ToTable("status_order");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<StatusTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_ticket_pk");

            entity.ToTable("status_ticket");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sold_tickets_pkey");

            entity.ToTable("tickets");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Barcode).HasColumnName("barcode");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PlaceId).HasColumnName("place_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Event).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tickets_event_id_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("tickets_order_id_fkey");

            entity.HasOne(d => d.Place).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tickets_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tickets_status_fk");
        });

        modelBuilder.Entity<TicketsInCart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tickets_in_cart_pk");

            entity.ToTable("tickets_in_cart");

            entity.HasIndex(e => new { e.TicketId, e.CartIdentify }, "tickets_in_cart_un").IsUnique();

            entity.HasIndex(e => e.TicketId, "tickets_in_cart_uniq").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('tickets_in_cart_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.AnnulateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("annulate_date");
            entity.Property(e => e.CartIdentify).HasColumnName("cart_identify");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");

            entity.HasOne(d => d.CartIdentifyNavigation).WithMany(p => p.TicketsInCarts)
                .HasForeignKey(d => d.CartIdentify)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tickets_in_cart_fk_1");

            entity.HasOne(d => d.Ticket).WithOne(p => p.TicketsInCart)
                .HasForeignKey<TicketsInCart>(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tickets_in_cart_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('users_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Commentary).HasColumnName("commentary");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Passwords).HasColumnName("passwords");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.SecondName).HasColumnName("second_name");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_role_id_fkey");
        });
        modelBuilder.HasSequence("logs_event_seq");
        modelBuilder.HasSequence("logs_seq");
        modelBuilder.HasSequence("orders_seq");
        modelBuilder.HasSequence("roles_seq");
        modelBuilder.HasSequence("scanned_ticket_seq");
        modelBuilder.HasSequence("tickets_in_cart_seq");
        modelBuilder.HasSequence("users_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
