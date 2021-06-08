using KHLightTrail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NKUST109_2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NKUST109_2.Controllers.RESTApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolumeDataApiController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public VolumeDataApiController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{year?}/{month?}")]
        public Task<List<VolumeData>> GetVolumeDatas(int? year, int? month)
        {
            IQueryable<VolumeData> query = dbContext.VolumeDatas.AsQueryable();
            if (year != null)
            {
                query = query.Where(vd => vd.Year == year);
            }
            if (month != null)
            {
                query = query.Where(vd => vd.Month == month);
            }
            return query.ToListAsync();
        }
    }
}