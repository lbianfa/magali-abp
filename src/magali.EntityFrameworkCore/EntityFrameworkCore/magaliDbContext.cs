﻿using magali.Authors;
using magali.Books;
using magali.Interceptors;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace magali.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ConnectionStringName("Default")]
public class magaliDbContext :
    AbpDbContext<magaliDbContext>,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    #endregion

    public magaliDbContext(DbContextOptions<magaliDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();

        /* Configure your own tables/entities inside here */

        builder.Entity<Author>(author =>
        {
            author.ToTable(magaliConsts.DbTablePrefix + "Authors", magaliConsts.DbSchema);
            author.ConfigureByConvention(); //auto configure for the base class props

            author.Property(a => a.Identification).IsRequired();
            author.Property(a => a.Name).IsRequired().HasMaxLength(AuthorConsts.MaxNameLength);
            author.Property(a => a.BirthDate).IsRequired();

            author.HasIndex(a => a.Name);

            //Primary key
            //author.HasKey(a => a.Identification);
        });

        builder.Entity<Book>(book =>
        {
            book.ToTable(magaliConsts.DbTablePrefix + "Books", magaliConsts.DbSchema);
            book.ConfigureByConvention(); //auto configure for the base class props

            book.Property(b => b.Name).IsRequired().HasMaxLength(BookConsts.MaxNameLength);

            // ADD THE MAPPING FOR THE RELATION
            book.HasOne<Author>().WithMany().HasForeignKey(author => author.AuthorId).IsRequired();
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.AddInterceptors(new LowerCaseStringInterceptor());
        base.OnConfiguring(optionsBuilder);
    }
}
