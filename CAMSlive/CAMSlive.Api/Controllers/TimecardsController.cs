using CAMSlive.Api.Models;
using CAMSlive.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAMSlive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimecardsController : ControllerBase
    {
        private readonly IChartRepository chartRepository;

        public TimecardsController(IChartRepository chartRepository)
        {
            this.chartRepository = chartRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetCharts()
        {
            try
            {
                return Ok(await chartRepository.GetCharts());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving data from teh database.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chart>> GetChart(string id)
        {
            try
            {
                var result = await chartRepository.GetChart(id);

                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from teh database.");
            }
        }

        [HttpPut("{id}")]
        //public async Task<ActionResult<Chart>> UpdateChart(string id, Chart chart)
        public async Task<ActionResult<Chart>> UpdateChart(string id, Chart chart)
        {
            try
            {
                if (id != chart.ChartId)
                {
                    return BadRequest("ID mismatch");
                }
                var chartToUpdate = await chartRepository.GetChart(id);

                if (chartToUpdate == null)
                {
                    return NotFound();
                }

                var result = (await chartRepository.UpdateChart(chart));
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from teh database.");
            }
        }
        ////public async Task<ActionResult<Chart>> UpdateChart(string id, Chart chart)
        //public async Task<ActionResult> UpdateChart([FromBody]Chart chart)
        //{
           
        //}

        [HttpPost]
        public async Task<ActionResult<Chart>> CreateChart(Chart chart)
        {
            try
            {
                if (chart == null)
                {
                    return BadRequest();
                }

                var createdChart = await chartRepository.AddChart(chart);

                return CreatedAtAction(nameof(GetChart), new { id = createdChart.ChartId}, createdChart);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from teh database.");
            }
            //return Ok();
        }
    }
}
