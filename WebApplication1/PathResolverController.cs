using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.service;

namespace WebApplication1
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathResolverController : ControllerBase
    {
        IPathResolver _pathResolver;
        public PathResolverController(IPathResolver pathResolver)
        {
            _pathResolver = pathResolver;
        }
        [HttpPost]
        public void Post([FromBody] List<Data> value)
        {
            _pathResolver.GetHangUpData(value);
        }

    }
}
