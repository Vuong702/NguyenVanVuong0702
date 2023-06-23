using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NguyenVanVuong0702.Models;

    public class BAITHI : DbContext
    {
        public BAITHI (DbContextOptions<BAITHI> options)
            : base(options)
        {
        }

        public DbSet<NguyenVanVuong0702.Models.NVVStudent> NVVStudent { get; set; } = default!;
    }
